using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Forms;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using java.nio.file;

namespace MergeFilesTool
{
    public partial class Form1 : Form
    {
        List<string> textboxs = new List<string>();
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
            fdlg.Title = "Select second pdf file.";
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
            fdlg.Title = "Select third pdf file.";
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
            textboxs.Add(txtFirstFile.Text);
            textboxs.Add(txtSecondFile.Text);
            textboxs.Add(txtThirdFile.Text);

            if (((textboxs.ElementAt(0).Length != 0) ||
                (textboxs.ElementAt(1).Length != 0) ||
                (textboxs.ElementAt(2).Length != 0)))
            {
                if ((textboxs.ElementAt(0).Length != 0) && 
                    (textboxs.ElementAt(1).Length != 0) && 
                    (textboxs.ElementAt(2).Length != 0))
                {
                    // Microsoft.Scripting.Hosting.ScriptEngine engine = Python.CreateEngine();

                    ScriptEngine engine = Python.CreateEngine();
                    ScriptScope scope = engine.CreateScope();
                    var paths = engine.GetSearchPaths();
                    paths.Add(@"c:\users\user\appdata\local\programs\python\python310\lib\site-packages");
                    engine.SetSearchPaths(paths);
                    engine.ExecuteFile(Environment.CurrentDirectory + @"\pythonscript\mergefiles.py", scope);
                    dynamic sumFunction = scope.GetVariable("merge1");
                    var result = sumFunction(textboxs);
                    lblStatus.Text = result;

                }

                else if ((textboxs.ElementAt(0).Length == 0 && 
                    textboxs.ElementAt(1).Length != 0 && 
                    textboxs.ElementAt(2).Length != 0))
                {
                    var p = Python.CreateEngine();
                    var scope = p.CreateScope();
                    var libs = new[] {
                                        "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\Common7\\IDE\\Extensions\\Microsoft\\Python Tools for Visual Studio\\2.2",
                                        "C:\\Program Files\\IronPython 2.7\\Lib",
                                        "C:\\Program Files\\IronPython 2.7\\DLLs",
                                        "C:\\Program Files\\IronPython 2.7",
                                        "C:\\Program Files\\IronPython 2.7\\Lib\\site-packages"
                                     };

                    p.SetSearchPaths(libs);
                    p.ExecuteFile("F:\\C#trial\\Hellomsg\\Hellomsg\\pythonscript\\mergefiles.py", scope);
                }

                else if ((textboxs.ElementAt(0).Length != 0 && 
                    textboxs.ElementAt(2).Length != 0))
                {  
                    MessageBox.Show("Sucessfuly merge"+ txtFirstFile.Text + " and"+ txtThirdFile.Text + " pdf files.");  
                }

                else if ((textboxs.ElementAt(0).Length != 0 && 
                    textboxs.ElementAt(1).Length != 0 && 
                    textboxs.ElementAt(2).Length == 0))
                {
                    
                    MessageBox.Show("Sucessfuly merge "+ txtFirstFile.Text +" and"+ txtSecondFile.Text + " pdf files.");
                    
                }

                else
                { 
                    MessageBox.Show("Select minimum two pdf files");
                }

            }
   
        }
    }
};