﻿using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Forms;
using IronPython.Hosting;
using System.Diagnostics;
using System.IO;
using static IronPython.Modules.PythonNT;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static IronPython.Modules._ast;

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

        private void button5_Click(object sender, EventArgs e)
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

                if ((txtFirstFile.Text != "") &&
                    (txtSecondFile.Text != "") &&
                    (txtThirdFile.Text != ""))
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

                    //C:\Users\User\Documents\
                    //C:/Users/User/Desktop/

                    string inputFilePath = @"C:\Users\User\Documents\" + txtmergefilename.Text + ".pdf";
                    if (File.Exists(inputFilePath))
                    {
                        MessageBox.Show("File is already exists in " + inputFilePath + " please enter another name.");
                        txtmergefilename.Focus();
                    }
                    else
                    {
                        //string res = inputFilePath.Replace(@"\\","/");
                        var result = sumFunction(textboxs, inputFilePath);
                        lblStatus.Text = result;
                        MessageBox.Show("Sucessfuly merge" + txtFirstFile.Text + " and" + txtSecondFile.Text + " and" + txtThirdFile.Text + " files.");
                    }

                    Cursor = Cursors.Arrow;
                }

                
                else if ((txtFirstFile.Text != "") &&
                    (txtSecondFile.Text != "") &&
                    (txtThirdFile.Text == ""))
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

                    //C:\Users\User\Documents\
                    //C:/Users/User/Desktop/
                    string inputFilePath = @"C:\Users\User\Documents\" + txtmergefilename.Text + ".pdf";
                    if (File.Exists(inputFilePath))
                    {
                        MessageBox.Show("File is already exists in " + inputFilePath + " please enter another name.");
                        txtmergefilename.Focus();
                    }
                    else
                    {
                        //string res = inputFilePath.Replace(@"\", "/");
                        var result = sumFunction(textboxs, inputFilePath);
                        lblStatus.Text = result;
                        MessageBox.Show("Sucessfuly merge " + txtFirstFile.Text + " and" + txtSecondFile.Text + " files.");
                    }

                    Cursor = Cursors.Arrow;
                }
   
            }

            else
            {
                MessageBox.Show("Enter minimum two files.");
                Application.Restart();
            }
            
            //Cursor = Cursors.Arrow;
            //this.Refresh();

        }
        
        private void reset_btn_Click(object sender, EventArgs e)
        {
            txtFirstFile.Text = "";
            txtSecondFile.Text = "";
            txtThirdFile.Text = "";
            txtmergefilename.Text = "";
            
        }

        private void preview_btn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //C:/Users/User/Documents/
            //C:/Users/User/Desktop/

            var directory = @"C:/Users/User/Documents/";
            if (txtmergefilename.Text != "")
            {
                string filePath = directory + txtmergefilename.Text + ".pdf";
                System.Diagnostics.Process.Start(filePath);
                MessageBox.Show("Merged file path is " + filePath);

            }
            else
            {
                MessageBox.Show("Select pdf files to merge pdf and give merge file name." );
            }
            Cursor = Cursors.Arrow;
            
        }

       
    }
};