<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActionUpdate.aspx.cs" Inherits="RoteSysProject.Form.ActionUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/Controls.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="TEXTBOX_Name" CssClass="BlockTextBox" />
            <asp:TextBox runat="server" ID="TEXTBOX_Detail" CssClass="BlockTextBox" />
            <asp:TextBox runat="server" ID="TEXTBOX_BeginTime" CssClass="BlockTextBox" />
            <asp:TextBox runat="server" ID="TEXTBOX_EndeTime" CssClass="BlockTextBox" />
            <asp:DropDownList runat="server" ID="DROPDOWNLIST_Stat" CssClass="BlockListBox" >
                <asp:ListItem Text="开启" Value="1" />
                <asp:ListItem Text="关闭" Value="0" />
            </asp:DropDownList>
            <asp:Button runat="server" Text="修改" CssClass="BlockButton" ID="BUTTON_Update" OnClick="BUTTON_Update_Click"/>
        </div>
    </form>
</body>
</html>
