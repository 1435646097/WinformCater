using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class MemberInfo
    {
        public int MId { get; set; }
        public int MTypeId { get; set; }
        public string MName { get; set; }
        public string MPhone { get; set; }
        public decimal MMoney { get; set; }
        public bool MIsDelete { get; set; }

        public string MTitle { get; set; }

        public decimal MDiscount { get; set; }
    }
}
