using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Post_test
{
    class SplitData
    {
        public string[] Split_1(string data)
        {
            string[] result = null;
            string new_str = CutOutString(data,"[", "]");
            new_str = new_str.Replace("\"","");
            result = new_str.Split(',');
            return result;
        }

        public string[] Split_2(string data)
        {
            string[] result = null;
            string[] str_arr = data.Split('\"');
            string result_str = "";
            for (int i = 0; i < str_arr.Length; i++)
            {
                if (str_arr[i] == "Name" || str_arr[i] == "ResourcesName" || str_arr[i] == "ResourcesUrl") result_str += str_arr[i + 2] + "\n";
            }
            if (result_str != "")
            {
                result_str = result_str.Substring(0, result_str.Length - 1);
                result_str = result_str.Replace("\\u0026","&");
                result = result_str.Split('\n');
            }
            return result;
        }

        private string CutOutString(string sourse, string startstr, string endstr)
        {
            Regex rg = new Regex("(?i)(?<=\\"+ startstr + ")(.*)(?=\\"+endstr+")");
            return rg.Match(sourse).Value;
        }
    }
}
