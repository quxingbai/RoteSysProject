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
    public class RootMenuBLL
    {
        RootMenuDAL DAL = new RootMenuDAL();
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
        public int InsertByModel(RootMenuModel Model)
        {
            return DAL.InsertByModel(Model);
        }
        public int UpdateByModel(RootMenuModel Model)
        {
            return DAL.UpdateByModel(Model);
        }
        public List<RootMenuModel> ToModel(DataTable Table)
        {
            return DAL.ToModel(Table);
        }
    }
}

