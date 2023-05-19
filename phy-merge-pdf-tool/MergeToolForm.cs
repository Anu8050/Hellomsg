using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using TextBox = System.Windows.Forms.TextBox;

namespace phy_merge_pdf_tool
{
    /// <summary>
    /// This is MergeToolForm class for creating application to merge pdf file.
    /// </summary>
    public partial class MergeToolForm : Form
    {
        List<string> textboxs = new List<string>();
        public MergeToolForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblProgressStatus.Visible = false;
        }

        /// <summary>
        /// This is browsing pdf documents method.
        /// </summary>
        /// <param name="textBox"></param>
        public void pdfFileBrowse(ref TextBox textBox)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a pdf file to merge";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //@"C:\Users\User\Documents\";
                //Only allow pdf files.
                openFileDialog.Filter = "Pdf Files (.pdf)|*.pdf";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = openFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// Browsing first pdf file documents by calling pdfFileBrowse method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseFirstFile_Click(object sender, EventArgs e)
        {
            //Calling pdfFileBrowse method.
            pdfFileBrowse(ref txtFirstFile);
        }

        /// <summary>
        /// Browsing second pdf file documents by calling pdfFileBrowse method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseSecondFile_Click(object sender, EventArgs e)
        {
            //Calling pdfFileBrowse method.
            pdfFileBrowse(ref txtSecondFile);
        }

        /// <summary>
        /// Browsing thrid pdf file documents calling by pdfFileBrowse method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseThridFile_Click(object sender, EventArgs e)
        {
            //Calling pdfFileBrowse method.
            pdfFileBrowse(ref txtThirdFile);
        }

        /// <summary>
        /// Use to merge pdf files. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mergePdfFiles_Click(object sender, EventArgs e)
        {
            //Adding items to textboxs list.
            textboxs.Add(txtFirstFile.Text);
            textboxs.Add(txtSecondFile.Text);
            textboxs.Add(txtThirdFile.Text);

            if (((textboxs.ElementAt(0).Length != 0) ||
                (textboxs.ElementAt(1).Length != 0) ||
                (textboxs.ElementAt(2).Length != 0)))
            {
                //Checking first pdf file is selected or not.
                if (string.IsNullOrWhiteSpace(txtFirstFile.Text))
                {
                    MessageBox.Show("Please select a pdf file.");
                    textboxs.Clear();
                    txtFirstFile.Focus();
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txtSecondFile.Text)) //Checking second pdf file is selected or not.
                {
                    MessageBox.Show("Please select a pdf file.");
                    textboxs.Clear();
                    txtSecondFile.Focus();
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txtMergeFileName.Text)) //Checking merge pdf file name is entered or not.
                {
                    MessageBox.Show("Please enter the merge pdf file name to proceed.");
                    textboxs.Clear();
                    txtMergeFileName.Focus();
                    return;
                }

                lblProgressStatus.Visible = true;
                Cursor = Cursors.WaitCursor;
                //Common method for merge pdf function.
                mergePdfFileCommonFun(txtFirstFile, txtSecondFile, txtThirdFile);

