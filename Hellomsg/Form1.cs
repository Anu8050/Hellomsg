using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Forms;
using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting.Hosting;

//using IronPython.Runtime;
//using IronPython;
//using Microsoft.Scripting;


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
                    ScriptEngine engine = Python.CreateEngine();
                    ScriptScope scope = engine.CreateScope();
                    var paths = engine.GetSearchPaths();

                    //paths.Add(@"C:\\Users\\User\\AppData\\Local\\Programs\\Python\\Python310\\Scripts");
                    //paths.Add(@"C:\\Users\\User\\AppData\Local\\Programs\\Python\\Python310\\include");
                    //paths.Add(@"C:\\Users\\User\\AppData\\Local\\Programs\\Python\Python310\\Lib");
                    paths.Add(@"C:\Users\User\AppData\Local\Programs\Python\Python310\Lib\site-packages");
                    paths.Add(@"C:\Users\User\AppData\Local\Programs\Python\Python310\Lib\site-packages\PyPDF2");
                    paths.Add(@"C:\\Program Files\\IronPython 3.4\\Lib");
                    paths.Add(@"F:\C#Example\Hellomsg\Hellomsg\packages\IronPython.3.4.0");
                    paths.Add(@"F:\C#Example\Hellomsg\Hellomsg\packages\IronPython.StdLib.3.4.0");


                    //paths.Add(@"F:\C#Example\Hellomsg\Hellomsg\packages\DynamicLanguageRuntime.1.3.3");
                    //paths.Add(@"C:\Users\User\AppData\Local\Programs\Python\Python310\Scripts");
                    //paths.Add(@"C:\Users\User\AppData\Local\Programs\Python\Python310\include");
                    //paths.Add(@"C:\Users\User\AppData\Local\Programs\Python\Python310\Lib");
                    //paths.Add(@"C:\Users\User\AppData\Local\Programs\Python\Python310\Lib\site-packages\PyPDF2");
                    ////paths.Add(@"F:\C#Example\Hellomsg\Hellomsg");
                    //paths.Add(@"C:\Program Files\IronPython 2.7\Lib");


                    //paths.Add(@"C:\myProject\'where mergefiles.py exists'");

                    //engine.SetSearchPaths(paths);
                    //var mainfile = @"F:\C#Example\Hellomsg\Hellomsg\pythonscript\mergefiles.py";
                    ////var scope = engine.CreateScope();
                    //engine.CreateScriptSourceFromFile(mainfile).Execute(scope);
                    //var result = scope.GetVariable("merge1");
                    //// Console.WriteLine(result);
                    //Console.ReadKey();

                    //paths.Add(@"C:\\Users\\User\\AppData\\Local\\Programs\\Python\\Python310\\DLLs");
                    //paths.Add(@"C:\\Users\\User\\AppData\\Local\\Programs\\Python\\Python310\\lib");
                    //paths.Add(@"C:\\Users\\User\\AppData\\Local\\Programs\\Python\\Python310");
                    //paths.Add(@"C:\\Users\\User\\AppData\\Roaming\\Python\\Python310\\site-packages");
                    //paths.Add(@"C:\\Users\\User\\AppData\\Local\\Programs\\Python\\Python310\\Lib\\site-packages\\PyPDF2");
                    //engine.SetSearchPaths(paths);
                    //engine.ExecuteFile(@"C:\Users\User\Documents\mergefiles.py", scope); 

                    //engine.ExecuteFile(@"F:\C#Example\Hellomsg\Hellomsg\pythonscript\mergefiles.py", scope);
                    //engine.ExecuteFile(Environment.CurrentDirectory + @"\pythonscript\mergefiles.py", scope);
                    engine.ExecuteFile(Environment.CurrentDirectory + @"\pythonscript\mergefiles.py", scope);
                    engine.SetSearchPaths(paths);
                    dynamic sumFunction = scope.GetVariable("merge");
                    var result = sumFunction(textboxs);
                    lblStatus.Text = result;
                }

                else if ((textboxs.ElementAt(0).Length == 0 && 
                    textboxs.ElementAt(1).Length != 0 && 
                    textboxs.ElementAt(2).Length != 0))
                {
                    ScriptEngine engine = Python.CreateEngine();
                    ScriptScope scope = engine.CreateScope();
                    engine.ExecuteFile(Environment.CurrentDirectory + @"\pythonscript\mergefiles.py", scope);
                    dynamic sumFunction = scope.GetVariable("merge");
                    var result = sumFunction(textboxs);
                    lblStatus.Text = result;
                    MessageBox.Show("Sucessfuly merge second and thrid pdf files.");   
                }

                else if ((textboxs.ElementAt(0).Length != 0 && 
                    textboxs.ElementAt(1).Length == 0 && 
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