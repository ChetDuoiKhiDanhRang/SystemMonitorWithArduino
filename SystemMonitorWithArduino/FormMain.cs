using Microsoft.Win32;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;



namespace SystemMonitorWithArduino
{
    public partial class FormMain : Form
    {
        public event ValueChangedHandler<bool> NetworkStartStop;
        public event ValueChangedHandler<bool> PowerSourceChanged;
        public event ValueChangedHandler<bool> ComputerAsServerChanged;
        public event ValueChangedHandler<bool> StartUpChanged;

        bool startNetwork;
        public bool StartNetwork
        {
            get => startNetwork;
            set
            {
                var e = new ValueChangedArguments<bool> { OldValue = startNetwork, NewValue = value };
                startNetwork = value;
                NetworkStartStop?.Invoke(this, e);
            }
        }

        bool powerSource = true;
        public bool PowerSource
        {
            get => powerSource;
            set
            {
                var e = new ValueChangedArguments<bool>() { OldValue = powerSource, NewValue = value };
                powerSource = value;
                PowerSourceChanged?.Invoke(this, e);
            }
        }


        bool computerAsServer;
        public bool ComputerAsServer
        {
            get => computerAsServer;
            set
            {
                var e = new ValueChangedArguments<bool> { OldValue = computerAsServer, NewValue = value };
                computerAsServer = value;
                ComputerAsServerChanged?.Invoke(this, e);
            }
        }

        bool startUp;
        public bool StartUp
        {
            get => startUp;
            set
            {
                var e = new ValueChangedArguments<bool> { OldValue = startUp, NewValue = value };
                startUp = value;
                StartUpChanged?.Invoke(this, null);
            }
        }

        string CPULoad = "##.##";
        string CPUTemp = "##.##";
        string RAMUsed = "##.##";
        string RAMAvai = "##.##";

        const int S_BUFFERSIZE = 20;
        const int R_BUFFERSIZE = 1;
        const string title = "SYSTEM MONITOR WITH ARDUINO - VOZFORUMS";

        TcpListener listener;
        Computer thisComputer;
        string ipClientMode;
        string portClientMode;
        string BasicInfor = "";
        int eventID = 1985;
        //=================================================================================================================================================
        public FormMain()
        {
            InitializeComponent();
            thisComputer = new Computer()
            {
                CPUEnabled = true,
                RAMEnabled = true,
            };
            thisComputer.Open();
            eventlog.Source = Application.ProductName;

            BasicInfor = GetBasicInfor();

            NetworkStartStop += FormMain_NetworkStartStop;
            PowerSourceChanged += FormMain_PowerSourceChanged;
            StartUpChanged += FormMain_StartUpChanged;
            ComputerAsServerChanged += FormMain_ComputerAsServerChanged;
        }


