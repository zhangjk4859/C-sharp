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
                        //内容转换为JSON字符串
                        Stream respStream = wr.GetResponseStream();
                        StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                        string strBuff = respStreamReader.ReadToEnd();
                        //处理JSON字符串
                        Dictionary<String, String> pList = new Dictionary<String, String>();
                        //JSON.parse<List<Dictionary<String, String>>>(strBuff);






                        System.Console.WriteLine(JSON.parse<List<Dictionary<String, String>>>(strBuff));
                        //MessageBox.Show(strBuff);

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

    //专门解析JSON的类
    public static class JSON
    {

        public static T parse<T>(string jsonString)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
            }
        }

        public static string stringify(object jsonObject)
        {
            using (var ms = new MemoryStream())
            {
                new DataContractJsonSerializer(jsonObject.GetType()).WriteObject(ms, jsonObject);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    } 

}
