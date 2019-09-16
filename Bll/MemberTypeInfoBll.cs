using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;

namespace Bll
{
   public class MemberTypeInfoBll
    {
        MemberTypeInfoDal MemberTypeInfoDal = new MemberTypeInfoDal();
        public List<MemberTypeInfo> Select()
        {
            return MemberTypeInfoDal.Select();
        }
        public bool Insert(MemberTypeInfo memberTypeInfo)
        {
            return MemberTypeInfoDal.Insert(memberTypeInfo) > 0;
        }
        public bool Update(MemberTypeInfo memberTypeInfo)
        {
            return MemberTypeInfoDal.Update(memberTypeInfo)>0;
        }

        public bool Delete(int id)
        {
            return MemberTypeInfoDal.Delete(id)>0;
        }
    }
}