        string keyName = "SystemMonitorWithArduino";

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadSettings();
            eventlog.WriteEntry(Application.ProductName + " ver " + Application.ProductVersion + ": started", EventLogEntryType.Information, eventID);

        }
        private void FormMain_Shown(object sender, EventArgs e)
        {
            btnStartValue.PerformClick();
            if(StartUp) btnStartNetwork.PerformClick();
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            SaveSettings();
            thisComputer.Close();
            eventlog.WriteEntry(Application.ProductName + " ver " + Application.ProductVersion + ": close!", EventLogEntryType.Information, eventID);
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        #region Custom events--------------------------------------------------------------------------------------
        private void FormMain_StartUpChanged(object sender, ValueChangedArguments<bool> e)
        {
            try
            {
                var startUpKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (StartUp)
                {
                    picStartWithSystem.Image = Properties.Resources.toggleON;
                    startUpKey.SetValue(keyName, Application.ExecutablePath);
                    lblStartup.Text = "Auto start: ON";
                }
                else
                {
                    if (startUpKey.GetValue(keyName) != null) startUpKey.DeleteValue(keyName);
                    picStartWithSystem.Image = Properties.Resources.toggleOFF;
                    lblStartup.Text = "Auto start: OFF";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Run program as Administrator plz", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void FormMain_NetworkStartStop(object sender, ValueChangedArguments<bool> e)
        {
            btnStartNetwork.Image = StartNetwork ? Properties.Resources.netON : Properties.Resources.netOFF;
            this.Invoke((Action)(() =>
            {
                cmbIPs.Enabled = txbPort.Enabled = picAsServer.Enabled = !StartNetwork;
                ckbIP4.Enabled = !e.NewValue;
                //btnStartNetwork.Text = e.NewValue ? "Stop" : "Start";
                txbLogs.AppendText((new string('=', 20)) + "[" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "]" + (new string('=', 20)) + Environment.NewLine);
                txbLogs.AppendText("RUN AS" + (ComputerAsServer ? " SERVER: " : " CLIENT: ") + (StartNetwork ? ("STARTED!") : ("STOPPED!")) + Environment.NewLine);
            }));

            if (StartNetwork)
            {
                if (IPAddress.TryParse(cmbIPs.Text, out IPAddress ip) && int.TryParse(txbPort.Text, out int port))
                {
                    Properties.Settings.Default.LastIP = cmbIPs.Text;
                    Properties.Settings.Default.Save();
                    if (ComputerAsServer)
                    {
                        try
                        {
                            var cli = new TcpClient();
                            cli.Connect(ip, port);
                            this.Invoke((Action)(() =>
                            {
                                lblErr.Text = ("THIS IP/PORT HAS BEEN USED BY ANOTHER PROGRAM!" + Environment.NewLine);
                                lblErr.Visible = true;
                            }));
                            StartNetwork = false;
                            cli.Close();
                            return;
                        }
                        catch (SocketException ex)
                        {
                            lblErr.Visible = false;
                            string s = ex.Message; //just for view what happen;

                            listener = new TcpListener(new IPEndPoint(IPAddress.Parse(cmbIPs.Text), int.Parse(txbPort.Text))) { ExclusiveAddressUse = false };
                            listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                            listener.Start();

                            this.Invoke((Action)(() => txbLogs.AppendText("IP Endpoint: [" + listener.LocalEndpoint + "]" + Environment.NewLine)));


                            tickerNet.Start();
                        }
                    }
                    else
                    {
                        ipClientMode = cmbIPs.Text;
                        portClientMode = txbPort.Text;
                        lblErr.Visible = false;
                        tickerNet.Start();
                    }

                }
                else
                {
                    this.Invoke((Action)(() =>
                    {
                        lblErr.Text = ("IP and PORT config failed!".ToUpper() + Environment.NewLine);
                        lblErr.Visible = true;
                    }));
                    StartNetwork = false;
                }



            }
            else
            {
                tickerNet.Stop();
                listener?.Server.Close();
                listener?.Stop();
            }

        }

        private void FormMain_PowerSourceChanged(object sender, ValueChangedArguments<bool> e)
        {
            if (e.OldValue & !e.NewValue)
            {
                eventlog.WriteEntry(Application.ProductName + " ver " + Application.ProductVersion + ": Power lost!", EventLogEntryType.Warning, 1985);

                Process p = new Process()
                {
                    StartInfo = new ProcessStartInfo("shutdown.exe", "/s /f /t " + delayShutDown),

                };
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                return;
            }
            if (!e.OldValue & e.NewValue)
            {
                eventlog.WriteEntry(Application.ProductName + " ver " + Application.ProductVersion + ": Power return!", EventLogEntryType.Information, 1985);

                Process p = new Process()
                {
                    StartInfo = new ProcessStartInfo("shutdown.exe", "/a")
                };
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
            }
        }

        private void FormMain_ComputerAsServerChanged(object sender, ValueChangedArguments<bool> e)
        {
            lblAsServer.Text = (ComputerAsServer ? "Server Mode" : "Client Mode");
            picAsServer.Image = ComputerAsServer ? Properties.Resources.toggleON : Properties.Resources.toggleOFF;

            if (ComputerAsServer)
            {
                cmbIPs.DropDownStyle = ComboBoxStyle.DropDownList;
                LoadIPAddresses(ckbIP4.Checked);
            }
            else
            {
                txbMAC.Clear();
                cmbIPs.DropDownStyle = ComboBoxStyle.DropDown;
                cmbIPs.Items.Clear(); ;
            }
        }
        #endregion

        #region Control events------------------------------------------------------------------------------

        private void ckbIP4_CheckedChanged(object sender, EventArgs e)
        {
            LoadIPAddresses(ckbIP4.Checked);
        }

        private void cmbIPs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIPs.SelectedIndex >= 0)
            {
                txbMAC.Text = GetMAC(cmbIPs.SelectedItem.ToString());//.Text);
            }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            StartNetwork = !StartNetwork;
        }

        private void tickerNet_Tick(object sender, EventArgs e)
        {
            if (computerAsServer)
            {
                Thread t = new Thread(new ThreadStart(ReceiveAndSendData_ComputerAsServer))
                {
                    IsBackground = true
                };
                t.Start();
            }
            else
            {
                Thread t = new Thread(new ThreadStart(ReceiveAndSendData_ComputerAsClient))
                {
                    IsBackground = true
                };
                t.Start();
            }
        }

        private void tickerGetValues_Tick(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(GetComputerStatus));
            t.IsBackground = true;
            t.Start();
            StringBuilder sb = new StringBuilder();
            if (title.Length > 0)
            {
                sb.AppendLine(title);
            }
            sb.AppendLine("CPU load".PadRight(15) + ": " + CPULoad + "  %");
            sb.AppendLine("CPU temp".PadRight(15) + ": " + CPUTemp + " °C");
            sb.AppendLine("RAM used".PadRight(15) + ": " + RAMUsed + " GB");
            sb.AppendLine("RAM avai".PadRight(15) + ": " + RAMAvai + " GB");
            sb.AppendLine("".PadRight(40, '-'));
            sb.AppendLine(BasicInfor);


            this.Invoke((Action)(() => txbValues.Text = sb.ToString()));
        }

        private void picAsServer_Click(object sender, EventArgs e)
        {
            ComputerAsServer = !ComputerAsServer;
        }

        private void txbPort_TextChanged(object sender, EventArgs e)
        {
            if (!((long.TryParse(txbPort.Text, out long port) && port <= 65535)))
            {
                txbPort.Text = "65535";
                lblErr.Text = ("Port must be between 1 and 65535!");
                lblErr.Visible = true;
            }
            else
            {
                lblErr.Visible = false;

            }
        }

        private void picStartWithSystem_Click(object sender, EventArgs e)
        {
            StartUp = !StartUp;
        }

        private void txbLogs_TextChanged(object sender, EventArgs e)
        {
            if (txbLogs.Lines.Count() >= 90000)
            {
                txbLogs.Clear();
            }
            txbLogs.ScrollToCaret();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyLog2Clipboard();
        }

        private void CopyLog2Clipboard()
        {
            Clipboard.SetText(txbLogs.Text, TextDataFormat.Text);
        }

        private void btnOpenLogFolder_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\Logs";
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("explorer.exe", path);
            p.Start();
        }

