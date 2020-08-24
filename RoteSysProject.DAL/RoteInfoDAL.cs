using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  RoteSysProject.DAL
{
    public class RoteInfoDAL
    {
        public DataTable SelectALL()
        {
            String sql = "SELECT * FROM  RoteInfo";
            return DataBaseOpen.Query(sql);
        }
        public DataTable SelectByID(int ID)
        {
            String sql = "SELECT * FROM  RoteInfo WHERE IRD=" + ID;
            return DataBaseOpen.Query(sql);
        }
        public int DeleteByID(int ID)
        {
            String sql = "DELETE  RoteInfo WHERE RID=" + ID;
            return DataBaseOpen.NoQuery(sql);
        }
        public int InsertByModel(RoteInfoModel Model)
        {
            String sql = "INSERT INTO RoteInfo(RUID,UID,RIP,RCreateTime) VALUES(@RUID,@UID,@RIP,@RCreateTime)";
            return DataBaseOpen.NoQuery(sql,new SqlParameter[]{
                new SqlParameter("@RID",Model.RID),
                new SqlParameter("@RUID",Model.RUID),
                new SqlParameter("@UID",Model.UID),
                new SqlParameter("@RIP",Model.RIP),
                new SqlParameter("@RCreateTime",Model.RCreateTime),
                });
        }
        public int UpdateByModel(RoteInfoModel Model)
        {
            String sql = "UPDATE RoteInfo SET RID=@RIDRUID=@RUID,UID=@UID,RIP=@RIP,RCreateTime=@RCreateTime WHERE ID=@ID";
            return DataBaseOpen.NoQuery(sql,new SqlParameter[]{
                new SqlParameter("@RID",Model.RID),
                new SqlParameter("@RUID",Model.RUID),
                new SqlParameter("@UID",Model.UID),
                new SqlParameter("@RIP",Model.RIP),
                new SqlParameter("@RCreateTime",Model.RCreateTime),
                });
        }
        public List<RoteInfoModel> ToModel(DataTable Table)
        {
            List<RoteInfoModel> list = new List<RoteInfoModel>();
            foreach (DataRow Row in Table.Rows)
            {
                list.Add(new RoteInfoModel()
                {
                    RID = Convert.ToInt32(Row["RID"]),
                    RUID = Convert.ToInt32(Row["RUID"]),
                    UID = Convert.ToInt32(Row["UID"]),
                    RIP = Convert.ToString(Row["RIP"]),
                    RCreateTime = Convert.ToString(Row["RCreateTime"]),
                });
            }
            return list;
        }}
}


