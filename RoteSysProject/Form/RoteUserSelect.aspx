<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoteUserSelect.aspx.cs" Inherits="RoteSysProject.Form.RoteUserSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/Controls.css" rel="stylesheet" />
    <script src="../JS/Tool.js"></script>
    <script>
        $(document).ready(function () {
            $("#form1").css({ height: GetScreenSize().height * 0.9, maxWidth: GetScreenSize().width });
        });
    </script>
    <style>
        .BlockListBox {
            width: 100%;
        }
        #DisplayTable tr td{
            min-width:200px;
        }
         #DisplayTable tr:hover{
             background-color:rgba(128, 128, 128, 0.30);
        }
           
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList runat="server" ID="DROPDOWNLIST_ActionSelect" OnSelectedIndexChanged="DROPDOWNLIST_ActionSelect_SelectedIndexChanged" CssClass="BlockListBox" AutoPostBack="true" />
        </div>
        <table id="DisplayTable">
            <thead>
                <tr>
                    <td>ID</td>
                    <td>名称</td>
                    <td>性别</td>
                    <td>年龄</td>
                    <td>格言</td>
                    <td>图像</td>
                    <td>操作</td>
                </tr>
            </thead>
            <asp:Repeater runat="server" ID="REPEATER_Display" OnItemCommand="REPEATER_Display_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("RUID") %></td>
                        <td><%#Eval("RUName") %></td>
                        <td><%#Eval("RUSex").ToString()=="0"?"男":"女" %></td>
                        <td><%#Eval("RUAge") %></td>
                        <td><%#Eval("RUDetail") %></td>
                        <td><img src="<%#Eval("RUImGUrl") %>" width="50"  height="50"/></td>
                        <td>
                            <asp:Button runat="server" CommandArgument='<%#Eval("RUID") %>' Text="删除" CommandName="DELETE" CssClass="BlockButton" />
                            <asp:Button runat="server" CommandArgument='<%#Eval("RUID") %>'  Text="修改" CommandName="UPDATE" CssClass="BlockButton"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
