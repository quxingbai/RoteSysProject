using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RoteSysProject.DAL
{
    public class FunctionDAL
    {
        /// <summary>
        /// 查找指定页数的 产于用户信息 并且包含了被投票的数量
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="Page"></param>
        /// <param name="AID"></param>
        /// <returns></returns>
        public DataTable SelectRoteInfoByPageAndAID(int PageSize,int Page,int AID)
        {
            String sql = "SELECT * FROM SelectRoteInfoByPageAndAID(@PageSize,@Page,@AID)";
            return DataBaseOpen.Query(sql, new SqlParameter[]{
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@Page",Page),
                new SqlParameter("@AID",AID),
            });
        }
    }
}
