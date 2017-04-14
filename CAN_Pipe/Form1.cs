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

namespace CAN_Pipe
{
    public partial class Form1 : Form

    {
        Thread th;
        SerialPort port;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cmbSerialPorts.DataSource = ports;
            

        }

        private void clickOnJesse(object sender, EventArgs e)
        {
            Clipboard.SetText(@"\\?\pipe\" + tbPipeName.Text);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            cmbSerialPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                if (!cmbSerialPorts.Items.Contains(ports[i]))
                {
                    cmbSerialPorts.Items.Add(ports[i]);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            th = new Thread(start);
            th.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            th.Abort();
            if (port.IsOpen) port.Close();
            port.Dispose();
        }

        private void start()
        {
            string text = "";
            this.Invoke((MethodInvoker)delegate ()
            {
                text = cmbSerialPorts.SelectedItem.ToString();
            });
            port = new SerialPort(text, 115200);
            bgw_DoWork();

        }
        private void bgw_DoWork()
        {
            try
            {
               port.Open();
            var ws = new Wireshark.WiresharkSender(tbPipeName.Text, 227);  // pipe name is \\.\pipe\bacnet
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
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
            }
            catch (Exception ex2)
            {
                //MessageBox.Show(ex2.Message);
            }
        }

    }
}


