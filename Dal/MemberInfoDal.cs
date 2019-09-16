using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common;
using System.Data;
using System.Data.SQLite;

namespace Dal
{
    public class MemberInfoDal
    {
        public List<MemberInfo> GetList(MemberInfo memberInfo)
        {
            string sql = "select mi.*,mti.MTitle,mti.MDiscount from MemberInfo mi join MemberTypeInfo mti on mi.MTypeId=mti.MId where mi.MIsDelete=0";
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (!string.IsNullOrEmpty(memberInfo.MName))
            {
                sql += " and MName like @name";
                listP.Add(new SQLiteParameter("@name", "%" + memberInfo.MName + "%"));
            }
            if (memberInfo.MId > 0)
            {
                sql += " and mi.MId=@id";
                listP.Add(new SQLiteParameter("@id", memberInfo.MId));
            }
            if (!string.IsNullOrEmpty(memberInfo.MPhone))
            {
                sql += " and MPhone like @phone";
                listP.Add(new SQLiteParameter("@phone", "%" + memberInfo.MPhone + "%"));
            }
            DataTable dt = SqliteHelper.GetList(sql, listP.ToArray());
            List<MemberInfo> list = new List<MemberInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["MId"]),
                    MMoney = Convert.ToDecimal(row["MMoney"]),
                    MName = row["MName"].ToString(),
                    MPhone = row["MPhone"].ToString(),
                    MTypeId = Convert.ToInt32(row["MtypeId"]),
                    MTitle = row["MTitle"].ToString(),
                    MDiscount = Convert.ToDecimal(row["MDiscount"])
                });
            }
            return list;
        }

        public int Insert(MemberInfo memberInfo)
        {
            string sql = "insert into memberInfo('MTypeId','MName','MPhone','MMoney','MIsDelete') values(@id,@name,@phone,@money,0)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@id",memberInfo.MTypeId),
                new SQLiteParameter("@name",memberInfo.MName),
                new SQLiteParameter("@phone",memberInfo.MPhone),
                new SQLiteParameter("@money",memberInfo.MMoney)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Delete(int id)
        {
            string sql = "update memberInfo set MIsDelete=1 where MId=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }

        public int Update(MemberInfo memberInfo)
        {
            string sql = "update memberInfo set MTypeId=@typeId,MName=@name,MPhone=@phone,MMoney=@money,MIsDelete=0 where MId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@typeId",memberInfo.MTypeId),
                new SQLiteParameter("@name",memberInfo.MName),
                new SQLiteParameter("@phone",memberInfo.MPhone),
                new SQLiteParameter("@money",memberInfo.MMoney),
                new SQLiteParameter("@id",memberInfo.MId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
