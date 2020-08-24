<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserControl.aspx.cs" Inherits="RoteSysProject.Form.UserControl" %>

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
        #display tr td{
            min-width:200px;
        }
         #display tr:hover{
             background-color:#808080;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="display">
                <thead >
                    <tr>
                        <td>ID</td>
                        <td>名称</td>
                        <td>账号</td>
                        <td>密码</td>
                        <td>操作</td>
                    </tr>
                </thead>
            <asp:Repeater ID="REPEATER_Display" runat="server" OnItemCommand="REPEATER_Display_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("UID") %></td>
                        <td><%#Eval("Uname") %></td>
                        <td><%#Eval("UCode") %></td>
                        <td><%#Eval("uPwd") %></td>
                        <td>
                            <asp:Button runat="server" Text="删除" CommandArgument='<%#Eval("UID") %>' CommandName="DELETE" CssClass="BlockButton" />
                            <asp:Button runat="server" Text="修改" CommandArgument='<%#Eval("UID") %>' CommandName="UPDATE" CssClass="BlockButton" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
