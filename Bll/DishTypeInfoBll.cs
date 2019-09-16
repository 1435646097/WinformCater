using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;

namespace Bll
{
   public class DishTypeInfoBll
    {
        DishTypeInfoDal DishTypeInfoDal = new DishTypeInfoDal();
        public List<DishTypeInfo> GetList()
        {
            return DishTypeInfoDal.GetList();
        }
        public bool Insert(DishTypeInfo dishTypeInfo)
        {
            return DishTypeInfoDal.Insert(dishTypeInfo) > 0;
        }
        public bool Update(DishTypeInfo dishTypeInfo)
        {
            return DishTypeInfoDal.Update(dishTypeInfo) > 0;
        }
        public bool Delete(int id)
        {
            return DishTypeInfoDal.Delete(id) > 0;
        }
    }
}
