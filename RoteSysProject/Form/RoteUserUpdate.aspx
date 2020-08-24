<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoteUserUpdate.aspx.cs" Inherits="RoteSysProject.Form.RoteUserUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JS/Tool.js"></script>
    <link href="../CSS/Controls.css" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            $("#form1").css({ height: GetScreenSize().height * 0.9, maxWidth: GetScreenSize().width });
        });
    </script>
    <style>
        .BlockListBox {
            width: 30%;
        }
        .BlockTextBox{
            width: 30%;
        }
        #BUTTON_Submit{
            margin-top:50px;
        }
        .DivBlock{
            margin-top:20px;
        }
        #FILEUPLOAD_UploadImage{
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="">
            <asp:DropDownList runat="server" ID="DROPDOWNLIST_ActionSelect" CssClass="BlockListBox" />
            <div class="DivBlock">
                <div>
                    姓名：
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TEXTBOX_Name" CssClass="BlockTextBox" />
                </div>
            </div>
            <div class="DivBlock">
                <div>
                    年龄：
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TEXTBOX_Age" CssClass="BlockTextBox" />
                </div>
            </div>
            <div class="DivBlock">
                <div>
                    性别：
                </div>
                <div>
                    <asp:DropDownList runat="server" ID="DROPDOWNLIST_Sex" CssClass="BlockListBox" Width="30%">
                        <asp:ListItem Value="0" Text="男" />
                        <asp:ListItem Value="1" Text="女" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="DivBlock">
                <div>
                    说的话：
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TEXTBOX_Detail" CssClass="BlockTextBox" />
                </div>
            </div>
            <div class="DivBlock">
                <div>
                    图片地址：
                </div>
                <div>
                    <asp:FileUpload ID="FILEUPLOAD_UploadImage"  runat="server" CssClass="BlockTextBox"/>
                    <label style="color:red">如果不选择就默认不修改此项</label>
                </div>
            </div>
            <asp:Button CssClass="BlockButton" runat="server" Text="修改" ID="BUTTON_Submit" OnClick="BUTTON_Submit_Click"/>
        </div>
    </form>
</body>
</html>
