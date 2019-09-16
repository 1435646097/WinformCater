using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal
{
    public class OrderInfoDal
    {
        public int KaiDan(int tableId)
        {
            string sql = "insert into OrderInfo(ODate,IsPay,TableId) values(datetime('now','localtime'),0,@tId);update TableInfo set TIsFree=0 where Tid=@Tid";
            SQLiteParameter p = new SQLiteParameter("@tId", tableId);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
        public double GetMoneyByTid(int tableId)
        {
            string sql = "select OMoney from OrderInfo where IsPay=0 and TableId=@tid";
            SQLiteParameter p = new SQLiteParameter("@tid", tableId);
            return Convert.ToDouble(SqliteHelper.ExecuteScalar(sql, p));
        }
        public int GetOrderId(int tableId)
        {
            string sql = "select * from OrderInfo where tableid=@tid and IsPay=0";
            SQLiteParameter p = new SQLiteParameter("@tid", tableId);
            return Convert.ToInt32(SqliteHelper.ExecuteScalar(sql, p));
        }
        public int DianCai(int orderId, int dishId)
        {
            string sql = "select count(*) from orderDetailInfo where orderid=@oid and dishid=@did";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@oid",orderId),
                new SQLiteParameter("@did",dishId)
            };
            int count = Convert.ToInt32(SqliteHelper.ExecuteScalar(sql, ps));
            if (count == 0)
            {
                //当前订单中没有指定菜品，则进行添加
                sql = "insert into orderDetailInfo(orderid,dishid,count) values(@oid,@did,1)";
            }
            else
            {
                //当前订单中已经存在此菜品，进行数量更新
                sql = "update orderDetailInfo set count=count+1 where orderid=@oid and dishid=@did";
            }
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public List<OrderDetailInfo> GetOrderDetail(int orderId)
        {
            string sql = "select odi.*,di.DTitle,di.DPrice" +
                         " from orderDetailInfo odi" +
                         " inner join dishInfo di" +
                         " on odi.dishid=di.did" +
                         " where odi.orderid=@oid";
            SQLiteParameter p = new SQLiteParameter("@oid", orderId);

            DataTable dt = SqliteHelper.GetList(sql, p);

            List<OrderDetailInfo> list = new List<OrderDetailInfo>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new OrderDetailInfo()
                {
                    OId = Convert.ToInt32(row["oid"]),
                    OrderId = orderId,
                    DishiId = Convert.ToInt32(row["DishId"]),
                    Count = Convert.ToInt32(row["Count"]),
                    DishTitle = row["dtitle"].ToString(),
                    DishPrice = Convert.ToDecimal(row["dprice"])
                });
            }
            return list;
        }
        public int UpdateDishCount(OrderDetailInfo odi)
        {
            string sql = "update OrderDetailInfo set Count=@count where OId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@count",odi.Count),
                new SQLiteParameter("@id",odi.OId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int Delete(int id)
        {
            string sql = "delete from OrderDetailInfo where OId=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
        public int XiaDan(int orderId, double totalMoney)
        {
            string sql = "update OrderInfo set OMoney=@money where OId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@money",totalMoney),
                new SQLiteParameter("@id",orderId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
        public int JieZhang(int tableId, int memberId, decimal discount, decimal payMoney)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                conn.Open();
                //开启事务
                SQLiteTransaction tran = conn.BeginTransaction();
                int counter = 0;
                try
                {
                    //创建command对象,并与事务相关联
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Transaction = tran;
                    //1、更改订单状态：ispay=1,
                    string sql = "update orderinfo set ispay=1";
                    //1.1、如果是会员，则记录下来
                    if (memberId > 0)
                    {
                        sql += ",memberId=" + memberId + ",discount=" + discount;
                    }
                    sql += " where tableId=" + tableId + " and ispay=0";
                    cmd.CommandText = sql;
                    counter += cmd.ExecuteNonQuery();

                    //2、将餐桌状态更改为1空闲
                    sql = "update tableInfo set tIsFree=1 where tid=" + tableId;
                    cmd.CommandText = sql;
                    counter += cmd.ExecuteNonQuery();

                    //3、如果使用余额结账，则更新会员余额
                    if (payMoney > 0)
                    {
                        sql = "update memberinfo set mMoney=mMoney-" + payMoney + " where mid=" + memberId;
                        cmd.CommandText = sql;
                        counter += cmd.ExecuteNonQuery();
                    }

                    //操作成功，则提交确定之前所有的操作
                    tran.Commit();
                }
                catch
                {
                    counter = 0;
                    //一旦出错，则回滚，放弃之前所有的操作
                    tran.Rollback();
                }
                return counter;
            }
        }
    }
}
