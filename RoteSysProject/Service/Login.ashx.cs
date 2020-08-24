using RoteSysProject.BLL;
using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RoteSysProject.Service
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler
    {
        UsersBLL userBLL = new UsersBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.HttpMethod == "POST")
            {
                String UserCode = context.Request["UserCode"];
                String UserPassword = context.Request["UserPassword"];
                if (UserCode.Length==0&&UserPassword.Length==0)
                {
                    context.Response.Write("False");
                    context.Response.End();
                }
                else
                {
                    DataTable table = userBLL.LoginByUserCodePasswordReturnModel(UserCode, UserPassword);
                    if (table.Rows.Count > 0)
                    {
                        context.Response.Write("True");
                        Double CookieOutDayTime = 10;
                        context.Response.Cookies.Add(new HttpCookie("UserCode", UserCode) {Expires=DateTime.Now.AddDays(CookieOutDayTime) });
                        context.Response.Cookies.Add(new HttpCookie("UserPassword", UserPassword) { Expires = DateTime.Now.AddDays(CookieOutDayTime) });
                        context.Response.End();
                    }
                    else
                    {
                        context.Response.Write("False");
                        context.Response.End();
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}