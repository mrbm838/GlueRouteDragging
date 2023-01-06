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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbAlpha = new System.Windows.Forms.Label();
            this.lbGlueWidth = new System.Windows.Forms.Label();
            this.tkBGlueWidth = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.tkBTransparency = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btOpenGluePath = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbZoom = new System.Windows.Forms.Label();
            this.btSaveGluePath = new System.Windows.Forms.Button();
            this.tbStandardY = new System.Windows.Forms.TextBox();
            this.tbStandardX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPY = new System.Windows.Forms.Label();
            this.lbPX = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCX = new System.Windows.Forms.Label();
            this.lbCY = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.cms_DataGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Append = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Insert = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
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
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
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
            this.splitContainer1.Panel2.Controls.Add(this.chart);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Size = new System.Drawing.Size(1621, 681);
            this.splitContainer1.SplitterDistance = 771;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.Location = new System.Drawing.Point(5, 54);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(763, 528);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ToolStripMenuItem_Fit_Click);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(2);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(844, 681);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart1";
            this.chart.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart_GetToolTipText);
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            this.chart.Validated += new System.EventHandler(this.chart_Validated);
            // 
            // lbAlpha
            // 
            this.lbAlpha.AutoSize = true;
            this.lbAlpha.Location = new System.Drawing.Point(1914, 443);
            this.lbAlpha.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbAlpha.Name = "lbAlpha";
            this.lbAlpha.Size = new System.Drawing.Size(17, 18);
            this.lbAlpha.TabIndex = 34;
            this.lbAlpha.Text = "0";
            // 
            // lbGlueWidth
            // 
            this.lbGlueWidth.AutoSize = true;
            this.lbGlueWidth.Location = new System.Drawing.Point(1914, 370);
            this.lbGlueWidth.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbGlueWidth.Name = "lbGlueWidth";
            this.lbGlueWidth.Size = new System.Drawing.Size(17, 18);
            this.lbGlueWidth.TabIndex = 33;
            this.lbGlueWidth.Text = "0";
            // 
            // tkBGlueWidth
            // 
            this.tkBGlueWidth.Location = new System.Drawing.Point(1710, 350);
            this.tkBGlueWidth.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tkBGlueWidth.Name = "tkBGlueWidth";
            this.tkBGlueWidth.Size = new System.Drawing.Size(194, 69);
            this.tkBGlueWidth.TabIndex = 32;
            this.tkBGlueWidth.ValueChanged += new System.EventHandler(this.tkbGlueWidth_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1643, 443);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "透明：";
            // 
            // tkBTransparency
            // 
            this.tkBTransparency.Location = new System.Drawing.Point(1710, 426);
            this.tkBTransparency.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tkBTransparency.Name = "tkBTransparency";
            this.tkBTransparency.Size = new System.Drawing.Size(194, 69);
            this.tkBTransparency.TabIndex = 30;
            this.tkBTransparency.ValueChanged += new System.EventHandler(this.tkBTransparency_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1643, 370);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "胶宽：";
            // 
            // btOpenGluePath
            // 
            this.btOpenGluePath.BackgroundImage = global::GlueReadWrite.Properties.Resources.下载;
            this.btOpenGluePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btOpenGluePath.FlatAppearance.BorderSize = 0;
            this.btOpenGluePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenGluePath.Location = new System.Drawing.Point(1671, 579);
            this.btOpenGluePath.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btOpenGluePath.Name = "btOpenGluePath";
            this.btOpenGluePath.Size = new System.Drawing.Size(74, 74);
            this.btOpenGluePath.TabIndex = 22;
            this.btOpenGluePath.UseVisualStyleBackColor = true;
            this.btOpenGluePath.Click += new System.EventHandler(this.btOpenGluePath_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1643, 294);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "缩放：";
            // 
            // lbZoom
            // 
            this.lbZoom.AutoSize = true;
            this.lbZoom.Location = new System.Drawing.Point(1740, 294);
            this.lbZoom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbZoom.Name = "lbZoom";
            this.lbZoom.Size = new System.Drawing.Size(17, 18);
            this.lbZoom.TabIndex = 20;
            this.lbZoom.Text = "1";
            // 
            // btSaveGluePath
            // 
            this.btSaveGluePath.BackgroundImage = global::GlueReadWrite.Properties.Resources.保存;
            this.btSaveGluePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSaveGluePath.FlatAppearance.BorderSize = 0;
            this.btSaveGluePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveGluePath.Location = new System.Drawing.Point(1848, 579);
            this.btSaveGluePath.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btSaveGluePath.Name = "btSaveGluePath";
            this.btSaveGluePath.Size = new System.Drawing.Size(74, 74);
            this.btSaveGluePath.TabIndex = 17;
            this.btSaveGluePath.UseVisualStyleBackColor = true;
            this.btSaveGluePath.Click += new System.EventHandler(this.btSaveGluePath_Click);
            // 
            // tbStandardY
            // 
            this.tbStandardY.Location = new System.Drawing.Point(1829, 518);
            this.tbStandardY.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tbStandardY.Name = "tbStandardY";
            this.tbStandardY.Size = new System.Drawing.Size(76, 28);
            this.tbStandardY.TabIndex = 15;
            // 
            // tbStandardX
            // 
            this.tbStandardX.Location = new System.Drawing.Point(1726, 518);
            this.tbStandardX.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.tbStandardX.Name = "tbStandardX";
            this.tbStandardX.Size = new System.Drawing.Size(76, 28);
            this.tbStandardX.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1643, 518);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "基准：";
            // 
            // lbPY
            // 
            this.lbPY.AutoSize = true;
            this.lbPY.Location = new System.Drawing.Point(1825, 218);
            this.lbPY.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbPY.Name = "lbPY";
            this.lbPY.Size = new System.Drawing.Size(17, 18);
            this.lbPY.TabIndex = 7;
            this.lbPY.Text = "0";
            // 
            // lbPX
            // 
            this.lbPX.AutoSize = true;
            this.lbPX.Location = new System.Drawing.Point(1751, 218);
            this.lbPX.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbPX.Name = "lbPX";
            this.lbPX.Size = new System.Drawing.Size(17, 18);
            this.lbPX.TabIndex = 6;
            this.lbPX.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1643, 218);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "图片坐标：";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.button2);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.textBox1);
            this.splitContainer2.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.lbCX);
            this.splitContainer2.Panel1.Controls.Add(this.lbCY);
            this.splitContainer2.Panel1.Controls.Add(this.lbAlpha);
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel1.Controls.Add(this.lbGlueWidth);
            this.splitContainer2.Panel1.Controls.Add(this.btSaveGluePath);
            this.splitContainer2.Panel1.Controls.Add(this.tkBGlueWidth);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.lbPX);
            this.splitContainer2.Panel1.Controls.Add(this.tkBTransparency);
            this.splitContainer2.Panel1.Controls.Add(this.lbPY);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.tbStandardX);
            this.splitContainer2.Panel1.Controls.Add(this.btOpenGluePath);
            this.splitContainer2.Panel1.Controls.Add(this.tbStandardY);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.lbZoom);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(1985, 1055);
            this.splitContainer2.SplitterDistance = 681;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1855, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 14);
            this.button2.TabIndex = 41;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1855, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 14);
            this.button1.TabIndex = 40;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1765, 54);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 28);
            this.textBox1.TabIndex = 39;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1653, 140);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 22);
            this.checkBox1.TabIndex = 38;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1643, 253);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 35;
            this.label5.Text = "表格坐标：";
            // 
            // lbCX
            // 
            this.lbCX.AutoSize = true;
            this.lbCX.Location = new System.Drawing.Point(1751, 253);
            this.lbCX.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbCX.Name = "lbCX";
            this.lbCX.Size = new System.Drawing.Size(17, 18);
            this.lbCX.TabIndex = 36;
            this.lbCX.Text = "0";
            // 
            // lbCY
            // 
            this.lbCY.AutoSize = true;
            this.lbCY.Location = new System.Drawing.Point(1825, 253);
            this.lbCY.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbCY.Name = "lbCY";
            this.lbCY.Size = new System.Drawing.Size(17, 18);
            this.lbCY.TabIndex = 37;
            this.lbCY.Text = "0";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.cms_DataGridView;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 60;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(1985, 368);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(1650, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 21);
            this.label7.TabIndex = 42;
            this.label7.Text = "旋转角度：";
            // 
            // FormGluePath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1985, 1055);
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
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
            ((System.ComponentModel.ISupportInitialize)(this.tkBGlueWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBTransparency)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPY;
        private System.Windows.Forms.Label lbPX;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox tbStandardY;
        private System.Windows.Forms.TextBox tbStandardX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btSaveGluePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbZoom;
        private System.Windows.Forms.Button btOpenGluePath;
        private System.Windows.Forms.ContextMenuStrip cms_DataGridView;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Append;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tkBTransparency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tkBGlueWidth;
        private System.Windows.Forms.Label lbAlpha;
        private System.Windows.Forms.Label lbGlueWidth;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Insert;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Clear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCX;
        private System.Windows.Forms.Label lbCY;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
    }
}

