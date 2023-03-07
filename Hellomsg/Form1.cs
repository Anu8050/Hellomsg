using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hellomsg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //lblHelloWorld.Text = "hello";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\User\AppData\Local\Programs\Python\Python310\python.exe";
            start.Arguments = @"F:\\C#Example\\PythonFile\\print.py";
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            string result = "";
            using (Process process = Process.Start(start))
            {
                result = process.StandardOutput.ReadToEnd();
            }
            lblHelloWorld.Text = result;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\User\AppData\Local\Programs\Python\Python310\python.exe";
            start.Arguments = @"F:\\C#Example\\PythonFile\\print.py";
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            string result = "";
            using (Process process = Process.Start(start))
            {
                result = process.StandardOutput.ReadToEnd();
            }

            string message = result;
            string title = "Python File content";
            MessageBox.Show(message, title);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
