using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SQLite;
using System.Data;
namespace Dal
{
    public class DishInfoDal
    {
        public List<DishInfo> GetList(DishInfo dishInfo)
        {
            string sql = "select di.*,dti.DTitle typeTitle from DishInfo di join DishTypeInfo dti on di.DTypeId=dti.DId where di.DIsDelete=0";
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (!string.IsNullOrEmpty(dishInfo.DTitle))
            {
                listP.Add(new SQLiteParameter("@title","%"+dishInfo.DTitle+"%"));
                sql += " and di.DTitle like @title";
            }
            if (dishInfo.DTypeId>0)
            {
                listP.Add(new SQLiteParameter("@typeId", dishInfo.DTypeId));
                sql += " and DTypeId=@typeId";
            }
            if (!string.IsNullOrEmpty(dishInfo.DChar))
            {
                listP.Add(new SQLiteParameter("@Dchar", "%"+ dishInfo.DChar + "%"));
                sql += " and DChar like @Dchar";
            }
            DataTable dt = SqliteHelper.GetList(sql,listP.ToArray());
            List<DishInfo> list = new List<DishInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DishInfo()
                {
                    DId = Convert.ToInt32(row["DId"]),
                    DChar = row["DChar"].ToString(),
                    DTitle = row["DTitle"].ToString(),
                    DTypeId = Convert.ToInt32(row["DtypeId"]),
                    DPrice = Convert.ToDecimal(row["DPrice"]),
                    DTypeTitle = row["typeTitle"].ToString()
                });
            }
            return list;
        }
        public int Insert(DishInfo dishInfo)
        {
            string sql = "insert into DishInfo(DTitle,DTypeId,DPrice,DChar,DIsdelete) values(@title,@typeId,@price,@char,0)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",dishInfo.DTitle),
                new SQLiteParameter("@typeid",dishInfo.DTypeId),
                new SQLiteParameter("@price",dishInfo.DPrice),
                new SQLiteParameter("@char",dishInfo.DChar)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Delete(int id)
        {
            string sql = "update DishInfo set DIsDelete=1 where DId=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
        public int Update(DishInfo dishInfo)
        {
            string sql = "update dishInfo set DTitle=@title,DTypeId=@typeId,DPrice=@price,DChar=@char where DId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",dishInfo.DTitle),
                new SQLiteParameter("@typeId",dishInfo.DTypeId),
                new SQLiteParameter("@price",dishInfo.DPrice),
                new SQLiteParameter("@char",dishInfo.DChar),
                new SQLiteParameter("@id",dishInfo.DId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
