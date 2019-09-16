using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class OrderDetailInfo
    {
        public int OId { get; set; }
        public int OrderId { get; set; }
        public int DishiId { get; set; }
        public int Count { get; set; }

        public string DishTitle { get; set; }
        public decimal DishPrice { get; set; }
    }
}
