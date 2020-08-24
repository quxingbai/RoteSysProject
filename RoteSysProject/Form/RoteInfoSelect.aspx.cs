using RoteSysProject.BLL;
using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoteSysProject.Form
{
    public partial class RoteInfoSelect : System.Web.UI.Page
    {
        RoteInfoBLL roteInfoBLL = new RoteInfoBLL();
        JoinTableBLL joinTableBLL = new JoinTableBLL();
        ActionInfoBLL actionInfoBLL = new ActionInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            List<ActionInfoModel> OldactionInfoModels = actionInfoBLL.ToModel(actionInfoBLL.SelectALL());
            List<ActionInfoModel> NewactionInfoModels = new List<ActionInfoModel>();
            foreach (ActionInfoModel model in OldactionInfoModels)
            {
                model.AName = (model.AName + "-----------开始时间：" + model.ABeginTime + "-----------结束时间：" + model.AEndTime).Replace("00:00:00", "");
                NewactionInfoModels.Add(model);
            }
            DROPDOWNLIST_ActionSelect.DataSource = NewactionInfoModels;
            DROPDOWNLIST_ActionSelect.DataValueField = "AID";
            DROPDOWNLIST_ActionSelect.DataTextField = "AName";
            DROPDOWNLIST_ActionSelect.DataBind();
            DROPDOWNLIST_ActionSelect_SelectedIndexChanged(null, null);
        }

        protected void LISTBOX_Action_SelectedIndexChanged(object sender, EventArgs e)
        {
            REPEATER_DisplayTable.DataSource = joinTableBLL.SelectRoteInfoByAID(GetSelectActionID());
            REPEATER_DisplayTable.DataBind();
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


        protected void DROPDOWNLIST_ActionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            REPEATER_DisplayTable.DataSource = joinTableBLL.SelectRoteInfoByAID(GetSelectActionID());
            REPEATER_DisplayTable.DataBind();
        }

        protected void REPEATER_DisplayTable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DELETE")
            {
                int RID = Convert.ToInt32(e.CommandArgument);
                int exec= roteInfoBLL.DeleteByID(RID);
                String MESSAGE = exec > 0 ? "操作成功" : "操作失败";
                Response.Write("<script>alert('" + MESSAGE + "');location.href=location.href;</script>");
            }
        }
    }
}