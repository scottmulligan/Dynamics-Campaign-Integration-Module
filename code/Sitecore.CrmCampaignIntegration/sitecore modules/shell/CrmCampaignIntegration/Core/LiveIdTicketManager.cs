#region

using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

#endregion

namespace Sitecore.Forms.Core.Crm
{
  /// <summary>
  /// Class for working with Windows Live ID tickets
  /// </summary>
  public class LiveIdTicketManager
  {
    /// <summary>
    /// The Windows Live Id environment that is being targeted 
    /// </summary>
    public enum LiveIdEnvironment
    {
      PROD = 0,
      INT = 1
    }

    private static LiveIdEnvironment _environment;
    private static String _authorizationEndpoint;

    private static String[] windowsLiveDeviceUrl =
      {
        @"https://login.live.com/ppsecure/DeviceAddCredential.srf",
        @"https://login.live-int.com/ppsecure/DeviceAddCredential.srf"
      };

    private static String[] federationMetadataUrl =
      {
        @"https://nexus.passport.com/federationmetadata/2006-12/FederationMetaData.xml",
        @"https://nexus.passport-int.com/federationmetadata/2006-12/FederationMetaData.xml"
      };

    private const String deviceTokenResponseFileName = "DeviceTokenResponse.xml";
    private const String securityTokenResponseFileName = "UserTokenResponse.xml";
    private static String deviceTokenResponseFilePath = String.Empty;
    private static String securityTokenResponseFilePath = String.Empty;
    /// <summary>
    /// XPath to parse the device/security token response including its Lifetime 
    /// from the Windows Live ID response XML.
    /// </summary>
    private const String RequestSecurityTokenExpiryResponseXPath =
      @"S:Envelope/S:Body/wst:RequestSecurityTokenResponse";

    /// <summary>
    /// XPath to parse the value of the device/security token 
    /// from the Windows Live ID response XML.
    /// </summary>
    private const String TokenResponseXPath =
      @"S:Envelope/S:Body/wst:RequestSecurityTokenResponse/wst:RequestedSecurityToken";

    /// <summary>
    /// XPath to parse the value of the Lifetime from the Windows Live ID response XML.
    /// </summary>
    private const String TokenExpiryXPath =
      @"S:Envelope/S:Body/wst:RequestSecurityTokenResponse/wst:Lifetime/wsu:Expires";

    #region Templates

    internal const String DeviceRegistrationTemplate =
      @"<DeviceAddRequest>
            <ClientInfo name=""{0:clientId}"" version=""1.0""/>
            <Authentication>
                <Membername>{1:prefix}{2:deviceName}</Membername>
                <Password>{3:password}</Password>
            </Authentication>
        </DeviceAddRequest>";

    internal const String DeviceTokenTemplate = @"<?xml version=""1.0"" encoding=""UTF-8""?>
        <s:Envelope 
          xmlns:s=""http://www.w3.org/2003/05/soap-envelope"" 
          xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" 
          xmlns:wsp=""http://schemas.xmlsoap.org/ws/2004/09/policy"" 
          xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" 
          xmlns:wsa=""http://www.w3.org/2005/08/addressing"" 
          xmlns:wst=""http://schemas.xmlsoap.org/ws/2005/02/trust"">
           <s:Header>
            <wsa:Action s:mustUnderstand=""1"">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</wsa:Action>
            <wsa:To s:mustUnderstand=""1"">http://Passport.NET/tb</wsa:To>    
            <wsse:Security>
              <wsse:UsernameToken wsu:Id=""devicesoftware"">
                <wsse:Username>{0:prefix}{1:deviceName}</wsse:Username>
                <wsse:Password>{2:password}</wsse:Password>
              </wsse:UsernameToken>
            </wsse:Security>
          </s:Header>
          <s:Body>
            <wst:RequestSecurityToken Id=""RST0"">
                 <wst:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</wst:RequestType>
                 <wsp:AppliesTo>
                    <wsa:EndpointReference>
                       <wsa:Address>http://Passport.NET/tb</wsa:Address>
                    </wsa:EndpointReference>
                 </wsp:AppliesTo>
              </wst:RequestSecurityToken>
          </s:Body>
        </s:Envelope>
        ";

