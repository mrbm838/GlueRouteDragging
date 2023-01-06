using GlueReadWrite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GluePathReadWrite
{
    //(x1,y1) wraps (x2,y2) θ to get (x,y)
    //x = (x1 - x2)* cos(pi / 180.0 * θ) - (y1 - y2)* sin(pi / 180.0 * θ) + x2;
    //y = (x1 - x2)* sin(pi / 180.0 * θ) + (y1 - y2)* cos(pi / 180.0 * θ) + y2;

    public partial class FormGluePath : Form
    {
        int xPos;
        int yPos;
        bool bMoveFlag;

        public Pen penRed = new Pen(Color.Red, 5);
        public Pen penBlue = new Pen(Color.Blue, 5);
        public Pen penGreen = new Pen(Color.Green, 5);
        Graphics graph;

        public double dMultiplyingG = 1;
        public double dMultiplyingP = 1;

        double dPictureBoxWidth;
        double dPictureBoxHeight;
        double dPictureBoxImageWidth;
        double dPictureBoxImageHeight;

        private double _dRatio;

        private readonly Dictionary<string, Rectangle> _dicGraphics = new Dictionary<string, Rectangle>();

        private int _selectedRow;
        private int _selectedColumn;

        private List<Coordination> _listCoorXAndZ = new List<Coordination>();
        private List<Coordination> _listCoorYAndZ = new List<Coordination>();
        private List<Series> _listSeries = new List<Series>();

        private Series _seriesX;
        private Series _seriesY;
        private int _pointIndex;

        private string _glueFilePath;

        public FormGluePath()
        {
            InitializeComponent();
            pictureBox.MouseWheel += new MouseEventHandler(pbxDrawing_MouseWheel);
            dataGridView.AllowUserToAddRows = false;
        }

        private void Form_GluePath_Load(object sender, EventArgs e)
        {
            textBox1.AutoSize = false;
            textBox1.Height = 28;
            textBox1.Font = new Font("宋体", 12);
            button1.Height = 16;
            button2.Height = 16;

            Bitmap bmp = ReadImageFile(Application.StartupPath + @"\File\glue.BMP");
            pictureBox.Image = bmp;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            SetPictureBox();

            dPictureBoxWidth = pictureBox.Width;
            dPictureBoxHeight = pictureBox.Height;
            dPictureBoxImageWidth = pictureBox.Image.Width;
            dPictureBoxImageHeight = pictureBox.Image.Height;

            tbStandardX.Text = "1160";
            tbStandardY.Text = "1280";

            graph = this.pictureBox.CreateGraphics();

            tkBGlueWidth.Maximum = 50;
            tkBGlueWidth.Minimum = 1;
            tkBGlueWidth.TickFrequency = 2;
            tkBGlueWidth.SmallChange = 1;
            tkBGlueWidth.Value = 3;

            tkBTransparency.Maximum = 255;
            tkBTransparency.Minimum = 0;
            tkBTransparency.TickFrequency = 25;
            tkBTransparency.SmallChange = 1;
            tkBTransparency.Value = 255;

            ConfigureSeries();

            #region MyRegion

            var str = @"E:\Cowain\2169\GlueReadWrite\bin\Debug\File\GluePath.txt";//@"E:\2169\胶路拖拽\GlueReadWrite\bin\Debug\File\GluePath.txt";//
            LoadToDataGridView(ReadGluePathFile(str));
            DrawGUIPoint(true);
            DrawGUILine();

            DrawChartLine();

            #endregion
        }

        private void DrawChartLine()
        {
            chart.Series.Clear();       // Clear series in "chart"
            _seriesX.Points.Clear();    // Clear points in "_seriesX"
            //chart.ChartAreas[0].AxisX.Maximum = _listCoorXAndZ.Find(t =>    )
            //_listSeries.ForEach(t => chart.Series.Add(t));
            FlashCoordinationList();
            chart.Series.Add(_seriesX);

            //chart.DataSource = _listCoorXAndZ;//C# chart获取绘制完成的信号
            for (int i = 0; i < _listCoorXAndZ.Count; i++)
            {
                _seriesX.Points.AddXY(_listCoorXAndZ[i].CoorX, _listCoorXAndZ[i].CoorZ);
                _seriesX.Points[i].Label = _listCoorXAndZ[i].strLabel;
            }

        }

        private void FlashCoordinationList()
        {
            _listCoorXAndZ.Clear();
            _listCoorYAndZ.Clear();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[1].Value.ToString() == EnumLineType.Line.ToString())
                {
                    _listCoorXAndZ.Add(new Coordination
                    {
                        CoorX = Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value),
                        CoorZ = Convert.ToDouble(dataGridView.Rows[i].Cells[8].Value),
                        strLabel = (i + 1).ToString()
                    });
                    _listCoorYAndZ.Add(new Coordination
                    {
                        CoorY = Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value),
                        CoorZ = Convert.ToDouble(dataGridView.Rows[i].Cells[8].Value),
                        strLabel = (i + 1).ToString()
                    });
                }
                else
                {
                    _listCoorXAndZ.AddRange(new[]{
                        new Coordination
                        {
                            CoorX = Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value),
                            CoorZ = Convert.ToDouble(dataGridView.Rows[i].Cells[5].Value),
                            strLabel = $"{i + 1}_1"
                        },
                        new Coordination
                        {
                            CoorX = Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value),
                            CoorZ = Convert.ToDouble(dataGridView.Rows[i].Cells[8].Value),
                            strLabel = $"{i + 1}_2"
                        }});
                    _listCoorYAndZ.AddRange(new[]{
                        new Coordination
                        {
                            CoorY = Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value),
                            CoorZ = Convert.ToDouble(dataGridView.Rows[i].Cells[5].Value),
                            strLabel = $"{i + 1}_1"
                        },
                        new Coordination
                        {
                            CoorY = Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value),
                            CoorZ = Convert.ToDouble(dataGridView.Rows[i].Cells[8].Value),
                            strLabel = $"{i + 1}_2"
                        }});
                }
            }
        }

        private void ConfigureSeries()
        {
            chart.ChartAreas[0].AxisX.TitleFont = new Font("宋体", 10);
            chart.ChartAreas[0].AxisY.TitleFont = new Font("宋体", 10);
            chart.ChartAreas[0].AxisX.Title = "X轴坐标";
            chart.ChartAreas[0].AxisY.Title = "Z轴坐标";
            //chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.Series.Clear();
            chart.Legends.Clear();
            _seriesX = new Series
            {
                ChartType = SeriesChartType.Spline,
                Color = Color.Maroon,
                XValueMember = "CoorX",
                YValueMembers = "CoorZ",
                MarkerSize = 8,
                MarkerBorderColor = Color.Black,
                MarkerColor = Color.Red,
                MarkerStyle = MarkerStyle.Circle,
                BorderWidth = Convert.ToInt32(Math.Log(2, tkBGlueWidth.Value)),
                //IsValueShownAsLabel = true
            };
        }

        private void btOpenGluePath_Click(object sender, EventArgs e)
        {
            _glueFilePath = OpenFileDialog(Application.StartupPath + "\\File");
            if (_glueFilePath != "")
            {
                this.Text = Path.GetFileName(_glueFilePath);
                LoadToDataGridView(ReadGluePathFile(_glueFilePath));
                DrawGUIPoint(true);
                DrawGUILine();

                DrawChartLine();
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
            FileStream fs = File.OpenRead(path);
            int fileLength = (int)fs.Length; //获得文件长度 
            byte[] image = new byte[fileLength]; //建立一个字节数组 
            fs.Read(image, 0, fileLength); //按字节流读取 
            Image result = Image.FromStream(fs);
            fs.Close();
            Bitmap bit = new Bitmap(result);
            return bit;
        }

        private void pbxDrawing_MouseWheel(object sender, MouseEventArgs e)
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

                this.pictureBox.Width = Convert.ToInt32(dPictureBoxWidth * dMultiplyingG);
                this.pictureBox.Height = Convert.ToInt32(dPictureBoxHeight * dMultiplyingG);
                this.pictureBox.Left += Convert.ToInt32(e.X - dMultiplyingP * e.X);
                this.pictureBox.Top += Convert.ToInt32(e.Y - dMultiplyingP * e.Y);
                _dRatio = Convert.ToDouble(pictureBox.Image.Width) / Convert.ToDouble(pictureBox.Width);
                lbZoom.Text = (1 / _dRatio).ToString("0.000");

                DrawGUIPoint(true);
                DrawGUILine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {
                bMoveFlag = false;
                _selectedRow = -1;
                _selectedColumn = -1;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bMoveFlag)
            {
                if (e.Button == MouseButtons.Right)
                {
                    pictureBox.Left += Convert.ToInt16(e.X - xPos);
                    pictureBox.Top += Convert.ToInt16(e.Y - yPos);
                }
                if (e.Button == MouseButtons.Left)
                {
                    //for (int selectedRow = 0; selectedRow < dataGridView.RowCount; selectedRow++) //遍历行
                    //{
                    //if (dataGridView.Rows[i].Cells[1].Value.ToString() == "Line")
                    //{
                    //    dataGridView.Rows[i].Cells[3].Value = "-";
                    //    dataGridView.Rows[i].Cells[4].Value = "-";
                    //    dataGridView.Rows[i].Cells[3].ReadOnly = true;
                    //    dataGridView.Rows[i].Cells[4].ReadOnly = true;
                    //}
                    //else if (dataGridView.Rows[i].Cells[1].Value.ToString() == "Arc")
                    //{
                    //    dataGridView.Rows[i].Cells[3].ReadOnly = false;
                    //    dataGridView.Rows[i].Cells[4].ReadOnly = false;
                    //}
                    try
                    {
                        if (dataGridView.Rows[_selectedRow].Cells[_selectedColumn].Selected || dataGridView.Rows[_selectedRow].Cells[_selectedColumn + 1].Selected)
                        {
                            dataGridView.Rows[_selectedRow].Cells[_selectedColumn].Value = Convert.ToDouble((e.X * _dRatio).ToString("0.000")) - Convert.ToDouble(tbStandardX.Text);
                            dataGridView.Rows[_selectedRow].Cells[_selectedColumn + 1].Value = Convert.ToDouble((e.Y * _dRatio).ToString("0.000")) - Convert.ToDouble(tbStandardY.Text);
                        }
                        DrawGUIPoint(true);
                        DrawGUILine();
                    }
                    catch
                    {
                        // ignored
                    }
                    //}
                }
            }

            lbPX.Text = (Convert.ToDouble(e.X) * dPictureBoxImageWidth / Convert.ToDouble(pictureBox.Width)).ToString("0.000");
            lbPY.Text = (Convert.ToDouble(e.Y) * dPictureBoxImageHeight / Convert.ToDouble(pictureBox.Height)).ToString("0.000");
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridView.ClearSelection();
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {
                this.pictureBox.Focus();
                this.Cursor = Cursors.Cross;
                bMoveFlag = true;
                xPos = e.X;
                yPos = e.Y;

                foreach (var item in _dicGraphics)
                {
                    if (item.Value.Contains(xPos, yPos))
                    {
                        string[] strings = item.Key.Split('-');
                        int serial = Convert.ToInt32(strings[0]);
                        _selectedRow = serial;
                        if (strings.Length == 1 || strings[1].Equals("2"))
                        {
                            dataGridView.Rows[serial].Cells[6].Selected = true;
                            dataGridView_CellClick(dataGridView, new DataGridViewCellEventArgs(6, serial));
                            _selectedColumn = 6;
                        }
                        else
                        {
                            dataGridView.Rows[serial].Cells[3].Selected = true;
                            dataGridView_CellClick(dataGridView, new DataGridViewCellEventArgs(3, serial));
                            _selectedColumn = 3;
                        }
                        break;
                    }

                    #region MyRegion


                    //int transCoordinateX = (int)(e.X * dRatio);
                    //int transCoordinateY = (int)(e.Y * dRatio);

                    //pT.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value) + Convert.ToDouble(tbStandardX.Text)) / dRatio);
                    //pT.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value) + Convert.ToDouble(tbStandardY.Text)) / dRatio);
                    //dataGridView.Rows[i].Cells[3].Value = Math.Round(e.X * dRatio, 3) - Convert.ToDouble(tbStandardX.Text);
                    //dataGridView.Rows[i].Cells[4].Value = Math.Round(e.Y * dRatio, 3) - Convert.ToDouble(tbStandardY.Text);

                    //if (GluePathForXAndY.IsNumberic(dataGridView.Rows[serial].Cells[3].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[serial].Cells[4].Value))
                    //{
                    //    //var transCoordinateMX = xPos + Convert.ToInt32(Convert.ToDouble(tbStandardX.Text) / dRatio);
                    //    //var transCoordinateMY = yPos + Convert.ToInt32(Convert.ToDouble(tbStandardY.Text) / dRatio);
                    //    //if (item.Value.Contains(transCoordinateMX, transCoordinateMY))
                    //    //{
                    //    //    //dataGridView.Rows[serial].Cells[3].Selected = true;
                    //    //    dataGridView_CellClick(dataGridView, new DataGridViewCellEventArgs(3, serial));
                    //    //    //DrawGUIPoint();
                    //    //    //DrawGUILine();
                    //    //}

                    //}
                    //if (GluePathForXAndY.IsNumberic(dataGridView.Rows[serial].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[serial].Cells[7].Value))
                    //{
                    //    //var transCoordinateTX = xPos + Convert.ToInt32(Convert.ToDouble(tbStandardX.Text) / dRatio);
                    //    //var transCoordinateTY = yPos + Convert.ToInt32(Convert.ToDouble(tbStandardY.Text) / dRatio);
                    //    //if (item.Value.Contains(transCoordinateTX, transCoordinateTY))
                    //    //{
                    //    //    //dataGridView.Rows[serial].Cells[6].Selected = true;
                    //    //    //DrawGUIPoint();
                    //    //    //DrawGUILine();
                    //    //}
                    //    //if (item.Value.Contains(xPos, yPos))
                    //    //{
                    //    //    dataGridView_CellClick(dataGridView, new DataGridViewCellEventArgs(6, serial));
                    //    //}
                    //}

                    #endregion

                }
            }
        }

        private void ToolStripMenuItem_Fit_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SetPictureBox();
                dMultiplyingG = 1;
                DrawGUIPoint(true);
                DrawGUILine();
            }
        }

        private void SetPictureBox()
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

            _dRatio = Convert.ToDouble(pictureBox.Image.Width) / Convert.ToDouble(pictureBox.Width);
            lbZoom.Text = (1 / _dRatio).ToString("0.000");
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
                dataGridView.Columns[i].Width = 70;
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
            StreamReader sr = new StreamReader(path, Encoding.Default);
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

        public void DrawGUILine()
        {
            penRed.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / _dRatio);
            penBlue.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / _dRatio);
            Point pS = new Point(), pM = default, pE = new Point();

            for (int i = 1; i < dataGridView.RowCount; i++)
            {
                try
                {
                    if (dataGridView.Rows[0] != null)
                    {
                        if (dataGridView.Rows[i].Cells[1].Value?.ToString() == "Line")
                        {
                            if (GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[7].Value) &&
                                GluePathForXAndY.IsNumberic(dataGridView.Rows[i - 1].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i - 1].Cells[7].Value))
                            {
                                pS.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[6].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                                pS.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[7].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                                pE.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                                pE.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
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
                        else if (dataGridView.Rows[i].Cells[1].Value?.ToString() == "Arc")
                        {
                            if (GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[3].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[4].Value) &&
                            GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[7].Value) &&
                                GluePathForXAndY.IsNumberic(dataGridView.Rows[i - 1].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i - 1].Cells[7].Value))
                            {
                                pS.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[6].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                                pS.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[7].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                                pM.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                                pM.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                                pE.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value.ToString()) + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                                pE.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value.ToString()) + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                                float[] drawArc = GluePathForXAndY.DrawArc(pS.X, pS.Y, pM.X, pM.Y, pE.X, pE.Y);
                                if (dataGridView.Rows[i].Cells[3].Selected || dataGridView.Rows[i].Cells[4].Selected || dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected)
                                {
                                    graph.DrawArc(penBlue, drawArc[0], drawArc[1], drawArc[2], drawArc[3], drawArc[4], drawArc[5]);
                                }
                                else
                                {
                                    graph.DrawArc(penRed, drawArc[0], drawArc[1], drawArc[2], drawArc[3], drawArc[4], drawArc[5]);
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

        private Rectangle _homeRectangle;

        private void DrawGUIPoint(bool isChange, bool bDrawSingle = false)
        {
            try
            {
                if (bDrawSingle)
                {
                    pictureBox.Invalidate(_homeRectangle);
                    string strKey = $"{_selectedRow}{(_selectedColumn == 3 ? -1 : -2)}";
                    pictureBox.Invalidate(_dicGraphics[strKey]);
                }
                else
                {
                    pictureBox.Refresh();
                }
            }
            catch
            {
                // ignored
            }
            pictureBox.Refresh();
            penRed.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / _dRatio);
            penBlue.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / _dRatio);
            penGreen.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / _dRatio);

            int iStandardX = Convert.ToInt32(Convert.ToDouble(tbStandardX.Text) / _dRatio);
            int iStandardY = Convert.ToInt32(Convert.ToDouble(tbStandardY.Text) / _dRatio);
            _homeRectangle = new Rectangle(iStandardX - 2, iStandardY - 2, 10, 10);
            graph.FillEllipse(Brushes.Green, _homeRectangle);
            //graph.DrawArc(penGreen, iStandardX - 30, iStandardY - 30, 6, 6, 0, 360);
            graph.DrawString("0", new Font("Verdana", 10), new SolidBrush(Color.Green), new PointF(iStandardX, iStandardY - 20));
            Point pT = new Point();
            bool isArc = false;

            if (bDrawSingle)
            {
                if (GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow].Cells[_selectedColumn].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow].Cells[_selectedColumn + 1].Value))
                {
                    int x = Convert.ToInt32(Convert.ToDouble(dataGridView.Rows[_selectedRow].Cells[_selectedColumn].Value));
                    int y = Convert.ToInt32(Convert.ToDouble(dataGridView.Rows[_selectedRow].Cells[_selectedColumn + 1].Value));
                    pT.X = Convert.ToInt32((x + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                    pT.Y = Convert.ToInt32((y + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                    Rectangle ellipse = new Rectangle(pT.X - 2, pT.Y - 2, 10, 10);

                    if (dataGridView.Rows[_selectedRow].Cells[_selectedColumn].Selected || dataGridView.Rows[_selectedRow].Cells[_selectedColumn + 1].Selected)
                    {
                        graph.FillEllipse(Brushes.Blue, ellipse);
                        graph.DrawString(dataGridView.Rows[_selectedRow].Cells[0].Value + (_selectedColumn == 3 ? "-1" : "-2"),
                            new Font("Verdana", 10), new SolidBrush(Color.Blue), new PointF(pT.X, pT.Y - 20));
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    isArc = false;
                    if (GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[3].Value) &&
                        GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[4].Value))
                    {
                        isArc = true;
                        int mx = Convert.ToInt32(Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value));
                        int my = Convert.ToInt32(Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value));
                        pT.X = Convert.ToInt32((mx + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                        pT.Y = Convert.ToInt32((my + Convert.ToDouble(tbStandardY.Text)) / _dRatio);

                        Rectangle ellipse = new Rectangle(pT.X - 2, pT.Y - 2, 10, 10);
                        if (isChange)
                        {
                            if (!_dicGraphics.Keys.Contains(i + "-1")) _dicGraphics.Add(i + "-1", ellipse);
                            else _dicGraphics[i + "-1"] = ellipse;
                        }

                        if (dataGridView.Rows[i].Cells[3].Selected || dataGridView.Rows[i].Cells[4].Selected)
                        {
                            graph.FillEllipse(Brushes.Blue, ellipse);
                            graph.DrawString(dataGridView.Rows[i].Cells[0].Value + "-1", new Font("Verdana", 10),
                                new SolidBrush(Color.Blue), new PointF(pT.X, pT.Y - 20));
                        }
                        else
                        {
                            graph.FillEllipse(Brushes.Red, ellipse);
                            graph.DrawString(dataGridView.Rows[i].Cells[0].Value + "-1", new Font("Verdana", 10),
                                new SolidBrush(Color.Red), new PointF(pT.X, pT.Y - 20));
                        }
                    }

                    if (GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[6].Value) &&
                        GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[7].Value))
                    {
                        int tx = Convert.ToInt32(Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value));
                        int ty = Convert.ToInt32(Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value));
                        pT.X = Convert.ToInt32((tx + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                        pT.Y = Convert.ToInt32((ty + Convert.ToDouble(tbStandardY.Text)) / _dRatio);

                        Rectangle ellipse = new Rectangle(pT.X - 2, pT.Y - 2, 10, 10);
                        if (isChange)
                        {
                            if (!_dicGraphics.Keys.Contains(i + (isArc ? "-2" : string.Empty)))
                                _dicGraphics.Add(i + (isArc ? "-2" : string.Empty), ellipse);
                            else _dicGraphics[i + (isArc ? "-2" : string.Empty)] = ellipse;
                        }

                        if (dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected)
                        {
                            graph.FillEllipse(Brushes.Blue, ellipse);
                            graph.DrawString(dataGridView.Rows[i].Cells[0].Value + (isArc ? "-2" : string.Empty),
                                new Font("Verdana", 10), new SolidBrush(Color.Blue), new PointF(pT.X, pT.Y - 20));
                        }
                        else
                        {
                            graph.FillEllipse(Brushes.Red, ellipse);
                            graph.DrawString(dataGridView.Rows[i].Cells[0].Value + (isArc ? "-2" : string.Empty),
                                new Font("Verdana", 10), new SolidBrush(Color.Red), new PointF(pT.X, pT.Y - 20));
                        }
                    }
                }
            }
        }

        private void btSaveGluePath_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog
            //{
            //    Filter = "(*.txt)|*.txt"
            //};
            //if (saveFileDialog.ShowDialog() != DialogResult.OK)
            //    return;
            if (DialogResult.OK != MessageBox.Show("是否保存胶路？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                return;

            string strFolderPath = _glueFilePath;
            StringBuilder strGlueData = new StringBuilder();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    strGlueData.Append(dataGridView.Columns[j].HeaderText + ":");
                    if (dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView.Rows[i].Cells[j].Value.ToString() == "Line")
                        {
                            strGlueData.Append("0");
                        }
                        else if (dataGridView.Rows[i].Cells[j].Value.ToString() == "Arc")
                        {
                            strGlueData.Append("1");
                        }
                        else
                        {
                            strGlueData.Append(dataGridView.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                    strGlueData.Append(j != dataGridView.Columns.Count - 1 ? "," : "\r\n");
                }
            }
            using (StreamWriter sw = new StreamWriter(strFolderPath, false, Encoding.Default))
            {
                sw.Write(strGlueData);
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

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DrawGUIPoint(false);
            DrawGUILine();
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
                    dataGridView.Columns[i].Width = 70;
                }
            }

            dataGridView.Rows.Add();
            dataGridView.Rows[dataGridView.RowCount - 1].Cells[0].Value = dataGridView.RowCount.ToString();

            DataGridViewComboBoxCell dgvComboBoxCellOfType = new DataGridViewComboBoxCell();
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

            DataGridViewRow row = new DataGridViewRow();
            int index = dataGridView.Rows.IndexOf(dataGridView.SelectedRows[0]);

            dataGridView.Rows.Insert(index + 1, row);

            DataGridViewComboBoxCell dgvComboBoxCellOfType = new DataGridViewComboBoxCell();
            dgvComboBoxCellOfType.Items.Add("Line");
            dgvComboBoxCellOfType.Items.Add("Arc");
            dataGridView.Rows[index].Cells[1] = dgvComboBoxCellOfType;

            DataGridViewComboBoxCell dgvComboBoxCellOfCircleMode = new DataGridViewComboBoxCell();
            dgvComboBoxCellOfCircleMode.Items.Add("");
            dgvComboBoxCellOfCircleMode.Items.Add("XY");
            dgvComboBoxCellOfCircleMode.Items.Add("XYZ");
            dataGridView.Rows[index].Cells[2] = dgvComboBoxCellOfCircleMode;

            for (int i = 3; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Rows[index].Cells[i].Value = string.Empty;
            }
            for (int i = index + 1; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Cells[0].Value = i + 1;
            }
            pictureBox.Refresh();
            DrawGUIPoint(true);
            DrawGUILine();
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
            DrawGUIPoint(true);
            DrawGUILine();
        }

        private void ToolStripMenuItem_Clear_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            this.Text = string.Empty;
            pictureBox.Refresh();
        }

        private void tkBTransparency_ValueChanged(object sender, EventArgs e)
        {
            lbAlpha.Text = tkBTransparency.Value.ToString();
            penRed.Color = Color.FromArgb(Convert.ToInt32(tkBTransparency.Value), Color.Red);
            penBlue.Color = Color.FromArgb(Convert.ToInt32(tkBTransparency.Value), Color.Blue);
            penGreen.Color = Color.FromArgb(Convert.ToInt32(tkBTransparency.Value), Color.Green);
            pictureBox.Refresh();
            DrawGUIPoint(false);
            DrawGUILine();
        }

        private void tkbGlueWidth_ValueChanged(object sender, EventArgs e)
        {
            lbGlueWidth.Text = tkBGlueWidth.Value.ToString();
            pictureBox.Refresh();
            DrawGUIPoint(false);
            DrawGUILine();
        }

        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridView.ClearSelection();
            if (e.Button == MouseButtons.Left)
            {
                HitTestResult hit = chart.HitTest(e.X, e.Y, ChartElementType.DataPoint);
                if (hit.Series != null)
                {
                    this.Cursor = Cursors.HSplit;
                    _pointIndex = hit.PointIndex;
                    //chart.Series[0].Points[hit.PointIndex].Color = Color.Blue;

                    var strings = _listCoorXAndZ[hit.PointIndex].strLabel.Split('_');
                    int id = Convert.ToInt32(strings[0]) - 1;
                    if (strings.Length == 1)
                    {
                        dataGridView.Rows[id].Cells[8].Selected = true;
                    }
                    else
                    {
                        if (strings[1] == "1")
                            dataGridView.Rows[id].Cells[5].Selected = true;
                        else
                            dataGridView.Rows[id].Cells[8].Selected = true;
                    }
                }
            }
        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            var xValue = Math.Round(chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X), 3);
            var yValue = Math.Round(chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y), 3);
            lbCX.Text = xValue.ToString(CultureInfo.InvariantCulture);
            lbCY.Text = yValue.ToString(CultureInfo.InvariantCulture);

            if (e.Button == MouseButtons.Left)
            {
                var strings = _listCoorXAndZ[_pointIndex].strLabel.Split('_');
                int id = Convert.ToInt32(strings[0]) - 1;
                if (dataGridView.Rows[id].Cells[5].Selected || dataGridView.Rows[id].Cells[8].Selected)
                {
                    if (strings.Length == 1)
                    {
                        dataGridView.Rows[id].Cells[8].Value = yValue;
                    }
                    else
                    {
                        if (strings[1] == "1")
                            dataGridView.Rows[id].Cells[5].Value = yValue;
                        else
                            dataGridView.Rows[id].Cells[8].Value = yValue;
                    }
                    DrawChartLine();
                }
            }
        }

        private void chart_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                //_bHitPoint = true;
                DataPoint dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                e.Text = $"({dataPoint.XValue}_{dataPoint.YValues[0]})";
            }
            else
            {
                //_bHitPoint = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void chart_Validated(object sender, EventArgs e)
        {

        }
    }
}
