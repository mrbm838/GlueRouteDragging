using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GluePathReadWrite
{
    public partial class Form_GluePath : Form
    {
        int xPos;
        int yPos;
        bool MoveFlag;

        public Pen penRed = new Pen(Color.Red, 5);
        public Pen penBlue = new Pen(Color.Blue, 5);
        public Pen penGreen = new Pen(Color.Green, 5);
        Graphics graph;

        string[,] strPathData;
        string[] strPathT;

        public double dMultiplyingG = 1;
        public double dMultiplyingP = 1;

        double dPictureBox1Width;
        double dPictureBox1Height;
        double dPictureBox1ImageWidth;
        double dPictureBox1ImageHeight;

        private readonly DataGridViewComboBoxCell[] aCellComboBox1 = new DataGridViewComboBoxCell[50];
        private readonly DataGridViewComboBoxCell[] aCellComboBox2 = new DataGridViewComboBoxCell[50];

        double dBShiftPK;

        public Form_GluePath()
        {
            InitializeComponent();
            pictureBox1.MouseWheel += new MouseEventHandler(pbxDrawing_MouseWheel);
            dataGridView1.AllowUserToAddRows = false;
            //splitContainer1.Panel1.MouseWheel += new MouseEventHandler(pbxDrawing_MouseWheel);
        }

        private void Form_GluePath_Load(object sender, EventArgs e)
        {
            Bitmap bmp = ReadImageFile(Application.StartupPath.ToString() + @"\File\Image3.BMP");
            pictureBox1.Image = bmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            SetPitureBox();

            dPictureBox1Width = pictureBox1.Width;
            dPictureBox1Height = pictureBox1.Height;
            dPictureBox1ImageWidth = pictureBox1.Image.Width;
            dPictureBox1ImageHeight = pictureBox1.Image.Height;

            tbStandardX.Text = "230";
            tbStandardY.Text = "195";

            graph = this.pictureBox1.CreateGraphics();

            tkBGlueWidth.Maximum = 100;
            tkBGlueWidth.Minimum = 1;
            tkBGlueWidth.TickFrequency = 10;
            tkBGlueWidth.SmallChange = 1;
            tkBGlueWidth.Value = 5;

            tkBTransparency.Maximum = 255;
            tkBTransparency.Minimum = 0;
            tkBTransparency.TickFrequency = 25;
            tkBTransparency.SmallChange = 1;
            tkBTransparency.Value = 255;
        }

        private void btOpenGluePath_Click(object sender, EventArgs e)
        {
            string strFilePath = OpenFileDialog(Application.StartupPath.ToString());
            if (strFilePath != "")
            {
                tbPath.Text = strFilePath;
                WriteToDataGridView(ReadFileGluePath(strFilePath));
                CreateGUIPoint();
                CreateGUILine();
            }
        }

        private string OpenFileDialog(string strPath)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = strPath;
                ofd.Filter = "(*.txt)|*.txt";
                ofd.Title = "请选择文件";
                ofd.Multiselect = false;
                ofd.CheckPathExists = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
            }
            return string.Empty;
        }

        public static Bitmap ReadImageFile(string path)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(path);
            int filelength = (int)fs.Length; //获得文件长度 
            Byte[] image = new Byte[filelength]; //建立一个字节数组 
            fs.Read(image, 0, filelength); //按字节流读取 
            System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
            fs.Close();
            Bitmap bit = new Bitmap(result);
            return bit;
        }

        private void pbxDrawing_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)//缩小
                {
                    if (0.1 < dMultiplyingG)
                        dMultiplyingP = 0.9;
                    else
                        dMultiplyingP = 1;
                }
                else//放大
                {
                    if (dMultiplyingG < 30)
                        dMultiplyingP = 1.1;
                    else
                        dMultiplyingP = 1;
                }
                dMultiplyingG *= dMultiplyingP;
                //lbM.Text = dMultiplyingG.ToString();

                this.pictureBox1.Width = Convert.ToInt32(dPictureBox1Width * dMultiplyingG);
                this.pictureBox1.Height = Convert.ToInt32(dPictureBox1Height * dMultiplyingG);
                this.pictureBox1.Left += Convert.ToInt32(e.X - dMultiplyingP * e.X);
                this.pictureBox1.Top += Convert.ToInt32(e.Y - dMultiplyingP * e.Y);
                dBShiftPK = Convert.ToDouble(pictureBox1.Image.Width) / Convert.ToDouble(pictureBox1.Width);
                lbK.Text = (1 / dBShiftPK).ToString("0.000");

                CreateGUIPoint();
                CreateGUILine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                MoveFlag = false;
                CreateGUIPoint();
                CreateGUILine();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (MoveFlag)
                {
                    pictureBox1.Left += Convert.ToInt16(e.X - xPos);
                    pictureBox1.Top += Convert.ToInt16(e.Y - yPos);
                }
            }

            lbPX.Text = (dPictureBox1ImageWidth * Convert.ToDouble(e.X) / Convert.ToDouble(pictureBox1.Width)).ToString("0.000");
            lbPY.Text = (dPictureBox1ImageHeight * Convert.ToDouble(e.Y) / Convert.ToDouble(pictureBox1.Height)).ToString("0.000");
            //lbBoxX.Text = e.X.ToString();
            //lbBoxY.Text = e.Y.ToString();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                this.pictureBox1.Focus();
                MoveFlag = true;
                xPos = e.X;
                yPos = e.Y;
            }

            else if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++) //遍历行
                {
                    if (dataGridView1.Rows[i].Cells[1].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "Line")
                        {
                            dataGridView1.Rows[i].Cells[3].Value = "-";
                            dataGridView1.Rows[i].Cells[4].Value = "-";
                            dataGridView1.Rows[i].Cells[3].ReadOnly = true;
                            dataGridView1.Rows[i].Cells[4].ReadOnly = true;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[3].ReadOnly = false;
                            dataGridView1.Rows[i].Cells[4].ReadOnly = false;
                        }
                    }
                    if (dataGridView1.Rows[i].Cells[6].Selected || dataGridView1.Rows[i].Cells[7].Selected)
                    {
                        dataGridView1.Rows[i].Cells[6].Value = Convert.ToDouble((e.X * dBShiftPK).ToString("0.000")) - Convert.ToDouble(tbStandardX.Text);
                        dataGridView1.Rows[i].Cells[7].Value = Convert.ToDouble((e.Y * dBShiftPK).ToString("0.000")) - Convert.ToDouble(tbStandardY.Text);
                    }
                    else if (dataGridView1.Rows[i].Cells[3].Selected || dataGridView1.Rows[i].Cells[4].Selected)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "Arc")
                        {
                            dataGridView1.Rows[i].Cells[3].Value = Convert.ToDouble((e.X * dBShiftPK).ToString("0.000")) - Convert.ToDouble(tbStandardX.Text);
                            dataGridView1.Rows[i].Cells[4].Value = Convert.ToDouble((e.Y * dBShiftPK).ToString("0.000")) - Convert.ToDouble(tbStandardY.Text);
                        }
                    }
                    CreateGUIPoint();
                    CreateGUILine();
                }
            }
        }

        private void 自适应ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPitureBox();
            dMultiplyingG = 1;
            CreateGUIPoint();
            CreateGUILine();
        }

        private void SetPitureBox()
        {
            splitContainer1.Panel1.AutoScroll = false;
            pictureBox1.Width = pictureBox1.Image.Width;
            pictureBox1.Height = pictureBox1.Image.Height;
            if ((Convert.ToDouble(splitContainer1.Panel1.Width) / Convert.ToDouble(splitContainer1.Panel1.Height))
                < (Convert.ToDouble(pictureBox1.Width) / Convert.ToDouble(pictureBox1.Height)))
            {
                pictureBox1.Width = splitContainer1.Panel1.Width;
                pictureBox1.Height = Convert.ToInt32(pictureBox1.Width * (Convert.ToDouble(pictureBox1.Image.Height) / Convert.ToDouble(pictureBox1.Image.Width)));
                this.pictureBox1.Left = 0;
                this.pictureBox1.Top = (splitContainer1.Panel1.Height - pictureBox1.Height) / 2;
            }
            else
            {
                pictureBox1.Height = splitContainer1.Panel1.Height;
                pictureBox1.Width = Convert.ToInt32(pictureBox1.Height * (Convert.ToDouble(pictureBox1.Image.Width) / Convert.ToDouble(pictureBox1.Image.Height)));
                this.pictureBox1.Left = (splitContainer1.Panel1.Width - pictureBox1.Width) / 2;
                this.pictureBox1.Top = 0;
            }

            dBShiftPK = Convert.ToDouble(pictureBox1.Image.Width) / Convert.ToDouble(pictureBox1.Width);
            lbK.Text = (1 / dBShiftPK).ToString("0.000");
        }

        private void WriteToDataGridView(string[] strTxt)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            string[] str_1 = strTxt[0].Split(',');
            strPathData = new string[strTxt.Count(), str_1.Count()];
            strPathT = new string[str_1.Count()];

            for (int i = 0; i < str_1.Count(); i++)//添加列
            {
                dataGridView1.Columns.Add("column" + str_1[i].Split(':')[0], str_1[i].Split(':')[0]);
                dataGridView1.Columns[i].Width = 65;
            }

            string[] str_2;
            for (int i = 0; i < strTxt.Count(); i++)//添加行
            {
                str_2 = strTxt[i].Split(',');
                this.dataGridView1.Rows.Add();
                for (int j = 0; j < str_2.Count(); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = str_2[j].Split(':')[1];
                    strPathData[i, j] = str_2[j].Split(':')[1];
                    if (i == 0)
                        strPathT[j] = str_2[j].Split(':')[0];
                }
            }

            for (int i = 0; i < strTxt.Count(); i++)
            {
                aCellComboBox1[i] = new DataGridViewComboBoxCell();
                aCellComboBox1[i].Items.Add("");
                aCellComboBox1[i].Items.Add("Line");
                aCellComboBox1[i].Items.Add("Arc");
                dataGridView1.Rows[i].Cells[1] = (DataGridViewCell)aCellComboBox1[i];

                aCellComboBox2[i] = new DataGridViewComboBoxCell();
                aCellComboBox2[i].Items.Add("");
                aCellComboBox2[i].Items.Add("XY");
                aCellComboBox2[i].Items.Add("XYZ");
                dataGridView1.Rows[i].Cells[2] = (DataGridViewCell)aCellComboBox2[i];

                if (strTxt[i].Split(',')[1].Split(':')[1] == "1")
                {
                    dataGridView1.Rows[i].Cells[1].Value = "Arc";
                    dataGridView1.Rows[i].Cells[2].Value = "XY";
                }
                else if (strTxt[i].Split(',')[1].Split(':')[1] == "0")
                {
                    dataGridView1.Rows[i].Cells[1].Value = "Line";
                    dataGridView1.Rows[i].Cells[3].ReadOnly = true;
                    dataGridView1.Rows[i].Cells[4].ReadOnly = true;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[1].Value = "";
                }
            }


        }

        public string[] ReadFileGluePath(string path)
        {
            string[] strLine1 = new string[100];
            System.IO.StreamReader sr = new System.IO.StreamReader(path, Encoding.Default);
            String line;
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                strLine1[i] = line.ToString();
                i++;
            }
            string[] strLine2 = new string[i];
            for (int j = 0; j < i; j++)
            {
                strLine2[j] = strLine1[j];
            }
            sr.Dispose();
            return strLine2;
        }

        public void CreateGUILine()
        {
            //if (!tbShowGluePath.Checked) return;
            penRed.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / dBShiftPK);
            penBlue.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / dBShiftPK);
            Point pS = new Point();
            Point pM = new Point();
            Point pE = new Point();
            for (int i = 1; i < dataGridView1.RowCount; i++)
            {
                try
                {
                    if (dataGridView1.Rows[i].Cells[1].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "Line")
                        {
                            if (IsNumberic(dataGridView1.Rows[i].Cells[6].Value) && IsNumberic(dataGridView1.Rows[i].Cells[7].Value) &&
                                IsNumberic(dataGridView1.Rows[i - 1].Cells[6].Value) && IsNumberic(dataGridView1.Rows[i - 1].Cells[7].Value))
                            {
                                pS.X = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[6].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                                pS.Y = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[7].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);
                                pE.X = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                                pE.Y = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);
                                if (dataGridView1.Rows[i].Cells[6].Selected || dataGridView1.Rows[i].Cells[7].Selected)
                                {
                                    graph.DrawLine(penBlue, pS, pE);
                                }
                                else
                                {
                                    graph.DrawLine(penRed, pS, pE);
                                }
                            }
                        }
                        else if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "Arc")
                        {
                            if (IsNumberic(dataGridView1.Rows[i].Cells[3].Value) && IsNumberic(dataGridView1.Rows[i].Cells[4].Value) &&
                                IsNumberic(dataGridView1.Rows[i].Cells[6].Value) && IsNumberic(dataGridView1.Rows[i].Cells[7].Value) &&
                                IsNumberic(dataGridView1.Rows[i - 1].Cells[6].Value) && IsNumberic(dataGridView1.Rows[i - 1].Cells[7].Value))
                            {
                                pS.X = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[6].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                                pS.Y = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[7].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);
                                pM.X = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                                pM.Y = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);
                                pE.X = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                                pE.Y = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);
                                if (dataGridView1.Rows[i].Cells[3].Selected || dataGridView1.Rows[i].Cells[4].Selected || dataGridView1.Rows[i].Cells[6].Selected || dataGridView1.Rows[i].Cells[7].Selected)
                                {
                                    DrawArc(penBlue, pS.X, pS.Y, pM.X, pM.Y, pE.X, pE.Y);
                                }
                                else
                                {
                                    DrawArc(penRed, pS.X, pS.Y, pM.X, pM.Y, pE.X, pE.Y);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void CreateGUIPoint()//string sName, Point p
        {
            penRed.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / dBShiftPK);
            penBlue.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / dBShiftPK);
            penGreen.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / dBShiftPK);
            pictureBox1.Refresh();

            int iStandardX = Convert.ToInt32(Convert.ToDouble(tbStandardX.Text) / dBShiftPK);
            int iStandardY = Convert.ToInt32(Convert.ToDouble(tbStandardY.Text) / dBShiftPK);
            //graph.FillEllipse(Brushes.Black, iStandardX - 3, iStandardY - 3, 6, 6);
            graph.DrawArc(penGreen, iStandardX - 3, iStandardY - 3, 6, 6, 0, 360);
            graph.DrawString("0", new Font("Verdana", 12), new SolidBrush(Color.Green), new PointF(iStandardX, iStandardY - 20));

            Point pT = new Point();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (IsNumberic(dataGridView1.Rows[i].Cells[3].Value) && IsNumberic(dataGridView1.Rows[i].Cells[4].Value))
                {
                    pT.X = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                    pT.Y = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);

                    if (dataGridView1.Rows[i].Cells[3].Selected || dataGridView1.Rows[i].Cells[4].Selected)
                    {
                        graph.DrawArc(penBlue, pT.X - 3, pT.Y - 3, 6, 6, 0, 360);
                        graph.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString() + "-1", new Font("Verdana", 12), new SolidBrush(Color.Blue), new PointF(pT.X, pT.Y - 20));
                    }
                    else
                    {
                        graph.DrawArc(penRed, pT.X - 3, pT.Y - 3, 6, 6, 0, 360);
                        graph.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString() + "-1", new Font("Verdana", 12), new SolidBrush(Color.Red), new PointF(pT.X, pT.Y - 20));
                    }
                }
                if (IsNumberic(dataGridView1.Rows[i].Cells[6].Value) && IsNumberic(dataGridView1.Rows[i].Cells[7].Value))
                {
                    pT.X = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                    pT.Y = Convert.ToInt32((Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);

                    if (dataGridView1.Rows[i].Cells[6].Selected || dataGridView1.Rows[i].Cells[7].Selected)
                    {
                        graph.DrawArc(penBlue, pT.X - 3, pT.Y - 3, 6, 6, 0, 360);
                        graph.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), new Font("Verdana", 12), new SolidBrush(Color.Blue), new PointF(pT.X, pT.Y - 20));
                    }
                    else
                    {
                        graph.DrawArc(penRed, pT.X - 3, pT.Y - 3, 6, 6, 0, 360);
                        graph.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), new Font("Verdana", 12), new SolidBrush(Color.Red), new PointF(pT.X, pT.Y - 20));
                    }
                }
            }
        }

        /// <summary>
        /// 根据三点画圆弧
        /// </summary>
        /// <param name="dX1">第一个点的X坐标</param>
        /// <param name="dY1">第一个点的Y坐标</param>
        /// <param name="dX2">第二个点的X坐标</param>
        /// <param name="dY2">第二个点的Y坐标</param>
        /// <param name="dX3">第三个点的X坐标</param>
        /// <param name="dY3">第三个点的Y坐标</param>
        private void DrawArc(Pen pen, double dX1, double dY1, double dX2, double dY2, double dX3, double dY3)
        {
            float[] dTemp = GetCircle(dX1, dY1, dX2, dY2, dX3, dY3);
            double dK1 = ReturnCircleK((float)dX1, (float)dY1, dTemp[0], dTemp[1]);
            double dK2 = ReturnCircleK((float)dX2, (float)dY2, dTemp[0], dTemp[1]);
            double dK3 = ReturnCircleK((float)dX3, (float)dY3, dTemp[0], dTemp[1]);

            int startAngle, sweepAngle;
            if ((dK1 < dK2 && dK3 > dK2) || (dK1 > dK2 && dK3 < dK2))//未横跨X轴正方向
            {
                startAngle = (int)(dK1 < dK3 ? dK1 : dK3); //数值较小的为起始点
                sweepAngle = (int)(dK1 < dK3 ? dK3 : dK1) - (int)(dK1 < dK3 ? dK1 : dK3);
            }
            else
            {
                startAngle = (int)(dK1 < dK3 ? dK3 : dK1);//数值较大的为起始点
                sweepAngle = 360 - ((int)(dK1 < dK3 ? dK3 : dK1) - (int)(dK1 < dK3 ? dK1 : dK3));
            }

            graph = this.pictureBox1.CreateGraphics();
            graph.DrawArc(pen, dTemp[0] - dTemp[2], dTemp[1] - dTemp[2], Math.Abs(dTemp[2] * 2), Math.Abs(dTemp[2] * 2), startAngle, sweepAngle);
        }

        public bool IsNumberic(object obj)
        {
            //double vsNum;
            bool isNum;
            if (obj != null)
            {
                isNum = double.TryParse(obj.ToString(), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out _);
            }
            else
            {
                isNum = false;
            }
            return isNum;
        }

        /// <summary>
        /// 根据三点计算并获取圆
        /// </summary>
        /// <param name="x1">第一点的X坐标</param>
        /// <param name="y1">第一点的Y坐标</param>
        /// <param name="x2">第二点的X坐标</param>
        /// <param name="y2">第二点的Y坐标</param>
        /// <param name="x3">第三点的X坐标</param>
        /// <param name="y3">第三点的Y坐标</param>
        /// <returns>圆参数float数组：圆心X坐标、圆心Y坐标、圆半径</returns>
        public float[] GetCircle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double k1 = (y2 - y1) / (x2 - x1);
            double k2 = (y3 - y1) / (x3 - x1);

            double xm1 = x1 - ((x1 - x2) / 2);
            double ym1 = y1 - ((y1 - y2) / 2);
            double km1 = -(1 / k1);
            double bm1 = ym1 - (km1 * xm1);

            double xm2 = x1 - ((x1 - x3) / 2);
            double ym2 = y1 - ((y1 - y3) / 2);
            double km2 = -(1 / k2);
            double bm2 = ym2 - (km2 * xm2);

            double xc = (bm2 - bm1) / (km1 - km2);
            double yc = km1 * xc + bm1;
            double rc = Math.Sqrt(Math.Pow((x1 - xc), 2) + Math.Pow((y1 - yc), 2));
            return new float[] { (float)xc, (float)yc, (float)rc };
        }

        public double ReturnCircleK(float fx1, float fy1, float fx2, float fy2)
        {
            double fA = Math.Atan2(fy1 - fy2, fx1 - fx2) / Math.PI * 180;
            if (fA < 0)
                fA += 360;
            return fA;
        }

        private void btSaveGluePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "(*.txt)|*.txt"
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            string strFolderPath = saveFileDialog.FileName.ToString();

            string strGluePath;
            System.IO.File.Delete(strFolderPath);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                strGluePath = "";
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    strGluePath += dataGridView1.Columns[j].HeaderText + ":";

                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString() == "Line")
                        {
                            strGluePath += "0";
                        }
                        else if (dataGridView1.Rows[i].Cells[j].Value.ToString() == "Arc")
                        {
                            strGluePath += "1";
                        }
                        else
                        {
                            strGluePath += dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    if (j != dataGridView1.Columns.Count - 1)
                        strGluePath += ",";
                }
                string[] aStrGluePath = { strGluePath };
                System.IO.File.AppendAllLines(strFolderPath, aStrGluePath);
            }
        }

        private void SaveImageJpeg(Image image, string strNamePath)
        {
            string strFolderPathImage = Application.StartupPath.ToString() + @"\File\";
            string pathFolder = strFolderPathImage + DateTime.Now.ToShortDateString().Replace('/', '_');
            string imagePath = pathFolder + @"\" + strNamePath + "_" + DateTime.Now.TimeOfDay.ToString().Substring(0, 12).Replace(':', '_').Replace('.', '_') + ".Jpeg";

            if (!System.IO.Directory.Exists(pathFolder))
                System.IO.Directory.CreateDirectory(pathFolder);
            try
            {
                image.Save(@imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CreateGUIPoint();
            CreateGUILine();
        }

        private void 添加行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ColumnCount == 0)
            {
                string str_0 = "ID:,Type:,CircleMode:,MX:,MY:,MZ:,TX:,TY:,TZ:,TR:,TA:,Speed:,AccSpeed:,IOStatus:,StartDelay:,EndDelay:,StartDelayIOStatus:,EndDelayIOStatus:";
                string[] str_1 = str_0.Split(',');
                for (int i = 0; i < str_1.Count(); i++)//添加列
                {
                    dataGridView1.Columns.Add("column" + str_1[i].Split(':')[0], str_1[i].Split(':')[0]);
                    dataGridView1.Columns[i].Width = 65;
                }
            }

            dataGridView1.Rows.Add();
            aCellComboBox1[dataGridView1.Rows.Count - 1] = new DataGridViewComboBoxCell();
            aCellComboBox1[dataGridView1.Rows.Count - 1].Items.Add("");
            aCellComboBox1[dataGridView1.Rows.Count - 1].Items.Add("Line");
            aCellComboBox1[dataGridView1.Rows.Count - 1].Items.Add("Arc");
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1] = aCellComboBox1[dataGridView1.Rows.Count - 1];

            aCellComboBox2[dataGridView1.Rows.Count - 1] = new DataGridViewComboBoxCell();
            aCellComboBox2[dataGridView1.Rows.Count - 1].Items.Add("");
            aCellComboBox2[dataGridView1.Rows.Count - 1].Items.Add("XY");
            aCellComboBox2[dataGridView1.Rows.Count - 1].Items.Add("XYZ");
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2] = aCellComboBox2[dataGridView1.Rows.Count - 1];

            for (int i = 3; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[i].Value = "";
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }

        }
        private void 插入行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            DataGridViewRow DGVR = new DataGridViewRow();
            int iIndex = dataGridView1.Rows.IndexOf(dataGridView1.SelectedRows[0]);

            dataGridView1.Rows.Insert(iIndex, DGVR);

            DataGridViewComboBoxCell DGVCBC_T1 = new DataGridViewComboBoxCell();
            DataGridViewComboBoxCell DGVCBC_T2 = new DataGridViewComboBoxCell();

            DGVCBC_T1.Items.Add("");
            DGVCBC_T1.Items.Add("Line");
            DGVCBC_T1.Items.Add("Arc");
            dataGridView1.Rows[iIndex].Cells[1] = DGVCBC_T1;

            DGVCBC_T2.Items.Add("");
            DGVCBC_T2.Items.Add("XY");
            DGVCBC_T2.Items.Add("XYZ");
            dataGridView1.Rows[iIndex].Cells[2] = DGVCBC_T2;


            for (int i = 3; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Rows[iIndex].Cells[i].Value = "";
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
            pictureBox1.Refresh();
            CreateGUIPoint();
            CreateGUILine();
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(item);
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
            pictureBox1.Refresh();
            CreateGUIPoint();
            CreateGUILine();
        }
        private void 清除胶路ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            tbPath.Text = "";
            pictureBox1.Refresh();
        }
        private void DataGridViewAddRow()
        {
            DataGridViewRow DGVR = new DataGridViewRow();

        }
        private void tkbAlpha_ValueChanged(object sender, EventArgs e)
        {
            lbAlpha.Text = tkBTransparency.Value.ToString();
            penRed.Color = Color.FromArgb(Convert.ToInt32(tkBTransparency.Value), Color.Red);
            penBlue.Color = Color.FromArgb(Convert.ToInt32(tkBTransparency.Value), Color.Blue);
            penGreen.Color = Color.FromArgb(Convert.ToInt32(tkBTransparency.Value), Color.Green);
            pictureBox1.Refresh();
            CreateGUIPoint();
            CreateGUILine();
        }

        private void tkbGlueWidth_ValueChanged(object sender, EventArgs e)
        {
            lbGlueWidth.Text = tkBGlueWidth.Value.ToString();
            pictureBox1.Refresh();
            CreateGUIPoint();
            CreateGUILine();
        }


    }
}
