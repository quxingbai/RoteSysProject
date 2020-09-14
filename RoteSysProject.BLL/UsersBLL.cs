using RoteSysProject.DAL;
using RoteSysProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoteSysProject.BLL
{
    public class UsersBLL
    {
        UsersDAL DAL = new UsersDAL();
        public DataTable SelectALL()
        {
            return DAL.SelectALL();
        }
        public DataTable SelectByID(int ID)
        {
            return DAL.SelectByID(ID);
        }
        public int DeleteByID(int ID)
        {
            return DAL.DeleteByID(ID);
        }
        public int UpdatePasswordByID(UsersModel Model)
        {
            return DAL.UpdatePasswordByID(Model);
        }
        public DataTable LoginByUserCodePasswordReturnModel(String Code, String Password)
        {
            return DAL.LoginByUserCodePasswordReturnModel(Code, Password);
        }
        public int InsertByModel(UsersModel Model)
        {
            return DAL.InsertByModel(Model);
        }
        public int UpdateByModel(UsersModel Model)
        {
            return DAL.UpdateByModel(Model);
        }
        public List<UsersModel> ToModel(DataTable Table)
        {
            return DAL.ToModel(Table);
        }
    }
}


