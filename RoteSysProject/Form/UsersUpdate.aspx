<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersUpdate.aspx.cs" Inherits="RoteSysProject.Form.UsersUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../JS/Tool.js"></script>
    <link href="../CSS/Controls.css" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            $("#form1").css({ height: GetScreenSize().height * 0.9, maxWidth: GetScreenSize().width });
        });
    </script>
    <style>
        td{
          min-width:100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>名称</td>
                    <td><asp:TextBox runat="server" ID="TEXTBOX_Name" CssClass="BlockTextBox" /></td>
                </tr>
                <tr>
                    <td>密码</td>
                    <td><asp:TextBox runat="server" ID="TEXTBOX_Pwd" CssClass="BlockTextBox"/></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="BUTTON_Submit" OnClick="BUTTON_Submit_Click" Text="修改" CssClass="BlockButton" Width="100%" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
