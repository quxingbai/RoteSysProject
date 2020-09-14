using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace RoteSysProject.Service
{
    public class Tool
    {
        public String QueryDateNotNull(HttpContext c, String Qname,String Default="")
        {
            String Val = c.Request[Qname];
            if (Val == null || Val == "")
            {
                Val =Default==""? DateTime.Now.ToString():Default;
            }
            return Val;
        }
        public String QueryStringNotNull(HttpContext c, String Qname,String Default="")
        {
            String Val = c.Request[Qname];
            if (Val == null || Val == "")
            {
                Val = Default;
            }
            return Val;
        }
        public int QueryIntNotNull(HttpContext c, String Qname, int Default = 0)
        {
            String Val = c.Request[Qname];
            int ValVal = 0;
            if (Val == null || Val == "")
            {
                ValVal = Default;
            }
            else
            {
                ValVal = Convert.ToInt32(Val);
            }
            return ValVal;
        }
        public Boolean QueryBooleanNotNull(HttpContext c, String Qname)
        {
            String Val = c.Request[Qname];
            if (Val == null || Val == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool SendEmail(string TargetEmailAddress, String Title, String Msg)
        {
            //登录邮箱
            String MyEmailAddress = "2332372339@qq.com";
            String MyEmailPassword = "uuqaiqmxbibgebbi";

            MailMessage mail = new MailMessage(new MailAddress(MyEmailAddress, "", Encoding.UTF8), new MailAddress(TargetEmailAddress, Title, Encoding.UTF8))
            {
                Body = Msg,
                Subject = Title,
            };
            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.qq.com",
                Port = 25,
                Credentials = new NetworkCredential(MyEmailAddress, MyEmailPassword),
            };
            try
            {
                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}