using RoteSysProject.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RoteSysProject.Model;

namespace RoteSysProject.Form
{
    public partial class ActionUpdate : System.Web.UI.Page
    {
        ActionInfoBLL actionInfoBLL = new ActionInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            int AID = Convert.ToInt32(Request["AID"]);
            try
            {
                ActionInfoModel infoModel = actionInfoBLL.ToModel(actionInfoBLL.SelectByID(AID))[0];
                TEXTBOX_BeginTime.Text = infoModel.ABeginTime;
                TEXTBOX_Detail.Text = infoModel.ADetail;
                TEXTBOX_EndeTime.Text = infoModel.AEndTime;
                TEXTBOX_Name.Text = infoModel.AName;
                DROPDOWNLIST_Stat.SelectedIndex = infoModel.AStatus ? 1 : 0;
            }
            catch
            {
                Response.End();
            }
        }

        protected void BUTTON_Update_Click(object sender, EventArgs e)
        {
            int AID = Convert.ToInt32(Request["AID"]);
            int exec = actionInfoBLL.UpdateByModel(new ActionInfoModel() { 
                ABeginTime=TEXTBOX_BeginTime.Text,
                ADetail=TEXTBOX_Detail.Text,
                AEndTime=TEXTBOX_EndeTime.Text,
                AID=AID,
                AName=TEXTBOX_Name.Text,
                AStatus=DROPDOWNLIST_Stat.SelectedValue=="1"
            });
            Response.Write("<script>alert('"+(exec > 0 ? "修改成功" : "修改失败") +"')</script>");
            if (exec > 0)
            {
                Response.Redirect("ActionInfo.aspx");
            }
        }
    }
}