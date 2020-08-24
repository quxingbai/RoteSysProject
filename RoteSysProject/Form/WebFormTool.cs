using RoteSysProject.BLL;
using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RoteSysProject.Form
{
    public class WebFormTool
    {
        ActionInfoBLL actionInfoBLL = new ActionInfoBLL();
        public void DropDownListSourceBindingToActionList(DropDownList DROPDOWNLIST_ActionSelect )
        {
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
        }
    }
}