using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;

namespace Bll
{
   public class MemberInfoBll
    {
        MemberInfoDal MemberInfoDal = new MemberInfoDal();
        public List<MemberInfo> GetList(MemberInfo memberInfo)
        {
            return MemberInfoDal.GetList(memberInfo);
        }

        public bool Insert(MemberInfo memberInfo)
        {
            return MemberInfoDal.Insert(memberInfo)>0;
        }

        public bool Delete(int id)
        {
            return MemberInfoDal.Delete(id)>0;
        }

        public bool Update(MemberInfo memberInfo)
        {
            return MemberInfoDal.Update(memberInfo)>0;
        }
    }
}
