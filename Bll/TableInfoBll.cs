using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;
namespace Bll
{
    public class TableInfoBll
    {
        private TableInfoDal tiDal = new TableInfoDal();
        public List<TableInfo> GetList(TableInfo ti)
        {
            return tiDal.GetList(ti);
        }

        public bool Insert(TableInfo ti)
        {
            return tiDal.Insert(ti) > 0;
        }
        public bool Update(TableInfo ti)
        {
            return tiDal.Update(ti) > 0;
        }
        public bool Delete(int id)
        {
            return tiDal.Delete(id) > 0;
        }
    }
}
