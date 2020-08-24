<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoteUserInfo.aspx.cs" Inherits="RoteSysProject.Form.RoteUserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JS/Tool.js"></script>
    <link href="../CSS/Controls.css" rel="stylesheet" />
    <script src="../JS/jquery-1.11.3.js"></script>
    <style>
        #form1 {
            position: absolute;
            left: 30%;
            width: 40%;
            height: 80%;
            font-size: 2em;
        }

        #Border {
            border-style: solid;
            border-color: black;
            border-width: 1px;
            width: 100%;
            height: 100%;
        }

        #Content {
            margin-left: 15%;
            margin-top:15%;
        }
        body {
        }

        #BackButton {
            width: 400px;
            height:100px;
            font-size: 1em;
        }
        label{

        }
        #IMAGE_UserImage{
            background-color:black;
            width:200px;
            height:200px;
        }
    </style>
    <script>
        $(document).ready(function () {

            $("body").css({ height: GetScreenSize().height, maxWidth: GetScreenSize().width });
            $("#BackButton").click(function () {
                // history.back();
                location.href = "Login.aspx";
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-size: 2em;margin-left:15%">
            明细界面
        </div>
        <div id="Border">
            <div id="Content">
                <table>
                    <tr>
                        <td>姓名：</td>
                        <td><asp:Label runat="server" ID="LABEL_UserName" /></td>
                    </tr> 
                    <tr>
                        <td>年龄：</td>
                        <td><asp:Label runat="server" ID="LABEL_Age" /></td>
                    </tr>
                    <tr>
                        <td>性别：</td>
                        <td><asp:Label runat="server" ID="LABEL_SEX" /></td>
                    </tr>
                    <tr>
                        <td>格言：</td>
                        <td><asp:Label runat="server" ID="LABEL_Detail" /></td>
                    </tr>
                    <tr>
                        <td>图片：</td>
                        <td><asp:Image runat="server" ID="IMAGE_UserImage" /></td>
                    </tr>
                    <tr style="position: absolute; bottom: 0px; ">
                        <td colspan="1">
                            <input type="button" value="返回" id="BackButton" class="BlockButton"   />
                        </td>
                    </tr>
                </table>
                <div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