    internal const String UserTokenTemplate = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <s:Envelope 
      xmlns:s=""http://www.w3.org/2003/05/soap-envelope"" 
      xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" 
      xmlns:wsp=""http://schemas.xmlsoap.org/ws/2004/09/policy"" 
      xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" 
      xmlns:wsa=""http://www.w3.org/2005/08/addressing"" 
      xmlns:wst=""http://schemas.xmlsoap.org/ws/2005/02/trust"">
       <s:Header>
        <wsa:Action s:mustUnderstand=""1"">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</wsa:Action>
        <wsa:To s:mustUnderstand=""1"">http://Passport.NET/tb</wsa:To>    
       <ps:AuthInfo Id=""PPAuthInfo"" xmlns:ps=""http://schemas.microsoft.com/LiveID/SoapServices/v1"">
             <ps:HostingApp>{0:clientId}</ps:HostingApp>
          </ps:AuthInfo>
          <wsse:Security>
             <wsse:UsernameToken wsu:Id=""user"">
                <wsse:Username>{1:userName}</wsse:Username>
                <wsse:Password>{2:password}</wsse:Password>
             </wsse:UsernameToken>
             <wsse:BinarySecurityToken ValueType=""urn:liveid:device"">
               {3:deviceTokenValue}
             </wsse:BinarySecurityToken>
          </wsse:Security>
      </s:Header>
      <s:Body>
        <wst:RequestSecurityToken Id=""RST0"">
             <wst:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</wst:RequestType>
             <wsp:AppliesTo>
                <wsa:EndpointReference>
                   <wsa:Address>{4:partnerUrl}</wsa:Address>
                </wsa:EndpointReference>
             </wsp:AppliesTo>
             <wsp:PolicyReference URI=""{5:policy}""/>
          </wst:RequestSecurityToken>
      </s:Body>
    </s:Envelope>
    ";

    #endregion

    private LiveIdTicketManager()
    {
    }

    /// <summary>
    /// This shows the method to retrieve the WLID ticket for the WLID user
    /// without using any certificate for authentication.     
    /// </summary>
    /// <param name="devicename">The random device name to use for this registration.
    /// Lowercase 12 to 14 ANSI characters. Recommended length is 12 characters.</param>
    /// <param name="devicepassword">The random device password to use for this registration.
    /// Between 16 to 24 characters allowed from set.
    /// <para>"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567891@#$%^*()-_=+;: ,./?`~"</para>
    /// </param>
    /// <param name="partner">sitename, i.e. crmapp.www.local-titan.com</param>
    /// <param name="username">The Windows Live ID for the user</param>
    /// <param name="password">The Windows Live ID password for the user</param>
    /// <param name="policy">Auth policy, i.e. MBI_SSL</param>
    /// <param name="environment">Live Id environment i.e. INT/PROD</param>
    /// <returns></returns>
    public static String RetrieveTicket(String devicename, String devicepassword, String partner,
      String username, String password, String policy, LiveIdEnvironment environment)
    {
      return RetrieveTicket(devicename, devicepassword, partner, username,
        password, policy, environment, "");
    }

