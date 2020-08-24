using RoteSysProject.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoteSysProject.Form
{
    public partial class RoteUserSelect : System.Web.UI.Page
    {
        WebFormTool webFormTool = new WebFormTool();
        RoteUserBLL roteUserBLL = new RoteUserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            webFormTool.DropDownListSourceBindingToActionList(DROPDOWNLIST_ActionSelect);
            DROPDOWNLIST_ActionSelect_SelectedIndexChanged(null, null);
        }

        protected void DROPDOWNLIST_ActionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            REPEATER_Display.DataSource = roteUserBLL.SelectByActionID(GetSelectActionID());
            REPEATER_Display.DataBind();
        }

        public int GetSelectActionID()
        {
            if (DROPDOWNLIST_ActionSelect.Items.Count < 0)
            {
                return 0;
            }
            int ID = 0;
            ID = Convert.ToInt32(DROPDOWNLIST_ActionSelect.SelectedValue);
            return ID;
        }
        protected void REPEATER_Display_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int RUID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "DELETE")
            {
                int exec = roteUserBLL.DeleteByID(RUID);
                String MESSAGE = exec > 0 ? "操作成功" : "操作失败";
                Response.Write("<script>alert('" + MESSAGE + "');location.href=location.href;</script>");
            }else if(e.CommandName=="UPDATE")
            {
                Response.Redirect("RoteUserUpdate.aspx?RUID="+RUID);
            }
        }
    }
}