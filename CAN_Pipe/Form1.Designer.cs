namespace CAN_Pipe
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
            this.lblSelectCOMPort = new System.Windows.Forms.Label();
            this.cmbSerialPorts = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblNameOfPipe = new System.Windows.Forms.Label();
            this.tbPipeName = new System.Windows.Forms.TextBox();
            this.btnStartSniff = new System.Windows.Forms.Button();
            this.btnStopSniff = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStopReplay = new System.Windows.Forms.Button();
            this.btnStartReplay = new System.Windows.Forms.Button();
            this.lblSelectedFileName = new System.Windows.Forms.Label();
            this.btnBrowseForCSV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCANSnifferUpload = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbListOnlyArduino = new System.Windows.Forms.CheckBox();
            this.btnCANSenderUpload = new System.Windows.Forms.Button();
            this.ofdFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelectCOMPort
            // 
            this.lblSelectCOMPort.AutoSize = true;
            this.lblSelectCOMPort.Location = new System.Drawing.Point(5, 20);
            this.lblSelectCOMPort.Name = "lblSelectCOMPort";
            this.lblSelectCOMPort.Size = new System.Drawing.Size(127, 13);
            this.lblSelectCOMPort.TabIndex = 0;
            this.lblSelectCOMPort.Text = "Select Arduino COM port:";
            // 
            // cmbSerialPorts
            // 
            this.cmbSerialPorts.FormattingEnabled = true;
            this.cmbSerialPorts.Location = new System.Drawing.Point(132, 17);
            this.cmbSerialPorts.Name = "cmbSerialPorts";
            this.cmbSerialPorts.Size = new System.Drawing.Size(148, 21);
            this.cmbSerialPorts.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(286, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(26, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblNameOfPipe
            // 
            this.lblNameOfPipe.AutoSize = true;
            this.lblNameOfPipe.Location = new System.Drawing.Point(11, 22);
            this.lblNameOfPipe.Name = "lblNameOfPipe";
            this.lblNameOfPipe.Size = new System.Drawing.Size(136, 13);
            this.lblNameOfPipe.TabIndex = 3;
            this.lblNameOfPipe.Text = "Name your pipe:  \\\\?\\pipe\\";
            // 
            // tbPipeName
            // 
            this.tbPipeName.Location = new System.Drawing.Point(144, 19);
            this.tbPipeName.Name = "tbPipeName";
            this.tbPipeName.Size = new System.Drawing.Size(112, 20);
            this.tbPipeName.TabIndex = 4;
            this.tbPipeName.Text = "canpipe1";
            // 
            // btnStartSniff
            // 
            this.btnStartSniff.Location = new System.Drawing.Point(14, 45);
            this.btnStartSniff.Name = "btnStartSniff";
            this.btnStartSniff.Size = new System.Drawing.Size(75, 23);
            this.btnStartSniff.TabIndex = 5;
            this.btnStartSniff.Text = "Start pipe";
            this.btnStartSniff.UseVisualStyleBackColor = true;
            this.btnStartSniff.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStopSniff
            // 
            this.btnStopSniff.Enabled = false;
            this.btnStopSniff.Location = new System.Drawing.Point(95, 45);
            this.btnStopSniff.Name = "btnStopSniff";
            this.btnStopSniff.Size = new System.Drawing.Size(75, 23);
            this.btnStopSniff.TabIndex = 6;
            this.btnStopSniff.Text = "Stop pipe";
            this.btnStopSniff.UseVisualStyleBackColor = true;
            this.btnStopSniff.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CAN_Pipe.Properties.Resources.jesse2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(267, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 53);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.clickOnJesse);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPipeName);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnStopSniff);
            this.groupBox1.Controls.Add(this.btnStartSniff);
            this.groupBox1.Controls.Add(this.lblNameOfPipe);
            this.groupBox1.Location = new System.Drawing.Point(12, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 82);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sniffing";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStopReplay);
            this.groupBox2.Controls.Add(this.btnStartReplay);
            this.groupBox2.Controls.Add(this.lblSelectedFileName);
            this.groupBox2.Controls.Add(this.btnBrowseForCSV);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 94);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replay";
            // 
            // btnStopReplay
            // 
            this.btnStopReplay.Enabled = false;
            this.btnStopReplay.Location = new System.Drawing.Point(95, 65);
            this.btnStopReplay.Name = "btnStopReplay";
            this.btnStopReplay.Size = new System.Drawing.Size(75, 23);
            this.btnStopReplay.TabIndex = 4;
            this.btnStopReplay.Text = "Stop replay";
            this.btnStopReplay.UseVisualStyleBackColor = true;
            this.btnStopReplay.Click += new System.EventHandler(this.btnStopReplay_Click);
            // 
            // btnStartReplay
            // 
            this.btnStartReplay.Location = new System.Drawing.Point(14, 65);
            this.btnStartReplay.Name = "btnStartReplay";
            this.btnStartReplay.Size = new System.Drawing.Size(75, 23);
            this.btnStartReplay.TabIndex = 3;
            this.btnStartReplay.Text = "Start replay";
            this.btnStartReplay.UseVisualStyleBackColor = true;
            this.btnStartReplay.Click += new System.EventHandler(this.btnStartReplay_Click);
            // 
            // lblSelectedFileName
            // 
            this.lblSelectedFileName.AutoSize = true;
            this.lblSelectedFileName.Location = new System.Drawing.Point(12, 44);
            this.lblSelectedFileName.Name = "lblSelectedFileName";
            this.lblSelectedFileName.Size = new System.Drawing.Size(68, 13);
            this.lblSelectedFileName.TabIndex = 2;
            this.lblSelectedFileName.Text = "Selected file:";
            // 
            // btnBrowseForCSV
            // 
            this.btnBrowseForCSV.Location = new System.Drawing.Point(87, 15);
            this.btnBrowseForCSV.Name = "btnBrowseForCSV";
            this.btnBrowseForCSV.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseForCSV.TabIndex = 1;
            this.btnBrowseForCSV.Text = "Browse...";
            this.btnBrowseForCSV.UseVisualStyleBackColor = true;
            this.btnBrowseForCSV.Click += new System.EventHandler(this.btnBrowseForCSV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose CSV";
            // 
            // btnCANSnifferUpload
            // 
            this.btnCANSnifferUpload.Location = new System.Drawing.Point(8, 67);
            this.btnCANSnifferUpload.Name = "btnCANSnifferUpload";
            this.btnCANSnifferUpload.Size = new System.Drawing.Size(204, 21);
            this.btnCANSnifferUpload.TabIndex = 10;
            this.btnCANSnifferUpload.Text = "Upload CAN Sniffer to Arduino";
            this.btnCANSnifferUpload.UseVisualStyleBackColor = true;
            this.btnCANSnifferUpload.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbListOnlyArduino);
            this.groupBox3.Controls.Add(this.btnCANSenderUpload);
            this.groupBox3.Controls.Add(this.cmbSerialPorts);
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.btnCANSnifferUpload);
            this.groupBox3.Controls.Add(this.lblSelectCOMPort);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 130);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set up everything here first";
            // 
            // cbListOnlyArduino
            // 
            this.cbListOnlyArduino.AutoSize = true;
            this.cbListOnlyArduino.Location = new System.Drawing.Point(8, 44);
            this.cbListOnlyArduino.Name = "cbListOnlyArduino";
            this.cbListOnlyArduino.Size = new System.Drawing.Size(156, 17);
            this.cbListOnlyArduino.TabIndex = 13;
            this.cbListOnlyArduino.Text = "List only Arduino COM ports";
            this.cbListOnlyArduino.UseVisualStyleBackColor = true;
            this.cbListOnlyArduino.CheckedChanged += new System.EventHandler(this.button1_Click);
            // 
            // btnCANSenderUpload
            // 
            this.btnCANSenderUpload.Location = new System.Drawing.Point(8, 94);
            this.btnCANSenderUpload.Name = "btnCANSenderUpload";
            this.btnCANSenderUpload.Size = new System.Drawing.Size(204, 21);
            this.btnCANSenderUpload.TabIndex = 11;
            this.btnCANSenderUpload.Text = "Upload CAN Sender to Arduino";
            this.btnCANSenderUpload.UseVisualStyleBackColor = true;
            this.btnCANSenderUpload.Click += new System.EventHandler(this.btnCANSenderUpload_Click);
            // 
            // ofdFileDialog
            // 
            this.ofdFileDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 343);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Arduino CAN bus tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSelectCOMPort;
        private System.Windows.Forms.ComboBox cmbSerialPorts;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblNameOfPipe;
        private System.Windows.Forms.TextBox tbPipeName;
        private System.Windows.Forms.Button btnStartSniff;
        private System.Windows.Forms.Button btnStopSniff;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCANSnifferUpload;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCANSenderUpload;
        private System.Windows.Forms.Label lblSelectedFileName;
        private System.Windows.Forms.Button btnBrowseForCSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdFileDialog;
        private System.Windows.Forms.Button btnStopReplay;
        private System.Windows.Forms.Button btnStartReplay;
        private System.Windows.Forms.CheckBox cbListOnlyArduino;
    }
}

