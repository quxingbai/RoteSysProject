<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActionInfo.aspx.cs" Inherits="RoteSysProject.Form.ActionInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/Controls.css" rel="stylesheet" />
    <link href="../JS/artDialog4.1.6/skins/black.css" rel="stylesheet" />
    <script src="../JS/jquery-1.11.3.js"></script>
    <script src="../JS/artDialog4.1.6/artDialog.js"></script>
    <style>
        #DisplayActions tr td {
            min-width: 200px;
        }

        .BlockButton {
            min-width: 50px;
            width: 100px;
        }
    </style>
    <script>
        $(document).ready(function () {
            $("#AddNewAction").click(function () {
                art.dialog({
                    id:"AddNewActionForm",
                    title: '添加',
                    content: $("#AddActionHtml").html(),
                    width: '20em',
                });

                $("#BUTTON_AddSubmit").click(function () {
                    var AddName = $("#TEXTBOX_AddName").val();
                    var AddBeginTime = $("#TEXTBOX_AddBeginTime").val();
                    var AddEndTime = $("#TEXTBOX_AddEndTime").val();
                    var AddDetail = $("#TEXTBOX_AddDetail").val();
                    var AddStat = ($("#SELECT_AddStat").select().val() == "1");
                    if (AddName == "" || AddBeginTime == "" || AddEndTime == "" || AddDetail == "") {
                        alert("文本框不能为空");
                        return;
                    }
                    $.ajax({
                        url: "../Service/AddAction.ashx",
                        type: "POST",
                        data: { Name: AddName, BeginTime: AddBeginTime, EndTime: AddEndTime, Detail:AddDetail, Stat: AddStat },
                        success: function (val) {
                            if (val == "True") {
                                alert("添加成功");
                                location.href = location.href;
                            } else {
                                alert("添加失败");
                            }
                        }
                    });
                });
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="margin-bottom: 5%;">
                <label>状态：</label>
                <asp:DropDownList runat="server" ID="DROPDOWNLIST_Stat" class="BlockListBox">
                    <asp:ListItem Text="开启" Value="1" />
                    <asp:ListItem Text="关闭" Value="0" />
                    <asp:ListItem Text="不限" Value="2" />
                </asp:DropDownList>
                <label>起始时间</label>
                <asp:TextBox ID="TEXTBOX_SelectBeginTime" runat="server" CssClass="BlockTextBox" />
                <label>结束时间</label>
                <asp:TextBox ID="TEXTBOX_SelectEndTime" runat="server" CssClass="BlockTextBox" />
                <asp:Button Text="查询" runat="server" class="BlockButton" ID="BUTTON_Select" OnClick="BUTTON_Select_Click" />
                <input value="新增" class="BlockButton" id="AddNewAction" type="button" />
            </div>
            <table id="DisplayActions">
                <thead>
                    <tr>
                        <td>活动名称</td>
                        <td>活动开始时间</td>
                        <td>活动结束时间</td>
                        <td>操作</td>
                    </tr>
                </thead>
                <asp:Repeater ID="REPEATER_ListAction" runat="server" OnItemCommand="REPEATER_ListAction_ItemCommand">
                    <ItemTemplate>
                        <tr title="<%#Eval("ADetail") %>" style='<%#Eval("AStatus")+""=="0"?"background-color:rgba(0, 0, 0, 0.15)": ""%>'>
                            <td><%#Eval("Aname") %></td>
                            <td><%#Eval("ABeginTime") %></td>
                            <td><%#Eval("AEndTime") %> </td>
                            <td>
                                <asp:Button runat="server" class="BlockButton" Text="删除" OnClientClick="return confirm('确认删除吗？')" CommandName="DELETE" CommandArgument='<%#Eval("AID") %>' />
                                <asp:Button runat="server" class="BlockButton" Text="修改" CommandName="UPDATE" CommandArgument='<%#Eval("AID") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div id="AddActionHtml" style="display: none">
            <table>
                <tr>
                    <td>名称</td>
                    <td>
                        <input type="text" id="TEXTBOX_AddName" class="BlockTextBox" />
                    </td>
                </tr>
                <tr>
                    <td>信息</td>
                    <td>
                        <input type="text" id="TEXTBOX_AddDetail" class="BlockTextBox" />
                    </td>
                </tr>
                <tr>
                    <td>开始时间</td>
                    <td>
                        <input type="text" runat="server" id="TEXTBOX_AddBeginTime" class="BlockTextBox" />
                    </td>
                </tr>
                <tr>
                    <td>结束时间</td>
                    <td>
                        <input type="text" runat="server" id="TEXTBOX_AddEndTime" class="BlockTextBox" />
                    </td>
                </tr>
                <tr>
                    <td>设置状态
                    </td>
                    <td>
                        <select id="SELECT_AddStat" class="BlockListBox">
                            <option value="1">开启</option>
                            <option value="0">关闭</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <input type="button" id="BUTTON_AddSubmit" value="提交" class="BlockButton" width="150" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
