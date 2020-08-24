using RoteSysProject.BLL;
using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoteSysProject.Form
{
    public partial class RoteUserUpdate : System.Web.UI.Page
    {
        RoteUserBLL roteUserBLL = new RoteUserBLL();
        WebFormTool webFormTool = new WebFormTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            webFormTool.DropDownListSourceBindingToActionList(DROPDOWNLIST_ActionSelect);
            DataTable userTbale = roteUserBLL.SelectByID(RUID());
            if (userTbale.Rows.Count <= 0)
            {
                return;
            }
            RoteUserModel userModel = roteUserBLL.ToModel(userTbale)[0];
            TEXTBOX_Name.Text = userModel.RUName;
            TEXTBOX_Age.Text = userModel.RUAge.ToString();
            TEXTBOX_Detail.Text = userModel.RUDetail;
            DROPDOWNLIST_Sex.SelectedIndex = userModel.RUSex ? 1 : 0;
            DROPDOWNLIST_ActionSelect.SelectedValue = userModel.AID.ToString();
        }
        public int RUID()
        {
            return Request["RUID"] == null ? 0 : Convert.ToInt32(Request["RUID"]);
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
        protected void BUTTON_Submit_Click(object sender, EventArgs e)
        {
            String FileName = "";
            if (FILEUPLOAD_UploadImage.FileName == null||FILEUPLOAD_UploadImage.FileName=="")
            {

            }
            else
            {
                String ImageFilePath = "../ImageResource/";
                String SPath = MapPath(ImageFilePath);
                DirectoryInfo directory = new DirectoryInfo(SPath);
                int FileCount = directory.GetFiles().Length;
                FileName = ImageFilePath + "img" + FileCount + ".png";
                FILEUPLOAD_UploadImage.SaveAs(MapPath(FileName));
            }

            int exec = roteUserBLL.UpdateByModel(new RoteUserModel()
            {
                RUID = RUID(),
                AID = GetSelectActionID(),
                RUAge = Convert.ToInt32(TEXTBOX_Age.Text),
                RUDetail=TEXTBOX_Detail.Text,
                RUImGUrl=FileName,
                RUName=TEXTBOX_Name.Text,
                RUSex=Convert.ToInt32(DROPDOWNLIST_Sex.SelectedValue)== 1
            });

            Response.Write("<script>alert('" + (exec > 0 ? "成功" : "失败") + "');</script>");
            if (exec > 0)
            {
                Response.Redirect("RoteUserSelect.aspx");
            }
        }
    }
}