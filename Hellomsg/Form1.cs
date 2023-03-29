﻿
using IronPython.Hosting;
using javax.script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ceTe.DynamicPDF.Merger;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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

            //textboxs = new List<string>
            //{
            //    txtFirstFile.Text, txtSecondFile.Text,txtThirdFile.Text
            //};

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
                    MessageBox.Show("Sucessfuly merge 3 pdf files.");
                    MergeDocument document = new MergeDocument(txtFirstFile.Text);
                    document.Append(txtSecondFile.Text);
                    document.Append(txtThirdFile.Text);
                    document.Draw("C://Users//User//Documents//Anuoutput2.pdf");
                }
                if ((textboxs.ElementAt(0).Length == 0 && 
                    textboxs.ElementAt(1).Length != 0 && 
                    textboxs.ElementAt(2).Length != 0))
                {
                    MessageBox.Show("Sucessfuly merge 3 pdf files.");
                    MergeDocument document = new MergeDocument(txtSecondFile.Text);;
                    document.Append(txtThirdFile.Text);
                    document.Draw("C://Users//User//Documents//Anuoutput2.pdf");
                }
                if ((textboxs.ElementAt(0).Length != 0 && 
                    textboxs.ElementAt(1).Length == 0 && 
                    textboxs.ElementAt(2).Length != 0))
                {
                    MessageBox.Show("Sucessfuly merge 3 pdf files.");
                    MergeDocument document = new MergeDocument(txtFirstFile.Text); ;
                    document.Append(txtThirdFile.Text);
                    document.Draw("C://Users//User//Documents//Anuoutput2.pdf");
                }
                if ((textboxs.ElementAt(0).Length != 0 && 
                    textboxs.ElementAt(1).Length != 0 && 
                    textboxs.ElementAt(2).Length == 0))
                {
                    MessageBox.Show("Sucessfuly merge 3 pdf files.");
                    MergeDocument document = new MergeDocument(txtFirstFile.Text); ;
                    document.Append(txtSecondFile.Text);
                    document.Draw("C://Users//User//Documents//Anuoutput2.pdf");
                }

                else
                {
                    MessageBox.Show("Select minimum two pdf files");
                }


            }
            

            
        }

    }
}
;