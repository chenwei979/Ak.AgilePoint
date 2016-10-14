<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simplelistexample.aspx.cs" Inherits="javascriptLibaray.Simplelistexample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="Scripts/knockout-3.4.0.js"></script>
</head>
<body>
    <form data-bind="submit: addItem">
    New item:
    <input data-bind='value: itemToAdd, valueUpdate: "afterkeydown"' />
    <button type="submit" data-bind="enable: itemToAdd().length > 0">Add</button>
    <p>Your items:</p>
    <select multiple="multiple" width="50" data-bind="options: items"> </select>
</form>
    <script>
        var SimpleListModel = function (items) {
            this.items = ko.observableArray(items);
            this.itemToAdd = ko.observable("");
            this.addItem = function () {
                if (this.itemToAdd() != "") {
                    this.items.push(this.itemToAdd()); // Adds the item. Writing to the "items" observableArray causes any associated UI to update.
                    this.itemToAdd(""); // Clears the text box, because it's bound to the "itemToAdd" observable
                }
            }.bind(this);  // Ensure that "this" is always this view model
        };

        ko.applyBindings(new SimpleListModel(["Alpha", "Beta", "Gamma"]));

    </script>
</body>
</html>
