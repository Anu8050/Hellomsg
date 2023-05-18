using System;

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
            this.txtThirdFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.previewMergedFile = new System.Windows.Forms.Button();
            this.browseThridFile = new System.Windows.Forms.Button();
            this.resetAllPdfFilesName = new System.Windows.Forms.Button();
            this.browseSecondFile = new System.Windows.Forms.Button();
            this.mergePdfFiles = new System.Windows.Forms.Button();
            this.browseFirstFile = new System.Windows.Forms.Button();
            this.txtMergeFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFirstFile
            // 
            this.txtFirstFile.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtFirstFile.Location = new System.Drawing.Point(53, 55);
            this.txtFirstFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtFirstFile.Name = "txtFirstFile";
            this.txtFirstFile.Size = new System.Drawing.Size(338, 20);
            this.txtFirstFile.TabIndex = 6;
            // 
            // txtSecondFile
            // 
            this.txtSecondFile.Location = new System.Drawing.Point(52, 104);
            this.txtSecondFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtSecondFile.Name = "txtSecondFile";
            this.txtSecondFile.Size = new System.Drawing.Size(338, 20);
            this.txtSecondFile.TabIndex = 8;
            // 
            // txtThirdFile
            // 
            this.txtThirdFile.Location = new System.Drawing.Point(52, 145);
            this.txtThirdFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtThirdFile.Name = "txtThirdFile";
            this.txtThirdFile.Size = new System.Drawing.Size(338, 20);
            this.txtThirdFile.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Select first pdf file(Mandatory)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Select second pdf file(Mandatory)";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Select third pdf file(Optional)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblProgressStatus);
            this.groupBox1.Controls.Add(this.previewMergedFile);
            this.groupBox1.Controls.Add(this.browseThridFile);
            this.groupBox1.Controls.Add(this.resetAllPdfFilesName);
            this.groupBox1.Controls.Add(this.browseSecondFile);
            this.groupBox1.Controls.Add(this.mergePdfFiles);
            this.groupBox1.Controls.Add(this.browseFirstFile);
            this.groupBox1.Controls.Add(this.txtMergeFileName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFirstFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSecondFile);
            this.groupBox1.Controls.Add(this.txtThirdFile);
            this.groupBox1.Location = new System.Drawing.Point(24, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(589, 321);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Browse files to merge";
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.AutoSize = true;
            this.lblProgressStatus.Location = new System.Drawing.Point(441, 259);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(69, 13);
            this.lblProgressStatus.TabIndex = 24;
            this.lblProgressStatus.Text = "In Progress...";
            // 
            // previewMergedFile
            // 
            this.previewMergedFile.BackColor = System.Drawing.SystemColors.ControlDark;
            this.previewMergedFile.Location = new System.Drawing.Point(419, 282);
            this.previewMergedFile.Margin = new System.Windows.Forms.Padding(2);
            this.previewMergedFile.Name = "previewMergedFile";
            this.previewMergedFile.Size = new System.Drawing.Size(91, 32);
            this.previewMergedFile.TabIndex = 23;
            this.previewMergedFile.Text = "Preview";
            this.previewMergedFile.UseVisualStyleBackColor = false;
            this.previewMergedFile.Click += new System.EventHandler(this.previewMergedFile_Click);
            // 
            // browseThridFile
            // 
            this.browseThridFile.BackColor = System.Drawing.SystemColors.ControlDark;
            this.browseThridFile.Location = new System.Drawing.Point(416, 143);
            this.browseThridFile.Margin = new System.Windows.Forms.Padding(2);
            this.browseThridFile.Name = "browseThridFile";
            this.browseThridFile.Size = new System.Drawing.Size(86, 24);
            this.browseThridFile.TabIndex = 22;
            this.browseThridFile.Text = "Browse";
            this.browseThridFile.UseVisualStyleBackColor = false;
            this.browseThridFile.Click += new System.EventHandler(this.browseThridFile_Click);
            // 
            // resetAllPdfFilesName
            // 
            this.resetAllPdfFilesName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.resetAllPdfFilesName.Location = new System.Drawing.Point(302, 224);
            this.resetAllPdfFilesName.Margin = new System.Windows.Forms.Padding(2);
            this.resetAllPdfFilesName.Name = "resetAllPdfFilesName";
            this.resetAllPdfFilesName.Size = new System.Drawing.Size(102, 33);
            this.resetAllPdfFilesName.TabIndex = 22;
            this.resetAllPdfFilesName.Text = "Reset";
            this.resetAllPdfFilesName.UseVisualStyleBackColor = false;
            this.resetAllPdfFilesName.Click += new System.EventHandler(this.resetAllPdfFilesName_Click);
            // 
            // browseSecondFile
            // 
            this.browseSecondFile.BackColor = System.Drawing.SystemColors.ControlDark;
            this.browseSecondFile.Location = new System.Drawing.Point(416, 101);
            this.browseSecondFile.Margin = new System.Windows.Forms.Padding(2);
            this.browseSecondFile.Name = "browseSecondFile";
            this.browseSecondFile.Size = new System.Drawing.Size(86, 24);
            this.browseSecondFile.TabIndex = 21;
            this.browseSecondFile.Text = "Browse";
            this.browseSecondFile.UseVisualStyleBackColor = false;
            this.browseSecondFile.Click += new System.EventHandler(this.browseSecondFile_Click);
            // 
            // mergePdfFiles
            // 
            this.mergePdfFiles.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mergePdfFiles.Location = new System.Drawing.Point(419, 224);
            this.mergePdfFiles.Margin = new System.Windows.Forms.Padding(2);
            this.mergePdfFiles.Name = "mergePdfFiles";
            this.mergePdfFiles.Size = new System.Drawing.Size(90, 33);
            this.mergePdfFiles.TabIndex = 21;
            this.mergePdfFiles.Text = "Merge pdf files";
            this.mergePdfFiles.UseVisualStyleBackColor = false;
            this.mergePdfFiles.Click += new System.EventHandler(this.mergePdfFiles_Click);
            // 
            // browseFirstFile
            // 
            this.browseFirstFile.BackColor = System.Drawing.SystemColors.ControlDark;
            this.browseFirstFile.Location = new System.Drawing.Point(416, 54);
            this.browseFirstFile.Margin = new System.Windows.Forms.Padding(2);
            this.browseFirstFile.Name = "browseFirstFile";
            this.browseFirstFile.Size = new System.Drawing.Size(86, 24);
            this.browseFirstFile.TabIndex = 20;
            this.browseFirstFile.Text = "Browse";
            this.browseFirstFile.UseVisualStyleBackColor = false;
            this.browseFirstFile.Click += new System.EventHandler(this.browseFirstFile_Click);
            // 
            // txtMergeFileName
            // 
            this.txtMergeFileName.Location = new System.Drawing.Point(52, 182);
            this.txtMergeFileName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMergeFileName.Name = "txtMergeFileName";
            this.txtMergeFileName.Size = new System.Drawing.Size(338, 20);
            this.txtMergeFileName.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 167);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Merged file name(Mandatory)";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(45, 245);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Crimson;
            this.label6.Location = new System.Drawing.Point(194, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Crimson;
            this.label7.Location = new System.Drawing.Point(223, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "*";
            // 
            // MergeToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 340);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MergeToolForm";
            this.Text = "Phyelements Merge PDF Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        

        #endregion
        private System.Windows.Forms.TextBox txtFirstFile;
        private System.Windows.Forms.TextBox txtSecondFile;
        private System.Windows.Forms.TextBox txtThirdFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMergeFileName;
        private System.Windows.Forms.Button browseFirstFile;
        private System.Windows.Forms.Button browseThridFile;
        private System.Windows.Forms.Button browseSecondFile;
        private System.Windows.Forms.Button mergePdfFiles;
        private System.Windows.Forms.Button resetAllPdfFilesName;
        private System.Windows.Forms.Button previewMergedFile;
        private System.Windows.Forms.Label lblProgressStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

