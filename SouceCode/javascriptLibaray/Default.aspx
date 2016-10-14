<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="javascriptLibaray._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        var object = { "name": "enzo", "sex": "man" };

        //console.log(object.name);
        //console.log(object.sex);

        var object1 = { "name": "enzo", "sex": "man" };

        //console.log(object1.name);
        //console.log(object1.sex);

        var json = { "objects": [{ "name": "enzo", "sex": "man" }, { "name": "enzo", "sex": "man" }] };
        
        console.log(json.objects);
        console.log(json.objects.length);

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
