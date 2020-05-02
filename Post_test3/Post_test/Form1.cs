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
        //private SortedDictionary<string, string> request_1 = new SortedDictionary<string, string> { { "ActivityId", "bp76iob6fdggt5eog93g" }, { "Grade", "Grade12" } };

        private string url_2 = "https://class.campus-app.net/tcloud_class/activity/user/schedule?RequestId=1587887167454";
        //private SortedDictionary<string, string> request_2 = new SortedDictionary<string, string> { { "ActivityId", "bp76iob6fdggt5eog93g" }, { "Grade", "Grade12" },{ "Date","20200423" } };


        private SplitData _split = new SplitData();

        private Download _down = new Download();
        private string[] result_class = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, string> request_1 = new SortedDictionary<string, string> { { "ActivityId", "bp76iob6fdggt5eog93g" }, { "Grade", comboBox1.Text } };
            string result_str = _POST.POST_JSON(url_1, _POST.Json2String(request_1));
            string[] result_arr = _split.Split_1(result_str);

            comboBox2.Items.Clear();
            for (int i = 0; i < result_arr.Length; i++) comboBox2.Items.Add(result_arr[i]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SortedDictionary<string, string> request_2 = new SortedDictionary<string, string> { { "ActivityId", "bp76iob6fdggt5eog93g" }, { "Grade", comboBox1.Text }, { "Date", comboBox2.Text } };
            string result_str = _POST.POST_JSON(url_2, _POST.Json2String(request_2));
            result_class = _split.Split_2(result_str);

            comboBox3.Items.Clear();
            for (int i = 0; i < result_class.Length; i+=3) comboBox3.Items.Add(result_class[i + 1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int _index = comboBox3.SelectedIndex;

            _down.Load(result_class[_index * 3 +1], result_class[_index * 3 + 2]);
        }
    }
}
