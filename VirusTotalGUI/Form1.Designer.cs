namespace VirusTotalGUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileLocator = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.scanButton = new System.Windows.Forms.Button();
            this.scannedFileListView = new System.Windows.Forms.ListView();
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateOfScan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkSum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileLocator
            // 
            this.fileLocator.BackColor = System.Drawing.SystemColors.Window;
            this.fileLocator.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.fileLocator.Location = new System.Drawing.Point(74, 56);
            this.fileLocator.MaximumSize = new System.Drawing.Size(397, 40);
            this.fileLocator.MinimumSize = new System.Drawing.Size(397, 40);
            this.fileLocator.Name = "fileLocator";
            this.fileLocator.Size = new System.Drawing.Size(397, 26);
            this.fileLocator.TabIndex = 6;
            this.fileLocator.DoubleClick += new System.EventHandler(this.FileLocator_DoubleClick);
            this.fileLocator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileLocator_KeyDown);
            this.fileLocator.Leave += new System.EventHandler(this.FileLocator_Leave);
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.Color.BlueViolet;
            this.browseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.browseButton.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.browseButton.Location = new System.Drawing.Point(499, 56);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(120, 39);
            this.browseButton.TabIndex = 7;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // scanButton
            // 
            this.scanButton.BackColor = System.Drawing.Color.BlueViolet;
            this.scanButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.scanButton.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.scanButton.Location = new System.Drawing.Point(625, 58);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(100, 38);
            this.scanButton.TabIndex = 8;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = false;
            this.scanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // scannedFileListView
            // 
            this.scannedFileListView.BackColor = System.Drawing.SystemColors.Window;
            this.scannedFileListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scannedFileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName,
            this.dateOfScan,
            this.checkSum,
            this.Result});
            this.scannedFileListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.scannedFileListView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scannedFileListView.ForeColor = System.Drawing.SystemColors.InfoText;
            this.scannedFileListView.FullRowSelect = true;
            this.scannedFileListView.GridLines = true;
            this.scannedFileListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.scannedFileListView.Location = new System.Drawing.Point(12, 122);
            this.scannedFileListView.Name = "scannedFileListView";
            this.scannedFileListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scannedFileListView.Size = new System.Drawing.Size(804, 340);
            this.scannedFileListView.TabIndex = 9;
            this.scannedFileListView.TileSize = new System.Drawing.Size(10, 10);
            this.scannedFileListView.UseCompatibleStateImageBehavior = false;
            this.scannedFileListView.View = System.Windows.Forms.View.Details;
            // 
            // fileName
            // 
            this.fileName.Text = "FileName";
            this.fileName.Width = 167;
            // 
            // dateOfScan
            // 
            this.dateOfScan.Text = "Date of Scan";
            this.dateOfScan.Width = 112;
            // 
            // Result
            // 
            this.Result.Text = "Results";
            this.Result.Width = 475;
            // 
            // checkSum
            // 
            this.checkSum.Text = "checksum";
            this.checkSum.Width = 161;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 474);
            this.Controls.Add(this.scannedFileListView);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.fileLocator);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Virus Scanner";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox fileLocator;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.ListView scannedFileListView;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader dateOfScan;
        private System.Windows.Forms.ColumnHeader Result;
        private System.Windows.Forms.ColumnHeader checkSum;
    }
}

