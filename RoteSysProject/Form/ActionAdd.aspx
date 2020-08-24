<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActionAdd.aspx.cs" Inherits="RoteSysProject.Form.ActionAdd" %>

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
            <table>
                <tr>
                    <td>姓名</td>
                    <td>
                        <asp:TextBox runat="server" ID="TEXTBOX_Name" CssClass="BlockTextBox" />
                    </td>
                </tr>
                <tr>
                    <td>信息</td>
                    <td>
                    <asp:TextBox runat="server" ID="TEXTBOX_Detail" CssClass="BlockTextBox" />
                    </td>
                </tr>
                <tr>
                    <td>开始时间</td>
                    <td>
                    <asp:TextBox runat="server" ID="TEXTBOX_BeginTime" CssClass="BlockTextBox" />
                    </td>
                </tr>
                <tr>
                    <td>结束时间</td>
                    <td>
                    <asp:TextBox runat="server" ID="TEXTBOX_EndTime" CssClass="BlockTextBox" />
                    </td>
                </tr>
                <tr>
                    <td>是否为开启
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="DROPDOWNLIST_Stat" CssClass="BlockListBox">
                            <asp:ListItem Text="开启" Value="1" />
                            <asp:ListItem Text="关闭" Value="0" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button runat="server" ID="BUTTON_Submit" Text="提交" CssClass="BlockButton" OnClick="BUTTON_Submit_Click" Width="150"  />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
