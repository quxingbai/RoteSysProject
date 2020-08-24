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
    public class RoteUserBLL
    {
        RoteUserDAL DAL = new RoteUserDAL();
        public DataTable SelectALL()
        {
            return DAL.SelectALL();
        }
        public DataTable SelectByID(int ID)
        {
            return DAL.SelectByID(ID);
        }
        public DataTable SelectByActionID(int ID)
        {
            return DAL.SelectByActionID(ID);
        }
        public int DeleteByID(int ID)
        {
            return DAL.DeleteByID(ID);
        }
        public int GetCount(int AID=0)
        {
            return DAL.GetCount(AID);
        }
        public int InsertByModel(RoteUserModel Model)
        {
            return DAL.InsertByModel(Model);
        }
        public int UpdateByModel(RoteUserModel Model)
        {
            return DAL.UpdateByModel(Model);
        }
        public List<RoteUserModel> ToModel(DataTable Table)
        {
            return DAL.ToModel(Table);
        }
    }
}


