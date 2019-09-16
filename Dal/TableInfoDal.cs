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
    public class TableInfoDal
    {
        public List<TableInfo> GetList(TableInfo ti)
        {
            string sql = "select ti.*,hi.HTitle from TableInfo ti join HallInfo hi on ti.THallId=hi.Hid where TIsDelete=0";
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (ti.HState > -1)
            {
                sql += " and ti.TIsFree=@free";
                listP.Add(new SQLiteParameter("@free", ti.HState));
            }
            if (ti.THallId > 0)
            {
                sql += " and ti.THallId=@id";
                listP.Add(new SQLiteParameter("@id", ti.THallId));
            }
            DataTable dt = SqliteHelper.GetList(sql, listP.ToArray());
            List<TableInfo> list = new List<TableInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new TableInfo()
                {
                    HTitle = row["HTitle"].ToString(),
                    THallId = Convert.ToInt32(row["THallId"]),
                    TId = Convert.ToInt32(row["TId"]),
                    TIsFree = Convert.ToBoolean(row["TIsFree"]),
                    TTitle = row["TTitle"].ToString()
                });
            }
            return list;
        }

        public int Insert(TableInfo ti)
        {
            string sql = "insert into tableInfo(TTitle,THallId,TIsFree,TIsDelete) values(@title,@hallId,@isFree,0)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",ti.TTitle),
                new SQLiteParameter("@hallId",ti.THallId),
                new SQLiteParameter("@isFree",ti.TIsFree)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Update(TableInfo ti)
        {
            string sql = "update tableInfo set TTitle=@title,THallId=@HallId,TIsFree=@IsFree,TIsDelete=0 where TId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",ti.TTitle),
                new SQLiteParameter("@HallId",ti.THallId),
                new SQLiteParameter("@IsFree",ti.TIsFree),
                new SQLiteParameter("@id",ti.TId)
            };
            return SqliteHelper.ExecuteNonQuery(sql,ps);
        }
        public int Delete(int id)
        {
            string sql = "update tableInfo set TIsDelete=1 where TId=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql,p);
        }
    }
}
