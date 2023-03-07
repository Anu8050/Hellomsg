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
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Diagnostics;

namespace Hellomsg
{
    public partial class Form2 : Form
    {
        int index = 0;
        List<string> listFiles = new List<string>();
        public Form2()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listFiles.Clear();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fdlg.FileName;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fdlg.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = fdlg.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string var1, var2, var3;
            var1 = textBox1.Text;
            var2 = textBox2.Text;
            var3 = textBox3.Text;

            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = @"C:\Users\User\AppData\Local\Programs\Python\Python310\python.exe";
            start.Arguments = string.Format("{0} {1} {2} {3}", Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "F:\\C#Example\\PythonFile\\arrfile.py"), var1, var2, var3);
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardInput = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.LoadUserProfile = true;
            using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(start))
            {
                using (StreamWriter myStreamWriter = process.StandardInput)
                {
                    myStreamWriter.WriteLine(var1, var2, var3);
                    myStreamWriter.Close();
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string stderr = process.StandardError.ReadToEnd();
                        string result = reader.ReadToEnd();
                        string message = result;
                        //Console.WriteLine(message);
                        string title = "Python File content";
                        MessageBox.Show(message, title);
                    }
                }
            }
        }





        }

}
