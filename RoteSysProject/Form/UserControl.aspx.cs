using RoteSysProject.BLL;
using RoteSysProject.Model;
using RoteSysProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoteSysProject.Form
{
    public partial class UserControl : System.Web.UI.Page
    {
        UsersBLL usersBLL = new UsersBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            REPEATER_Display.DataSource = usersBLL.SelectALL();
            REPEATER_Display.DataBind();
        }

        protected void REPEATER_Display_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int UID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "DELETE")
            {
                int exec = usersBLL.DeleteByID(UID);
                String MESSAGE = exec > 0 ? "操作成功" : "操作失败";
                Response.Write("<script>alert('" + MESSAGE + "');location.href=location.href;</script>");
            }
            else if (e.CommandName == "UPDATE")
            {
                Response.Redirect("UsersUpdate.aspx?UID=" + UID);
            }else if(e.CommandName== "RANDOM_UPDATEPASSWORD")
            {
                String NewPWD = "";
                Random rd = new Random();
                UsersModel user = usersBLL.ToModel(usersBLL.SelectByID(UID))[0];
                for (int f = 0; f < 6; f++)
                {
                    NewPWD += Convert.ToChar(rd.Next('A', 'z'));
                }
                NewPWD += UID;
                Boolean IsSend = false;
                if(usersBLL.UpdatePasswordByID(new UsersModel() { UID = UID, uPwd = NewPWD }) > 0){
                    IsSend=Tool.SendEmail(user.UCode, "密码已重置", "新密码：" + NewPWD);
                }
                this.ClientScript.RegisterClientScriptBlock(GetType(), "script", "<script>alert('"+(IsSend?"新的密码已发送":"密码发送失败")+"')</script>");
            }
        }
    }
}