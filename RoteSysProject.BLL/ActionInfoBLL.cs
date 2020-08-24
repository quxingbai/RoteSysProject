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
    public class ActionInfoBLL
    {
        ActionInfoDAL DAL = new ActionInfoDAL();
        public DataTable SelectALL(Boolean StateIsTrue=true)
        {
            return DAL.SelectALL(StateIsTrue);
        }
        public DataTable SelectByID(int ID)
        {
            return DAL.SelectByID(ID);
        }
        public DataTable SelectByStat(Boolean Stat)
        {
            return DAL.SelectByStat(Stat);
        }
        public DataTable SelectByBeginTimeAndEndTimeAndStat(String BeginTime, String EndTime, Boolean Stat)
        {
            return DAL.SelectByBeginTimeAndEndTimeAndStat(BeginTime, EndTime, Stat);
        }
        public DataTable SelectByBeginTimeAndEndTime(String BeginTime, String EndTime)
        {
            return DAL.SelectByBeginTimeAndEndTime(BeginTime, EndTime);
        }
        public int DeleteByID(int ID)
        {
            return DAL.DeleteByID(ID);
        }
        public int InsertByModel(ActionInfoModel Model)
        {
            return DAL.InsertByModel(Model);
        }
        public int UpdateByModel(ActionInfoModel Model)
        {
            return DAL.UpdateByModel(Model);
        }
        public List<ActionInfoModel> ToModel(DataTable Table)
        {
            return DAL.ToModel(Table);
        }
    }
}


