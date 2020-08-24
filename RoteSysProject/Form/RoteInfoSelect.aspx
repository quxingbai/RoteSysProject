<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoteInfoSelect.aspx.cs" Inherits="RoteSysProject.Form.RoteInfoSelect" %>

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
        .BlockListBox{
            width:100%;
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
            <asp:DropDownList runat="server" ID="DROPDOWNLIST_ActionSelect" OnSelectedIndexChanged="DROPDOWNLIST_ActionSelect_SelectedIndexChanged" CssClass="BlockListBox" AutoPostBack="true"/>
            <table id="DisplayTable">
                <thead>
                    <tr>
                        <td>被投票人ID</td>
                        <td>被投票人名称</td>
                        <td>投票人ID</td>
                        <td>投票人名称</td>
                        <td>投票人IP</td>
                        <td>操作</td>
                    </tr>
                </thead>
                <asp:Repeater runat="server" ID="REPEATER_DisplayTable" OnItemCommand="REPEATER_DisplayTable_ItemCommand">
                    <ItemTemplate>
                    <tr>
                        <td><%#Eval("RUID") %></td>
                        <td><%#Eval("RUName") %></td>
                        <td><%#Eval("UID") %></td>
                        <td><%#Eval("Uname") %></td>
                        <td><%#Eval("RIP") %></td>
                        <td>
                            <asp:Button runat="server" CssClass="BlockButton" Text="删除" CommandArgument='<%#Eval("RID") %>' CommandName="DELETE"  />
                        </td>
                    </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