                lblProgressStatus.Visible = false;
                Cursor = Cursors.Arrow;
            }
            else
            {
                MessageBox.Show("You need to atleast select two pdf files to merge.");
                textboxs.Clear();
                txtFirstFile.Focus();
            }
        }

        /// <summary>
        /// Checking the merge file name format function.
        /// </summary>
        /// <param name="txtMergeFileName"></param>
        /// <returns></returns>
        private bool isValidMergeFileName(TextBox txtMergeFileName)
        {
            // Regular expression pattern to match .pdf or .txt extension
            string pattern = @".(pdf|txt)$";
            return !Regex.IsMatch(txtMergeFileName.Text, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Establish coonection between c# to python script file by passing parameter.
        /// </summary>
        /// <param name="txtFirstFile"></param>
        /// <param name="txtSecondFile"></param>
        /// <param name="txtThirdFile"></param>
        void mergePdfFileCommonFun(TextBox txtFirstFile, TextBox txtSecondFile, TextBox txtThirdFile)
        {
            //Create IronPython Variable.
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            string ironPythonInstalledPath = ConfigurationManager.AppSettings["ironpython-installedpath"];

            var libs = new[] {
                                        ironPythonInstalledPath + "\\Lib",
                                        ironPythonInstalledPath + "\\Lib\\DLLs",
                                        ironPythonInstalledPath ,
                                        ironPythonInstalledPath + "\\Lib\\site-packages",
                                        ironPythonInstalledPath + "\\Lib\\site-packages\\PyPDF2"
                                     };

            engine.SetSearchPaths(libs);
            //Connecting C# windows to python script.
            engine.ExecuteFile(Environment.CurrentDirectory + @"\pythonscript\mergefiles.py", scope);

            for (int i = textboxs.Count - 1; i >= 0; i--)
            {
                textboxs[i] = textboxs[i].Replace(@"\", "/");
                if (textboxs[i].Trim() == "")
                {
                    textboxs.RemoveAt(i);
                }
            }

            string mergeFolderPath = Environment.CurrentDirectory + "\\mergedfiles";
            if (!Directory.Exists(mergeFolderPath))
            {
                Directory.CreateDirectory(mergeFolderPath);
            }
            string inputFilePath = mergeFolderPath + "\\" + txtMergeFileName.Text + ".pdf";
            //Checking merge file name is correct format or not by calling isValidString method.
            if (isValidMergeFileName(txtMergeFileName))
            {
                //Checking merged file name is present or not.
                if (File.Exists(inputFilePath))
                {
                    MessageBox.Show("File already exists in " + inputFilePath + " please enter a different file name.");
                    txtMergeFileName.Text = string.Empty;
                    textboxs.Clear();
                    txtMergeFileName.Focus();
                }
                else
                {
                    //Calling & Passing parameter to function.
                    dynamic sumFunction = scope.GetVariable("mergePdfMethod");
                    var result = sumFunction(textboxs, inputFilePath);
                    lblStatus.Text = result;
                    StringBuilder successMessage = new StringBuilder();
                    successMessage.Append($"Successfuly merged below files:{Environment.NewLine}");
                    if (txtFirstFile.Text.Trim() != string.Empty)
                    {
                        successMessage.Append(Path.GetFileName(txtFirstFile.Text.Trim()))
                                      .Append(Environment.NewLine);
                    }
                    if (txtSecondFile.Text.Trim() != string.Empty)
                    {
                        successMessage.Append(Path.GetFileName(txtSecondFile.Text.Trim()))
                                      .Append(Environment.NewLine);
                    }
                    if (txtThirdFile.Text.Trim() != string.Empty)
                    {
                        successMessage.Append(Path.GetFileName(txtThirdFile.Text.Trim()))
                                      .Append(Environment.NewLine);
                    }

                    MessageBox.Show(successMessage.ToString());
                    textboxs.Clear();
                }
            }
            else
            {
                MessageBox.Show("Invalid merge file name format. Please enter a valid merge file name format without .pdf or .txt extension.");
                textboxs.Clear();
            }   
        }

        /// <summary>
        /// Reset all pdf files name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetAllPdfFilesName_Click(object sender, EventArgs e)
        {
            if((txtFirstFile.Text != string.Empty) || 
                (txtSecondFile.Text != string.Empty) ||
                (txtThirdFile.Text != string.Empty) ||
                (txtMergeFileName.Text != string.Empty))
            {
                txtFirstFile.Text = string.Empty;
                txtSecondFile.Text = string.Empty;
                txtThirdFile.Text = string.Empty;
                txtMergeFileName.Text = string.Empty;
                textboxs.Clear();
                txtFirstFile.Focus();
            }
            else
            {
                MessageBox.Show("There is no file name to reset. Please enter file name.");
            }
        }

        /// <summary>
        /// Preview merge pdf file Path & content.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previewMergedFile_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var directory = Environment.CurrentDirectory  + "\\mergedfiles";
            string filePath = directory + "\\" + txtMergeFileName.Text + ".pdf";

            if (File.Exists(filePath))
            {
                System.Diagnostics.Process.Start(filePath);
                MessageBox.Show("Merged file path is " + filePath);
            }
            else
            {
                MessageBox.Show("There is no file to preview with this file name. Please select atleast two PDF files to perform merge.");
                textboxs.Clear();
            }
            Cursor = Cursors.Arrow;
        }
    }
}