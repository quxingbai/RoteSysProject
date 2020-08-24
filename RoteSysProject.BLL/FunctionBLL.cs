using RoteSysProject.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoteSysProject.BLL
{
    public class FunctionBLL
    {
        FunctionDAL DAL = new FunctionDAL();
        /// <summary>
        /// 查找指定页数的 产于用户信息 并且包含了被投票的数量
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="Page">在BLL中手动减去1</param>
        /// <param name="AID"></param>
        /// <returns></returns>
        public DataTable SelectRoteInfoByPageAndAID(int PageSize, int Page, int AID)
        {
            Page -= 1;
            if (Page < 0)
            {
                throw new Exception("页数太小了");
            }
            return DAL.SelectRoteInfoByPageAndAID(PageSize, Page, AID);
        }
    }
}
