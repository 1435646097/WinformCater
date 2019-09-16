using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPinyin;

namespace Common
{
   public class PinYinHelper
    {
        public static string GetPinYin(string str)
        {
           return Pinyin.GetPinyin(str);
        }
    }
}
