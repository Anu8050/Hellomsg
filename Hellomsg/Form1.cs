﻿
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MergeFilesTool
{
    public partial class Form1 : Form
    {
        List<string> textboxs = new List<string>();
        //string[] textboxs = new string[5];
        public Form1()
        {
            InitializeComponent();
        }
  
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select first pdf file";
            fdlg.InitialDirectory = @"C:\Users\User\Documents\";
            //Only allow pdf files
            fdlg.Filter = "Pdf Files (.pdf)|*.pdf";
                
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtFirstFile.Text = fdlg.FileName;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select second pdf file";
            //point to documents folder
            fdlg.InitialDirectory = @"C:\Users\User\Documents\";
            //Only allow pdf files
            fdlg.Filter = "Pdf Files (.pdf)|*.pdf";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtSecondFile.Text = fdlg.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select third pdf file";
            fdlg.InitialDirectory = @"C:\Users\User\Documents\";
            fdlg.Filter = "Pdf Files (.pdf)|*.pdf";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtThirdFile.Text = fdlg.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

            textboxs = new List<string>
            {
                txtFirstFile.Text, txtSecondFile.Text,txtThirdFile.Text
            };

            if((textboxs.ElementAt(0).Length != 0 && textboxs.ElementAt(1).Length != 0 && textboxs.ElementAt(2).Length != 0)
                || (textboxs.ElementAt(0).Length == 0 && textboxs.ElementAt(1).Length != 0 && textboxs.ElementAt(2).Length != 0)
                || (textboxs.ElementAt(0).Length != 0 && textboxs.ElementAt(1).Length == 0 && textboxs.ElementAt(2).Length != 0)
                || (textboxs.ElementAt(0).Length != 0 && textboxs.ElementAt(1).Length != 0 && textboxs.ElementAt(2).Length == 0)

                )
            {
                ScriptEngine engine = Python.CreateEngine();
                ScriptScope scope = engine.CreateScope();

                engine.ExecuteFile(Environment.CurrentDirectory + @"\pythonscript\mergefiles.py", scope);
                dynamic sumFunction = scope.GetVariable("arry1");
                var result = sumFunction(textboxs);
                lblStatus.Text = result;

            }
            else 
            {
                MessageBox.Show("Select minimum two pdf file");
            }

            

            //textboxs.Add(textBox2.Text);
            //textboxs.Add(textBox3.Text);
            //textboxs.Add(textBox4.Text);

            //ScriptEngine engine = Python.CreateEngine();
            //ScriptScope scope = engine.CreateScope();

            //engine.ExecuteFile(Environment.CurrentDirectory + @"\pythonscript\mergefiles.py", scope);
            //dynamic sumFunction = scope.GetVariable("arry1");
            //var result = sumFunction(textboxs);
            //lblStatus.Text = result;


            //ScriptRuntimeSetup setup = Python.CreateRuntimeSetup(null);
            //ScriptRuntime runtime = new ScriptRuntime(setup);
            //ScriptEngine engine = Python.GetEngine(runtime);
            //ScriptSource source = engine.CreateScriptSourceFromFile("F:\\C#Example\\PythonFile\\print.py");
            //ScriptScope scope = engine.CreateScope();

            //engine.GetSysModule().SetVariable("textboxs", textboxs);
            //source.Execute(scope);
            //var result = run_cmd();
            //Console.WriteLine(result);

        }

     

      


       
    }
}
