function FieldsTree_onNodeSelect(sender, eventArgs) {
	var selectedNode = eventArgs.get_node();
	var parentNode = selectedNode.get_parentNode();

	if (selectedNode != null) {
		var response = scForm.postEvent(this, event, 'OnTreeViewNodeSelected("' + selectedNode.get_value() + '")');
		//
		//For an undetermined reason the checkboxes are being rendered twice. 
		//In this case the server is generating client-side code where the 
		//checkbox is changed the checked property is changed on the SECOND 
		//checkbox only. This code ensures the other checkboxes are changed.
		//
		//START: change
		var hiddenSection = document.querySelector("[value='" + selectedNode.Value + "']").parentNode;
		var hiddenCheckboxes = hiddenSection.querySelectorAll("[type='checkbox']");
		for (var i = 0; i < hiddenCheckboxes.length; i++) {
			var hiddenCheckbox = hiddenCheckboxes[i];
			var nodeList = document.getElementsByName(hiddenCheckbox.name);
			var checkboxes = reverseNodeList(nodeList);
			syncCheckboxes(checkboxes)
		}
		//END: change
		//
		return response;
	}
}
function reverseNodeList(nodeList) {
	var elements = [];
	for (var i = 0, n; n = nodeList[i]; ++i) {
		elements.push(n);
	}
	elements.reverse();
	return elements;
}
function syncCheckboxes(checkboxes) {
	//
	//The first checkbox has the value that must be assigned to the other checkboxes.
	for (var i = 1; i < checkboxes.length; i++) {
		checkboxes[i].checked = checkboxes[0].checked;
	}
}

function OnItemStateChanged(sender, args) {
	var nodes = sender.select('input[type="checkbox"]');
	//
	//For an undetermined reason the checkboxes are being rendered twice. 
	//When a checkbox is changed the checked property is 
	//changed on the FIRST the checkbox only. This code 
	//ensures the other checkboxes are changed.
	//
	//START: change
	for (var n = 0; n < nodes.length; n++) {
		var node = nodes[n];
		var elements = document.getElementsByName(node.name);
		syncCheckboxes(elements);
	}
	//END: change
	//
	if (nodes.first().checked) {
		var element = nodes.first().next();
		ModeCombobox.set_text(element.innerText || element.innerHTML);
	}
	else {
		var text = "";
		nodes.each(function (node) {
			if (node.checked) {
				text = text + ", " + node.next().innerHTML;
			}
		});

		if (text.blank()) {
			text = sc.dictionary['Never'];
		}

		if (text.startsWith(",")) {
			text = text.substring(2);
		}
		ModeCombobox.set_text(text);
	}
}
