using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RoteSysProject.DAL
{
    public class JoinTableDAL
    {
        /// <summary>
        /// 用于判断一个IP是否参加过这次活动
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public int GetRoteInfoCountByIP(int AID, String IP)
        {
            String sql = "SELECT COUNT(RU.RUID) FROM RoteUser AS RU INNER JOIN RoteInfo AS RI ON RI.RUID=RU.RUID AND RI.RIP=@RIP AND AID=@AID";
            return Convert.ToInt32(DataBaseOpen.QueryOne(sql, new SqlParameter[]{
                new SqlParameter("@RIP",IP),
                new SqlParameter("@AID",AID)
            }));
        }
        /// <summary>
        /// 查询RoteUser额外一个票数统计的 RoteInfoCount
        /// </summary>
        /// <returns></returns>
        public DataTable SelectRoteUsersAndAllRoteInfoCountOrderByDesc()
        {
            String sql = "SELECT RU.*,COUNT(RI.RID) AS 'RoteInfoCount' FROM RoteUser AS RU  INNER JOIN RoteInfo AS RI ON RU.RUID=RI.RUID GROUP BY RU.RUName,RU.RUID,RU.AID,RU.RUSex,RU.RUAge,RU.RUDetail,RU.RUImGUrl ORDER BY COUNT(RI.RID) DESC";
            return DataBaseOpen.Query(sql);
        }
        /// <summary>
        /// 查询RoteUser额外一个票数统计的 RoteInfoCount
        /// </summary>
        /// <param name="AID">ActionID</param>
        /// <returns></returns>
        public DataTable SelectRoteUsersAndAllRoteInfoCountOrderByDesc(int AID)
        {
            String sql = "SELECT RU.*,COUNT(RI.RID) AS 'RoteInfoCount' FROM RoteUser AS RU  INNER JOIN RoteInfo AS RI ON RU.RUID=RI.RUID WHERE RU.AID=@AID GROUP BY RU.RUName,RU.RUID,RU.AID,RU.RUSex,RU.RUAge,RU.RUDetail,RU.RUImGUrl ORDER BY COUNT(RI.RID) DESC";
            return DataBaseOpen.Query(sql, new SqlParameter[] {
                 new SqlParameter("@AID",AID),
            });
        }
        /// <summary>
        /// 获取到的值分别是 RID  RUID	RUName	UID	UName	RIP
        /// </summary>
        /// <param name="AID"></param>
        /// <returns></returns>
        public DataTable SelectRoteInfoByAID(int AID)
        {
            String sql = "SELECT RI.RID,RI.RUID,RU.RUName,U.UID,U.UName,RI.RIP FROM RoteInfo AS RI INNER JOIN RoteUser AS RU ON RI.RUID=RU.RUID INNER JOIN Users AS U ON U.UID=RI.UID WHERE RU.AID=" + AID;
            return DataBaseOpen.Query(sql);
        }
    }
}
