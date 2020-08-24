using RoteSysProject.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoteSysProject.Form
{
    public partial class UsersAdd : System.Web.UI.Page
    {
        UsersBLL usersBLL = new UsersBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BUTTON_Submit_Click(object sender, EventArgs e)
        {
            int exec = usersBLL.InsertByModel(new Model.UsersModel()
            {
                UID=0,
                UCode=TEXTBOX_Code.Text,
                UName =TEXTBOX_Name.Text,
                uPwd=TEXTBOX_Pwd.Text
            });
            String msg = exec > 0 ? "添加成功" : "添加失败";
            Response.Write("<script>alert('"+ msg + "');</script>");
            if (exec > 0)
            {
                Response.Redirect("UserControl.aspx");
            }
        }
    }
}