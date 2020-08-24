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
    public class UsersDAL
    {
        public DataTable SelectALL()
        {
            String sql = "SELECT * FROM  Users";
            return DataBaseOpen.Query(sql);
        }
        public DataTable SelectByID(int ID)
        {
            String sql = "SELECT * FROM  Users WHERE UID=" + ID;
            return DataBaseOpen.Query(sql);
        }
        public int DeleteByID(int ID)
        {
            String sql = "DELETE  Users WHERE UID=" + ID;
            return DataBaseOpen.NoQuery(sql);
        }

        public DataTable LoginByUserCodePasswordReturnModel(String UserCode, String Password)
        {
            String sql = "SELECT * FROM Users WHERE UCode=@UserCode AND uPwd=@Password";
            return DataBaseOpen.Query(sql,new SqlParameter[]{
                new SqlParameter("@UserCode",UserCode),
                new SqlParameter("@Password",Password),
            });
        }
        public int InsertByModel(UsersModel Model)
        {
            String sql = "INSERT INTO Users(UCode,uPwd,UName) VALUES(@UCode,@uPwd,@UName)";
            return DataBaseOpen.NoQuery(sql,new SqlParameter[]{
                new SqlParameter("@UID",Model.UID),
                new SqlParameter("@UCode",Model.UCode),
                new SqlParameter("@uPwd",Model.uPwd),
                new SqlParameter("@UName",Model.UName),
                });
        }
        public int UpdateByModel(UsersModel Model)
        {
            String sql = "UPDATE Users SET uPwd=@uPwd,UName=@UName WHERE UID=@UID";
            return DataBaseOpen.NoQuery(sql,new SqlParameter[]{
                new SqlParameter("@UID",Model.UID),
                new SqlParameter("@uPwd",Model.uPwd),
                new SqlParameter("@UName",Model.UName),
                });
        }
        public List<UsersModel> ToModel(DataTable Table)
        {
            List<UsersModel> list = new List<UsersModel>();
            foreach (DataRow Row in Table.Rows)
            {
                list.Add(new UsersModel()
                {
                    UID = Convert.ToInt32(Row["UID"]),
                    UCode = Convert.ToString(Row["UCode"]),
                    uPwd = Convert.ToString(Row["uPwd"]),
                    UName = Convert.ToString(Row["UName"]),
                });
            }
            return list;
        }}
}


