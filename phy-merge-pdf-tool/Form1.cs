using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Forms;
using IronPython.Hosting;
using System.Diagnostics;
using System.IO;
using static IronPython.Modules.PythonNT;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace phy_merge_pdf_tool
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

        private void button1_Click(object sender, EventArgs e)
        {
            var directory = @"C:/Users/User/Documents/";
            string filePath = directory + txtmergefilename.Text + ".pdf";
            System.Diagnostics.Process.Start(filePath);
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            txtFirstFile.Text = "";
            txtSecondFile.Text = "";
            txtThirdFile.Text = "";
            txtmergefilename.Text = "";
            //mergebtn.Enabled = true;
            MessageBox.Show("reset all data.");
            //Cursor = Cursors.Arrow;
        }

        private void preview_btn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var directory = @"C:/Users/User/Documents/";
            string filePath = directory + txtmergefilename.Text + ".pdf";
            System.Diagnostics.Process.Start(filePath);
            MessageBox.Show("Merged file path is" + filePath);
            Cursor = Cursors.Arrow;
            
        }

        private void mergebtn_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            textboxs.Add(txtFirstFile.Text);
            textboxs.Add(txtSecondFile.Text);
            textboxs.Add(txtThirdFile.Text);

            if (((textboxs.ElementAt(0).Length != 0) ||
                (textboxs.ElementAt(1).Length != 0) ||
                (textboxs.ElementAt(2).Length != 0)))
            {
                if ((txtFirstFile.Text == "") ||
                   (txtSecondFile.Text == "") ||
                   (txtmergefilename.Text == ""))
                {
                    if ((txtFirstFile.Text == "") ||
                        (txtSecondFile.Text == ""))
                    {
                        MessageBox.Show("Please enter pdf File.");
                    }

                    if (string.IsNullOrWhiteSpace(txtFirstFile.Text))
                    {
                        MessageBox.Show("Please enter First text File.");
                        txtFirstFile.Focus();
                        return;
                    }

                    else if (string.IsNullOrWhiteSpace(txtSecondFile.Text))
                    {
                        MessageBox.Show("Please enter Second text File.");
                        txtSecondFile.Focus();
                        return;

                    }

                    else if (string.IsNullOrWhiteSpace(txtmergefilename.Text))
                    {
                        MessageBox.Show("Please enter the mergepdf file name to proceed.");
                        txtmergefilename.Focus();
                        return;
                    }

                }

                if ((textboxs.ElementAt(0).Length != 0) &&
                    (textboxs.ElementAt(1).Length != 0) &&
                    (textboxs.ElementAt(2).Length != 0))
                {

                    Cursor = Cursors.WaitCursor;
                    var engine = Python.CreateEngine();
                    var scope = engine.CreateScope();
                    var libs = new[] {
                                        //"F:\\C#Example\\Hellomsg\\Hellomsg\\packages\\DynamicLanguageRuntime.1.3.3\\lib",
                                        "C:\\Program Files\\IronPython 3.4\\Lib",
                                        "C:\\Program Files\\IronPython 3.4\\Lib\\DLLs",
                                        "C:\\Program Files\\IronPython 3.4",
                                        "C:\\Program Files\\IronPython 3.4\\Lib\\site-packages",
                                        "C:\\Program Files\\IronPython 3.4\\Lib\\site-packages\\PyPDF2"
                                     };

                    engine.SetSearchPaths(libs);
                    engine.ExecuteFile(Environment.CurrentDirectory + @"\pythonscript\mergefiles.py", scope);
                    dynamic sumFunction = scope.GetVariable("merge1");

                    for (int i = textboxs.Count - 1; i >= 0; i--)
                    {
                        textboxs[i] = textboxs[i].Replace(@"\", "/");
                        if (textboxs[i].Trim() == "")
                        {
                            textboxs.RemoveAt(i);
                        }
                        //textboxs[i] = textboxs[i].Replace(@"\", "/");
                    }

                    var path = @"C://Users//User//Documents//" + txtmergefilename.Text + ".pdf";
                    if (!File.Exists(path))
                    {
                        var result = sumFunction(textboxs, txtmergefilename.Text);
                        lblStatus.Text = result;
                        MessageBox.Show("Sucessfuly merge" + txtFirstFile.Text + " and" + txtSecondFile.Text + " and" + txtThirdFile.Text + " pdf files.");
                    }

                    else
                    {
                        MessageBox.Show("File is already present in " + path + " please enter another name.");
                    }

                    Cursor = Cursors.Arrow;

                }


                else if ((textboxs.ElementAt(0).Length != 0 &&
                    textboxs.ElementAt(1).Length != 0 &&
                    textboxs.ElementAt(2).Length == 0
                    ))
                {

                    Cursor = Cursors.WaitCursor;
                    var engine = Python.CreateEngine();
                    var scope = engine.CreateScope();
                    var libs = new[] {
                                        //"F:\\C#Example\\Hellomsg\\Hellomsg\\packages\\DynamicLanguageRuntime.1.3.3\\lib",
                                        "C:\\Program Files\\IronPython 3.4\\Lib",
                                        "C:\\Program Files\\IronPython 3.4\\Lib\\DLLs",
                                        "C:\\Program Files\\IronPython 3.4",
                                        "C:\\Program Files\\IronPython 3.4\\Lib\\site-packages",
                                        "C:\\Program Files\\IronPython 3.4\\Lib\\site-packages\\PyPDF2"
                                     };

                    engine.SetSearchPaths(libs);
                    engine.ExecuteFile(Environment.CurrentDirectory + @"\pythonscript\mergefiles.py", scope);
                    dynamic sumFunction = scope.GetVariable("merge1");

                    for (int i = textboxs.Count - 1; i >= 0; i--)
                    {
                        textboxs[i] = textboxs[i].Replace(@"\", "/");
                        if (textboxs[i].Trim() == "")
                        {
                            textboxs.RemoveAt(i);
                        }
                    }

                    var path = @"C://Users//User//Documents//" + txtmergefilename.Text + ".pdf";
                    if (!File.Exists(path))
                    {
                        var result = sumFunction(textboxs, txtmergefilename.Text);
                        lblStatus.Text = result;
                        MessageBox.Show("Sucessfuly merge " + txtFirstFile.Text + " and" + txtSecondFile.Text + " pdf files.");
                    }

                    else
                    {
                        MessageBox.Show("File is already present in " + path + " please enter another name.");
                    }

                    Cursor = Cursors.Arrow;


                }

            }

        }

    }
  
}