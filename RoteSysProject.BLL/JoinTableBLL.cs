using RoteSysProject.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoteSysProject.BLL
{
    public class JoinTableBLL
    {
        JoinTableDAL DAL = new JoinTableDAL();
        /// <summary>
        /// 用于判断一个IP是否参加过这次活动
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public int GetRoteInfoCountByIP(int AID, String IP)
        {
            return DAL.GetRoteInfoCountByIP(AID, IP);
        }
        /// <summary>
        /// 获取到的值分别是 RID  RUID	RUName	UID	UName	RIP
        /// </summary>
        /// <param name="AID"></param>
        /// <returns></returns>
        public DataTable SelectRoteInfoByAID(int AID)
        {
            return DAL.SelectRoteInfoByAID(AID);
        }

        /// <summary>
        /// 查询RoteUser额外一个票数统计的 RoteInfoCount
        /// </summary>
        /// <returns></returns>
        public DataTable SelectRoteUsersAndAllRoteInfoCountOrderByDesc()
        {
            return DAL.SelectRoteUsersAndAllRoteInfoCountOrderByDesc();
        }
        /// <summary>
        /// 查询RoteUser额外一个票数统计的 RoteInfoCount
        /// </summary>
        /// <param name="AID">ActionID</param>
        /// <returns></returns>
        public DataTable SelectRoteUsersAndAllRoteInfoCountOrderByDesc(int AID)
        {
            return DAL.SelectRoteUsersAndAllRoteInfoCountOrderByDesc(AID);
        }
    }
}
