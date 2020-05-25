namespace SystemMonitorWithArduino
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblErr = new System.Windows.Forms.Label();
            this.btnClearLogScreen = new System.Windows.Forms.Button();
            this.btnStopValue = new System.Windows.Forms.Button();
            this.btnOpenLogFolder = new System.Windows.Forms.Button();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.btnStartValue = new System.Windows.Forms.Button();
            this.btnShowLogScreen = new System.Windows.Forms.Button();
            this.picStartWithSystem = new System.Windows.Forms.PictureBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.picAsServer = new System.Windows.Forms.PictureBox();
            this.txbValues = new System.Windows.Forms.TextBox();
            this.txbMAC = new System.Windows.Forms.TextBox();
            this.btnStartNetwork = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStartup = new System.Windows.Forms.Label();
            this.txbDelayShutdown = new System.Windows.Forms.TextBox();
            this.txbPort = new System.Windows.Forms.TextBox();
            this.lblAsServer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbIP4 = new System.Windows.Forms.CheckBox();
            this.cmbIPs = new System.Windows.Forms.ComboBox();
            this.txbLogs = new System.Windows.Forms.RichTextBox();
            this.tickerNet = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            this.tickerGetValues = new System.Windows.Forms.Timer(this.components);
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.eventlog = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStartWithSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAsServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventlog)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblErr);
            this.splitContainer1.Panel1.Controls.Add(this.btnClearLogScreen);
            this.splitContainer1.Panel1.Controls.Add(this.btnStopValue);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpenLogFolder);
            this.splitContainer1.Panel1.Controls.Add(this.btnSaveLog);
            this.splitContainer1.Panel1.Controls.Add(this.btnStartValue);
            this.splitContainer1.Panel1.Controls.Add(this.btnShowLogScreen);
            this.splitContainer1.Panel1.Controls.Add(this.picStartWithSystem);
            this.splitContainer1.Panel1.Controls.Add(this.btnCopy);
            this.splitContainer1.Panel1.Controls.Add(this.picAsServer);
            this.splitContainer1.Panel1.Controls.Add(this.txbValues);
            this.splitContainer1.Panel1.Controls.Add(this.txbMAC);
            this.splitContainer1.Panel1.Controls.Add(this.btnStartNetwork);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lblStartup);
            this.splitContainer1.Panel1.Controls.Add(this.txbDelayShutdown);
            this.splitContainer1.Panel1.Controls.Add(this.txbPort);
            this.splitContainer1.Panel1.Controls.Add(this.lblAsServer);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.ckbIP4);
            this.splitContainer1.Panel1.Controls.Add(this.cmbIPs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txbLogs);
            this.splitContainer1.Size = new System.Drawing.Size(897, 471);
            this.splitContainer1.SplitterDistance = 427;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErr.ForeColor = System.Drawing.Color.Maroon;
            this.lblErr.Location = new System.Drawing.Point(115, 13);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(33, 12);
            this.lblErr.TabIndex = 10;
            this.lblErr.Text = "label4";
            this.lblErr.Visible = false;
            // 
            // btnClearLogScreen
            // 
            this.btnClearLogScreen.BackColor = System.Drawing.Color.Transparent;
            this.btnClearLogScreen.BackgroundImage = global::SystemMonitorWithArduino.Properties.Resources.clear;
            this.btnClearLogScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearLogScreen.FlatAppearance.BorderSize = 0;
            this.btnClearLogScreen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClearLogScreen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClearLogScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLogScreen.Location = new System.Drawing.Point(253, 198);
            this.btnClearLogScreen.Name = "btnClearLogScreen";
            this.btnClearLogScreen.Size = new System.Drawing.Size(38, 30);
            this.btnClearLogScreen.TabIndex = 7;
            this.btnClearLogScreen.UseVisualStyleBackColor = false;
            this.btnClearLogScreen.Click += new System.EventHandler(this.btnClearLogScreen_Click);
            // 
            // btnStopValue
            // 
            this.btnStopValue.BackColor = System.Drawing.Color.Transparent;
            this.btnStopValue.BackgroundImage = global::SystemMonitorWithArduino.Properties.Resources.stop;
            this.btnStopValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStopValue.FlatAppearance.BorderSize = 0;
            this.btnStopValue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnStopValue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStopValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopValue.Location = new System.Drawing.Point(50, 198);
            this.btnStopValue.Name = "btnStopValue";
            this.btnStopValue.Size = new System.Drawing.Size(38, 30);
            this.btnStopValue.TabIndex = 5;
            this.tip.SetToolTip(this.btnStopValue, "Stop get infor");
            this.btnStopValue.UseVisualStyleBackColor = false;
            this.btnStopValue.Click += new System.EventHandler(this.btnStopValue_Click);
            // 
            // btnOpenLogFolder
            // 
            this.btnOpenLogFolder.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenLogFolder.BackgroundImage = global::SystemMonitorWithArduino.Properties.Resources.folder;
            this.btnOpenLogFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOpenLogFolder.FlatAppearance.BorderSize = 0;
            this.btnOpenLogFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnOpenLogFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOpenLogFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenLogFolder.Location = new System.Drawing.Point(118, 198);
            this.btnOpenLogFolder.Name = "btnOpenLogFolder";
            this.btnOpenLogFolder.Size = new System.Drawing.Size(38, 30);
            this.btnOpenLogFolder.TabIndex = 6;
            this.tip.SetToolTip(this.btnOpenLogFolder, "Open log folder");
            this.btnOpenLogFolder.UseVisualStyleBackColor = false;
            this.btnOpenLogFolder.Click += new System.EventHandler(this.btnOpenLogFolder_Click);
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveLog.BackgroundImage = global::SystemMonitorWithArduino.Properties.Resources.download;
            this.btnSaveLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveLog.FlatAppearance.BorderSize = 0;
            this.btnSaveLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSaveLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSaveLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveLog.Location = new System.Drawing.Point(208, 198);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(38, 30);
            this.btnSaveLog.TabIndex = 7;
            this.tip.SetToolTip(this.btnSaveLog, "Save log to text file");
            this.btnSaveLog.UseVisualStyleBackColor = false;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // btnStartValue
            // 
            this.btnStartValue.BackColor = System.Drawing.Color.Transparent;
            this.btnStartValue.BackgroundImage = global::SystemMonitorWithArduino.Properties.Resources.play;
            this.btnStartValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStartValue.FlatAppearance.BorderSize = 0;
            this.btnStartValue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnStartValue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStartValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartValue.Location = new System.Drawing.Point(5, 198);
            this.btnStartValue.Name = "btnStartValue";
            this.btnStartValue.Size = new System.Drawing.Size(38, 30);
            this.btnStartValue.TabIndex = 4;
            this.tip.SetToolTip(this.btnStartValue, "Get CPU/RAM infor ");
            this.btnStartValue.UseVisualStyleBackColor = false;
            this.btnStartValue.Click += new System.EventHandler(this.btnStartValue_Click);
            // 
            // btnShowLogScreen
            // 
            this.btnShowLogScreen.BackColor = System.Drawing.Color.Transparent;
            this.btnShowLogScreen.BackgroundImage = global::SystemMonitorWithArduino.Properties.Resources.cs;
            this.btnShowLogScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowLogScreen.FlatAppearance.BorderSize = 0;
            this.btnShowLogScreen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnShowLogScreen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnShowLogScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowLogScreen.Location = new System.Drawing.Point(298, 198);
            this.btnShowLogScreen.Name = "btnShowLogScreen";
            this.btnShowLogScreen.Size = new System.Drawing.Size(38, 30);
            this.btnShowLogScreen.TabIndex = 8;
            this.tip.SetToolTip(this.btnShowLogScreen, "Show/Hide log screen ");
            this.btnShowLogScreen.UseVisualStyleBackColor = false;
            this.btnShowLogScreen.Click += new System.EventHandler(this.btnShowLogScreen_Click);
            // 
            // picStartWithSystem
            // 
            this.picStartWithSystem.BackColor = System.Drawing.Color.Transparent;
            this.picStartWithSystem.Image = ((System.Drawing.Image)(resources.GetObject("picStartWithSystem.Image")));
            this.picStartWithSystem.Location = new System.Drawing.Point(118, 122);
            this.picStartWithSystem.Name = "picStartWithSystem";
            this.picStartWithSystem.Size = new System.Drawing.Size(80, 29);
            this.picStartWithSystem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStartWithSystem.TabIndex = 7;
            this.picStartWithSystem.TabStop = false;
            this.tip.SetToolTip(this.picStartWithSystem, "Auto start with system boot");
            this.picStartWithSystem.Click += new System.EventHandler(this.picStartWithSystem_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.Transparent;
            this.btnCopy.BackgroundImage = global::SystemMonitorWithArduino.Properties.Resources.save;
            this.btnCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Location = new System.Drawing.Point(163, 198);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(38, 30);
            this.btnCopy.TabIndex = 7;
            this.tip.SetToolTip(this.btnCopy, "Copy logs to clipboard");
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // picAsServer
            // 
            this.picAsServer.BackColor = System.Drawing.Color.Transparent;
            this.picAsServer.Image = ((System.Drawing.Image)(resources.GetObject("picAsServer.Image")));
            this.picAsServer.Location = new System.Drawing.Point(118, 93);
            this.picAsServer.Name = "picAsServer";
            this.picAsServer.Size = new System.Drawing.Size(80, 29);
            this.picAsServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAsServer.TabIndex = 7;
            this.picAsServer.TabStop = false;
            this.tip.SetToolTip(this.picAsServer, "Toggle Server/Client mode");
            this.picAsServer.Click += new System.EventHandler(this.picAsServer_Click);
            // 
            // txbValues
            // 
            this.txbValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbValues.BackColor = System.Drawing.Color.Black;
            this.txbValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbValues.Font = new System.Drawing.Font("Consolas", 10F);
            this.txbValues.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txbValues.Location = new System.Drawing.Point(3, 234);
            this.txbValues.Multiline = true;
            this.txbValues.Name = "txbValues";
            this.txbValues.ReadOnly = true;
            this.txbValues.Size = new System.Drawing.Size(419, 232);
            this.txbValues.TabIndex = 6;
            this.txbValues.WordWrap = false;
            // 
            // txbMAC
            // 
            this.txbMAC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMAC.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMAC.Location = new System.Drawing.Point(118, 65);
            this.txbMAC.Name = "txbMAC";
            this.txbMAC.ReadOnly = true;
            this.txbMAC.Size = new System.Drawing.Size(295, 22);
            this.txbMAC.TabIndex = 2;
            this.txbMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStartNetwork
            // 
            this.btnStartNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartNetwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStartNetwork.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnStartNetwork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartNetwork.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartNetwork.Image = global::SystemMonitorWithArduino.Properties.Resources.netOFF;
            this.btnStartNetwork.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStartNetwork.Location = new System.Drawing.Point(204, 96);
            this.btnStartNetwork.Name = "btnStartNetwork";
            this.btnStartNetwork.Size = new System.Drawing.Size(209, 84);
            this.btnStartNetwork.TabIndex = 3;
            this.btnStartNetwork.Text = "Start/Stop network";
            this.btnStartNetwork.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStartNetwork.UseVisualStyleBackColor = true;
            this.btnStartNetwork.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Shutdown after:";
            // 
            // lblStartup
            // 
            this.lblStartup.AutoSize = true;
            this.lblStartup.Location = new System.Drawing.Point(16, 129);
            this.lblStartup.Name = "lblStartup";
            this.lblStartup.Size = new System.Drawing.Size(69, 15);
            this.lblStartup.TabIndex = 2;
            this.lblStartup.Text = "Startup: ON";
            // 
            // txbDelayShutdown
            // 
            this.txbDelayShutdown.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txbDelayShutdown.Location = new System.Drawing.Point(117, 157);
            this.txbDelayShutdown.MaxLength = 5;
            this.txbDelayShutdown.Name = "txbDelayShutdown";
            this.txbDelayShutdown.Size = new System.Drawing.Size(80, 23);
            this.txbDelayShutdown.TabIndex = 2;
            this.txbDelayShutdown.Text = "65535";
            this.txbDelayShutdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbDelayShutdown.TextChanged += new System.EventHandler(this.txbDelayShutdown_TextChanged);
            // 
            // txbPort
            // 
            this.txbPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPort.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txbPort.Location = new System.Drawing.Point(365, 32);
            this.txbPort.MaxLength = 5;
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(48, 23);
            this.txbPort.TabIndex = 1;
            this.txbPort.Text = "65535";
            this.txbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbPort.TextChanged += new System.EventHandler(this.txbPort_TextChanged);
            // 
            // lblAsServer
            // 
            this.lblAsServer.AutoSize = true;
            this.lblAsServer.Location = new System.Drawing.Point(16, 100);
            this.lblAsServer.Name = "lblAsServer";
            this.lblAsServer.Size = new System.Drawing.Size(100, 15);
            this.lblAsServer.TabIndex = 2;
            this.lblAsServer.Text = "Run as server: ON";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "MAC  address:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(349, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP address/Port:";
            // 
            // ckbIP4
            // 
            this.ckbIP4.AutoSize = true;
            this.ckbIP4.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbIP4.Location = new System.Drawing.Point(19, 11);
            this.ckbIP4.Name = "ckbIP4";
            this.ckbIP4.Size = new System.Drawing.Size(67, 16);
            this.ckbIP4.TabIndex = 1;
            this.ckbIP4.Text = "IPv4 only";
            this.ckbIP4.UseVisualStyleBackColor = true;
            this.ckbIP4.CheckedChanged += new System.EventHandler(this.ckbIP4_CheckedChanged);
            // 
            // cmbIPs
            // 
            this.cmbIPs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIPs.IntegralHeight = false;
            this.cmbIPs.ItemHeight = 15;
            this.cmbIPs.Location = new System.Drawing.Point(118, 31);
            this.cmbIPs.Name = "cmbIPs";
            this.cmbIPs.Size = new System.Drawing.Size(225, 23);
            this.cmbIPs.TabIndex = 0;
            this.cmbIPs.SelectedIndexChanged += new System.EventHandler(this.cmbIPs_SelectedIndexChanged);
            // 
            // txbLogs
            // 
            this.txbLogs.BackColor = System.Drawing.Color.Black;
            this.txbLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbLogs.Font = new System.Drawing.Font("Consolas", 10F);
            this.txbLogs.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txbLogs.Location = new System.Drawing.Point(0, 0);
            this.txbLogs.Name = "txbLogs";
            this.txbLogs.ReadOnly = true;
            this.txbLogs.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txbLogs.Size = new System.Drawing.Size(463, 469);
            this.txbLogs.TabIndex = 4;
            this.txbLogs.Text = "";
            this.txbLogs.WordWrap = false;
            this.txbLogs.TextChanged += new System.EventHandler(this.txbLogs_TextChanged);
            // 
            // tickerNet
            // 
            this.tickerNet.Interval = 1000;
            this.tickerNet.Tick += new System.EventHandler(this.tickerNet_Tick);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 24);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // imglist
            // 
            this.imglist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist.ImageStream")));
            this.imglist.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist.Images.SetKeyName(0, "173075 - play.png");
            this.imglist.Images.SetKeyName(1, "173105 - stop.png");
            // 
            // tickerGetValues
            // 
            this.tickerGetValues.Interval = 1000;
            this.tickerGetValues.Tick += new System.EventHandler(this.tickerGetValues_Tick);
            // 
            // tip
            // 
            this.tip.ShowAlways = true;
            this.tip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tip.ToolTipTitle = "System monitor - Vozforums";
            // 
            // eventlog
            // 
            this.eventlog.SynchronizingObject = this;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 493);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "SYSTEM MONITOR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picStartWithSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAsServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventlog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox ckbIP4;
        private System.Windows.Forms.ComboBox cmbIPs;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartNetwork;
        private System.Windows.Forms.Timer tickerNet;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.RichTextBox txbLogs;
        private System.Windows.Forms.ImageList imglist;
        private System.Windows.Forms.TextBox txbMAC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer tickerGetValues;
        private System.Windows.Forms.TextBox txbValues;
        private System.Windows.Forms.Label lblAsServer;
        private System.Windows.Forms.PictureBox picAsServer;
        private System.Windows.Forms.Label lblStartup;
        private System.Windows.Forms.PictureBox picStartWithSystem;
        private System.Windows.Forms.Button btnStopValue;
        private System.Windows.Forms.Button btnStartValue;
        private System.Windows.Forms.Button btnOpenLogFolder;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.Button btnShowLogScreen;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbDelayShutdown;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.Button btnClearLogScreen;
        private System.Diagnostics.EventLog eventlog;
    }
}

