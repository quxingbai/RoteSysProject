using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace  RoteSysProject.DAL
{
    public class RoteUserDAL
    {
        public DataTable SelectALL()
        {
            String sql = "SELECT * FROM  RoteUser";
            return DataBaseOpen.Query(sql);
        }
        public DataTable SelectByID(int ID)
        {
            String sql = "SELECT * FROM  RoteUser WHERE RUID=" + ID;
            return DataBaseOpen.Query(sql);
        }
        public DataTable SelectByActionID(int ID)
        {
            String sql = "SELECT * FROM  RoteUser WHERE AID=" + ID;
            return DataBaseOpen.Query(sql);
        }
        public int DeleteByID(int ID)
        {
            String sql = "DELETE  RoteUser WHERE RUID=" + ID;
            return DataBaseOpen.NoQuery(sql);
        }
        public int GetCount(int AID=0)
        {
            String sql = "SELECT COUNT(RUID) FROM RoteUser"+(AID == 0 ? "" : " WHERE AID="+AID);
            return Convert.ToInt32(DataBaseOpen.QueryOne(sql));
        }
        public int InsertByModel(RoteUserModel Model)
        {
            String sql = "INSERT INTO RoteUser(AID,RUName,RUSex,RUAge,RUDetail,RUImGUrl) VALUES(@AID,@RUName,@RUSex,@RUAge,@RUDetail,@RUImGUrl)";
            return DataBaseOpen.NoQuery(sql,new SqlParameter[]{
                new SqlParameter("@RUID",Model.RUID),
                new SqlParameter("@AID",Model.AID),
                new SqlParameter("@RUName",Model.RUName),
                new SqlParameter("@RUSex",Model.RUSex),
                new SqlParameter("@RUAge",Model.RUAge),
                new SqlParameter("@RUDetail",Model.RUDetail),
                new SqlParameter("@RUImGUrl",Model.RUImGUrl),
                });
        }
        public int UpdateByModel(RoteUserModel Model)
        {
            String ImgSql =Model.RUImGUrl==""?"":" ,RUImGUrl=@RUImGUrl ";
            String sql = "UPDATE RoteUser SET AID=@AID,RUName=@RUName,RUSex=@RUSex,RUAge=@RUAge,RUDetail=@RUDetail "+ ImgSql + " WHERE RUID=@RUID";
            return DataBaseOpen.NoQuery(sql,new SqlParameter[]{
                new SqlParameter("@RUID",Model.RUID),
                new SqlParameter("@AID",Model.AID),
                new SqlParameter("@RUName",Model.RUName),
                new SqlParameter("@RUSex",Model.RUSex),
                new SqlParameter("@RUAge",Model.RUAge),
                new SqlParameter("@RUDetail",Model.RUDetail),
                new SqlParameter("@RUImGUrl",Model.RUImGUrl),
                });
        }
        public List<RoteUserModel> ToModel(DataTable Table)
        {
            List<RoteUserModel> list = new List<RoteUserModel>();
            foreach (DataRow Row in Table.Rows)
            {
                list.Add(new RoteUserModel()
                {
                    RUID = Convert.ToInt32(Row["RUID"]),
                    AID = Convert.ToInt32(Row["AID"]),
                    RUName = Convert.ToString(Row["RUName"]),
                    RUSex = (Row["RUSex"].ToString()=="1"),
                    RUAge = Convert.ToInt32(Row["RUAge"]),
                    RUDetail = Convert.ToString(Row["RUDetail"]),
                    RUImGUrl = Convert.ToString(Row["RUImGUrl"]),
                });
            }
            return list;
        }}
}


