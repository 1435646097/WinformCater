﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;

namespace Bll
{
    public class ManagerInfoBll
    {
        ManagerInfoDal miDal = new ManagerInfoDal();

        public List<ManagerInfo> GetList()
        {
            return miDal.GetList(null);
        }

        public bool Add(ManagerInfo mi)
        {
            return miDal.Insert(mi) > 0;
        }

        public bool Remove(int id)
        {
            return miDal.DeleteById(id) > 0;
        }

        public bool Edit(ManagerInfo mi)
        {
            return miDal.Update(mi) > 0;
        }

        public bool Login(ManagerInfo mi)
        {
            List<ManagerInfo> list = miDal.GetList(mi);
            mi.MType=list[0].MType;
            return list.Count > 0;
        }
    }
}
