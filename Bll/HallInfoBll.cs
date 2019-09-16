using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;
namespace Bll
{
    public class HallInfoBll
    {
        private HallInfoDal hid = new HallInfoDal();
        public List<HallInfo> GetList()
        {
            return hid.GetList();
        }

        public bool Insert(HallInfo hi)
        {
            return hid.Insert(hi) > 0;
        }

        public bool Update(HallInfo hi)
        {
            return hid.Update(hi) > 0;
        }
        public bool Delete(int id)
        {
            return hid.Delete(id) > 0;
        }
    }
}
