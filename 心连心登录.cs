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
using System.Web;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;




namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //存储sessionID  
        public static string sessionID;
        public static string xlxName;
        public static string xlxPassword;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //拿到textbox的值
           username =  this.username;
           password =  this.password;
           xlxName = username.Text;
           xlxPassword = password.Text;

            //检查输入框不能为空
           if (xlxName == "")
            {
                MessageBox.Show("请输入用户名");
                username.Focus();
                return;
            }
           if (xlxPassword == "")
            {
                MessageBox.Show("请输入密码");
                password.Focus();
                return;
            }

            //开始网络验证用户名和密码
                //1.发送请求
            try
            {
                string param = "UserCode=" + xlxName + "&ip=&pcName=&area=&UserPwd=" + xlxPassword + "&X-Requested-With=XMLHttpRequest";
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
                        //内容转换为JSON字符串
                        Stream respStream = wr.GetResponseStream();
                        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                        string strBuff = respStreamReader.ReadToEnd();
                        //处理JSON字符串
                        JObject messageModel = (JObject)JsonConvert.DeserializeObject(strBuff);
                        string message = (string)messageModel["model"];
                        //ok 和 false两种
                        string result = (string)messageModel["result"];
                        //显示登录结果
                        MessageBox.Show(message);
                        //登录成功进行跳转
                        if (result == "ok") { 
                           //拿出sessionID
                                string cookies = wr.Headers["Set-Cookie"];
                                //处理字符串
                                string[] resultString = Regex.Split(cookies, ";", RegexOptions.IgnoreCase);
                                //存储sessionID
                                sessionID = resultString[0];
                           
                           //进行登陆后的页面跳转
                                operateForm operatePage = new operateForm();
                                operatePage.Show();
                                this.Hide();
                        }
                    }

                }//using
            }//try
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
