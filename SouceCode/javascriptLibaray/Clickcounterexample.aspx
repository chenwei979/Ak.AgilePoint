<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clickcounterexample.aspx.cs" Inherits="javascriptLibaray.Clickcounterexample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <script src="Scripts/knockout-3.4.0.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <div>You've clicked <span data-bind='text: numberOfClicks'>&nbsp;</span> times</div>

        <button data-bind='click: registerClick, disable: hasClickedTooManyTimes'>Click me</button>

        <div data-bind='visible: hasClickedTooManyTimes'>
            That's too many clicks! Please stop before you wear out your fingers.
    <button data-bind='click: resetClicks'>Reset clicks</button>
        </div>
    </form>

    <script>

        var ClickCounterViewModel = function () {
            this.numberOfClicks = ko.observable(0);

            this.registerClick = function () {
                this.numberOfClicks(this.numberOfClicks() + 1);
            };

            this.resetClicks = function () {
                this.numberOfClicks(0);
            };

            this.hasClickedTooManyTimes = ko.pureComputed(function () {
                return this.numberOfClicks() >= 5;
            }, this);
        };

        ko.applyBindings(new ClickCounterViewModel());
    </script>
</body>
</html>
