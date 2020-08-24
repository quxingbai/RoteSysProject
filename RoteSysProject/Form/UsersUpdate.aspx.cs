using RoteSysProject.BLL;
using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoteSysProject.Form
{
    public partial class UsersUpdate : System.Web.UI.Page
    {
        UsersBLL usersBLL = new UsersBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            DataTable table = usersBLL.SelectByID(UID());
            if (table.Rows.Count <= 0)
            {
                return;
            }
            UsersModel UserModel = usersBLL.ToModel(table)[0];
            TEXTBOX_Name.Text =UserModel.UName ;
            TEXTBOX_Pwd.Text =UserModel.uPwd ;
        }
        int UID()
        {
            return Request["UID"] == null ? 0 : Convert.ToInt32(Request["UID"]);
        }

        protected void BUTTON_Submit_Click(object sender, EventArgs e)
        {
            int exec = usersBLL.UpdateByModel(new UsersModel()
            {
                UID=UID(),
                uPwd = TEXTBOX_Pwd.Text,
                UName = TEXTBOX_Name.Text,
            });
            String msg = exec > 0 ? "修改成功" : "修改失败";
            Response.Write("<script>alert('"+msg+ "');</script>");
            if (exec > 0)
            {
                Response.Redirect("UserControl.aspx");
            }
        }
    }
}