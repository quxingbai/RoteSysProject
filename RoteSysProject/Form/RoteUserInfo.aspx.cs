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
    public partial class RoteUserInfo : System.Web.UI.Page
    {
        RoteUserBLL roteUserBLL = new RoteUserBLL();
        RoteInfoBLL roteInfoBLL = new RoteInfoBLL();
        UsersBLL userBLL = new UsersBLL();
        JoinTableBLL joinTableBLL = new JoinTableBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            UsersModel usermodel = null;
            if (Request.Cookies["UserCode"] == null || Request.Cookies["UserPassword"] == null)
            {
                Request.Cookies.Add(new HttpCookie("UserCode"));
                Request.Cookies.Add(new HttpCookie("UserPassword"));
            }
            String UserCode = Request.Cookies["UserCode"].Value;
            String UserPassword = Request.Cookies["UserPassword"].Value;
            if (UserPassword == null || UserPassword == "")
            {
                //未登陆
                return;
            }
            else
            {
                usermodel = userBLL.ToModel(userBLL.LoginByUserCodePasswordReturnModel(UserCode, UserPassword))[0];
                //已经登录
            }
            try
            {
                int RUID = Convert.ToInt32(Request["RUID"]);
                String IP = Request.UserHostAddress.ToString();
                RoteUserModel model = roteUserBLL.ToModel(roteUserBLL.SelectByID(RUID))[0];
                LABEL_Age.Text = model.RUAge.ToString();
                LABEL_Detail.Text = model.RUDetail.ToString();
                LABEL_SEX.Text = model.RUSex ? "女" : "男";
                LABEL_UserName.Text = model.RUName;
                IMAGE_UserImage.ImageUrl = model.RUImGUrl;
                if (joinTableBLL.GetRoteInfoCountByIP(model.AID, IP) <= 0)
                {
                    int exc = roteInfoBLL.InsertByModel(new RoteInfoModel()
                    {
                        RCreateTime = DateTime.Now.ToString(),
                        RID = 0,
                        RIP = IP,
                        RUID = RUID,
                        UID = usermodel.UID,
                    });
                }
            }
            catch
            {
                Response.End();
            }
        }
    }
}