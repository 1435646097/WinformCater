using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;

namespace Bll
{
   public class DishInfoBll
    {
        DishInfoDal dishInfoDal = new DishInfoDal();
        public List<DishInfo> GetList(DishInfo dishInfo)
        {
            return dishInfoDal.GetList(dishInfo);
        }
        public bool Insert(DishInfo dishInfo)
        {
            return dishInfoDal.Insert(dishInfo)>0;
        }
        public bool Delete(int id)
        {
            return dishInfoDal.Delete(id)>0;
        }
        public bool Update(DishInfo dishInfo)
        {
            return dishInfoDal.Update(dishInfo) > 0;
        }
    }
}
