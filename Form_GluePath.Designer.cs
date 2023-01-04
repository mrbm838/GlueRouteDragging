namespace GluePathReadWrite
{
    partial class Form_GluePath
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cms_SplitContainer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Fit = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lbAlpha = new System.Windows.Forms.Label();
            this.lbGlueWidth = new System.Windows.Forms.Label();
            this.tkBGlueWidth = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.tkBTransparency = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.cms_DataGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Append = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Insert = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cms_SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.splitContainer1.Panel1.ContextMenuStrip = this.cms_SplitContainer;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel2.Controls.Add(this.cartesianChart1);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Size = new System.Drawing.Size(1441, 550);
            this.splitContainer1.SplitterDistance = 728;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // cms_SplitContainer
            // 
            this.cms_SplitContainer.Enabled = false;
            this.cms_SplitContainer.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms_SplitContainer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Fit});
            this.cms_SplitContainer.Name = "cms_1";
            this.cms_SplitContainer.Size = new System.Drawing.Size(124, 28);
            // 
            // ToolStripMenuItem_Fit
            // 
            this.ToolStripMenuItem_Fit.Enabled = false;
            this.ToolStripMenuItem_Fit.Name = "ToolStripMenuItem_Fit";
            this.ToolStripMenuItem_Fit.Size = new System.Drawing.Size(123, 24);
            this.ToolStripMenuItem_Fit.Text = "自适应";
            this.ToolStripMenuItem_Fit.Click += new System.EventHandler(this.ToolStripMenuItem_Fit_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.ContextMenuStrip = this.cms_SplitContainer;
            this.pictureBox.Location = new System.Drawing.Point(4, 45);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(682, 440);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // lbAlpha
            // 
            this.lbAlpha.AutoSize = true;
            this.lbAlpha.Location = new System.Drawing.Point(1702, 369);
            this.lbAlpha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAlpha.Name = "lbAlpha";
            this.lbAlpha.Size = new System.Drawing.Size(15, 15);
            this.lbAlpha.TabIndex = 34;
            this.lbAlpha.Text = "0";
            // 
            // lbGlueWidth
            // 
            this.lbGlueWidth.AutoSize = true;
            this.lbGlueWidth.Location = new System.Drawing.Point(1702, 307);
            this.lbGlueWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGlueWidth.Name = "lbGlueWidth";
            this.lbGlueWidth.Size = new System.Drawing.Size(15, 15);
            this.lbGlueWidth.TabIndex = 33;
            this.lbGlueWidth.Text = "0";
            // 
            // tkBGlueWidth
            // 
            this.tkBGlueWidth.Location = new System.Drawing.Point(1520, 293);
            this.tkBGlueWidth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tkBGlueWidth.Name = "tkBGlueWidth";
            this.tkBGlueWidth.Size = new System.Drawing.Size(173, 56);
            this.tkBGlueWidth.TabIndex = 32;
            this.tkBGlueWidth.ValueChanged += new System.EventHandler(this.tkbGlueWidth_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1460, 369);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "透明：";
            // 
            // tkBTransparency
            // 
            this.tkBTransparency.Location = new System.Drawing.Point(1520, 355);
            this.tkBTransparency.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tkBTransparency.Name = "tkBTransparency";
            this.tkBTransparency.Size = new System.Drawing.Size(173, 56);
            this.tkBTransparency.TabIndex = 30;
            this.tkBTransparency.ValueChanged += new System.EventHandler(this.tkBTransparency_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1460, 307);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "胶宽：";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(1449, 110);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbPath.Multiline = true;
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(311, 28);
            this.tbPath.TabIndex = 23;
            // 
            // btOpenGluePath
            // 
            this.btOpenGluePath.BackgroundImage = global::GlueReadWrite.Properties.Resources.下载;
            this.btOpenGluePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btOpenGluePath.FlatAppearance.BorderSize = 0;
            this.btOpenGluePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenGluePath.Location = new System.Drawing.Point(1495, 29);
            this.btOpenGluePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btOpenGluePath.Name = "btOpenGluePath";
            this.btOpenGluePath.Size = new System.Drawing.Size(67, 62);
            this.btOpenGluePath.TabIndex = 22;
            this.btOpenGluePath.UseVisualStyleBackColor = true;
            this.btOpenGluePath.Click += new System.EventHandler(this.btOpenGluePath_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1460, 245);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "缩放：";
            // 
            // lbZoom
            // 
            this.lbZoom.AutoSize = true;
            this.lbZoom.Location = new System.Drawing.Point(1547, 245);
            this.lbZoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbZoom.Name = "lbZoom";
            this.lbZoom.Size = new System.Drawing.Size(15, 15);
            this.lbZoom.TabIndex = 20;
            this.lbZoom.Text = "1";
            // 
            // btSaveGluePath
            // 
            this.btSaveGluePath.BackgroundImage = global::GlueReadWrite.Properties.Resources.保存;
            this.btSaveGluePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSaveGluePath.FlatAppearance.BorderSize = 0;
            this.btSaveGluePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveGluePath.Location = new System.Drawing.Point(1650, 29);
            this.btSaveGluePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btSaveGluePath.Name = "btSaveGluePath";
            this.btSaveGluePath.Size = new System.Drawing.Size(67, 62);
            this.btSaveGluePath.TabIndex = 17;
            this.btSaveGluePath.UseVisualStyleBackColor = true;
            this.btSaveGluePath.Click += new System.EventHandler(this.btSaveGluePath_Click);
            // 
            // tbStandardY
            // 
            this.tbStandardY.Location = new System.Drawing.Point(1625, 432);
            this.tbStandardY.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbStandardY.Name = "tbStandardY";
            this.tbStandardY.Size = new System.Drawing.Size(68, 25);
            this.tbStandardY.TabIndex = 15;
            // 
            // tbStandardX
            // 
            this.tbStandardX.Location = new System.Drawing.Point(1533, 432);
            this.tbStandardX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbStandardX.Name = "tbStandardX";
            this.tbStandardX.Size = new System.Drawing.Size(68, 25);
            this.tbStandardX.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1460, 432);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "基准：";
            // 
            // lbPY
            // 
            this.lbPY.AutoSize = true;
            this.lbPY.Location = new System.Drawing.Point(1622, 182);
            this.lbPY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPY.Name = "lbPY";
            this.lbPY.Size = new System.Drawing.Size(15, 15);
            this.lbPY.TabIndex = 7;
            this.lbPY.Text = "0";
            // 
            // lbPX
            // 
            this.lbPX.AutoSize = true;
            this.lbPX.Location = new System.Drawing.Point(1547, 182);
            this.lbPX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPX.Name = "lbPX";
            this.lbPX.Size = new System.Drawing.Size(15, 15);
            this.lbPX.TabIndex = 6;
            this.lbPX.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1460, 182);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "坐标：";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer2.Location = new System.Drawing.Point(0, -76);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
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
            this.splitContainer2.Panel1.Controls.Add(this.tbPath);
            this.splitContainer2.Panel1.Controls.Add(this.tbStandardX);
            this.splitContainer2.Panel1.Controls.Add(this.btOpenGluePath);
            this.splitContainer2.Panel1.Controls.Add(this.tbStandardY);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.lbZoom);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(1782, 879);
            this.splitContainer2.SplitterDistance = 550;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.cms_DataGridView;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 60;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(1782, 324);
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
            this.cms_DataGridView.Size = new System.Drawing.Size(139, 100);
            // 
            // ToolStripMenuItem_Append
            // 
            this.ToolStripMenuItem_Append.Name = "ToolStripMenuItem_Append";
            this.ToolStripMenuItem_Append.Size = new System.Drawing.Size(138, 24);
            this.ToolStripMenuItem_Append.Text = "追加行";
            this.ToolStripMenuItem_Append.Click += new System.EventHandler(this.ToolStripMenuItem_Append_Click);
            // 
            // ToolStripMenuItem_Insert
            // 
            this.ToolStripMenuItem_Insert.Name = "ToolStripMenuItem_Insert";
            this.ToolStripMenuItem_Insert.Size = new System.Drawing.Size(138, 24);
            this.ToolStripMenuItem_Insert.Text = "插入行";
            this.ToolStripMenuItem_Insert.Click += new System.EventHandler(this.ToolStripMenuItem_Insert_Click);
            // 
            // ToolStripMenuItem_Delete
            // 
            this.ToolStripMenuItem_Delete.Name = "ToolStripMenuItem_Delete";
            this.ToolStripMenuItem_Delete.Size = new System.Drawing.Size(138, 24);
            this.ToolStripMenuItem_Delete.Text = "删除行";
            this.ToolStripMenuItem_Delete.Click += new System.EventHandler(this.ToolStripMenuItem_Delete_Click);
            // 
            // ToolStripMenuItem_Clear
            // 
            this.ToolStripMenuItem_Clear.Name = "ToolStripMenuItem_Clear";
            this.ToolStripMenuItem_Clear.Size = new System.Drawing.Size(138, 24);
            this.ToolStripMenuItem_Clear.Text = "清除胶路";
            this.ToolStripMenuItem_Clear.Click += new System.EventHandler(this.ToolStripMenuItem_Clear_Click);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(3, 29);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(702, 509);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // Form_GluePath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 803);
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form_GluePath";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_GluePath_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cms_SplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
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
        private System.Windows.Forms.ContextMenuStrip cms_SplitContainer;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Fit;
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
        private System.Windows.Forms.TextBox tbPath;
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
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
    }
}

