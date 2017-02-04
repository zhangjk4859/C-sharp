using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //拿到textbox的值
           username =  this.username;
           password =  this.password;

            //检查输入框不能为空
            if (username.Text == "")
            {
                MessageBox.Show("请输入用户名");
                username.Focus();
                return;
            }
            if (password.Text == "")
            {
                MessageBox.Show("请输入密码");
                password.Focus();
                return;
            }

            //开始网络验证用户名和密码
                //1.发送请求
            try
            {
                string param = "UserCode=" + username.Text + "&ip=&pcName=&area=&UserPwd=" + password.Text + "&X-Requested-With=XMLHttpRequest";
                byte[] bs = Encoding.ASCII.GetBytes(param);
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://61.163.55.55:10026/Login/UserLogin");
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = bs.Length;
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
                        Stream respStream = wr.GetResponseStream();
                        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                        string strBuff = respStreamReader.ReadToEnd();
                        JavaScriptSerializer Serializer = new JavaScriptSerializer();
                        List<T> objs = Serializer.Deserialize<List<T>>(JsonStr);



                        System.Console.WriteLine(respStream);
                        MessageBox.Show(strBuff);

                    }

                    
                    
                }
            }
            catch (WebException exception)
            {
                System.Console.WriteLine(exception.Status);
            }
            catch (Exception exception) {
                System.Console.WriteLine(exception.Message);
            }
	

                


        }
    }
}