    /// <summary>
    /// This shows the method to retrieve the WLID ticket for the WLID user
    /// without using any certificate for authentication.     
    /// </summary>
    /// <param name="devicename">The random device name to use for this registration.
    /// Lowercase 12 to 14 ANSI characters. Recommended length is 12 characters.</param>
    /// <param name="devicepassword">The random device password to use for this registration.
    /// Characters from the following set.
    /// <para>"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567891@#$%^*()-_=+;: ,./?`~"</para>
    /// Between 16 and 24 characters.</param>
    /// <param name="partner">sitename, i.e. crmapp.www.local-titan.com</param>
    /// <param name="username">The Windows Live ID for the user.</param>
    /// <param name="password">The Windows Live ID password for the user.</param>
    /// <param name="policy">Auth policy, i.e. MBI_SSL</param>
    /// <param name="environment">Live Id environment i.e. INT/PROD</param>
    /// <param name="savedTicketPath">The local disc path for saving ticket info.</param>
    /// <returns></returns>
    public static String RetrieveTicket(String devicename, String devicepassword, String partner,
      String username, String password, String policy, LiveIdEnvironment environment, String ticketPath)
    {
      if (ticketPath != "")
      {
        deviceTokenResponseFilePath = ticketPath + "\\" + deviceTokenResponseFileName;
        securityTokenResponseFilePath = ticketPath + "\\" + securityTokenResponseFileName;
      }
      else
      {
        deviceTokenResponseFilePath = deviceTokenResponseFileName;
        securityTokenResponseFilePath = securityTokenResponseFileName;
      }

      _environment = environment;
      SetAuthorizationEndpoint(_environment);

      Guid clientId = Guid.NewGuid();

      String deviceToken = string.Empty;
      String ticket = string.Empty;
      // Check and also retrieve if valid security token already exist 
      // in the SecurityTokenResponse.xml file created during latest run.
      if (!TokenExist(securityTokenResponseFilePath, out ticket))
      {
        // Check and also retrieve if valid device token already exist 
        // in the DeviceTokenResponse.xml file created during latest run.
        if (!TokenExist(deviceTokenResponseFilePath, out deviceToken))
        {
          // Do the following once per machine.  
          // Register each machine in the production 
          // environment that you need to authenticate with.
          XmlNodeList responseNodes = RegisterMachine(devicename,
            devicepassword, clientId);

          // Now, authenticate the device.  
          // Once you receive the device token, 
          // you can save it and don't need to auth again until it expires.
          deviceToken = IssueDeviceToken(devicename, devicepassword);
        }
        //Finally, request the ticket itself.
        ticket = Issue(username, password, partner, policy, clientId, deviceToken);
      }

      return ticket;
    }

    #region Private Methods

    /// <summary>
    /// Gets a Windows Live ID RequestSecurityTokenResponse ticket for a specified user.  
    /// Store the response in the SecurityTokenResponse.xml file 
    /// in the executable folder for future reuse.
    /// </summary>
    /// <param name="userName">The Windows Live ID email address for the user.</param>
    /// <param name="password">The Windows Live ID password for the user</param>
    /// <param name="partner">sitename, i.e. crmapp.www.local-titan.com</param>
    /// <param name="policy">auth policy, i.e. MBI_SSL</param>
    /// <param name="clientId">The unique id of the client/application</param>
    /// <param name="deviceToken">The device token xml</param>
    /// <returns>A <c>string</c> that contains the Windows Live ID ticket for 
    /// the supplied paramters</returns>
    private static String Issue(string userName, string password, string partner,
      string policy, Guid clientId, string deviceToken)
    {

      string soapEnvelope = string.Format(CultureInfo.InvariantCulture,
        UserTokenTemplate, clientId.ToString(),
        userName, password, deviceToken, partner, policy);
      XmlDocument doc = CallLiveIdServices(_authorizationEndpoint, "POST", soapEnvelope);

      XmlNamespaceManager namespaceManager = CreateNamespaceManager(doc.NameTable);

      // Validate Windows Live ID service response for exceptions.
      if (IsResponseValid(doc, namespaceManager, "IssueTicket"))
      {
        XmlNode ticket = SelectNode(doc, namespaceManager, TokenResponseXPath);
        if (ticket != null)
        {
          return ticket.InnerText;
        }
      }
      return String.Empty;
    }


