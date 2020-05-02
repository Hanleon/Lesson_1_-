using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Post_test
{
    class Download
    {
        public bool Load(string filename,string URL)
        {
            try
            {
                HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                WebHeaderCollection colHeader = myrp.Headers;
                int len = int.Parse(colHeader.Get("Content-Length"));

                Stream st = myrp.GetResponseStream();
                Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, (int)by.Length);
                    Console.WriteLine(so.Length);
                }
                so.Close();
                st.Close();
                myrp.Close();
                Myrq.Abort();
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }
    }
}
