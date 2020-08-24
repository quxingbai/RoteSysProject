<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RootControl.aspx.cs" Inherits="RoteSysProject.Form.RootControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JS/Tool.js"></script>
    <link href="../CSS/Controls.css" rel="stylesheet" />
    <script src="../JS/jquery-1.11.3.js"></script>
    <script>
        $(document).ready(function () {
            $("#form1").css({ height: GetScreenSize().height*0.9, maxWidth: GetScreenSize().width });
        });
    </script>
    <style>
        #LeftMenu {
            float: left;
            width: 15%;
            height: 100%;
        }

        #IFRAME_DisplayForm {
            float: right;
            width: 80%;
            height: 100%;
            border-style:solid;
            border-width:1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="LeftMenu">
            <asp:TreeView runat="server" ID="TREEVIEW_LeftMenu">
            </asp:TreeView>
        </div>
        <iframe id="IFRAME_DisplayForm" name="DisplayForm"></iframe>
    </form>
</body>
</html>
