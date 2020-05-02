using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Post_test
{
    public partial class Form1 : Form
    {
        private POST _POST = new POST();
        private string url_1 = "https://class.campus-app.net/tcloud_class/activity/user/schedule-dot?RequestId=1587887167454";
        private SortedDictionary<string, string> request_1 = new SortedDictionary<string, string> { { "ActivityId", "bp76iob6fdggt5eog93g" }, { "Grade", "Grade12" } };

        private string url_2 = "https://class.campus-app.net/tcloud_class/activity/user/schedule?RequestId=1587887167454";
        private SortedDictionary<string, string> request_2 = new SortedDictionary<string, string> { { "ActivityId", "bp76iob6fdggt5eog93g" }, { "Grade", "Grade12" },{ "Date","20200423" } };


        private SplitData _split = new SplitData();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result_str = _POST.POST_JSON(url_1,_POST.Json2String(request_1));
            string[] result_arr = _split.Split_1(result_str);

            string result = "";
            for (int i = 0; i < result_arr.Length; i++) result += result_arr[i] + "\r\n";
            textBox1.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string result_str = _POST.POST_JSON(url_2, _POST.Json2String(request_2));
            string[] result_arr = _split.Split_2(result_str);

            string result = "";
            for (int i = 0; i < result_arr.Length; i++) result += result_arr[i] + "\r\n";
            textBox1.Text = result;
        }
    }
}
