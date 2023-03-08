using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Runtime;
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
using static IronPython.Modules.PythonCsvModule;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

using IronPython.Runtime;
using IronPython;
using Microsoft.Scripting;
using static IronPython.Modules.ArrayModule;

namespace Hellomsg
{
    public partial class Form1 : Form
    {
        List<string> textboxs = new List<string>();
        //string[] textboxs = new string[5];
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string var1;
            var1 = textBox1.Text;
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            engine.ExecuteFile(@"F:\\C#Example\\PythonFile\\print.py ", scope);
            dynamic sumFunction = scope.GetVariable("sum");
            var result = sumFunction(var1);
            Console.WriteLine(result);
            MessageBox.Show(result);
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "F# Corner Open File Dialog";
            fdlg.InitialDirectory = @"f:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fdlg.FileName;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "F# Corner Open File Dialog";
            fdlg.InitialDirectory = @"f:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = fdlg.FileName;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "F# Corner Open File Dialog";
            fdlg.InitialDirectory = @"f:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = fdlg.FileName;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            textboxs = new List<string>
            {
                textBox2.Text, textBox3.Text,textBox4.Text
            };
            
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            engine.ExecuteFile(@"F:\\C#Example\\PythonFile\\print.py ", scope);
            dynamic sumFunction = scope.GetVariable("arry");
            var result = sumFunction(textboxs);
            Console.WriteLine(result);
            

           
        }
    }
}
