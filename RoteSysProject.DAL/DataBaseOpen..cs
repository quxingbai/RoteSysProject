using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace RoteSysProject.DAL
{
    public class DataBaseOpen
    {
        static String DataBaseKey = ConfigurationManager.ConnectionStrings["DataBaseKey"].ConnectionString;
        static SqlConnection DataBase = new SqlConnection(DataBaseKey);
        static DataBaseOpen()
        {
            DataBase.Open();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable Query(String sql, SqlParameter[] parameters = null)
        {
            DataTable table = new DataTable();
            using (SqlCommand cmd = new SqlCommand(sql, DataBase))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(table);
                }
            }
            return table;
        }
        /// <summary>
        /// 非查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int NoQuery(String sql, SqlParameter[] parameters = null)
        {
            using (SqlCommand cmd = new SqlCommand(sql, DataBase))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 查询一个值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Object QueryOne(String sql, SqlParameter[] parameters = null)
        {
            DataTable table = new DataTable();
            using (SqlCommand cmd = new SqlCommand(sql, DataBase))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(table);
                }
            }
            if (table.Rows.Count > 0)
            {
                return table.Rows[0][0];
            }
            else
            {
                return null;
            }
        }


        public enum DataBaseTransactionType
        {
            Start=1,
            Submit=2,
            Close=3,
        }
        /// <summary>
        /// 数据库的事物状态
        /// </summary>
        /// <param name="State">状态</param>
        public static void DataBaseTransaction(DataBaseTransactionType State)
        {
            if (State ==  DataBaseTransactionType.Start)
            {
                DataBase.BeginTransaction().Commit();
            }
            else if (State ==  DataBaseTransactionType.Submit)
            {
                DataBase.BeginTransaction();
            }
            else if (State ==  DataBaseTransactionType.Close)
            {
                DataBase.BeginTransaction().Dispose();
            }
        }
    }
}

