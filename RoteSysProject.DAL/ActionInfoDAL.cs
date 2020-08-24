using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoteSysProject.DAL
{
    public class ActionInfoDAL
    {
        public DataTable SelectALL(Boolean StateIsTrue = true)
        {
            String state = StateIsTrue ? " AND AStatus=1" : "";
            String sql = "SELECT * FROM ActionInfo WHERE 1=1 " + state;
            return DataBaseOpen.Query(sql);
        }
        public DataTable SelectByStat(Boolean Stat)
        {
            String sql = "SELECT * FROM ActionInfo WHERE AStatus=@Stat";
            return DataBaseOpen.Query(sql, new SqlParameter[]{
                new SqlParameter("@Stat",Stat)
            });
        }
        public DataTable SelectByID(int ID)
        {
            String sql = "SELECT * FROM  ActionInfo WHERE AID=" + ID;
            return DataBaseOpen.Query(sql);
        }
        public int DeleteByID(int ID)
        {
            String sql = "DELETE  ActionInfo WHERE AID=" + ID + " AND AStatus=1";
            return DataBaseOpen.NoQuery(sql);
        }
        public DataTable SelectByBeginTimeAndEndTimeAndStat(String BeginTime, String EndTime, Boolean Stat)
        {
            String sql = "SELECT * FROM ActionInfo WHERE ABeginTime<=@ABeginTime AND AEndTime>=@AEndTime AND AStatus=@Stat";
            return DataBaseOpen.Query(sql, new SqlParameter[] {
                new SqlParameter("@ABeginTime",BeginTime),
                new SqlParameter("@AEndTime",EndTime),
                new SqlParameter("@Stat",Stat),
            });
        }
        public DataTable SelectByBeginTimeAndEndTime(String BeginTime, String EndTime)
        {
            String sql = "SELECT * FROM ActionInfo WHERE ABeginTime<=@ABeginTime AND AEndTime>=@AEndTime ";
            return DataBaseOpen.Query(sql, new SqlParameter[] {
                new SqlParameter("@ABeginTime",BeginTime),
                new SqlParameter("@AEndTime",EndTime),
            });
        }
        public int InsertByModel(ActionInfoModel Model)
        {
            String sql = "INSERT INTO ActionInfo(AName,ADetail,ABeginTime,AEndTime,AStatus) VALUES(@AName,@ADetail,@ABeginTime,@AEndTime,@AStatus)";
            return DataBaseOpen.NoQuery(sql, new SqlParameter[]{
                new SqlParameter("@AID",Model.AID),
                new SqlParameter("@AName",Model.AName),
                new SqlParameter("@ADetail",Model.ADetail),
                new SqlParameter("@ABeginTime",Model.ABeginTime),
                new SqlParameter("@AEndTime",Model.AEndTime),
                new SqlParameter("@AStatus",Model.AStatus),
                });
        }
        public int UpdateByModel(ActionInfoModel Model)
        {
            String sql = "UPDATE ActionInfo SET AName=@AName,ADetail=@ADetail,ABeginTime=@ABeginTime,AEndTime=@AEndTime,AStatus=@AStatus WHERE AID=@AID";
            return DataBaseOpen.NoQuery(sql, new SqlParameter[]{
                new SqlParameter("@AID",Model.AID),
                new SqlParameter("@AName",Model.AName),
                new SqlParameter("@ADetail",Model.ADetail),
                new SqlParameter("@ABeginTime",Model.ABeginTime),
                new SqlParameter("@AEndTime",Model.AEndTime),
                new SqlParameter("@AStatus",Model.AStatus),
                });
        }
        public List<ActionInfoModel> ToModel(DataTable Table)
        {
            List<ActionInfoModel> list = new List<ActionInfoModel>();
            foreach (DataRow Row in Table.Rows)
            {
                list.Add(new ActionInfoModel()
                {
                    AID = Convert.ToInt32(Row["AID"]),
                    AName = Convert.ToString(Row["AName"]),
                    ADetail = Convert.ToString(Row["ADetail"]),
                    ABeginTime = Convert.ToString(Row["ABeginTime"]),
                    AEndTime = Convert.ToString(Row["AEndTime"]),
                    AStatus = Row["AStatus"].ToString() == "0",
                });
            }
            return list;
        }
    }
}


