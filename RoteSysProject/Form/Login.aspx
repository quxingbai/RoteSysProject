<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RoteSysProject.Form.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JS/Tool.js"></script>
    <link href="../CSS/Controls.css" rel="stylesheet" />
    <script src="../JS/jquery-1.11.3.js"></script>
    <script src="../JS/artDialog4.1.6/artDialog.js"></script>
    <link href="../JS/artDialog4.1.6/skins/black.css" rel="stylesheet" />
    <script>
        <%
        int AID = Convert.ToInt32(DROPDOWNLIST_ActionSelect.SelectedValue);
        int PageCount = GetPageCount(AID) / MaxPageSize;
        %>
        var Login;
        $(document).ready(function () {
            var PageSelectDiv = $("#PageSelectDIV");
            for (f = 1; f <= <%=PageCount+1%>; f++) {
                PageSelectDiv.append('<div class="PageBlock"><div class="PageBlockA" href="' + location.href.substring(0, location.href.indexOf('?')) + '?Page=' + f + '&AID=' + <%=AID%>+'">第' + f + '页</a></div>');
            }
            $(".PageBlockA").click(function () {
                var url = $(this).attr("href");
                if (url != location.href) {
                    location.href = url;
                }
            })
            $("#form1").css({ height: GetScreenSize().height * 0.9, maxWidth: GetScreenSize().width });
            $("#BUTTON_UserName").click(function () {
                art.artDialog({
                    id: "LoginForm",
                    title: '登录',
                    content: $("#DIV_LoginDiv").html(),
                    width: '350px',
                });
            });
            Login = function () {
                var loginName = $("#TEXTBOX_LoginName").val();
                var loginPassword = $("#TEXTBOX_LoginPassword").val();
                $.ajax({
                    url: "../Service/Login.ashx",
                    type: "Post",
                    data: { UserCode: loginName, UserPassword: loginPassword },
                    success: function (val) {
                        if (val == "True") {
                            alert("登录成功");
                            location.href = location.href;
                        } else {
                            alert("登录失败");
                        }
                    }
                })
            }

            $("#BUTTON_Login").click(function () {
                Login();
            });

        });
    </script>
</head>
<body>
    <style>
        #TopDiv {
            height: 19%;
            border-width: 15px;
            border-bottom-style: solid;
        }

        #BottomDiv {
            height: 74.5%;
        }

        body {
            margin: 0px;
        }

        #LABEL_Rank {
        }

        #BUTTON_UserName {
            width: 200px;
        }

        .RightDisplay {
            float: right;
        }

        #LABEL_Rank {
            float: right;
        }

        .UsersBlock {
            background-color: rgba(0, 0, 0, 0.19);
            border-style: solid;
            border-width: 1px;
            margin: 5px;
            width: 210px;
            float: left;
        }

            .UsersBlock div {
                padding: 5px;
            }

        .BlockListBox {
            width: 100%;
            height: 2em;
        }


        #PageSelectDIV {
            bottom: 30%;
            width: 100%;
            background-color: rgba(0, 0, 0, 0.19);
        }

        .PageBlock {
            margin-left: 10px;
            float: left;
            border-width: 0.4px;
            border-style: solid;
            border-color: black;
        }

        a {
            text-decoration: none;
        }
    </style>
    <form id="form1" runat="server">
        <div id="TopDiv">
            <div class="RightDisplay">
                <input type="button" runat="server" class="BlockButton" id="BUTTON_UserName" /><asp:Label runat="server" ID="LABEL_Rank" />
            </div>
        </div>
        <div id="BottomDiv">
            <asp:DropDownList CssClass="BlockListBox" runat="server" ID="DROPDOWNLIST_ActionSelect" OnSelectedIndexChanged="DROPDOWNLIST_ActionSelect_SelectedIndexChanged" AutoPostBack="true" />
            <asp:Repeater runat="server" ID="REPEATER_UsersDIV">
                <ItemTemplate>
                    <div id="UsersDiv">
                        <div class="UsersBlock">
                            <div><%#Eval("RUName") %><span style="background-color: black; color: lime; float: right;"><%#Eval("RoteInfoCount") %>票</span></div>
                            <div>
                                <img src="<%#Eval("RUImGUrl") %>" style="width: 100px; height: 100px; background-color: black" />
                            </div>
                            <div><%#Eval("RUDetail") %></div>
                            <div><%#Eval("RUSex").ToString()=="0"?"男":"女" %></div>
                            <div><a href="RoteUserInfo.aspx?RUID=<%# Eval("RUID")%>">为我投票</a></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div style="clear: both"></div>
            <div id="PageSelectDIV" style="width: 100%;">
            </div>
        </div>
        <div id="DIV_LoginDiv" style="display: none;">
            <table>
                <tr>
                    <td>登录账号：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TEXTBOX_LoginName" CssClass="BlockTextBox" />
                    </td>
                </tr>
                <tr>
                    <td>登录密码：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TEXTBOX_LoginPassword" CssClass="BlockTextBox" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="button" id="BUTTON_Login" class="BlockButton" value="登录" style="width: 100%" onclick="Login();" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
