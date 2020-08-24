using RoteSysProject.BLL;
using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace RoteSysProject.Form
{
    public partial class AddRoteUseer : System.Web.UI.Page
    {
        ActionInfoBLL actionInfoBLL = new ActionInfoBLL();
        RoteUserBLL roteUserBLL = new RoteUserBLL();
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
        }

        protected void BUTTON_Add_Click(object sender, EventArgs e)
        {
            int AID = Convert.ToInt32(DROPDOWNLIST_ActionSelect.SelectedValue);
            String ImageFilePath = "../ImageResource/";
            String SPath = MapPath(ImageFilePath);
            DirectoryInfo directory = new DirectoryInfo(SPath);
            int FileCount = directory.GetFiles().Length;
            String FileName = ImageFilePath + "img" + FileCount + ".png";
            String FileName2 = ImageFilePath + "img" + FileCount + ".png";
            FILEUPLOAD_UploadImage.SaveAs(MapPath(FileName));
            int exec = roteUserBLL.InsertByModel(new RoteUserModel()
            {
                AID = AID,
                RUName = TEXTBOX_Name.Text,
                RUAge = Convert.ToInt32(TEXTBOX_Age.Text),
                RUDetail = TEXTBOX_Detail.Text,
                RUImGUrl = FileName,
                RUSex = DROPDOWNLIST_Sex.SelectedValue == 1.ToString(),
            });

            Response.Write("<script>alert('" + (exec > 0 ? "成功" : "失败") + "');</script>");
            if (exec > 0)
            {
                Response.Redirect("ActionInfo.aspx");
            }
        }
    }
}