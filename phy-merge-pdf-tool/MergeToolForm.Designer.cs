﻿using System;

namespace phy_merge_pdf_tool
{
    partial class MergeToolForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFirstFile = new System.Windows.Forms.TextBox();
            this.txtSecondFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtListFile = new System.Windows.Forms.ListBox();
            this.browseSecondFile = new System.Windows.Forms.Button();
            this.browseFirstFile = new System.Windows.Forms.Button();
            this.txtMergeFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.mergePdfFiles = new System.Windows.Forms.Button();
            this.resetAllPdfFilesName = new System.Windows.Forms.Button();
            this.previewMergedFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFirstFile
            // 
            this.txtFirstFile.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtFirstFile.Location = new System.Drawing.Point(46, 63);
            this.txtFirstFile.Name = "txtFirstFile";
            this.txtFirstFile.Size = new System.Drawing.Size(506, 26);
            this.txtFirstFile.TabIndex = 6;
            // 
            // txtSecondFile
            // 
            this.txtSecondFile.Location = new System.Drawing.Point(46, 128);
            this.txtSecondFile.Name = "txtSecondFile";
            this.txtSecondFile.Size = new System.Drawing.Size(506, 26);
            this.txtSecondFile.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Merge Files Tool";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Select first pdf file(Mandatory)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Select second pdf file(Mandatory)";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Select third pdf file(Optional)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtListFile);
            this.groupBox1.Controls.Add(this.browseSecondFile);
            this.groupBox1.Controls.Add(this.browseFirstFile);
            this.groupBox1.Controls.Add(this.txtMergeFileName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFirstFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSecondFile);
            this.groupBox1.Location = new System.Drawing.Point(16, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 351);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Browse files to merge";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.Location = new System.Drawing.Point(593, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 36);
            this.button1.TabIndex = 24;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.browseMultipleFiles_Click);
            // 
            // txtListFile
            // 
            this.txtListFile.FormattingEnabled = true;
            this.txtListFile.ItemHeight = 20;
            this.txtListFile.Location = new System.Drawing.Point(46, 197);
            this.txtListFile.Name = "txtListFile";
            this.txtListFile.Size = new System.Drawing.Size(506, 64);
            this.txtListFile.TabIndex = 23;
            // 
            // browseSecondFile
            // 
            this.browseSecondFile.BackColor = System.Drawing.SystemColors.ControlDark;
            this.browseSecondFile.Location = new System.Drawing.Point(593, 123);
            this.browseSecondFile.Name = "browseSecondFile";
            this.browseSecondFile.Size = new System.Drawing.Size(129, 36);
            this.browseSecondFile.TabIndex = 21;
            this.browseSecondFile.Text = "Browse";
            this.browseSecondFile.UseVisualStyleBackColor = false;
            this.browseSecondFile.Click += new System.EventHandler(this.browseSecondFile_Click);
            // 
            // browseFirstFile
            // 
            this.browseFirstFile.BackColor = System.Drawing.SystemColors.ControlDark;
            this.browseFirstFile.Location = new System.Drawing.Point(593, 63);
            this.browseFirstFile.Name = "browseFirstFile";
            this.browseFirstFile.Size = new System.Drawing.Size(129, 36);
            this.browseFirstFile.TabIndex = 20;
            this.browseFirstFile.Text = "Browse";
            this.browseFirstFile.UseVisualStyleBackColor = false;
            this.browseFirstFile.Click += new System.EventHandler(this.browseFirstFile_Click);
            // 
            // txtMergeFileName
            // 
            this.txtMergeFileName.Location = new System.Drawing.Point(46, 299);
            this.txtMergeFileName.Name = "txtMergeFileName";
            this.txtMergeFileName.Size = new System.Drawing.Size(506, 26);
            this.txtMergeFileName.TabIndex = 19;
            this.txtMergeFileName.TextChanged += new System.EventHandler(this.txtmergefilename_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Merged file name(Mandatory)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(68, 377);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            this.lblStatus.TabIndex = 17;
            // 
            // mergePdfFiles
            // 
            this.mergePdfFiles.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mergePdfFiles.Location = new System.Drawing.Point(643, 450);
            this.mergePdfFiles.Name = "mergePdfFiles";
            this.mergePdfFiles.Size = new System.Drawing.Size(135, 51);
            this.mergePdfFiles.TabIndex = 21;
            this.mergePdfFiles.Text = "Merge pdf files";
            this.mergePdfFiles.UseVisualStyleBackColor = false;
            this.mergePdfFiles.Click += new System.EventHandler(this.mergePdfFiles_Click);
            // 
            // resetAllPdfFilesName
            // 
            this.resetAllPdfFilesName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.resetAllPdfFilesName.Location = new System.Drawing.Point(18, 450);
            this.resetAllPdfFilesName.Name = "resetAllPdfFilesName";
            this.resetAllPdfFilesName.Size = new System.Drawing.Size(153, 51);
            this.resetAllPdfFilesName.TabIndex = 22;
            this.resetAllPdfFilesName.Text = "Reset";
            this.resetAllPdfFilesName.UseVisualStyleBackColor = false;
            this.resetAllPdfFilesName.Click += new System.EventHandler(this.resetAllPdfFilesName_Click);
            // 
            // previewMergedFile
            // 
            this.previewMergedFile.BackColor = System.Drawing.SystemColors.ControlDark;
            this.previewMergedFile.Location = new System.Drawing.Point(322, 449);
            this.previewMergedFile.Name = "previewMergedFile";
            this.previewMergedFile.Size = new System.Drawing.Size(168, 52);
            this.previewMergedFile.TabIndex = 23;
            this.previewMergedFile.Text = "Preview merged file";
            this.previewMergedFile.UseVisualStyleBackColor = false;
            this.previewMergedFile.Click += new System.EventHandler(this.previewMergedFile_Click);
            // 
            // MergeToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 522);
            this.Controls.Add(this.previewMergedFile);
            this.Controls.Add(this.resetAllPdfFilesName);
            this.Controls.Add(this.mergePdfFiles);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MergeToolForm";
            this.Text = "phyelements pdf merge tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.TextBox txtFirstFile;
        private System.Windows.Forms.TextBox txtSecondFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMergeFileName;
        private System.Windows.Forms.Button browseFirstFile;
        private System.Windows.Forms.Button browseSecondFile;
        private System.Windows.Forms.Button mergePdfFiles;
        private System.Windows.Forms.Button resetAllPdfFilesName;
        private System.Windows.Forms.Button previewMergedFile;
        private System.Windows.Forms.ListBox txtListFile;
        private System.Windows.Forms.Button button1;
    }
}

