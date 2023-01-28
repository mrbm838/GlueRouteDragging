namespace GluePathReadWrite
{
    partial class FormGluePath
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cms_LoadPicture = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_LoadPic = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.tbCompensationX = new System.Windows.Forms.TextBox();
            this.tbCompensationY = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lbPhysicX = new System.Windows.Forms.Label();
            this.lbPhysicY = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbPictureX = new System.Windows.Forms.Label();
            this.lbPictureY = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPhyscialLength = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPixelsNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btCounterClockWise = new System.Windows.Forms.Button();
            this.btClockWise = new System.Windows.Forms.Button();
            this.tbRotation = new System.Windows.Forms.TextBox();
            this.cbWhole = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCX = new System.Windows.Forms.Label();
            this.lbCY = new System.Windows.Forms.Label();
            this.lbTransparency = new System.Windows.Forms.Label();
            this.lbGlueWidth = new System.Windows.Forms.Label();
            this.btSaveGluePath = new System.Windows.Forms.Button();
            this.tkBGlueWidth = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPixelX = new System.Windows.Forms.Label();
            this.tkBTransparency = new System.Windows.Forms.TrackBar();
            this.lbPixelY = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStandardX = new System.Windows.Forms.TextBox();
            this.btOpenGluePath = new System.Windows.Forms.Button();
            this.tbStandardY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbZoom = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.cms_DataGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Append = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Insert = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Clear = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cms_LoadPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkBGlueWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBTransparency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.cms_DataGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.splitContainer1.Panel1.ContextMenuStrip = this.cms_LoadPicture;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.chart);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Size = new System.Drawing.Size(2014, 742);
            this.splitContainer1.SplitterDistance = 811;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // cms_LoadPicture
            // 
            this.cms_LoadPicture.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_LoadPicture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_LoadPic});
            this.cms_LoadPicture.Name = "cms_LoadPicture";
            this.cms_LoadPicture.Size = new System.Drawing.Size(153, 34);
            // 
            // ToolStripMenuItem_LoadPic
            // 
            this.ToolStripMenuItem_LoadPic.Name = "ToolStripMenuItem_LoadPic";
            this.ToolStripMenuItem_LoadPic.Size = new System.Drawing.Size(152, 30);
            this.ToolStripMenuItem_LoadPic.Text = "加载图片";
            this.ToolStripMenuItem_LoadPic.Click += new System.EventHandler(this.ToolStripMenuItem_LoadPic_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.Location = new System.Drawing.Point(4, 54);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(764, 528);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ToolStripMenuItem_Fit_Click);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(854, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 742);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Left;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(2);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(854, 742);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart1";
            this.chart.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart_GetToolTipText);
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            this.chart.Validated += new System.EventHandler(this.chart_Validated);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.tbCompensationX);
            this.panel1.Controls.Add(this.tbCompensationY);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lbPhysicX);
            this.panel1.Controls.Add(this.lbPhysicY);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lbPictureX);
            this.panel1.Controls.Add(this.lbPictureY);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tbPhyscialLength);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tbPixelsNumber);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btCounterClockWise);
            this.panel1.Controls.Add(this.btClockWise);
            this.panel1.Controls.Add(this.tbRotation);
            this.panel1.Controls.Add(this.cbWhole);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbCX);
            this.panel1.Controls.Add(this.lbCY);
            this.panel1.Controls.Add(this.lbTransparency);
            this.panel1.Controls.Add(this.lbGlueWidth);
            this.panel1.Controls.Add(this.btSaveGluePath);
            this.panel1.Controls.Add(this.tkBGlueWidth);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbPixelX);
            this.panel1.Controls.Add(this.tkBTransparency);
            this.panel1.Controls.Add(this.lbPixelY);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbStandardX);
            this.panel1.Controls.Add(this.btOpenGluePath);
            this.panel1.Controls.Add(this.tbStandardY);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbZoom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(859, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 742);
            this.panel1.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 604);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 18);
            this.label13.TabIndex = 103;
            this.label13.Text = "补偿(mm)：";
            // 
            // tbCompensationX
            // 
            this.tbCompensationX.Location = new System.Drawing.Point(128, 598);
            this.tbCompensationX.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbCompensationX.Name = "tbCompensationX";
            this.tbCompensationX.Size = new System.Drawing.Size(76, 28);
            this.tbCompensationX.TabIndex = 104;
            this.tbCompensationX.Text = "0";
            this.tbCompensationX.Leave += new System.EventHandler(this.tbCompensationX_Leave);
            // 
            // tbCompensationY
            // 
            this.tbCompensationY.Location = new System.Drawing.Point(230, 598);
            this.tbCompensationY.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbCompensationY.Name = "tbCompensationY";
            this.tbCompensationY.Size = new System.Drawing.Size(76, 28);
            this.tbCompensationY.TabIndex = 105;
            this.tbCompensationY.Text = "0";
            this.tbCompensationY.Leave += new System.EventHandler(this.tbCompensationY_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 212);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 18);
            this.label15.TabIndex = 100;
            this.label15.Text = "物理坐标：";
            // 
            // lbPhysicX
            // 
            this.lbPhysicX.AutoSize = true;
            this.lbPhysicX.Location = new System.Drawing.Point(136, 212);
            this.lbPhysicX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPhysicX.Name = "lbPhysicX";
            this.lbPhysicX.Size = new System.Drawing.Size(17, 18);
            this.lbPhysicX.TabIndex = 101;
            this.lbPhysicX.Text = "0";
            // 
            // lbPhysicY
            // 
            this.lbPhysicY.AutoSize = true;
            this.lbPhysicY.Location = new System.Drawing.Point(219, 212);
            this.lbPhysicY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPhysicY.Name = "lbPhysicY";
            this.lbPhysicY.Size = new System.Drawing.Size(17, 18);
            this.lbPhysicY.TabIndex = 102;
            this.lbPhysicY.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 286);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 18);
            this.label12.TabIndex = 97;
            this.label12.Text = "图像坐标：";
            // 
            // lbPictureX
            // 
            this.lbPictureX.AutoSize = true;
            this.lbPictureX.Location = new System.Drawing.Point(136, 286);
            this.lbPictureX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPictureX.Name = "lbPictureX";
            this.lbPictureX.Size = new System.Drawing.Size(17, 18);
            this.lbPictureX.TabIndex = 98;
            this.lbPictureX.Text = "0";
            // 
            // lbPictureY
            // 
            this.lbPictureY.AutoSize = true;
            this.lbPictureY.Location = new System.Drawing.Point(219, 286);
            this.lbPictureY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPictureY.Name = "lbPictureY";
            this.lbPictureY.Size = new System.Drawing.Size(17, 18);
            this.lbPictureY.TabIndex = 99;
            this.lbPictureY.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(238, 171);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 18);
            this.label11.TabIndex = 96;
            this.label11.Text = "mm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(238, 128);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 18);
            this.label10.TabIndex = 95;
            this.label10.Text = "pt";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 171);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 18);
            this.label9.TabIndex = 94;
            this.label9.Text = "长边物理长度：";
            // 
            // tbPhyscialLength
            // 
            this.tbPhyscialLength.Location = new System.Drawing.Point(171, 162);
            this.tbPhyscialLength.Margin = new System.Windows.Forms.Padding(4);
            this.tbPhyscialLength.Name = "tbPhyscialLength";
            this.tbPhyscialLength.Size = new System.Drawing.Size(62, 28);
            this.tbPhyscialLength.TabIndex = 93;
            this.tbPhyscialLength.Text = "20";
            this.tbPhyscialLength.Leave += new System.EventHandler(this.tbPhyscialLength_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 128);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 18);
            this.label8.TabIndex = 92;
            this.label8.Text = "长边像素数量：";
            // 
            // tbPixelsNumber
            // 
            this.tbPixelsNumber.Location = new System.Drawing.Point(171, 118);
            this.tbPixelsNumber.Margin = new System.Windows.Forms.Padding(4);
            this.tbPixelsNumber.Name = "tbPixelsNumber";
            this.tbPixelsNumber.Size = new System.Drawing.Size(62, 28);
            this.tbPixelsNumber.TabIndex = 91;
            this.tbPixelsNumber.Text = "2448";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(27, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 21);
            this.label7.TabIndex = 90;
            this.label7.Text = "旋转角度：";
            // 
            // btCounterClockWise
            // 
            this.btCounterClockWise.BackgroundImage = global::GlueReadWrite.Properties.Resources.xiangxia;
            this.btCounterClockWise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCounterClockWise.Location = new System.Drawing.Point(242, 42);
            this.btCounterClockWise.Name = "btCounterClockWise";
            this.btCounterClockWise.Size = new System.Drawing.Size(40, 16);
            this.btCounterClockWise.TabIndex = 89;
            this.btCounterClockWise.UseVisualStyleBackColor = true;
            this.btCounterClockWise.Click += new System.EventHandler(this.btCounterClockWise_Click);
            // 
            // btClockWise
            // 
            this.btClockWise.BackgroundImage = global::GlueReadWrite.Properties.Resources.xiangshang;
            this.btClockWise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btClockWise.Location = new System.Drawing.Point(242, 20);
            this.btClockWise.Name = "btClockWise";
            this.btClockWise.Size = new System.Drawing.Size(40, 15);
            this.btClockWise.TabIndex = 88;
            this.btClockWise.UseVisualStyleBackColor = true;
            this.btClockWise.Click += new System.EventHandler(this.btClockWise_Click);
            // 
            // tbRotation
            // 
            this.tbRotation.Location = new System.Drawing.Point(152, 21);
            this.tbRotation.Margin = new System.Windows.Forms.Padding(4);
            this.tbRotation.Name = "tbRotation";
            this.tbRotation.Size = new System.Drawing.Size(128, 28);
            this.tbRotation.TabIndex = 87;
            this.tbRotation.Text = "1";
            // 
            // cbWhole
            // 
            this.cbWhole.AutoSize = true;
            this.cbWhole.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWhole.Location = new System.Drawing.Point(27, 75);
            this.cbWhole.Margin = new System.Windows.Forms.Padding(4);
            this.cbWhole.Name = "cbWhole";
            this.cbWhole.Size = new System.Drawing.Size(132, 28);
            this.cbWhole.TabIndex = 86;
            this.cbWhole.Text = "整体移动";
            this.cbWhole.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 324);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 83;
            this.label5.Text = "表格坐标：";
            // 
            // lbCX
            // 
            this.lbCX.AutoSize = true;
            this.lbCX.Location = new System.Drawing.Point(136, 324);
            this.lbCX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCX.Name = "lbCX";
            this.lbCX.Size = new System.Drawing.Size(17, 18);
            this.lbCX.TabIndex = 84;
            this.lbCX.Text = "0";
            // 
            // lbCY
            // 
            this.lbCY.AutoSize = true;
            this.lbCY.Location = new System.Drawing.Point(219, 324);
            this.lbCY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCY.Name = "lbCY";
            this.lbCY.Size = new System.Drawing.Size(17, 18);
            this.lbCY.TabIndex = 85;
            this.lbCY.Text = "0";
            // 
            // lbTransparency
            // 
            this.lbTransparency.AutoSize = true;
            this.lbTransparency.Location = new System.Drawing.Point(292, 482);
            this.lbTransparency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTransparency.Name = "lbTransparency";
            this.lbTransparency.Size = new System.Drawing.Size(17, 18);
            this.lbTransparency.TabIndex = 82;
            this.lbTransparency.Text = "0";
            // 
            // lbGlueWidth
            // 
            this.lbGlueWidth.AutoSize = true;
            this.lbGlueWidth.Location = new System.Drawing.Point(292, 405);
            this.lbGlueWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGlueWidth.Name = "lbGlueWidth";
            this.lbGlueWidth.Size = new System.Drawing.Size(17, 18);
            this.lbGlueWidth.TabIndex = 81;
            this.lbGlueWidth.Text = "0";
            // 
            // btSaveGluePath
            // 
            this.btSaveGluePath.BackgroundImage = global::GlueReadWrite.Properties.Resources.保存;
            this.btSaveGluePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSaveGluePath.FlatAppearance.BorderSize = 0;
            this.btSaveGluePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveGluePath.Location = new System.Drawing.Point(190, 663);
            this.btSaveGluePath.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btSaveGluePath.Name = "btSaveGluePath";
            this.btSaveGluePath.Size = new System.Drawing.Size(74, 74);
            this.btSaveGluePath.TabIndex = 73;
            this.btSaveGluePath.UseVisualStyleBackColor = true;
            this.btSaveGluePath.Click += new System.EventHandler(this.btSaveGluePath_Click);
            // 
            // tkBGlueWidth
            // 
            this.tkBGlueWidth.Location = new System.Drawing.Point(96, 400);
            this.tkBGlueWidth.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tkBGlueWidth.Maximum = 50;
            this.tkBGlueWidth.Minimum = 1;
            this.tkBGlueWidth.Name = "tkBGlueWidth";
            this.tkBGlueWidth.Size = new System.Drawing.Size(194, 69);
            this.tkBGlueWidth.TabIndex = 80;
            this.tkBGlueWidth.Value = 3;
            this.tkBGlueWidth.ValueChanged += new System.EventHandler(this.tkbGlueWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 249);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 67;
            this.label2.Text = "像素坐标：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 484);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 79;
            this.label3.Text = "透明：";
            // 
            // lbPixelX
            // 
            this.lbPixelX.AutoSize = true;
            this.lbPixelX.Location = new System.Drawing.Point(136, 249);
            this.lbPixelX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPixelX.Name = "lbPixelX";
            this.lbPixelX.Size = new System.Drawing.Size(17, 18);
            this.lbPixelX.TabIndex = 68;
            this.lbPixelX.Text = "0";
            // 
            // tkBTransparency
            // 
            this.tkBTransparency.Location = new System.Drawing.Point(96, 468);
            this.tkBTransparency.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tkBTransparency.Maximum = 255;
            this.tkBTransparency.Name = "tkBTransparency";
            this.tkBTransparency.Size = new System.Drawing.Size(194, 69);
            this.tkBTransparency.TabIndex = 78;
            this.tkBTransparency.Value = 255;
            this.tkBTransparency.ValueChanged += new System.EventHandler(this.tkBTransparency_ValueChanged);
            // 
            // lbPixelY
            // 
            this.lbPixelY.AutoSize = true;
            this.lbPixelY.Location = new System.Drawing.Point(219, 249);
            this.lbPixelY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPixelY.Name = "lbPixelY";
            this.lbPixelY.Size = new System.Drawing.Size(17, 18);
            this.lbPixelY.TabIndex = 69;
            this.lbPixelY.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 422);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 77;
            this.label1.Text = "胶宽：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 549);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 70;
            this.label4.Text = "基准(pt)：";
            // 
            // tbStandardX
            // 
            this.tbStandardX.Location = new System.Drawing.Point(128, 543);
            this.tbStandardX.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbStandardX.Name = "tbStandardX";
            this.tbStandardX.Size = new System.Drawing.Size(76, 28);
            this.tbStandardX.TabIndex = 71;
            this.tbStandardX.Text = "0";
            // 
            // btOpenGluePath
            // 
            this.btOpenGluePath.BackgroundImage = global::GlueReadWrite.Properties.Resources.下载;
            this.btOpenGluePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btOpenGluePath.FlatAppearance.BorderSize = 0;
            this.btOpenGluePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenGluePath.Location = new System.Drawing.Point(69, 663);
            this.btOpenGluePath.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btOpenGluePath.Name = "btOpenGluePath";
            this.btOpenGluePath.Size = new System.Drawing.Size(74, 74);
            this.btOpenGluePath.TabIndex = 76;
            this.btOpenGluePath.UseVisualStyleBackColor = true;
            this.btOpenGluePath.Click += new System.EventHandler(this.btOpenGluePath_Click);
            // 
            // tbStandardY
            // 
            this.tbStandardY.Location = new System.Drawing.Point(230, 543);
            this.tbStandardY.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbStandardY.Name = "tbStandardY";
            this.tbStandardY.Size = new System.Drawing.Size(76, 28);
            this.tbStandardY.TabIndex = 72;
            this.tbStandardY.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 362);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 18);
            this.label6.TabIndex = 75;
            this.label6.Text = "图像缩放：";
            // 
            // lbZoom
            // 
            this.lbZoom.AutoSize = true;
            this.lbZoom.Location = new System.Drawing.Point(136, 362);
            this.lbZoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbZoom.Name = "lbZoom";
            this.lbZoom.Size = new System.Drawing.Size(17, 18);
            this.lbZoom.TabIndex = 74;
            this.lbZoom.Text = "1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(2014, 1140);
            this.splitContainer2.SplitterDistance = 742;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.cms_DataGridView;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 60;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(2014, 392);
            this.dataGridView.TabIndex = 5;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // cms_DataGridView
            // 
            this.cms_DataGridView.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_DataGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Append,
            this.ToolStripMenuItem_Insert,
            this.ToolStripMenuItem_Delete,
            this.ToolStripMenuItem_Clear});
            this.cms_DataGridView.Name = "cms_DataGridView";
            this.cms_DataGridView.Size = new System.Drawing.Size(153, 124);
            // 
            // ToolStripMenuItem_Append
            // 
            this.ToolStripMenuItem_Append.Name = "ToolStripMenuItem_Append";
            this.ToolStripMenuItem_Append.Size = new System.Drawing.Size(152, 30);
            this.ToolStripMenuItem_Append.Text = "追加行";
            this.ToolStripMenuItem_Append.Click += new System.EventHandler(this.ToolStripMenuItem_Append_Click);
            // 
            // ToolStripMenuItem_Insert
            // 
            this.ToolStripMenuItem_Insert.Name = "ToolStripMenuItem_Insert";
            this.ToolStripMenuItem_Insert.Size = new System.Drawing.Size(152, 30);
            this.ToolStripMenuItem_Insert.Text = "插入行";
            this.ToolStripMenuItem_Insert.Click += new System.EventHandler(this.ToolStripMenuItem_Insert_Click);
            // 
            // ToolStripMenuItem_Delete
            // 
            this.ToolStripMenuItem_Delete.Name = "ToolStripMenuItem_Delete";
            this.ToolStripMenuItem_Delete.Size = new System.Drawing.Size(152, 30);
            this.ToolStripMenuItem_Delete.Text = "删除行";
            this.ToolStripMenuItem_Delete.Click += new System.EventHandler(this.ToolStripMenuItem_Delete_Click);
            // 
            // ToolStripMenuItem_Clear
            // 
            this.ToolStripMenuItem_Clear.Name = "ToolStripMenuItem_Clear";
            this.ToolStripMenuItem_Clear.Size = new System.Drawing.Size(152, 30);
            this.ToolStripMenuItem_Clear.Text = "清除胶路";
            this.ToolStripMenuItem_Clear.Click += new System.EventHandler(this.ToolStripMenuItem_Clear_Click);
            // 
            // FormGluePath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(2014, 1140);
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "FormGluePath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form11";
            this.Load += new System.EventHandler(this.Form_GluePath_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cms_LoadPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkBGlueWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBTransparency)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.cms_DataGridView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ContextMenuStrip cms_DataGridView;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Append;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Delete;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Insert;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Clear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btCounterClockWise;
        private System.Windows.Forms.Button btClockWise;
        private System.Windows.Forms.TextBox tbRotation;
        private System.Windows.Forms.CheckBox cbWhole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCX;
        private System.Windows.Forms.Label lbCY;
        private System.Windows.Forms.Label lbTransparency;
        private System.Windows.Forms.Label lbGlueWidth;
        private System.Windows.Forms.Button btSaveGluePath;
        private System.Windows.Forms.TrackBar tkBGlueWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPixelX;
        private System.Windows.Forms.TrackBar tkBTransparency;
        private System.Windows.Forms.Label lbPixelY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStandardX;
        private System.Windows.Forms.Button btOpenGluePath;
        private System.Windows.Forms.TextBox tbStandardY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbZoom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPhyscialLength;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPixelsNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbPhysicX;
        private System.Windows.Forms.Label lbPhysicY;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbPictureX;
        private System.Windows.Forms.Label lbPictureY;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbCompensationX;
        private System.Windows.Forms.TextBox tbCompensationY;
        private System.Windows.Forms.ContextMenuStrip cms_LoadPicture;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_LoadPic;
    }
}

