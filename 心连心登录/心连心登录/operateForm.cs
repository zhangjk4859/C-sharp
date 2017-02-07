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
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace WindowsFormsApplication1
{
     public partial class operateForm : Form
    {
        public CookieContainer cookieContainer;
        private System.Data.DataTable dataTable;
        private JArray objectList;
        
        public operateForm()
        {
            InitializeComponent();
        }

        private void operateForm_Load(object sender, EventArgs e)
        {
            this.Text = "心连心SRM系统";
        }

         //关闭窗口确认
        private void operateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("您确认退出吗？", "版权归属：王钰瑾", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
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
        private System.Data.DataTable JArrayToDataTable(JArray array) {
            if (array.Count > 0)
            {
                StringBuilder columns = new StringBuilder();
                System.Data.DataTable table = new System.Data.DataTable();
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
        //生成查询条件方法
        private string getQueryString() {

            return "BillDate like '%" + textBox1.Text.Trim() + "%'"
                + "and DeliveryNoticeCode like '%" + textBox2.Text.Trim() + "%'"
                + "and MaterialCode like '%" + textBox3.Text.Trim() + "%'"
                + "and MaterialName like '%" + textBox4.Text.Trim() + "%'"
                + "and Model like '%" + textBox5.Text.Trim() + "%'";
        }
        //查询框查询数据

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //dataTable.DefaultView.RowFilter = getQueryString();

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //dataTable.DefaultView.RowFilter = getQueryString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //dataTable.DefaultView.RowFilter = getQueryString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //dataTable.DefaultView.RowFilter = getQueryString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //dataTable.DefaultView.RowFilter = getQueryString();
        }

        //查询按钮
        private void button3_Click(object sender, EventArgs e)
        {
            //dataTable有数据才能查询
            if (dataTable != null)
            {
                dataTable.DefaultView.RowFilter = getQueryString();
                label7.Text = dataTable.DefaultView.Count.ToString().Trim() + " 条结果符合条件";
            }
        }
        //显示全部结果，清空rowFilter
        private void button4_Click(object sender, EventArgs e)
        {
            ////dataTable有数据才能查询
            //if (dataTable != null)
            //{
            //    dataTable.DefaultView.RowFilter = "";
            //    label7.Text = "一共" + dataTable.DefaultView.Count.ToString().Trim() + "条数据";
            //}

            //清除所有的textBox的数据
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

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

         //导出excel功能
        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewToExcel(dataGridView1);
        }

         //导出EXCEL功能
        public static void DataGridViewToExcel(DataGridView dgv)
        {


            #region   验证可操作性

            //申明保存对话框      
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀      
            dlg.DefaultExt = "xls ";
            //文件后缀列表      
            dlg.Filter = "EXCEL文件(*.XLS)|*.xls ";
            //默然路径是系统当前路径      
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框      
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径      
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效      
            if (fileNameString.Trim() == " ")
            { return; }
            //定义表格内数据的行数和列数      
            int rowscount = dgv.Rows.Count;
            int colscount = dgv.Columns.Count;
            //行数必须大于0      
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数必须大于0      
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //行数不可以大于65536      
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数不可以大于255      
            if (colscount > 255)
            {
                MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它      
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            #endregion
            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet objsheet = null;
            try
            {
                //申明对象      
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(System.Reflection.Missing.Value);
                objsheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.ActiveSheet;
                //设置EXCEL不可见      
                objExcel.Visible = false;

                //向Excel中写入表格的表头      
                int displayColumnsCount = 1;
                for (int i = 0; i <= dgv.ColumnCount - 1; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                    {
                        objExcel.Cells[1, displayColumnsCount] = dgv.Columns[i].HeaderText.Trim();
                        displayColumnsCount++;
                    }
                }
                //设置进度条      
                //tempProgressBar.Refresh();      
                //tempProgressBar.Visible   =   true;      
                //tempProgressBar.Minimum=1;      
                //tempProgressBar.Maximum=dgv.RowCount;      
                //tempProgressBar.Step=1;      
                //向Excel中逐行逐列写入表格中的数据      
                for (int row = 0; row <= dgv.RowCount - 1; row++)
                {
                    //tempProgressBar.PerformStep();      

                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (dgv.Columns[col].Visible == true)
                        {
                            try
                            {
                                objExcel.Cells[row + 2, displayColumnsCount] = dgv.Rows[row].Cells[col].Value.ToString().Trim();
                                displayColumnsCount++;
                            }
                            catch (Exception)
                            {

                            }

                        }
                    }
                }
                //隐藏进度条      
                //tempProgressBar.Visible   =   false;      
                //保存文件      
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用      
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();

                objsheet = null;
                objWorkbook = null;
                objExcel = null;
            }
            MessageBox.Show(fileNameString + "/n/n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

      

         

        

            

    }//class
}//namespace
