using RoteSysProject.BLL;
using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoteSysProject.Service
{
    /// <summary>
    /// AddAction 的摘要说明
    /// </summary>
    public class AddAction : IHttpHandler
    {
        ActionInfoBLL actionInfoBLL = new ActionInfoBLL();
        Tool tool = new Tool();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int exec= actionInfoBLL.InsertByModel(new ActionInfoModel()
            {
                ABeginTime = tool.QueryDateNotNull(context, "BeginTime"),
                AEndTime = tool.QueryDateNotNull(context, "EndTime"),
                ADetail = tool.QueryStringNotNull(context, "Detail"),
                AName=tool.QueryStringNotNull(context,"Name"),
                AStatus=tool.QueryBooleanNotNull(context,"Stat"),
            }) ;
            context.Response.Write(exec > 0 ? "True" : "False");
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