using RoteSysProject.BLL;
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
            }
        }
    }
}