/**************************************************************************
*                           MIT License
* 
* Copyright (C) 2015 Frederic Chaxel <fchaxel@free.fr>
*
* Permission is hereby granted, free of charge, to any person obtaining
* a copy of this software and associated documentation files (the
* "Software"), to deal in the Software without restriction, including
* without limitation the rights to use, copy, modify, merge, publish,
* distribute, sublicense, and/or sell copies of the Software, and to
* permit persons to whom the Software is furnished to do so, subject to
* the following conditions:
*
* The above copyright notice and this permission notice shall be included
* in all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
* IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
* CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
* TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
* SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*
*********************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Management;
using Wireshark;
using System.IO;

namespace CAN_Pipe
{
    public partial class Form1 : Form

    {
        Thread th;
        SerialPort port;
        WiresharkSender ws;
        string[] data;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
            ofdFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            ofdFileDialog.FileName = ofdFileDialog.InitialDirectory + "\\CSV\\example.csv";
        }

        private void clickOnJesse(object sender, EventArgs e)
        {
            Clipboard.SetText(@"\\?\pipe\" + tbPipeName.Text);
        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbSerialPorts.DataSource = null;
            cmbSerialPorts.Items.Clear();
            ManagementObjectCollection ManObjReturn;
            ManagementObjectSearcher ManObjSearch;
            ManObjSearch = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'");
            ManObjReturn = ManObjSearch.Get();
            //this will show only arduino serial ports
            foreach (ManagementObject ManObj in ManObjReturn)
            {
                if (cbListOnlyArduino.Checked)
                {
                    if (!cmbSerialPorts.Items.Contains(ManObj["Name"].ToString()) && (ManObj["Name"].ToString().Contains("Arduino")))
                    {
                        String temp = ManObj["Name"].ToString();
                        temp = temp.Remove(0, temp.IndexOf("(")+1);
                        temp = temp.Remove(temp.IndexOf(")"), temp.Length - temp.IndexOf(")"));
                        cmbSerialPorts.Items.Add(temp);
                    }
                }
                else
                {
                    if (!cmbSerialPorts.Items.Contains(ManObj["Name"].ToString()))
                    {
                        String temp = ManObj["Name"].ToString();
                        temp = temp.Remove(0, temp.IndexOf("(")+1);
                        temp = temp.Remove(temp.IndexOf(")"), temp.Length- temp.IndexOf(")") );
                        cmbSerialPorts.Items.Add(temp);
                    }
                }
            }
            if (cmbSerialPorts.Items.Count != 0) cmbSerialPorts.SelectedIndex = 0;

           
        }
        

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStartSniff.Enabled = false;
            btnStopSniff.Enabled = true;
            th = new Thread(startSniffing);
            th.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStartSniff.Enabled = true;
            btnStopSniff.Enabled = false;
            ws.WiresharkPipe.Close();
            th.Abort();
            if (port.IsOpen) port.Close();
            port.Dispose();
        }

        private void startSniffing()
        {
            string text = "";
            this.Invoke((MethodInvoker)delegate ()
            {
                text = cmbSerialPorts.SelectedItem.ToString();
            });
            port = new SerialPort(text, 115200);
            bgw_DoSniffing();

        }
        private void bgw_DoSniffing()
        {
            try
            {
               port.Open();
            ws = new Wireshark.WiresharkSender(tbPipeName.Text, 227);  
            while (true)
                {
                if (ws.isConnected)
                {
                    try
                    {
                        string line = port.ReadLine();
                        line = line.Replace("\r", string.Empty);
                        string[] lines = line.Split('|');
                        Int32 canid = Convert.ToInt32(lines[0]);
                        byte[] id = new byte[4];
                        id = BitConverter.GetBytes(canid);
                        lines = lines[1].Split(' ');
                        byte[] data = new byte[lines.Length - 1]; 
                        for (int i = 0; i < data.Length; i++)
                        {
                            if (lines[i] != "")
                            {
                                data[i] = Convert.ToByte(lines[i]);
                            }
                        }
                        byte[] pcap = new byte[4 + 4 + data.Length];
                        pcap[0] = id[3];
                        pcap[1] = id[2];
                        pcap[2] = id[1];
                        pcap[3] = id[0];
                        pcap[4] = Convert.ToByte(data.Length);
                        pcap[5] = 0;
                        pcap[6] = 0;
                        pcap[7] = 0;
                        for (int i = 8; i < pcap.Length; i++)
                        {
                            pcap[i] = data[i - 8];
                        }
                        ws.SendToWireshark(pcap, 0, pcap.Length);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void btnCANSnifferUpload_Click_Click(object sender, EventArgs e)
        {
            try
            {
                ArduinoUploader.ArduinoSketchUploaderOptions options = new ArduinoUploader.ArduinoSketchUploaderOptions();
                options.ArduinoModel = ArduinoUploader.Hardware.ArduinoModel.UnoR3;
                options.PortName = cmbSerialPorts.SelectedItem.ToString();
                options.PortName = options.PortName.Substring(options.PortName.IndexOf("COM"), options.PortName.Length-options.PortName.LastIndexOf(")")+4);
                options.FileName = Directory.GetCurrentDirectory() + "\\sniffer\\sniffer.ino.standard.hex";
                ArduinoUploader.ArduinoSketchUploader up = new ArduinoUploader.ArduinoSketchUploader(options);
                up.UploadSketch();
                MessageBox.Show("Upload complete without errors");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw;
            }
}

        private void btnCANSenderUpload_Click(object sender, EventArgs e)
        {
            try
            {
                ArduinoUploader.ArduinoSketchUploaderOptions options = new ArduinoUploader.ArduinoSketchUploaderOptions();
                options.ArduinoModel = ArduinoUploader.Hardware.ArduinoModel.UnoR3;
                options.PortName = cmbSerialPorts.SelectedItem.ToString();
                options.PortName = options.PortName.Substring(options.PortName.IndexOf("COM"), options.PortName.Length - options.PortName.LastIndexOf(")") + 4);
                options.FileName = Directory.GetCurrentDirectory() + "\\sender\\sender.ino.standard.hex";
                ArduinoUploader.ArduinoSketchUploader up = new ArduinoUploader.ArduinoSketchUploader(options);
                up.UploadSketch();
                MessageBox.Show("Upload complete without errors");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw;
            }
        }

        private void btnBrowseForCSV_Click(object sender, EventArgs e)
        {
            ofdFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            ofdFileDialog.FileName = ofdFileDialog.InitialDirectory + "\\CSV\\example.csv";
            ofdFileDialog.ShowDialog();
            lblSelectedFileName.Text = lblSelectedFileName.Text+" "+ofdFileDialog.SafeFileName;
        }

        private void btnStartReplay_Click(object sender, EventArgs e)
        {
            btnStartReplay.Enabled = false;
            btnStopReplay.Enabled = true;
            data = File.ReadAllLines(ofdFileDialog.FileName);
            th = new Thread(startReplay);
            th.Start();
        }

        private void startReplay()
        {
            string text = "";
            this.Invoke((MethodInvoker)delegate ()
            {
                text = cmbSerialPorts.SelectedItem.ToString();
            });
            port = new SerialPort(text, 115200);
            bgw_DoReplay();

        }

        private void bgw_DoReplay()
        {
            try
            {
                port.Open();
                while (true)
                {
                    for (int i = 1; i < data.Length; i++)
                    {
                        
                        Thread.Sleep(10); //Time to send data dn let arduino parse it;
                        port.Write(data[i]+"\n");
                    }
                  
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void btnStopReplay_Click(object sender, EventArgs e)
        {
            btnStartReplay.Enabled = true;
            btnStopReplay.Enabled = false;
            th.Abort();
            if (port.IsOpen) port.Close();
            port.Dispose();
        }
    }
}


