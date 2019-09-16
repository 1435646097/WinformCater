using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Dal
{
    public static class SqliteHelper
    {
        //读取配置文件，获得连接字符串
        private static string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public static DataTable GetList(string sql,params SQLiteParameter[] ps)
        {
            //根据连接字符串创建连接对象
            using (SQLiteConnection conn=new SQLiteConnection(connStr))
            {
                //创建adapter对象，用于执行查询
                SQLiteDataAdapter adapter=new SQLiteDataAdapter(sql,conn);
                adapter.SelectCommand.Parameters.AddRange(ps);
                DataTable dt=new DataTable();
                adapter.Fill(dt);//将数据库中的数据填充到dt中
                return dt;//返回数据
            }
        }

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteConnection conn=new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd=new SQLiteCommand(sql,conn);
                cmd.Parameters.AddRange(ps);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql,params SQLiteParameter[] ps)
        {
            using (SQLiteConnection conn=new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddRange(ps);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
