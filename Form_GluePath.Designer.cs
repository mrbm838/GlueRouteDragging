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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPhyscialLength = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPixelsNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.lbPX = new System.Windows.Forms.Label();
            this.tkBTransparency = new System.Windows.Forms.TrackBar();
            this.lbPY = new System.Windows.Forms.Label();
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
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.chart);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Size = new System.Drawing.Size(1343, 452);
            this.splitContainer1.SplitterDistance = 541;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.Location = new System.Drawing.Point(3, 36);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(509, 352);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ToolStripMenuItem_Fit_Click);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(569, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 452);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Dock = System.Windows.Forms.DockStyle.Left;
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(1);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(569, 452);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart1";
            this.chart.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart_GetToolTipText);
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            this.chart.Validated += new System.EventHandler(this.chart_Validated);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tbPhyscialLength);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tbPixelsNumber);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
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
            this.panel1.Controls.Add(this.lbPX);
            this.panel1.Controls.Add(this.tkBTransparency);
            this.panel1.Controls.Add(this.lbPY);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbStandardX);
            this.panel1.Controls.Add(this.btOpenGluePath);
            this.panel1.Controls.Add(this.tbStandardY);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbZoom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(573, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 452);
            this.panel1.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 94;
            this.label9.Text = "长边物理长度：";
            // 
            // tbPhyscialLength
            // 
            this.tbPhyscialLength.Location = new System.Drawing.Point(114, 135);
            this.tbPhyscialLength.Name = "tbPhyscialLength";
            this.tbPhyscialLength.Size = new System.Drawing.Size(43, 21);
            this.tbPhyscialLength.TabIndex = 93;
            this.tbPhyscialLength.Text = "20";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 92;
            this.label8.Text = "长边像素数量：";
            // 
            // tbPixelsNumber
            // 
            this.tbPixelsNumber.Location = new System.Drawing.Point(114, 103);
            this.tbPixelsNumber.Name = "tbPixelsNumber";
            this.tbPixelsNumber.Size = new System.Drawing.Size(43, 21);
            this.tbPixelsNumber.TabIndex = 91;
            this.tbPixelsNumber.Text = "2448";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(18, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 90;
            this.label7.Text = "旋转角度：";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::GlueReadWrite.Properties.Resources.xiangxia;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(161, 43);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 11);
            this.button2.TabIndex = 89;
            this.button2.Text = "b";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::GlueReadWrite.Properties.Resources.xiangshang;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(161, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 10);
            this.button1.TabIndex = 88;
            this.button1.Text = "b";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbRotation
            // 
            this.tbRotation.Location = new System.Drawing.Point(101, 29);
            this.tbRotation.Name = "tbRotation";
            this.tbRotation.Size = new System.Drawing.Size(87, 21);
            this.tbRotation.TabIndex = 87;
            this.tbRotation.Text = "0.1";
            // 
            // cbWhole
            // 
            this.cbWhole.AutoSize = true;
            this.cbWhole.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWhole.Location = new System.Drawing.Point(18, 65);
            this.cbWhole.Name = "cbWhole";
            this.cbWhole.Size = new System.Drawing.Size(90, 20);
            this.cbWhole.TabIndex = 86;
            this.cbWhole.Text = "整体移动";
            this.cbWhole.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 83;
            this.label5.Text = "表格坐标：";
            // 
            // lbCX
            // 
            this.lbCX.AutoSize = true;
            this.lbCX.Location = new System.Drawing.Point(91, 201);
            this.lbCX.Name = "lbCX";
            this.lbCX.Size = new System.Drawing.Size(11, 12);
            this.lbCX.TabIndex = 84;
            this.lbCX.Text = "0";
            // 
            // lbCY
            // 
            this.lbCY.AutoSize = true;
            this.lbCY.Location = new System.Drawing.Point(146, 201);
            this.lbCY.Name = "lbCY";
            this.lbCY.Size = new System.Drawing.Size(11, 12);
            this.lbCY.TabIndex = 85;
            this.lbCY.Text = "0";
            // 
            // lbTransparency
            // 
            this.lbTransparency.AutoSize = true;
            this.lbTransparency.Location = new System.Drawing.Point(195, 314);
            this.lbTransparency.Name = "lbTransparency";
            this.lbTransparency.Size = new System.Drawing.Size(11, 12);
            this.lbTransparency.TabIndex = 82;
            this.lbTransparency.Text = "0";
            // 
            // lbGlueWidth
            // 
            this.lbGlueWidth.AutoSize = true;
            this.lbGlueWidth.Location = new System.Drawing.Point(195, 263);
            this.lbGlueWidth.Name = "lbGlueWidth";
            this.lbGlueWidth.Size = new System.Drawing.Size(11, 12);
            this.lbGlueWidth.TabIndex = 81;
            this.lbGlueWidth.Text = "0";
            // 
            // btSaveGluePath
            // 
            this.btSaveGluePath.BackgroundImage = global::GlueReadWrite.Properties.Resources.保存;
            this.btSaveGluePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSaveGluePath.FlatAppearance.BorderSize = 0;
            this.btSaveGluePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveGluePath.Location = new System.Drawing.Point(139, 393);
            this.btSaveGluePath.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btSaveGluePath.Name = "btSaveGluePath";
            this.btSaveGluePath.Size = new System.Drawing.Size(49, 49);
            this.btSaveGluePath.TabIndex = 73;
            this.btSaveGluePath.UseVisualStyleBackColor = true;
            // 
            // tkBGlueWidth
            // 
            this.tkBGlueWidth.Location = new System.Drawing.Point(64, 260);
            this.tkBGlueWidth.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tkBGlueWidth.Maximum = 50;
            this.tkBGlueWidth.Minimum = 1;
            this.tkBGlueWidth.Name = "tkBGlueWidth";
            this.tkBGlueWidth.Size = new System.Drawing.Size(129, 45);
            this.tkBGlueWidth.TabIndex = 80;
            this.tkBGlueWidth.Value = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 67;
            this.label2.Text = "像素坐标：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 79;
            this.label3.Text = "透明：";
            // 
            // lbPX
            // 
            this.lbPX.AutoSize = true;
            this.lbPX.Location = new System.Drawing.Point(91, 177);
            this.lbPX.Name = "lbPX";
            this.lbPX.Size = new System.Drawing.Size(11, 12);
            this.lbPX.TabIndex = 68;
            this.lbPX.Text = "0";
            // 
            // tkBTransparency
            // 
            this.tkBTransparency.Location = new System.Drawing.Point(64, 305);
            this.tkBTransparency.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tkBTransparency.Maximum = 255;
            this.tkBTransparency.Name = "tkBTransparency";
            this.tkBTransparency.Size = new System.Drawing.Size(129, 45);
            this.tkBTransparency.TabIndex = 78;
            this.tkBTransparency.Value = 255;
            // 
            // lbPY
            // 
            this.lbPY.AutoSize = true;
            this.lbPY.Location = new System.Drawing.Point(146, 177);
            this.lbPY.Name = "lbPY";
            this.lbPY.Size = new System.Drawing.Size(11, 12);
            this.lbPY.TabIndex = 69;
            this.lbPY.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 77;
            this.label1.Text = "胶宽：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 70;
            this.label4.Text = "基准：";
            // 
            // tbStandardX
            // 
            this.tbStandardX.Location = new System.Drawing.Point(75, 353);
            this.tbStandardX.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbStandardX.Name = "tbStandardX";
            this.tbStandardX.Size = new System.Drawing.Size(52, 21);
            this.tbStandardX.TabIndex = 71;
            // 
            // btOpenGluePath
            // 
            this.btOpenGluePath.BackgroundImage = global::GlueReadWrite.Properties.Resources.下载;
            this.btOpenGluePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btOpenGluePath.FlatAppearance.BorderSize = 0;
            this.btOpenGluePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenGluePath.Location = new System.Drawing.Point(48, 393);
            this.btOpenGluePath.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btOpenGluePath.Name = "btOpenGluePath";
            this.btOpenGluePath.Size = new System.Drawing.Size(49, 49);
            this.btOpenGluePath.TabIndex = 76;
            this.btOpenGluePath.UseVisualStyleBackColor = true;
            // 
            // tbStandardY
            // 
            this.tbStandardY.Location = new System.Drawing.Point(143, 353);
            this.tbStandardY.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tbStandardY.Name = "tbStandardY";
            this.tbStandardY.Size = new System.Drawing.Size(52, 21);
            this.tbStandardY.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 75;
            this.label6.Text = "图像缩放：";
            // 
            // lbZoom
            // 
            this.lbZoom.AutoSize = true;
            this.lbZoom.Location = new System.Drawing.Point(91, 228);
            this.lbZoom.Name = "lbZoom";
            this.lbZoom.Size = new System.Drawing.Size(11, 12);
            this.lbZoom.TabIndex = 74;
            this.lbZoom.Text = "1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
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
            this.splitContainer2.Size = new System.Drawing.Size(1343, 703);
            this.splitContainer2.SplitterDistance = 452;
            this.splitContainer2.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.cms_DataGridView;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 60;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(1343, 247);
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
            this.cms_DataGridView.Size = new System.Drawing.Size(125, 92);
            // 
            // ToolStripMenuItem_Append
            // 
            this.ToolStripMenuItem_Append.Name = "ToolStripMenuItem_Append";
            this.ToolStripMenuItem_Append.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_Append.Text = "追加行";
            this.ToolStripMenuItem_Append.Click += new System.EventHandler(this.ToolStripMenuItem_Append_Click);
            // 
            // ToolStripMenuItem_Insert
            // 
            this.ToolStripMenuItem_Insert.Name = "ToolStripMenuItem_Insert";
            this.ToolStripMenuItem_Insert.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_Insert.Text = "插入行";
            this.ToolStripMenuItem_Insert.Click += new System.EventHandler(this.ToolStripMenuItem_Insert_Click);
            // 
            // ToolStripMenuItem_Delete
            // 
            this.ToolStripMenuItem_Delete.Name = "ToolStripMenuItem_Delete";
            this.ToolStripMenuItem_Delete.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_Delete.Text = "删除行";
            this.ToolStripMenuItem_Delete.Click += new System.EventHandler(this.ToolStripMenuItem_Delete_Click);
            // 
            // ToolStripMenuItem_Clear
            // 
            this.ToolStripMenuItem_Clear.Name = "ToolStripMenuItem_Clear";
            this.ToolStripMenuItem_Clear.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_Clear.Text = "清除胶路";
            this.ToolStripMenuItem_Clear.Click += new System.EventHandler(this.ToolStripMenuItem_Clear_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(159, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 95;
            this.label10.Text = "pt";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(159, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 96;
            this.label11.Text = "mm";
            // 
            // FormGluePath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1343, 703);
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "FormGluePath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form11";
            this.Load += new System.EventHandler(this.Form_GluePath_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.Label lbPX;
        private System.Windows.Forms.TrackBar tkBTransparency;
        private System.Windows.Forms.Label lbPY;
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
    }
}

