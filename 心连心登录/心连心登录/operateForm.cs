using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class operateForm : Form
    {
        public CookieContainer cookieContainer;
        private DataTable dataTable;
        private JArray objectList;
        
        public operateForm()
        {
            InitializeComponent();
        }

        private void operateForm_Load(object sender, EventArgs e)
        {
            
        }

      

        //获取数据按钮
        private void button1_Click(object sender, EventArgs e)
        {
            //1.1 先发送一次请求，请求10条数据，获取总条目
             JObject totalModel = sendRequestWithParams("1");
             
             if (totalModel != null)
             {
                 //开始请求总数据
                 string totalCount = (string)totalModel["total"];
                 JObject resultModel = sendRequestWithParams(totalCount);
                 //System.Console.WriteLine(resultModel);
                 //增加一个本地存储，进行总数对比，如果一样就显示本地，不一样再进行网络查询

                 //开始用模型解析数据
                 objectList = (JArray)resultModel["rows"];
                 
                 //4.显示在girdView里面
                    //设置数据源
                 dataTable = JArrayToDataTable(objectList);

                 dataGridView1.DataSource = dataTable;

                 dataGridView1.Columns[1].HeaderText = "公司";
                 dataGridView1.Columns[1].Width = 180;

                 dataGridView1.Columns[2].HeaderText = "发货日期";
                 dataGridView1.Columns[2].Width = 150;

                 dataGridView1.Columns[4].HeaderText = "发货通知单";
                 dataGridView1.Columns[4].Width = 100;

                 dataGridView1.Columns[8].HeaderText = "供应商";
                 dataGridView1.Columns[8].Width = 180;

                 dataGridView1.Columns[17].HeaderText = "业务员";
                 dataGridView1.Columns[17].Width = 60;

                 dataGridView1.Columns[19].HeaderText = "备注";
                 dataGridView1.Columns[19].Width = 40;

                 dataGridView1.Columns[20].HeaderText = "制单日期";
                 dataGridView1.Columns[20].Width = 180;

                 dataGridView1.Columns[26].HeaderText = "产品编码";
                 dataGridView1.Columns[27].HeaderText = "产品";
                 dataGridView1.Columns[28].HeaderText = "规格型号";
                 dataGridView1.Columns[26].Width = 100;
                 dataGridView1.Columns[27].Width = 180;
                 dataGridView1.Columns[28].Width = 180;

                 dataGridView1.Columns[34].HeaderText = "单位";
                 dataGridView1.Columns[34].Width = 40;

                 dataGridView1.Columns[35].HeaderText = "数量";
                 dataGridView1.Columns[36].HeaderText = "单价";
                 dataGridView1.Columns[37].HeaderText = "金额";
                 dataGridView1.Columns[40].HeaderText = "收货状态";
                 dataGridView1.Columns[41].HeaderText = "实发数量";

                 
           
                 dataGridView1.Columns[0].Visible = false;
                 //dataGridView1.Columns[1].Visible = false;
                 //dataGridView1.Columns[2].Visible = false;
                 dataGridView1.Columns[3].Visible = false;
                 //dataGridView1.Columns[4].Visible = false;
                 dataGridView1.Columns[5].Visible = false;
                 dataGridView1.Columns[6].Visible = false;
                 dataGridView1.Columns[7].Visible = false;
                 //dataGridView1.Columns[8].Visible = false;
                 dataGridView1.Columns[9].Visible = false;
                 dataGridView1.Columns[10].Visible = false;
                 dataGridView1.Columns[11].Visible = false;
                 dataGridView1.Columns[12].Visible = false;
                 dataGridView1.Columns[13].Visible = false;
                 dataGridView1.Columns[14].Visible = false;
                 dataGridView1.Columns[15].Visible = false;
                 dataGridView1.Columns[16].Visible = false;
                 //dataGridView1.Columns[17].Visible = false;
                 dataGridView1.Columns[18].Visible = false;
                 //dataGridView1.Columns[19].Visible = false;
                 //dataGridView1.Columns[20].Visible = false;
                 dataGridView1.Columns[21].Visible = false;
                 dataGridView1.Columns[22].Visible = false;
                 dataGridView1.Columns[23].Visible = false;
                 dataGridView1.Columns[24].Visible = false;
                 dataGridView1.Columns[25].Visible = false;
                 //dataGridView1.Columns[26].Visible = false;
                 //dataGridView1.Columns[27].Visible = false;
                 //dataGridView1.Columns[28].Visible = false;
                 dataGridView1.Columns[29].Visible = false;
                 dataGridView1.Columns[30].Visible = false;
                 dataGridView1.Columns[31].Visible = false;
                 dataGridView1.Columns[32].Visible = false;
                 dataGridView1.Columns[33].Visible = false;
                 //dataGridView1.Columns[34].Visible = false;
                 //dataGridView1.Columns[35].Visible = false;
                 //dataGridView1.Columns[36].Visible = false;
                 //dataGridView1.Columns[37].Visible = false;
                 dataGridView1.Columns[38].Visible = false;
                 dataGridView1.Columns[39].Visible = false;
                 //dataGridView1.Columns[40].Visible = false;
                 //dataGridView1.Columns[41].Visible = false;

                 //允许用户拖动列
                 dataGridView1.AllowUserToOrderColumns = true;
             }
             
        }
       



        //网络请求统一方法
        private JObject sendRequestWithParams(string countString) { 

             //1.发送网络请求
             try {
                 string param = "page=1&rows="+ countString;
                 byte[] bs = Encoding.ASCII.GetBytes(param);
                 HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://61.163.55.55:10026/SRM_Gy_DeliveryNotice/GetDataAll");
                 req.Method = "POST";
                 req.ContentType = "application/x-www-form-urlencoded";
                 req.ContentLength = bs.Length;
                 req.CookieContainer = this.cookieContainer;
                 using (Stream reqStream = req.GetRequestStream())
                 {
                     reqStream.Write(bs, 0, bs.Length);
                 }
                 //2.处理返回的请求
                 using (HttpWebResponse wr = (HttpWebResponse)req.GetResponse())
                 {
                     //判断网络状态
                     if (wr.StatusCode == HttpStatusCode.OK)
                     {
                         //内容转换为JSON字符串
                         Stream respStream = wr.GetResponseStream();
                         StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                         string strBuff = respStreamReader.ReadToEnd();
                         //处理JSON字符串，转换成模型返回出去
                         //JObject resultModel = (JObject)JsonConvert.DeserializeObject(strBuff);
                         JObject resultModel = JObject.Parse(strBuff);
                         return resultModel;

                     }
                     else
                     {
                         System.Console.WriteLine(wr.StatusCode);
                         return null;
                     }
                 }//using


             }
             catch (WebException exception)
             {
                 System.Console.WriteLine(exception.Status);
                 return null;
             }
             catch (Exception exception)
             {
                 System.Console.WriteLine(exception.Message);
                 return null;
             }

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        

        //转化数据源方法
        private DataTable JArrayToDataTable(JArray array) {
            if (array.Count > 0)
            {
                StringBuilder columns = new StringBuilder();
                DataTable table = new DataTable();
                JObject objColumns = array[0] as JObject;
                //构造表头
                foreach (JToken jkon in objColumns.AsEnumerable<JToken>())
                {
                    string name = ((JProperty)(jkon)).Name;
                    columns.Append(name + ",");
                    table.Columns.Add(name);
                }
                //向表中添加数据
                for (int i = 0; i < array.Count; i++)
                {
                    DataRow row = table.NewRow();
                    JObject obj = array[i] as JObject;
                    foreach (JToken jkon in obj.AsEnumerable<JToken>())
                    {

                        string name = ((JProperty)(jkon)).Name;
                        string value = ((JProperty)(jkon)).Value.ToString();
                        row[name] = value;
                    }
                    table.Rows.Add(row);
                }
                return table;
            }
            else {
                return null;
            }

        }
        //查询框查询数据
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataTable.DefaultView.RowFilter = "BillDate like '%" + textBox1.Text.Trim() + "%'";
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataTable.DefaultView.RowFilter = "DeliveryNoticeCode like '%" + textBox2.Text.Trim() + "%'";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataTable.DefaultView.RowFilter = "MaterialCode like '%" + textBox3.Text.Trim() + "%'";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataTable.DefaultView.RowFilter = "MaterialName like '%" + textBox4.Text.Trim() + "%'";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            dataTable.DefaultView.RowFilter = "Model like '%" + textBox5.Text.Trim() + "%'";
        }

        //dataGridView1 显示行数
        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            //{
            //    DataGridViewRow r = this.dataGridView1.Rows[i];
            //    r.HeaderCell.Value = string.Format("{0}", i + 1);
            //}
            //this.dataGridView1.Refresh();
        }

    }
}