    /// <summary>
    /// Registers a machine/device with the device registration Windows Live ID service. 
    /// Device registration is required only once per computer or device.
    /// The result of this request will contain the PUID (Device ID) of the device registered 
    /// and should be saved for later use.
    /// </summary>
    /// <param name="deviceName">The random device name to use for this registration.</param>
    /// <param name="devicePassword">The random device password 
    /// to use for this registration.</param>
    /// <param name="clientId">The app GUID, a unique id for the client/application.</param>
    private static XmlNodeList RegisterMachine(String deviceName, String devicePassword, Guid clientId)
    {
      try
      {
        string soapEnvelope = string.Format(CultureInfo.InvariantCulture,
          DeviceRegistrationTemplate,
          clientId.ToString(),
          "11", // Windows Live ID device registration requires using "11" as a prefix.
          deviceName,
          devicePassword);
        XmlDocument doc = CallLiveIdServices(windowsLiveDeviceUrl[(int)_environment],
          "POST", soapEnvelope);
        if (doc != null)
        {
          XmlNodeList nodes = doc.SelectNodes(@"DeviceAddResponse");
          if (nodes != null && nodes.Count > 0)
          {
            if (nodes[0].Attributes[0].Value ==
              false.ToString(CultureInfo.InvariantCulture))
            {
              //TODO: The device was not registered.							
            }
          }
          return nodes;
        }
      }
      catch (WebException ex)
      {
        // Bad Request typically means that the machine is already registered, 
        // so we are ok with swallowing this exception and unfortunately
        // there is no other distingushing details on this exception
        if (!ex.Message.Contains("Bad Request"))
        {
          throw;
        }
      }
      return null;
    }

    /// <summary>
    /// Get a device authorization token from the Windows Live ID service.
    /// Store the response in the DeviceTokenResponse.xml file 
    /// in the executable folder for future reuse.
    /// </summary>
    /// <param name="deviceName">The random device name used for this registration.</param>
    /// <param name="devicePassword">The random device password used for this registration.</param>
    /// <returns>The device token to use when retrieving a user token</returns>
    private static string IssueDeviceToken(String deviceName, String devicePassword)
    {
      string soapEnvelope = string.Format(CultureInfo.InvariantCulture,
        DeviceTokenTemplate,
        "11", // Windows Live ID device registration requires using "11" as a prefix.
        deviceName,
        devicePassword);
      XmlDocument doc = CallLiveIdServices(_authorizationEndpoint, "POST", soapEnvelope);

      XmlNamespaceManager namespaceManager = CreateNamespaceManager(doc.NameTable);

      // Validate Windows Live ID service response for exceptions.
      if (IsResponseValid(doc, namespaceManager, "IssueDeviceToken"))
      {
        return SelectNode(doc, namespaceManager, TokenResponseXPath).InnerXml;
      }
      else
        return String.Empty;
    }

    /// <summary>
    /// Validate Windows Live ID response for any exception.
    /// </summary>
    /// <param name="doc">The Windows Live ID service response.</param>
    /// <param name="namespaceManager">The XmlnamespaceMangager for Windows Live ID service response.</param>
    /// <param name="source">An exception source.</param>
    /// <returns>true/false</returns>
    private static Boolean IsResponseValid(XmlDocument doc, XmlNamespaceManager namespaceManager, String source)
    {
      String faultPath = @"S:Envelope/S:Body/S:Fault";

      // Checking main fault.
      if (null != SelectNode(doc, namespaceManager, faultPath))
      {
        String faultReason = String.Empty;
        String innerError = String.Empty;
        String faultReasonPath = @"S:Envelope/S:Body/S:Fault/S:Reason/S:Text";
        String internalErrorPath = @"S:Envelope/S:Body/S:Fault/S:Detail/psf:error/psf:internalerror";

        faultReason = SelectNode(doc, namespaceManager, faultReasonPath).InnerText;

        faultReason = (source != "") ? source + ": " + faultReason : faultReason;

        // Checking inner fault.
        if (null != SelectNode(doc, namespaceManager, internalErrorPath))
        {
          innerError = SelectNode(doc, namespaceManager, internalErrorPath + "//psf:text").InnerText;
          throw new Exception(faultReason, new Exception(innerError));
        }
        else
          throw new Exception(faultReason);

      }
      else
        return true;

    }

