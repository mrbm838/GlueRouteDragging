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

        public double dMultiplyingG = 1;
        public double dMultiplyingP = 1;

        double dPictureBox1Width;
        double dPictureBox1Height;
        double dPictureBox1ImageWidth;
        double dPictureBox1ImageHeight;

        double dBShiftPK;

        public Form_GluePath()
        {
            InitializeComponent();
            pictureBox.MouseWheel += new MouseEventHandler(pbxDrawing_MouseWheel);
            dataGridView.AllowUserToAddRows = false;
            //splitContainer1.Panel1.MouseWheel += new MouseEventHandler(pbxDrawing_MouseWheel);
        }

        private void Form_GluePath_Load(object sender, EventArgs e)
        {
            Bitmap bmp = ReadImageFile(Application.StartupPath.ToString() + @"\File\Image3.BMP");
            pictureBox.Image = bmp;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            SetPitureBox();

            dPictureBox1Width = pictureBox.Width;
            dPictureBox1Height = pictureBox.Height;
            dPictureBox1ImageWidth = pictureBox.Image.Width;
            dPictureBox1ImageHeight = pictureBox.Image.Height;

            tbStandardX.Text = "230";
            tbStandardY.Text = "195";

            graph = this.pictureBox.CreateGraphics();

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
            string strFilePath = OpenFileDialog(Application.StartupPath);
            if (strFilePath != "")
            {
                tbPath.Text = strFilePath;
                LoadToDataGridView(ReadGluePathFile(strFilePath));
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

                this.pictureBox.Width = Convert.ToInt32(dPictureBox1Width * dMultiplyingG);
                this.pictureBox.Height = Convert.ToInt32(dPictureBox1Height * dMultiplyingG);
                this.pictureBox.Left += Convert.ToInt32(e.X - dMultiplyingP * e.X);
                this.pictureBox.Top += Convert.ToInt32(e.Y - dMultiplyingP * e.Y);
                dBShiftPK = Convert.ToDouble(pictureBox.Image.Width) / Convert.ToDouble(pictureBox.Width);
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
                    pictureBox.Left += Convert.ToInt16(e.X - xPos);
                    pictureBox.Top += Convert.ToInt16(e.Y - yPos);
                }
            }

            lbPX.Text = (dPictureBox1ImageWidth * Convert.ToDouble(e.X) / Convert.ToDouble(pictureBox.Width)).ToString("0.000");
            lbPY.Text = (dPictureBox1ImageHeight * Convert.ToDouble(e.Y) / Convert.ToDouble(pictureBox.Height)).ToString("0.000");
            //lbBoxX.Text = e.X.ToString();
            //lbBoxY.Text = e.Y.ToString();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                this.pictureBox.Focus();
                MoveFlag = true;
                xPos = e.X;
                yPos = e.Y;
            }

            else if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < dataGridView.RowCount; i++) //遍历行
                {
                    if (dataGridView.Rows[i].Cells[1].Value != null)
                    {
                        if (dataGridView.Rows[i].Cells[1].Value.ToString() == "Line")
                        {
                            dataGridView.Rows[i].Cells[3].Value = "-";
                            dataGridView.Rows[i].Cells[4].Value = "-";
                            dataGridView.Rows[i].Cells[3].ReadOnly = true;
                            dataGridView.Rows[i].Cells[4].ReadOnly = true;
                        }
                        else
                        {
                            dataGridView.Rows[i].Cells[3].ReadOnly = false;
                            dataGridView.Rows[i].Cells[4].ReadOnly = false;
                        }
                    }
                    if (dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected)
                    {
                        dataGridView.Rows[i].Cells[6].Value = Convert.ToDouble((e.X * dBShiftPK).ToString("0.000")) - Convert.ToDouble(tbStandardX.Text);
                        dataGridView.Rows[i].Cells[7].Value = Convert.ToDouble((e.Y * dBShiftPK).ToString("0.000")) - Convert.ToDouble(tbStandardY.Text);
                    }
                    else if (dataGridView.Rows[i].Cells[3].Selected || dataGridView.Rows[i].Cells[4].Selected)
                    {
                        if (dataGridView.Rows[i].Cells[1].Value.ToString() == "Arc")
                        {
                            dataGridView.Rows[i].Cells[3].Value = Convert.ToDouble((e.X * dBShiftPK).ToString("0.000")) - Convert.ToDouble(tbStandardX.Text);
                            dataGridView.Rows[i].Cells[4].Value = Convert.ToDouble((e.Y * dBShiftPK).ToString("0.000")) - Convert.ToDouble(tbStandardY.Text);
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
            pictureBox.Width = pictureBox.Image.Width;
            pictureBox.Height = pictureBox.Image.Height;
            if ((Convert.ToDouble(splitContainer1.Panel1.Width) / Convert.ToDouble(splitContainer1.Panel1.Height))
                < (Convert.ToDouble(pictureBox.Width) / Convert.ToDouble(pictureBox.Height)))
            {
                pictureBox.Width = splitContainer1.Panel1.Width;
                pictureBox.Height = Convert.ToInt32(pictureBox.Width * (Convert.ToDouble(pictureBox.Image.Height) / Convert.ToDouble(pictureBox.Image.Width)));
                this.pictureBox.Left = 0;
                this.pictureBox.Top = (splitContainer1.Panel1.Height - pictureBox.Height) / 2;
            }
            else
            {
                pictureBox.Height = splitContainer1.Panel1.Height;
                pictureBox.Width = Convert.ToInt32(pictureBox.Height * (Convert.ToDouble(pictureBox.Image.Width) / Convert.ToDouble(pictureBox.Image.Height)));
                this.pictureBox.Left = (splitContainer1.Panel1.Width - pictureBox.Width) / 2;
                this.pictureBox.Top = 0;
            }

            dBShiftPK = Convert.ToDouble(pictureBox.Image.Width) / Convert.ToDouble(pictureBox.Width);
            lbK.Text = (1 / dBShiftPK).ToString("0.000");
        }

        private void LoadToDataGridView(string[] strTxt)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            string[] strHead = strTxt[0].Split(',');
            string[,] strPathData = new string[strTxt.Length, strHead.Length];

            for (int i = 0; i < strHead.Length; i++)//添加列
            {
                dataGridView.Columns.Add("column" + strHead[i].Split(':')[0], strHead[i].Split(':')[0]);
                dataGridView.Columns[i].Width = 65;
            }

            string[] strings;
            for (int i = 0; i < strTxt.Length; i++)//添加行
            {
                strings = strTxt[i].Split(',');
                this.dataGridView.Rows.Add();
                for (int j = 0; j < strings.Length; j++)
                {
                    if (j == 1)
                    {
                        DataGridViewComboBoxCell dgvComboBoxCellOfType = new DataGridViewComboBoxCell();
                        dgvComboBoxCellOfType.Items.Add("");
                        dgvComboBoxCellOfType.Items.Add("Line");
                        dgvComboBoxCellOfType.Items.Add("Arc");
                        dataGridView.Rows[i].Cells[1] = (DataGridViewCell)dgvComboBoxCellOfType;
                        
                    }
                    else if (j == 2)
                    {
                        DataGridViewComboBoxCell dgvComboBoxCellOfCircleMode = new DataGridViewComboBoxCell();
                        dgvComboBoxCellOfCircleMode.Items.Add("");
                        dgvComboBoxCellOfCircleMode.Items.Add("XY");
                        dgvComboBoxCellOfCircleMode.Items.Add("XYZ");
                        dataGridView.Rows[i].Cells[2] = (DataGridViewCell)dgvComboBoxCellOfCircleMode;
                    }
                    else
                    {
                        dataGridView.Rows[i].Cells[j].Value = strings[j].Split(':')[1];
                    }

                    strPathData[i, j] = strings[j].Split(':')[1];
                }
                if (strTxt[i].Split(',')[1].Split(':')[1] == "1")
                {
                    dataGridView.Rows[i].Cells[1].Value = "Arc";
                    dataGridView.Rows[i].Cells[2].Value = "XY";
                }
                else if (strTxt[i].Split(',')[1].Split(':')[1] == "0")
                {
                    dataGridView.Rows[i].Cells[1].Value = "Line";
                    dataGridView.Rows[i].Cells[3].ReadOnly = true;
                    dataGridView.Rows[i].Cells[4].ReadOnly = true;
                }
                else
                {
                    dataGridView.Rows[i].Cells[1].Value = "";
                }
            }
        }

        public string[] ReadGluePathFile(string path)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(path, Encoding.Default);
            List<string> list = new List<string>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                list.Add(line);
            }
            sr.Close();
            sr.Dispose();
            return list.ToArray();
        }

        public void CreateGUILine()
        {
            //if (!tbShowGluePath.Checked) return;
            penRed.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / dBShiftPK);
            penBlue.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / dBShiftPK);
            Point pS = new Point();
            Point pM = new Point();
            Point pE = new Point();
            for (int i = 1; i < dataGridView.RowCount; i++)
            {
                try
                {
                    if (dataGridView.Rows[i].Cells[1].Value != null)
                    {
                        if (dataGridView.Rows[i].Cells[1].Value.ToString() == "Line")
                        {
                            if (IsNumberic(dataGridView.Rows[i].Cells[6].Value) && IsNumberic(dataGridView.Rows[i].Cells[7].Value) &&
                                IsNumberic(dataGridView.Rows[i - 1].Cells[6].Value) && IsNumberic(dataGridView.Rows[i - 1].Cells[7].Value))
                            {
                                pS.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[6].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                                pS.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[7].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);
                                pE.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                                pE.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);
                                if (dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected)
                                {
                                    graph.DrawLine(penBlue, pS, pE);
                                }
                                else
                                {
                                    graph.DrawLine(penRed, pS, pE);
                                }
                            }
                        }
                        else if (dataGridView.Rows[i].Cells[1].Value.ToString() == "Arc")
                        {
                            if (IsNumberic(dataGridView.Rows[i].Cells[3].Value) && IsNumberic(dataGridView.Rows[i].Cells[4].Value) &&
                                IsNumberic(dataGridView.Rows[i].Cells[6].Value) && IsNumberic(dataGridView.Rows[i].Cells[7].Value) &&
                                IsNumberic(dataGridView.Rows[i - 1].Cells[6].Value) && IsNumberic(dataGridView.Rows[i - 1].Cells[7].Value))
                            {
                                pS.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[6].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                                pS.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[7].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);
                                pM.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                                pM.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);
                                pE.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                                pE.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);
                                if (dataGridView.Rows[i].Cells[3].Selected || dataGridView.Rows[i].Cells[4].Selected || dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected)
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
            pictureBox.Refresh();

            int iStandardX = Convert.ToInt32(Convert.ToDouble(tbStandardX.Text) / dBShiftPK);
            int iStandardY = Convert.ToInt32(Convert.ToDouble(tbStandardY.Text) / dBShiftPK);
            //graph.FillEllipse(Brushes.Black, iStandardX - 3, iStandardY - 3, 6, 6);
            graph.DrawArc(penGreen, iStandardX - 3, iStandardY - 3, 6, 6, 0, 360);
            graph.DrawString("0", new Font("Verdana", 12), new SolidBrush(Color.Green), new PointF(iStandardX, iStandardY - 20));

            Point pT = new Point();
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if (IsNumberic(dataGridView.Rows[i].Cells[3].Value) && IsNumberic(dataGridView.Rows[i].Cells[4].Value))
                {
                    pT.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                    pT.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);

                    if (dataGridView.Rows[i].Cells[3].Selected || dataGridView.Rows[i].Cells[4].Selected)
                    {
                        graph.DrawArc(penBlue, pT.X - 3, pT.Y - 3, 6, 6, 0, 360);
                        graph.DrawString(dataGridView.Rows[i].Cells[0].Value.ToString() + "-1", new Font("Verdana", 12), new SolidBrush(Color.Blue), new PointF(pT.X, pT.Y - 20));
                    }
                    else
                    {
                        graph.DrawArc(penRed, pT.X - 3, pT.Y - 3, 6, 6, 0, 360);
                        graph.DrawString(dataGridView.Rows[i].Cells[0].Value.ToString() + "-1", new Font("Verdana", 12), new SolidBrush(Color.Red), new PointF(pT.X, pT.Y - 20));
                    }
                }
                if (IsNumberic(dataGridView.Rows[i].Cells[6].Value) && IsNumberic(dataGridView.Rows[i].Cells[7].Value))
                {
                    pT.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value) + Convert.ToDouble(tbStandardX.Text)) / dBShiftPK);
                    pT.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value) + Convert.ToDouble(tbStandardY.Text)) / dBShiftPK);

                    if (dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected)
                    {
                        graph.DrawArc(penBlue, pT.X - 3, pT.Y - 3, 6, 6, 0, 360);
                        graph.DrawString(dataGridView.Rows[i].Cells[0].Value.ToString(), new Font("Verdana", 12), new SolidBrush(Color.Blue), new PointF(pT.X, pT.Y - 20));
                    }
                    else
                    {
                        graph.DrawArc(penRed, pT.X - 3, pT.Y - 3, 6, 6, 0, 360);
                        graph.DrawString(dataGridView.Rows[i].Cells[0].Value.ToString(), new Font("Verdana", 12), new SolidBrush(Color.Red), new PointF(pT.X, pT.Y - 20));
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

            graph = this.pictureBox.CreateGraphics();
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
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                strGluePath = "";
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    strGluePath += dataGridView.Columns[j].HeaderText + ":";

                    if (dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView.Rows[i].Cells[j].Value.ToString() == "Line")
                        {
                            strGluePath += "0";
                        }
                        else if (dataGridView.Rows[i].Cells[j].Value.ToString() == "Arc")
                        {
                            strGluePath += "1";
                        }
                        else
                        {
                            strGluePath += dataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    if (j != dataGridView.Columns.Count - 1)
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

        private void ToolStripMenuItem_Append_Click(object sender, EventArgs e)
        {
            if (dataGridView.ColumnCount == 0)
            {
                string strHeader = "ID:,Type:,CircleMode:,MX:,MY:,MZ:,TX:,TY:,TZ:,TR:,TA:,Speed:,AccSpeed:,IOStatus:,StartDelay:,EndDelay:,StartDelayIOStatus:,EndDelayIOStatus:";
                string[] strings = strHeader.Split(',');
                for (int i = 0; i < strings.Length; i++)//添加列
                {
                    dataGridView.Columns.Add("column" + strings[i].Split(':')[0], strings[i].Split(':')[0]);
                    dataGridView.Columns[i].Width = 65;
                }
            }

            dataGridView.Rows[dataGridView.RowCount - 1].Cells[0].Value = dataGridView.RowCount.ToString();

            dataGridView.Rows.Add();
            DataGridViewComboBoxCell dgvComboBoxCellOfType = new DataGridViewComboBoxCell();
            dgvComboBoxCellOfType.Items.Add("");
            dgvComboBoxCellOfType.Items.Add("Line");
            dgvComboBoxCellOfType.Items.Add("Arc");
            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1] = dgvComboBoxCellOfType;

            DataGridViewComboBoxCell dgvComboBoxCellOfCircleMode = new DataGridViewComboBoxCell();
            dgvComboBoxCellOfCircleMode.Items.Add("");
            dgvComboBoxCellOfCircleMode.Items.Add("XY");
            dgvComboBoxCellOfCircleMode.Items.Add("XYZ");
            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[2] = dgvComboBoxCellOfCircleMode;

            for (int i = 3; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Rows[dataGridView.RowCount - 1].Cells[i].Value = string.Empty;
            }
        }

        private void ToolStripMenuItem_Insert_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count < 1)
                return;

            DataGridViewRow DGVR = new DataGridViewRow();
            int iIndex = dataGridView.Rows.IndexOf(dataGridView.SelectedRows[0]);

            dataGridView.Rows.Insert(iIndex, DGVR);

            DataGridViewComboBoxCell DGVCBC_T1 = new DataGridViewComboBoxCell();
            DataGridViewComboBoxCell DGVCBC_T2 = new DataGridViewComboBoxCell();

            DGVCBC_T1.Items.Add("");
            DGVCBC_T1.Items.Add("Line");
            DGVCBC_T1.Items.Add("Arc");
            dataGridView.Rows[iIndex].Cells[1] = DGVCBC_T1;

            DGVCBC_T2.Items.Add("");
            DGVCBC_T2.Items.Add("XY");
            DGVCBC_T2.Items.Add("XYZ");
            dataGridView.Rows[iIndex].Cells[2] = DGVCBC_T2;


            for (int i = 3; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Rows[iIndex].Cells[i].Value = "";
            }
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Cells[0].Value = i + 1;
            }
            pictureBox.Refresh();
            CreateGUIPoint();
            CreateGUILine();
        }

        private void ToolStripMenuItem_Delete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView.SelectedRows)
            {
                dataGridView.Rows.Remove(item);
            }

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
            pictureBox.Refresh();
            CreateGUIPoint();
            CreateGUILine();
        }

        private void ToolStripMenuItem_Clear_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            tbPath.Text = "";
            pictureBox.Refresh();
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
            pictureBox.Refresh();
            CreateGUIPoint();
            CreateGUILine();
        }

        private void tkbGlueWidth_ValueChanged(object sender, EventArgs e)
        {
            lbGlueWidth.Text = tkBGlueWidth.Value.ToString();
            pictureBox.Refresh();
            CreateGUIPoint();
            CreateGUILine();
        }

    }
}
