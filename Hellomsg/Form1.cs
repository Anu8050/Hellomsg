using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Hellomsg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

            string var;
            var = textBox1.Text;

            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = @"C:\Users\User\AppData\Local\Programs\Python\Python310\python.exe";
            start.Arguments = string.Format("{0}", Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "F:\\C#Example\\PythonFile\\print.py"), var);
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
                    myStreamWriter.WriteLine(var);
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

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter ws = new StreamWriter("F:\\C#Example\\PythonFile\\File.txt");

            //sw.Write(String.Join(Environment.NewLine, listBox1.Items));
            //textbox
            ws.Write(String.Join(Environment.NewLine, "Name : "));
            ws.WriteLine(String.Join(Environment.NewLine, textBox2.Text));

            //ws.WriteLine(String.Join(Environment.NewLine, "Responses are "));

            ws.WriteLine(String.Join(Environment.NewLine, "\n"));


            //saving
            ws.Close();
            MessageBox.Show("saved.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
