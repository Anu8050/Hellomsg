﻿using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Forms;
using IronPython.Hosting;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            Cursor = Cursors.WaitCursor;
            textboxs.Add(txtFirstFile.Text);
            textboxs.Add(txtSecondFile.Text);
            textboxs.Add(txtThirdFile.Text);

            if((textboxs.ElementAt(0).Length != 0) ||
               (textboxs.ElementAt(1).Length != 0))
            {
                if (string.IsNullOrWhiteSpace(txtFirstFile.Text))
                {
                    MessageBox.Show("Please enter a value for First text File.");
                    txtFirstFile.Focus();
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txtSecondFile.Text))
                {
                    MessageBox.Show("Please enter a value for Second text File");
                    txtSecondFile.Focus();
                    return;
                }
            }


            if (((textboxs.ElementAt(0).Length != 0) ||
                (textboxs.ElementAt(1).Length != 0) ||
                (textboxs.ElementAt(2).Length != 0)))
            {
                if ((textboxs.ElementAt(0).Length != 0) && 
                    (textboxs.ElementAt(1).Length != 0) && 
                    (textboxs.ElementAt(2).Length != 0))
                {
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
                        if (textboxs[i].Trim() == "")
                        {
                            textboxs.RemoveAt(i);
                        }
                        textboxs[i] = textboxs[i].Replace(@"\", "/");
                    }

                    var result = sumFunction(textboxs, txtmergefilename.Text);
                    lblStatus.Text = result;
                    MessageBox.Show("Sucessfuly merge" + txtFirstFile.Text + " and" + txtSecondFile.Text + " and" + txtThirdFile.Text + " pdf files.");

                }

                else if ((textboxs.ElementAt(0).Length != 0 && 
                    textboxs.ElementAt(1).Length != 0 &&
                    textboxs.ElementAt(2).Length == 0
                    ))
                {
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

                    var result = sumFunction(textboxs, txtmergefilename.Text);
                    lblStatus.Text = result;

                    MessageBox.Show("Sucessfuly merge "+ txtFirstFile.Text +" and"+ txtSecondFile.Text + " pdf files.");
                    
                }

                else
                { 
                    MessageBox.Show("Select minimum two pdf files");
                }

            }

            else if(((textboxs.ElementAt(0).Length == 0) ||
                (textboxs.ElementAt(1).Length == 0) ||
                (textboxs.ElementAt(2).Length == 0)))
            {

                MessageBox.Show("Select pdf files");
            }


            Cursor = Cursors.Arrow;
   
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var directory = "C:/Users/User/Documents/";
            string filePath = directory+txtmergefilename.Text+ ".pdf";
            //string filePath = "C:/Users/User/Documents/Anusha.pdf";
            //System.Diagnostics.Process.Start(filename);
            System.Diagnostics.Process.Start(filePath);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            txtFirstFile.Text = "";
            txtSecondFile.Text = "";
            txtThirdFile.Text = "";
            txtmergefilename.Text = "";
        }


    }
};