        int panel1Width;
        int panel2Width;
        private void btnShowLogScreen_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                panel1Width = splitContainer1.Panel1.Width;
                panel2Width = splitContainer1.Panel2.Width;
                splitContainer1.Panel2Collapsed = true;

                this.Width = panel1Width + 38;
            }
            else
            {
                splitContainer1.Panel2Collapsed = false;
                this.Width = panel1Width + panel2Width + 38;
            }

        }

        private void btnStartValue_Click(object sender, EventArgs e)
        {
            tickerGetValues.Start();
        }

        private void btnStopValue_Click(object sender, EventArgs e)
        {
            tickerGetValues.Stop();
        }

        int delayShutDown;
        private void txbDelayShutdown_TextChanged(object sender, EventArgs e)
        {
            if (txbDelayShutdown.Text.Length > 0 && int.TryParse(txbDelayShutdown.Text, out int delay) && delay <= 315359999)
            {
                delayShutDown = delay;
                lblErr.Visible = false;
            }
            else
            {
                txbDelayShutdown.Text = "60";
                lblErr.Text = "must be between 0 and 315359999 (~10 years!)";
                lblErr.Visible = true;
            }
        }

        private void btnClearLogScreen_Click(object sender, EventArgs e)
        {
            txbLogs.Clear();
        }

        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            SaveLog();
        }
        #endregion

        #region Methods--------------------------------------------------------------------------------------
        private string GetBasicInfor()
        {
            string tmp = "Computer: " + Environment.GetEnvironmentVariable("COMPUTERNAME") + Environment.NewLine;
            tmp += "User: " + Environment.GetEnvironmentVariable("USERNAME") + Environment.NewLine;

            ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_ComputerSystemProduct");

            foreach (ManagementObject item in searcher.Get())
            {
                tmp += "Vendor: " + item["vendor"].ToString() + Environment.NewLine;
                tmp += item["Caption"].ToString() + ": " + item["Name"].ToString() + Environment.NewLine;
                tmp += "Indentify number: " + item["IdentifyingNumber"].ToString() + Environment.NewLine;
            }

            ManagementClass mcp = new ManagementClass("Win32_Processor");
            var mcpi = mcp.GetInstances();
            if (mcpi.Count > 0)
            {
                foreach (var item in mcpi)
                {
                    tmp += item.GetPropertyValue("name").ToString() + Environment.NewLine;
                }
            }

            ManagementClass mcr = new ManagementClass("Win32_ComputerSystem");
            var mcri = mcr.GetInstances();
            if (mcri.Count > 0)
            {
                foreach (var item in mcri)
                {
                    tmp += "Total physical memmory: " + (long.Parse(item["TotalPhysicalMemory"].ToString()) / (1024f * 1024 * 1024)).ToString("00.00") + " GB";
                }
            }
            return tmp.Remove(tmp.Length - 1);
        }

        private void LoadIPAddresses(bool IPv4Only)
        {
            string hostName = Dns.GetHostName();
            var ips = IPv4Only ? Dns.GetHostAddresses(hostName).Where(x => x.AddressFamily == AddressFamily.InterNetwork) : Dns.GetHostAddresses(hostName);
            cmbIPs.Items.Clear();
            foreach (var ip in ips)
            {
                cmbIPs.Items.Add(ip.ToString());
            }

            if (cmbIPs.Items.Count > 0)
            {
                foreach (var item in cmbIPs.Items)
                {
                    if (item.ToString() == Properties.Settings.Default.LastIP)
                    {
                        cmbIPs.SelectedItem = item;
                        return;
                    }
                }
                cmbIPs.SelectedIndex = 0;
            }
        }

        private string GetMAC(string IP)
        {
            var nic = (from x in NetworkInterface.GetAllNetworkInterfaces().
                       Where(x => x.GetIPProperties().UnicastAddresses.
                       Where(u => u.Address.ToString() == IP).Count() > 0)
                       select x).FirstOrDefault();
            string MAC = "MAC address";
            if (nic != null)
            {
                MAC = "";
                var tmpMAC = nic.GetPhysicalAddress().ToString();
                for (int i = 0; i < tmpMAC.Length; i += 2)
                {
                    string tmp = "0x" + tmpMAC[i] + tmpMAC[i + 1] + ":";
                    MAC += tmp;
                }
            }
            MAC = MAC.Remove(MAC.Length - 1);
            return MAC;
        }

        private void LoadSettings()
        {
            var x = Properties.Settings.Default;
            ckbIP4.Checked = x.IPv4Only;
            txbPort.Text = x.Port;
            lblErr.Visible = false;

            var startUpKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            ComputerAsServer = x.RunAsServer;

            if (!ComputerAsServer)
            {
                cmbIPs.Text = x.LastIP;
            }
            txbDelayShutdown.Text = x.DelayShutdown;

            if (x.HideLogScreen)
            {
                btnShowLogScreen.PerformClick();
            }

            StartUp = (startUpKey.GetValue(keyName) != null && (startUpKey.GetValue(keyName).ToString() == Application.ExecutablePath));

        }

        private void SaveSettings()
        {
            var x = Properties.Settings.Default;
            x.LastIP = cmbIPs.Text;
            x.Port = txbPort.Text;
            x.IPv4Only = ckbIP4.Checked;
            x.RunAsServer = ComputerAsServer;
            x.StartUp = StartUp;
            x.DelayShutdown = txbDelayShutdown.Text;
            x.HideLogScreen = splitContainer1.Panel2Collapsed;
            x.Save();
        }

        bool waitingFlag;
        private void ReceiveAndSendData_ComputerAsServer()
        {
            if (StartNetwork && !waitingFlag && ComputerAsServer)
            {
                waitingFlag = true;
                try
                {
                    this.Invoke((Action)(() => txbLogs.AppendText("Waiting connection...!" + Environment.NewLine)));
                    Socket sock = listener.AcceptSocket();


                    if (sock.Available > 0)
                    {
                        this.Invoke((Action)(() => txbLogs.AppendText(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "|" + "Received info from client: " + sock.RemoteEndPoint.ToString() + Environment.NewLine)));
                        byte[] re = new byte[R_BUFFERSIZE] { 0xFF };
                        sock.Receive(re);
                        PowerSource = (re[0] == 0xFF);
                        this.Invoke((Action)(() => txbLogs.AppendText("Power source: " + (PowerSource ? "ON" : "OFF") + Environment.NewLine)));
                    }
                    string s = CPULoad + CPUTemp + RAMUsed + RAMAvai;
                    byte[] InfoSend = new byte[S_BUFFERSIZE];
                    InfoSend = ASCIIEncoding.ASCII.GetBytes(s);
                    sock.SendBufferSize = 20;
                    sock.Send(InfoSend);//InfoSend);
                    this.Invoke((Action)(() =>
                    {
                        txbLogs.AppendText(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "|" + "Send to client: " + sock.RemoteEndPoint.ToString() + Environment.NewLine);
                        txbLogs.AppendText("[" + CPULoad + "] " + "[" + CPUTemp + "] " + "[" + RAMUsed + "] " + "[" + RAMAvai + "] " + Environment.NewLine);
                        txbLogs.AppendText("".PadRight(40, '-') + Environment.NewLine);
                    }
                    ));
                    sock.Close();
                    sock.Dispose();
                }
                catch (SocketException ex)
                {
                    this.Invoke((Action)(() => txbLogs.AppendText(ex.Message + Environment.NewLine)));
                    StartNetwork = false;
                    Thread.CurrentThread.Abort();
                    //just cancel waiting socket
                }
                finally { waitingFlag = false; }
            }
        }

        private void ReceiveAndSendData_ComputerAsClient()
        {
            if (StartNetwork && !waitingFlag && !ComputerAsServer)
            {
                try
                {
                    waitingFlag = true;
                    IPAddress ip = IPAddress.Parse(ipClientMode);
                    int port = int.Parse(portClientMode);
                    TcpClient client = new TcpClient();
                    this.Invoke((Action)(() =>
                    {
                        txbLogs.AppendText("[" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "]" + Environment.NewLine);
                        txbLogs.AppendText("Connecting to: " + ip.ToString() + ":" + port + Environment.NewLine);
                    }));
                    client.Connect(ip, port);
                    if (client.Connected)
                    {
                        this.Invoke((Action)(() =>
                        {
                            txbLogs.AppendText("Connected!" + Environment.NewLine);
                            txbLogs.AppendText("This local IP address: " + client.Client.LocalEndPoint.ToString() + Environment.NewLine);
                            string ipm = client.Client.LocalEndPoint.ToString().Substring(0, client.Client.LocalEndPoint.ToString().IndexOf(':'));
                            txbMAC.Text = GetMAC(ipm) + Environment.NewLine;
                            txbLogs.AppendText("".PadRight(40, '-') + Environment.NewLine);
                        }));
                    }
                    client.Close();
                    waitingFlag = false;
                }
                catch (Exception ex)
                {
                    this.Invoke((Action)(() => txbLogs.AppendText(ex.Message + Environment.NewLine)));
                    StartNetwork = false;
                    Thread.CurrentThread.Abort();
                }
                finally { waitingFlag = false; }
            }
        }

        private void GetComputerStatus()
        {

            CPULoad = GetSensorValue(HardwareType.CPU, SensorType.Load, "core");
            CPUTemp = GetSensorValue(HardwareType.CPU, SensorType.Temperature, "package");
            RAMUsed = GetSensorValue(HardwareType.RAM, SensorType.Data, "used");
            RAMAvai = GetSensorValue(HardwareType.RAM, SensorType.Data, "avail");
        }

        private string GetSensorValue(HardwareType HType, SensorType STYpe, string keyword)
        {
            var hw = thisComputer.Hardware.Where(x => x.HardwareType == HType).FirstOrDefault();
            if (hw != null)
            {
                hw.Update();
                var sensors = hw.Sensors.Where(x => x.SensorType == STYpe && x.Name.ToLower().Contains(keyword));

                if (sensors.Count() > 0)
                {
                    List<float> vals = new List<float>();
                    foreach (var sensor in sensors)
                    {
                        vals.Add(sensor.Value.GetValueOrDefault());
                    }
                    return vals.Average().ToString("00.00");
                }
            }
            return "##.##";
        }

        private void SaveLog()
        {
            string path = Application.StartupPath + "\\Logs";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            Directory.CreateDirectory(path);

            string filename = DateTime.Now.ToString("yy.MM.dd_HH.mm.ss") + ".txt";
            int i = 1;
            while (File.Exists(path + "\\" + filename))
            {
                filename = DateTime.Now.ToString("yy.MM.dd_HH.mm.ss") + "_" + i + ".txt";
                i++;
            }
            txbLogs.SaveFile(path + "\\" + filename, RichTextBoxStreamType.PlainText);
        }

        #endregion
    }

}
