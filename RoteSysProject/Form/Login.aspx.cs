using RoteSysProject.BLL;
using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace RoteSysProject.Form
{
    public partial class Login : System.Web.UI.Page
    {
        UsersBLL userBLL = new UsersBLL();
        RoteUserBLL roteUserBLL = new RoteUserBLL();
        ActionInfoBLL actionInfoBLL = new ActionInfoBLL();
        JoinTableBLL joinTableBLL = new JoinTableBLL();
        FunctionBLL functionBLL = new FunctionBLL();
        public static int MaxPageSize = 7;
        public int LoadAID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsCallback)
            {
                return;
            }
            if (Request.Cookies["UserCode"]==null|| Request.Cookies["UserPassword"] ==null)
            {
                Request.Cookies.Add(new HttpCookie("UserCode"));
                Request.Cookies.Add(new HttpCookie("UserPassword"));
            }
            String UserCode = Request.Cookies["UserCode"].Value;
            String UserPassword = Request.Cookies["UserPassword"].Value;
            if (UserPassword == null || UserPassword == "")
            {
                //未登陆
                BUTTON_UserName.Value = "未登陆";
                LABEL_Rank.Text = "";
            }
            else
            {
                UsersModel model = userBLL.ToModel(userBLL.LoginByUserCodePasswordReturnModel(UserCode, UserPassword))[0];
                //已经登录
                BUTTON_UserName.Value =model.UName;
                //LABEL_Rank.Text = "排名---1";
            }
            if (IsPostBack)
            {
                return;
            }
            List<ActionInfoModel> OldactionInfoModels = actionInfoBLL.ToModel(actionInfoBLL.SelectALL());
            List<ActionInfoModel> NewactionInfoModels = new List<ActionInfoModel>();
            foreach(ActionInfoModel model in OldactionInfoModels)
            {
                model.AName =(model.AName+ "-----------开始时间：" + model.ABeginTime + "-----------结束时间：" + model.AEndTime).Replace("00:00:00","");
                NewactionInfoModels.Add(model);
            }
            DROPDOWNLIST_ActionSelect.DataSource = NewactionInfoModels;
            DROPDOWNLIST_ActionSelect.DataValueField = "AID";
            DROPDOWNLIST_ActionSelect.DataTextField = "AName";
            DROPDOWNLIST_ActionSelect.DataBind();
            int AID = Convert.ToInt32(NotNullRequest("AID", 0));
            if (AID != 0)
            {
                DROPDOWNLIST_ActionSelect.SelectedValue = AID.ToString();
            }
            ReRoteUsersInfoRepeaterSourceByPage();
        }

        protected void DROPDOWNLIST_ActionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReRoteUsersInfoRepeaterSourceByPage();
        }
        /// <summary>
        /// 获取不带分页的
        /// </summary>
        void ReRoteUsersInfoRepeaterSource()
        {
            int ID = Convert.ToInt32(DROPDOWNLIST_ActionSelect.SelectedValue);
            REPEATER_UsersDIV.DataSource = joinTableBLL.SelectRoteUsersAndAllRoteInfoCountOrderByDesc(ID);
            REPEATER_UsersDIV.DataBind();
        }
        /// <summary>
        /// 带分页的
        /// </summary>
        void ReRoteUsersInfoRepeaterSourceByPage()
        {
            int PageSize = NotNullRequest("PageSize", MaxPageSize);
            int Page = NotNullRequest("Page",1);
            int AID = Convert.ToInt32(DROPDOWNLIST_ActionSelect.SelectedValue);
            REPEATER_UsersDIV.DataSource = functionBLL.SelectRoteInfoByPageAndAID(PageSize, Page, AID);
            REPEATER_UsersDIV.DataBind();
        }
        int NotNullRequest(String RName,int Default=0)
        {
            if (Request[RName] == null)
            {
                return Default;
            }
            else
            {
                String str = Request[RName].ToString();
                return Convert.ToInt32(str);
            }
        }
        public int GetPageCount(int AID=0)
        {
            return roteUserBLL.GetCount(AID);
        }
    }
}