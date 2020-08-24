using RoteSysProject.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoteSysProject.Form
{
    public partial class ActionInfo : System.Web.UI.Page
    {
        ActionInfoBLL actionInfoBLL = new ActionInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            ReDisplayTableSource(actionInfoBLL.SelectALL(false));
            TEXTBOX_AddBeginTime.Value = DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
            TEXTBOX_AddEndTime.Value = DateTime.Now.AddMonths(1).ToString("yyyy/MM/dd");

        }

        protected void REPEATER_ListAction_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int AID = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName == "DELETE")
            {
                int exec = actionInfoBLL.DeleteByID(AID);
                Response.Write("<script>alert('" + (exec > 0 ? "删除成功" : "删除失败") + "');location.href=location.href;</script>");
            }
            else if (e.CommandName == "UPDATE")
            {
                Response.Redirect("ActionUpdate.aspx?AID=" + AID);
            }
        }

        protected void BUTTON_Select_Click(object sender, EventArgs e)
        {
            String BeTime = TEXTBOX_SelectBeginTime.Text;
            String EnTime = TEXTBOX_SelectEndTime.Text;
            int StatVal = Convert.ToInt32(DROPDOWNLIST_Stat.SelectedValue);
            Boolean Stat = StatVal == 1;
            if (BeTime == EnTime && BeTime == "")
            {
                if (StatVal == 2)
                {
                    ReDisplayTableSource(actionInfoBLL.SelectALL(false));
                }
                else
                {
                    ReDisplayTableSource(actionInfoBLL.SelectByStat(Stat));
                }
            }
            else
            {
                ReDisplayTableSource(actionInfoBLL.SelectByBeginTimeAndEndTimeAndStat(BeTime, EnTime, Stat));
            }
        }
        void ReDisplayTableSource(Object Source)
        {

            REPEATER_ListAction.DataSource = Source;
            REPEATER_ListAction.DataBind();
        }
    }
}