    private static XmlNamespaceManager CreateNamespaceManager(XmlNameTable nameTable)
    {
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(nameTable);
      namespaceManager.AddNamespace("wst", "http://schemas.xmlsoap.org/ws/2005/02/trust");
      namespaceManager.AddNamespace("S", "http://www.w3.org/2003/05/soap-envelope");
      namespaceManager.AddNamespace("wsu",
        "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
      namespaceManager.AddNamespace("psf",
        "http://schemas.microsoft.com/Passport/SoapServices/SOAPFault");
      return namespaceManager;
    }

    private static void SetAuthorizationEndpoint(LiveIdEnvironment environment)
    {
      if (String.IsNullOrEmpty(_authorizationEndpoint))
      {
        _authorizationEndpoint = GetServiceEndpoint(environment);
        return;
      }
      //Throw an exception if we can't get the endpoint.
    }

    private static string GetServiceEndpoint(LiveIdEnvironment environment)
    {
      XmlDocument doc = CallLiveIdServices(federationMetadataUrl[(int)environment], "GET", null);
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(doc.NameTable);
      namespaceManager.AddNamespace("fed", "http://schemas.xmlsoap.org/ws/2006/03/federation");
      namespaceManager.AddNamespace("wsa", "http://www.w3.org/2005/08/addressing");
      return SelectNode(doc, namespaceManager,
        @"//fed:FederationMetadata/fed:Federation/fed:TargetServiceEndpoint/wsa:Address"
        ).InnerText.Trim();
    }

    private static XmlDocument CallLiveIdServices(string serviceUrl,
      string method, string soapMessageEnvelope)
    {
      // Buid the web request
      string url = serviceUrl;
      WebRequest request = WebRequest.Create(url);
      request.Method = method;
      request.Timeout = 180000;
      if (method == "POST")
      {
        // If we are "posting" then this is always a SOAP message
        request.ContentType = "application/soap+xml; charset=UTF-8";
      }

      // If a SOAP envelope is supplied, then we need to write to the request stream
      // If there isn't a SOAP message supplied then continue onto just process the raw XML
      if (!string.IsNullOrEmpty(soapMessageEnvelope))
      {
        byte[] bytes = Encoding.UTF8.GetBytes(soapMessageEnvelope);
        using (Stream str = request.GetRequestStream())
        {
          str.Write(bytes, 0, bytes.Length);
          str.Close();
        }
      }

      // Read the response into an XmlDocument and return that doc
      string xml;
      using (WebResponse response = request.GetResponse())
      {
        using (System.IO.StreamReader reader =
          new System.IO.StreamReader(response.GetResponseStream()))
        {
          xml = reader.ReadToEnd();
        }

        response.Close();
      }

      XmlDocument document = new XmlDocument();
      document.LoadXml(xml);
      return document;
    }

    private static XmlNode SelectNode(XmlDocument document,
      XmlNamespaceManager namespaceManager, string xPathToNode)
    {
      XmlNodeList nodes = document.SelectNodes(xPathToNode, namespaceManager);
      if (nodes != null && nodes.Count > 0 && nodes[0] != null)
      {
        return nodes[0];
      }
      return null;
    }

    /// <param name="deviceToken"></param>
    /// <returns>Return true if the token exist and valid.</returns>
    /// <summary>
    /// Check and retrieve unexpired token if it is already exist in the respective xml file
    /// (i.e. DeviceTokenResponse.xml or SecurityTokenResponse.xml) from the executable folder. 
    /// </summary>
    /// <param name="filePath">Set the file path.</param>
    /// <param name="token">Get the token value.</param>
    /// <returns>Return true if the token exist and valid.</returns>
    private static bool TokenExist(String filePath, out String token)
    {
      bool isValid = false;
      token = string.Empty;

      if (File.Exists(filePath))
      {
        XmlDocument doc = new XmlDocument();
        doc.Load(filePath);

        XmlNamespaceManager namespaceManager = CreateNamespaceManager(doc.NameTable);

        String strExpiryDate = SelectNode(doc, namespaceManager, TokenExpiryXPath).InnerXml;

        String[] date = strExpiryDate.Split('T')[0].Split('-');
        String[] time = strExpiryDate.Split('T')[1].Split('Z')[0].Split(':');

        DateTime expiryDate = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]),
          int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));

        if (DateTime.UtcNow.CompareTo(expiryDate) < 0)
        {
          XmlNode tokenNode = SelectNode(doc, namespaceManager, TokenResponseXPath);
          if (tokenNode != null)
          {
            if (filePath == deviceTokenResponseFilePath)
              token = tokenNode.InnerXml;
            else
              token = tokenNode.InnerText;
            isValid = true;
          }
        }
      }
      return isValid;
    }

    #endregion Private Methods
  }
}