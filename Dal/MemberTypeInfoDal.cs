using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using System.Data.SQLite;
using Model;

namespace Dal
{
    public class MemberTypeInfoDal
    {
        public List<MemberTypeInfo> Select()
        {
            string sql = "select * from MemberTypeInfo where MisDelete=0";
            DataTable dt = SqliteHelper.GetList(sql);
            List<MemberTypeInfo> memberTypeInfoList = new List<MemberTypeInfo>();
            foreach (DataRow item in dt.Rows)
            {
                memberTypeInfoList.Add(new MemberTypeInfo()
                {
                    MId = Convert.ToInt32(item["MId"]),
                    MDiscount = Convert.ToDecimal(item["MDiscount"]),
                    MTitle = item["Mtitle"].ToString(),
                    MIsDelete = Convert.ToInt32(item["MIsDelete"])
                });
            }
            return memberTypeInfoList;
        }
        public int Insert(MemberTypeInfo memberTypeInfo)
        {
            string sql = "insert into MemberTypeInfo('MTitle','MDiscount','MIsDelete') values(@title,@discount,0)";
            SQLiteParameter[] ps =
             {
                new SQLiteParameter("@title",memberTypeInfo.MTitle),
                new SQLiteParameter("@discount",memberTypeInfo.MDiscount),
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Update(MemberTypeInfo memberTypeInfo)
        {
            string sql = "update MemberTypeInfo set MDiscount=@discount,MTitle=@title where MId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@discount",memberTypeInfo.MDiscount),
                new SQLiteParameter("@title",memberTypeInfo.MTitle),
                new SQLiteParameter("@id",memberTypeInfo.MId)
            };
            return SqliteHelper.ExecuteNonQuery(sql,ps);
        }

        public int Delete(int id)
        {
            string sql = "update MemberTypeInfo set MIsDelete=1 where MId=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
