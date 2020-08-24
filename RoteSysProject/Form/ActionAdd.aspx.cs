using RoteSysProject.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoteSysProject.Form
{
    public partial class ActionAdd : System.Web.UI.Page
    {
        ActionInfoBLL actionInfoBLL = new ActionInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            TEXTBOX_BeginTime.Text = DateTime.Now.AddDays(1).ToString() ;
            TEXTBOX_EndTime.Text = DateTime.Now.AddMonths(2).ToString() ;
        }

        protected void BUTTON_Submit_Click(object sender, EventArgs e)
        {
            int exec = actionInfoBLL.InsertByModel(new Model.ActionInfoModel()
            {
                ABeginTime = TEXTBOX_BeginTime.Text,
                ADetail = TEXTBOX_Detail.Text,
                AEndTime = TEXTBOX_EndTime.Text,
                AID = 0,
                AName = TEXTBOX_Name.Text,
                AStatus = false
            }) ;
            if (exec > 0)
            {
                Response.Write("<script>alert('"+(exec > 0 ? "成功" : "失败") +"');</script>"); 
            }

        }
    }
}