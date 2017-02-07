using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 login = new Form1();
            login.ShowDialog();

            if (login.DialogResult == DialogResult.OK)
            {
                operateForm operatePage = new operateForm();
                //传递cookie参数
                operatePage.cookieContainer = login.cookieContainer;

                Application.Run(operatePage);
            }
            else
            {
                return;
            }
            
            
        }
    }
}
