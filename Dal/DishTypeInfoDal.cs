using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SQLite;

namespace Dal
{
    public class DishTypeInfoDal
    {
        public List<DishTypeInfo> GetList()
        {
            string sql = "select * from DishTypeInfo where DIsDelete=0";
            DataTable dt = SqliteHelper.GetList(sql);
            List<DishTypeInfo> list = new List<DishTypeInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DishTypeInfo()
                {
                    DId = Convert.ToInt32(row["Did"]),
                    DTitle = row["DTitle"].ToString(),
                });
            }
            return list;
        }
        public int Insert(DishTypeInfo dishTypeInfo)
        {
            string sql = "insert into dishTypeInfo('DTitle','DIsDelete') values(@title,0)";
            SQLiteParameter p = new SQLiteParameter("@title", dishTypeInfo.DTitle);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
        public int Update(DishTypeInfo dishTypeInfo)
        {
            string sql = "update dishTypeInfo set DTitle=@title where DId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",dishTypeInfo.DTitle),
                new SQLiteParameter("@id",dishTypeInfo.DId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Delete(int id)
        {
            string sql = "update dishTypeInfo set DIsDelete=1 where Did=@id";
            SQLiteParameter p = new SQLiteParameter("@id",id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
