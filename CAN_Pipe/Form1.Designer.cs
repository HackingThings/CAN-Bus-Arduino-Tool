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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelectCOMPort
            // 
            this.lblSelectCOMPort.AutoSize = true;
            this.lblSelectCOMPort.Location = new System.Drawing.Point(12, 13);
            this.lblSelectCOMPort.Name = "lblSelectCOMPort";
            this.lblSelectCOMPort.Size = new System.Drawing.Size(127, 13);
            this.lblSelectCOMPort.TabIndex = 0;
            this.lblSelectCOMPort.Text = "Select Arduino COM port:";
            // 
            // cmbSerialPorts
            // 
            this.cmbSerialPorts.FormattingEnabled = true;
            this.cmbSerialPorts.Location = new System.Drawing.Point(145, 10);
            this.cmbSerialPorts.Name = "cmbSerialPorts";
            this.cmbSerialPorts.Size = new System.Drawing.Size(80, 21);
            this.cmbSerialPorts.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(231, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Reload";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblNameOfPipe
            // 
            this.lblNameOfPipe.AutoSize = true;
            this.lblNameOfPipe.Location = new System.Drawing.Point(12, 40);
            this.lblNameOfPipe.Name = "lblNameOfPipe";
            this.lblNameOfPipe.Size = new System.Drawing.Size(136, 13);
            this.lblNameOfPipe.TabIndex = 3;
            this.lblNameOfPipe.Text = "Name your pipe:  \\\\?\\pipe\\";
            // 
            // tbPipeName
            // 
            this.tbPipeName.Location = new System.Drawing.Point(145, 37);
            this.tbPipeName.Name = "tbPipeName";
            this.tbPipeName.Size = new System.Drawing.Size(112, 20);
            this.tbPipeName.TabIndex = 4;
            this.tbPipeName.Text = "canpipe1";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 67);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start pipe";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(96, 67);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop pipe";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CAN_Pipe.Properties.Resources.jesse2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(263, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 53);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.clickOnJesse);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 98);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbPipeName);
            this.Controls.Add(this.lblNameOfPipe);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbSerialPorts);
            this.Controls.Add(this.lblSelectCOMPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Wireshark CAN pipe tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectCOMPort;
        private System.Windows.Forms.ComboBox cmbSerialPorts;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblNameOfPipe;
        private System.Windows.Forms.TextBox tbPipeName;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

