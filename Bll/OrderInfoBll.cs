using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;
namespace Bll
{
    public class OrderInfoBll
    {
        private OrderInfoDal oiDal = new OrderInfoDal();
        public bool KaiDan(int tableId)
        {
            return oiDal.KaiDan(tableId) > 0;
        }
        public int GetOrderId(int tableId)
        {
            return oiDal.GetOrderId(tableId);
        }
        public double GetMoneyByTid(int tableId)
        {
            return oiDal.GetMoneyByTid(tableId);
        }
        public bool DianCai(int orderId, int dishId)
        {
            return oiDal.DianCai(orderId, dishId) > 0;
        }
        public List<OrderDetailInfo> GetOrderDetial(int orderId)
        {
            return oiDal.GetOrderDetail(orderId);
        }

        public bool UpdateDishCount(OrderDetailInfo odi)
        {
            return oiDal.UpdateDishCount(odi) > 0;

        }
        public bool Delete(int id)
        {
            return oiDal.Delete(id) > 0;
        }
        public bool XiaDan(int orderId, double totalMoney)
        {
            return oiDal.XiaDan(orderId, totalMoney) > 0;
        }
        public bool JieZhang(int tableId, int memberId, decimal discount, decimal payMoney)
        {
            return oiDal.JieZhang(tableId, memberId, discount, payMoney) > 0;
        }
    }
}
