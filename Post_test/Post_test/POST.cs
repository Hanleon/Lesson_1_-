using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Post_test
{
    class POST
    {
        public string POST_JSON(string url, string jsonParam)
        {
            //发送请求
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            var byteData = Encoding.UTF8.GetBytes(jsonParam);
            var length = byteData.Length;
            request.ContentLength = length;
            var writer = request.GetRequestStream();
            writer.Write(byteData, 0, length);
            writer.Close();

            //接收数据
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();

            return responseString;
        }

        public string Json2String(SortedDictionary<string, string> dic)
        {
            string str = "{";
            for (int i = 0; i < dic.Count; i++)
            {
                str += "\"" + dic.ToList()[i].Key + "\":\"" + dic.ToList()[i].Value + "\"";
                if (i != dic.Count - 1) str += ",";
            }
            str += "}";
            return str;
        }
    }
}
