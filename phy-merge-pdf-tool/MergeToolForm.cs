using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Forms;
using IronPython.Hosting;
using System.IO;
using TextBox = System.Windows.Forms.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;


namespace phy_merge_pdf_tool
{
    /// <summary>
    /// This is MergeToolForm class for creating application to merge pdf file.
    /// </summary>
    public partial class MergeToolForm : Form
    {

        List<string> textboxs = new List<string>();

        List<string> filePaths = new List<string>();

        public MergeToolForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is browsing pdf documents method.
        /// </summary>
        /// <param name="textBox"></param>
        public void pdfFileBrowse(ref TextBox textBox)
        {    
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select pdf file";
            openFileDialog.InitialDirectory = @"C:\Users\User\Documents\";
            //Only allow pdf files.
            openFileDialog.Filter = "Pdf Files (.pdf)|*.pdf";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = openFileDialog.FileName;
                              
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
        /// Browsing multiple pdf files method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseMultipleFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select pdf file";
            openFileDialog.InitialDirectory = @"C:\Users\User\Documents\";
            //Only allow pdf files.
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            openFileDialog.Multiselect = true;
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    filePaths.Add(filePath);
                    txtListFile.Items.Add(filePath);
                    txtListFile.Text = openFileDialog.FileName;
                }
            }

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
            foreach (var item in txtListFile.Items)
            {
                textboxs.Add(item.ToString());
            }
            

            string inputFilePath = @"C:\Users\User\Documents\" + txtMergeFileName.Text + ".pdf";

            if (((textboxs.ElementAt(0).Length != 0) ||
                (textboxs.ElementAt(1).Length != 0) ||
                (textboxs.ElementAt(2).Length != 0)))
            {

                //Checking wheter the pdf file is entered or not. 
                if ((txtFirstFile.Text == "") ||
                    (txtSecondFile.Text == "") ||
                    (txtMergeFileName.Text == ""))
                {
                    //Checking first pdf file is selected or not.
                    if (string.IsNullOrWhiteSpace(txtFirstFile.Text))
                    {
                        MessageBox.Show("Please enter First text File.");
                        textboxs.Clear();
                        txtFirstFile.Focus();
                        return;
                    }

                    //Checking second pdf file is selected or not.
                    else if (string.IsNullOrWhiteSpace(txtSecondFile.Text))
                    {
                        MessageBox.Show("Please enter Second text File.");
                        textboxs.Clear();
                        txtSecondFile.Focus();
                        return;

                    }

                    //Checking merge pdf file name is entered or not.
                    else if (string.IsNullOrWhiteSpace(txtMergeFileName.Text))
                    {
                        MessageBox.Show("Please enter the mergepdf file name to proceed.");
                        textboxs.Clear();
                        txtMergeFileName.Focus();
                        return;
                    }

                }

                //Common method for merge pdf function.
                void mergePdfFileCommonFun(TextBox txtFirstFile, TextBox txtSecondFile, ListBox txtListFile)
                {
                    //Create IronPython Variable.
                    Cursor = Cursors.WaitCursor;
                    var engine = Python.CreateEngine();
                    var scope = engine.CreateScope();
                    var libs = new[] {
                                        "C:\\Program Files\\IronPython 3.4\\Lib",
                                        "C:\\Program Files\\IronPython 3.4\\Lib\\DLLs",
                                        "C:\\Program Files\\IronPython 3.4",
                                        "C:\\Program Files\\IronPython 3.4\\Lib\\site-packages",
                                        "C:\\Program Files\\IronPython 3.4\\Lib\\site-packages\\PyPDF2"
                                     };

                    engine.SetSearchPaths(libs);
                    //Connecting C# windows to python script.
                    engine.ExecuteFile(Environment.CurrentDirectory + @"\pythonscript\mergefiles.py", scope);
                    dynamic sumFunction = scope.GetVariable("mergePdfMethod");

                    for (int i = textboxs.Count - 1; i >= 0; i--)
                    {
                        textboxs[i] = textboxs[i].Replace(@"\", "/");
                        if (textboxs[i].Trim() == "")
                        {
                            textboxs.RemoveAt(i);
                        }
                    }

                    //Checking merged file name is present or not.
                    if (File.Exists(inputFilePath))
                    {
                        MessageBox.Show("File is already exists in " + inputFilePath + " please enter another name.");
                        txtMergeFileName.Text = string.Empty;
                        textboxs.Clear();
                        txtMergeFileName.Focus();

                    }
                    
                    else
                    {
                        //Calling & Passing parameter to function.
                        var result = sumFunction(textboxs, inputFilePath);
                        lblStatus.Text = result;
                        MessageBox.Show("Sucessfuly merge" + txtFirstFile.Text + " and" + txtSecondFile.Text + " and" + txtListFile.Text + " files.");
                    }

                    Cursor = Cursors.Arrow;
                }

                //Merging first , second and thrid pdf files.
                if ((txtFirstFile.Text != "") &&
                    (txtSecondFile.Text != "") &&
                    (txtListFile.Text != ""))
                {
                    //Calling mergePdfFileCommonFun maethod.
                    mergePdfFileCommonFun(txtFirstFile, txtSecondFile, txtListFile);
                    
                }

                //Merging first pdf & second pdf files.
                else if ((txtFirstFile.Text != "") &&
                    (txtSecondFile.Text != "") &&
                    (txtListFile.Text == ""))
                {
                    //Calling mergePdfFileCommonFun maethod.
                    mergePdfFileCommonFun(txtFirstFile, txtSecondFile, txtListFile);

                }

            }

            else
            {

                MessageBox.Show("Enter minimum two files.");
                textboxs.Clear();
                txtFirstFile.Focus();

            }

        }

        /// <summary>
        /// Reset all pdf files name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetAllPdfFilesName_Click(object sender, EventArgs e)
        {

            txtFirstFile.Text = string.Empty;
            txtSecondFile.Text = string.Empty;
            txtListFile.Items.Clear();
            txtMergeFileName.Text = string.Empty;
            textboxs.Clear();
            txtFirstFile.Focus();

        }

        /// <summary>
        /// Preview merge pdf file Path & content.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previewMergedFile_Click(object sender, EventArgs e)
        {
            
            Cursor = Cursors.WaitCursor;

            var directory = @"C:/Users/User/Documents/";
            if (txtMergeFileName.Text != "")
            {

                string filePath = directory + txtMergeFileName.Text + ".pdf";
                System.Diagnostics.Process.Start(filePath);
                MessageBox.Show("Merged file path is " + filePath);

            }

            else
            {
                MessageBox.Show("Select pdf files to merge pdf and give merge file name.");
                textboxs.Clear();
            }
            Cursor = Cursors.Arrow;

        }
 
    }
};