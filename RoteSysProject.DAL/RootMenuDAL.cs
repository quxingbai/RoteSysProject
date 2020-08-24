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
    public class RootMenuDAL
    {
        public DataTable SelectALL()
        {
            String sql = "SELECT * FROM  RootMenu";
            return DataBaseOpen.Query(sql);
        }
        public DataTable SelectByID(int ID)
        {
            String sql = "SELECT * FROM  RootMenu WHERE ID=" + ID;
            return DataBaseOpen.Query(sql);
        }
        public int DeleteByID(int ID)
        {
            String sql = "DELETE  RootMenu WHERE ID=" + ID;
            return DataBaseOpen.NoQuery(sql);
        }

        public int InsertByModel(RootMenuModel Model)
        {
            String sql = "INSERT INTO RootMenu(Title,ParentID,Link) VALUES(@Title,@ParentID,@Link)";
            return DataBaseOpen.NoQuery(sql, new SqlParameter[]{
                new SqlParameter("@Title",Model.Title),
                new SqlParameter("@ParentID",Model.ParentID),
                new SqlParameter("@Link",Model.Link),
                });
        }
        public int UpdateByModel(RootMenuModel Model)
        {
            String sql = "UPDATE RootMenu SET Title=@Title,ParentID=@ParentID,Link=@Link WHERE ID=@ID";
            return DataBaseOpen.NoQuery(sql, new SqlParameter[]{
                new SqlParameter("@Title",Model.Title),
                new SqlParameter("@ParentID",Model.ParentID),
                new SqlParameter("@Link",Model.Link),
                });
        }
        public List<RootMenuModel> ToModel(DataTable Table)
        {
            List<RootMenuModel> list = new List<RootMenuModel>();
            foreach (DataRow Row in Table.Rows)
            {
                list.Add(new RootMenuModel()
                {
                    ID = Convert.ToInt32(Row["ID"]),
                    Title = Convert.ToString(Row["Title"]),
                    ParentID = Convert.ToInt32(Row["ParentID"]),
                    Link = Convert.ToString(Row["Link"]),
                });
            }
            return list;
        }
    }
}

