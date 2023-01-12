using GlueReadWrite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

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
        private Rectangle _homeRectangle;

        private readonly Dictionary<string, Rectangle> _dicRectangles = new Dictionary<string, Rectangle>();
        private readonly Dictionary<string, GraphicsPath> _dicGraphicsPaths = new Dictionary<string, GraphicsPath>();
        //private readonly GraphicsPath _dicGraphicsPaths = new GraphicsPath();

        private int _selectedRow;
        private int _selectedColumn;

        private List<Coordination> _listCoorXAndZ = new List<Coordination>();
        private List<Coordination> _listCoorYAndZ = new List<Coordination>();

        private Series _seriesX;
        private Series _seriesY;
        private int _pointIndex = -1;

        private string _glueFilePath;
        private Bitmap _bmp;

        private int _lastSelectedRow = -1;
        private int _lastSelectedColumn = -1;
        private string _strGlueFileTail;

        public FormGluePath()
        {
            InitializeComponent();
            pictureBox.MouseWheel += new MouseEventHandler(pbxDrawing_MouseWheel);
            //pictureBox.Paint += new PaintEventHandler(pictureBox_Paint);
            dataGridView.AllowUserToAddRows = false;
            dataGridView.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter };
        }

        private void Form_GluePath_Load(object sender, EventArgs e)
        {
            tbRotation.AutoSize = false;
            tbRotation.Height = 28;
            tbRotation.Font = new Font("宋体", 12);
            button1.Height = 16;
            button2.Height = 17;
            button1.Text = string.Empty;
            button2.Text = string.Empty;

            _bmp = ReadImageFile(Application.StartupPath + @"\File\glue.BMP");
            pictureBox.Image = _bmp;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            SetPictureBox();

            dPictureBoxWidth = pictureBox.Width;
            dPictureBoxHeight = pictureBox.Height;
            dPictureBoxImageWidth = pictureBox.Image.Width;
            dPictureBoxImageHeight = pictureBox.Image.Height;

            tbStandardX.Text = "1160";
            tbStandardY.Text = "1280";

            graph = this.pictureBox.CreateGraphics();
            //graph = Graphics.FromImage(bmp);

            tkBGlueWidth.TickFrequency = 2;
            tkBGlueWidth.SmallChange = 1;

            tkBTransparency.TickFrequency = 25;
            tkBTransparency.SmallChange = 1;

            lbGlueWidth.Text = tkBGlueWidth.Value.ToString();
            lbTransparency.Text = tkBTransparency.Value.ToString();

            ConfigureSeries();

            #region MyRegion

            _glueFilePath = @"E:\2169\胶路拖拽\GlueReadWrite - 副本\bin\Debug\File\jiaolu.csv";
            //@"E:\Cowain\2169\GlueReadWrite\bin\Debug\File\jiaolu.csv";

            LoadToDataGridViewCsv(ReadGluePathFile(_glueFilePath));
            DrawGuiPointNew();
            DrawGuiLineNew();
            DrawChartLine();

            #endregion

        }

        private void DrawChartLine()
        {
            chart.Series.Clear();       // Clear series in "chart"
            _seriesX.Points.Clear();    // Clear points in "_seriesX"
            FlashCoordinationList();
            chart.Series.Add(_seriesX);

            //chart.DataSource = _listCoorXAndZ;// C# chart获取绘制完成的信号
            for (int i = 0; i < _listCoorXAndZ.Count; i++)
            {
                _seriesX.Points.AddXY(_listCoorXAndZ[i].CoorX, _listCoorXAndZ[i].CoorZ);
                _seriesX.Points[i].Label = _listCoorXAndZ[i].StrLabel;
                _seriesX.Points[i].MarkerColor = i == _pointIndex ? Color.Blue : Color.Red;
                _seriesX.Points[i].MarkerSize = 10;
            }

        }

        private void FlashCoordinationList()
        {
            _listCoorXAndZ.Clear();
            _listCoorYAndZ.Clear();
            try
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (dataGridView.Rows[i].Cells[1].Value.ToString() == EnumLineType.Line.ToString())
                    {
                        _listCoorXAndZ.Add(new Coordination
                        {
                            CoorX = Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value),
                            CoorZ = Convert.ToDouble(dataGridView.Rows[i].Cells[8].Value),
                            StrLabel = (i + 1).ToString()
                        });
                        _listCoorYAndZ.Add(new Coordination
                        {
                            CoorY = Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value),
                            CoorZ = Convert.ToDouble(dataGridView.Rows[i].Cells[8].Value),
                            StrLabel = (i + 1).ToString()
                        });
                    }
                    else
                    {
                        _listCoorXAndZ.AddRange(new[]{
                        new Coordination
                        {
                            CoorX = Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value),
                            CoorZ = Convert.ToDouble(dataGridView.Rows[i].Cells[5].Value),
                            StrLabel = $"{i + 1}-1"
                        },
                        new Coordination
                        {
                            CoorX = Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value),
                            CoorZ = Convert.ToDouble(dataGridView.Rows[i].Cells[8].Value),
                            StrLabel = $"{i + 1}-2"
                        }});
                        _listCoorYAndZ.AddRange(new[]{
                        new Coordination
                        {
                            CoorY = Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value),
                            CoorZ = Convert.ToDouble(dataGridView.Rows[i].Cells[5].Value),
                            StrLabel = $"{i + 1}-1"
                        },
                        new Coordination
                        {
                            CoorY = Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value),
                            CoorZ = Convert.ToDouble(dataGridView.Rows[i].Cells[8].Value),
                            StrLabel = $"{i + 1}-2"
                        }});
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }

        }

        private void ConfigureSeries()
        {
            Coordination temp = new Coordination();

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
                XValueMember = nameof(temp.CoorX),//"CoorX",
                YValueMembers = nameof(temp.CoorZ),//"CoorZ",
                MarkerSize = 12,
                MarkerBorderColor = Color.Black,
                MarkerColor = Color.Red,
                MarkerStyle = MarkerStyle.Circle,
                BorderWidth = 2//Convert.ToInt32(Math.Log(2, tkBGlueWidth.Value)),
                //IsValueShownAsLabel = true
            };
            temp = null;
        }

        private void btOpenGluePath_Click(object sender, EventArgs e)
        {
            _glueFilePath = OpenFileDialog(Application.StartupPath + "\\File");
            if (_glueFilePath != "")
            {
                this.Text = Path.GetFileName(_glueFilePath);
                LoadToDataGridViewCsv(ReadGluePathFile(_glueFilePath));
                DrawGuiPointNew();
                DrawGuiLineNew();
                DrawChartLine();
            }
            graph.DrawLine(penRed, 200, 200, 400, 400);
        }

        private string OpenFileDialog(string strPath)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = strPath;
                ofd.Filter = "(txt)(csv)(excel)|*.txt;*.csv;*.xls;*.xlsx";
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

                DrawGuiPointNew();
                DrawGuiLineNew();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            graph.DrawLine(penRed, 200, 200, 400, 400);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {
                bMoveFlag = false;
                _selectedRow = -1;
                _selectedColumn = -1;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
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
                    try
                    {
                        double dx = 0.008, dy = 0.008;

                        if (dataGridView.Rows[_selectedRow].Cells[_selectedColumn].Selected || dataGridView.Rows[_selectedRow].Cells[_selectedColumn + 1].Selected)
                        {
                            dataGridView.Rows[_selectedRow].Cells[_selectedColumn].Value = Math.Round(e.X * _dRatio * dx - Convert.ToDouble(tbStandardX.Text) * dx, 3);
                            dataGridView.Rows[_selectedRow].Cells[_selectedColumn + 1].Value = Math.Round(e.Y * _dRatio * dy - Convert.ToDouble(tbStandardY.Text) * dy, 3);
                        }
                    }
                    catch
                    {
                        // ignored
                    }
                }
                DrawGuiPointNew();
                DrawGuiLineNew();
            }

            lbPX.Text = (e.X * dPictureBoxImageWidth / pictureBox.Width).ToString("0.000");
            lbPY.Text = (e.Y * dPictureBoxImageHeight / pictureBox.Height).ToString("0.000");
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridView.ClearSelection();
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {
                this.pictureBox.Focus();
                bMoveFlag = true;
                xPos = e.X;
                yPos = e.Y;

                //if (_dicGraphicsPaths.IsOutlineVisible(xPos, yPos, penRed))
                //{

                //}

                foreach (var rectangle in _dicRectangles)
                {
                    if (rectangle.Value.Contains(xPos, yPos))
                    {
                        this.Cursor = Cursors.Cross;
                        if (cbWhole.Checked)
                        {

                        }
                        else
                        {
                            string[] strings = rectangle.Key.Split('-');
                            int serial = Convert.ToInt32(strings[0]);
                            _selectedRow = serial;
                            if (strings.Length == 1 || strings[1].Equals("2"))
                            {
                                dataGridView.Rows[serial].Cells[6].Selected = true;
                                _pointIndex = _dicRectangles.Keys.ToList().IndexOf(rectangle.Key);
                                _selectedColumn = 6;
                                dataGridView_CellClick(dataGridView, new DataGridViewCellEventArgs(6, serial));
                            }
                            else
                            {
                                dataGridView.Rows[serial].Cells[3].Selected = true;
                                _pointIndex = Array.IndexOf(_dicRectangles.Keys.ToArray(), rectangle.Key);
                                _selectedColumn = 3;
                                dataGridView_CellClick(dataGridView, new DataGridViewCellEventArgs(3, serial));
                            }
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
                    //    //    //DrawGuiPointNew();
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
                    //    //    //DrawGuiPointNew();
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
                DrawGuiPointNew();
                DrawGuiLineNew();
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

        private void LoadToDataGridViewTxt(string[] strTxt)
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
                        dgvComboBoxCellOfType.DataSource = Enum.GetValues(typeof(EnumLineType));
                        dataGridView.Rows[i].Cells[1] = dgvComboBoxCellOfType;

                    }
                    else if (j == 2)
                    {
                        DataGridViewComboBoxCell dgvComboBoxCellOfCircleMode = new DataGridViewComboBoxCell();
                        dgvComboBoxCellOfCircleMode.Items.Add("");
                        dgvComboBoxCellOfCircleMode.Items.Add("XY");
                        dgvComboBoxCellOfCircleMode.Items.Add("XYZ");
                        dataGridView.Rows[i].Cells[2] = dgvComboBoxCellOfCircleMode;
                    }
                    else
                    {
                        dataGridView.Rows[i].Cells[j].Value = strings[j].Split(':')[1];
                    }

                    strPathData[i, j] = strings[j].Split(':')[1];
                }
                if (strTxt[i].Split(',')[1].Split(':')[1] == "1")
                {
                    dataGridView.Rows[i].Cells[1].Value = EnumLineType.Arc;
                    dataGridView.Rows[i].Cells[2].Value = "XY";
                }
                else if (strTxt[i].Split(',')[1].Split(':')[1] == "0")
                {
                    dataGridView.Rows[i].Cells[1].Value = EnumLineType.Line;
                    dataGridView.Rows[i].Cells[3].ReadOnly = true;
                    dataGridView.Rows[i].Cells[4].ReadOnly = true;
                }
                else
                {
                    dataGridView.Rows[i].Cells[1].Value = "";
                }
            }
            dataGridView.ClearSelection();
        }

        private void btSaveGluePath_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != MessageBox.Show("是否保存胶路？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                return;

            //string strFolderPath = _glueFilePath;
            StringBuilder strGlueData = new StringBuilder();
            for (int i = -1; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (i == -1)
                    {
                        strGlueData.Append(dataGridView.Columns[j].HeaderText + (j != dataGridView.Columns.Count - 1 ? "," : "\r\n"));
                        continue;
                    }

                    if (dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        switch (j)
                        {
                            case 1:
                                if (dataGridView.Rows[i].Cells[1].Value.ToString() == EnumLineType.Line.ToString())
                                    strGlueData.Append("0");
                                else if (dataGridView.Rows[i].Cells[1].Value.ToString() == EnumLineType.Arc.ToString())
                                    strGlueData.Append("2");
                                break;
                            case 2:
                                try
                                {
                                    strGlueData.Append((int)(EnumCircleMode)Enum.Parse(typeof(EnumCircleMode), dataGridView.Rows[i].Cells[2].Value.ToString()));
                                }
                                catch (ArgumentException)
                                {
                                    strGlueData.Append("-1");
                                }
                                break;
                            case 13:
                                if ((bool)dataGridView.Rows[i].Cells[13].Value)
                                    strGlueData.Append("1");
                                else
                                    strGlueData.Append("0");
                                break;
                            default:
                                strGlueData.Append(dataGridView.Rows[i].Cells[j].Value);
                                break;
                        }
                    }
                    strGlueData.Append(j != dataGridView.Columns.Count - 1 ? "," : "\r\n");
                }
            }
            strGlueData.Append(_strGlueFileTail);
            using (StreamWriter sw = new StreamWriter(_glueFilePath, false, Encoding.Default))
            {
                sw.Write(strGlueData);
            }
        }

        private void LoadToDataGridViewCsv(string[] strTxt)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            string[] strHead = strTxt[0].Split(',');
            _strGlueFileTail = strTxt.Last();
            //string[,] strPathData = new string[strTxt.Length, strHead.Length];

            for (int i = 0; i < strHead.Length; i++)//添加列
            {
                if (i == 13)
                {
                    DataGridViewCheckBoxColumn dgvCheckBoxColumn = new DataGridViewCheckBoxColumn();
                    dgvCheckBoxColumn.Name = "column" + strHead[i].Split(',')[0];
                    dgvCheckBoxColumn.HeaderText = strHead[i].Split(',')[0];
                    dgvCheckBoxColumn.Width = 50;
                    dataGridView.Columns.Add(dgvCheckBoxColumn);
                    continue;
                }
                dataGridView.Columns.Add("column" + strHead[i].Split(',')[0], strHead[i].Split(',')[0]);
                dataGridView.Columns[i].Width = 70;
            }

            for (int i = 0; i < strTxt.Length - 2; i++)//添加行
            {
                var strings = strTxt[i + 1].Split(',');
                this.dataGridView.Rows.Add();
                for (int j = 0; j < strings.Length; j++)
                {
                    if (j == 1)
                    {
                        DataGridViewComboBoxCell dgvComboBoxCellOfType = new DataGridViewComboBoxCell();
                        dgvComboBoxCellOfType.DataSource = Enum.GetValues(typeof(EnumLineType));
                        dataGridView.Rows[i].Cells[1] = dgvComboBoxCellOfType;
                    }
                    else if (j == 2)
                    {
                        DataGridViewComboBoxCell dgvComboBoxCellOfCircleMode = new DataGridViewComboBoxCell();
                        dgvComboBoxCellOfCircleMode.DataSource = Enum.GetValues(typeof(EnumCircleMode));
                        dataGridView.Rows[i].Cells[2] = dgvComboBoxCellOfCircleMode;
                    }
                    else
                    {
                        dataGridView.Rows[i].Cells[j].Value = strings[j];
                    }
                    //strPathData[i, j] = strings[j];
                }

                if (strings[1] == "0")
                {
                    dataGridView.Rows[i].Cells[1].Value = EnumLineType.Line;
                    dataGridView.Rows[i].Cells[2].ReadOnly = true;
                    dataGridView.Rows[i].Cells[3].ReadOnly = true;
                    dataGridView.Rows[i].Cells[4].ReadOnly = true;
                    dataGridView.Rows[i].Cells[5].ReadOnly = true;
                    dataGridView.Rows[i].Cells[3].Style.BackColor = Color.Pink;
                    dataGridView.Rows[i].Cells[4].Style.BackColor = Color.Pink;
                    dataGridView.Rows[i].Cells[5].Style.BackColor = Color.Pink;
                }
                else
                {
                    dataGridView.Rows[i].Cells[1].Value = EnumLineType.Arc;
                    dataGridView.Rows[i].Cells[2].Value = EnumCircleMode.XY;
                }

                if (strings[2] == "-1")
                {
                    dataGridView.Rows[i].Cells[2].Value = string.Empty;
                }

                dataGridView.Rows[i].Cells[13].Value = strings[13] == "1";
            }
            dataGridView.ClearSelection();
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

        public void DrawGuiLine(bool isChange = true, bool bDrawSingle = false)
        {
            try
            {
                if (bDrawSingle)
                {
                    //pictureBox.Invalidate(_dicPoints[strKey]);
                    //if (dataGridView.Rows[_selectedRow].Cells[1].Value?.ToString() == EnumLineType.Line.ToString())
                    //{
                    //    _dicGraphicsPaths[(_selectedRow + 1).ToString()].ClearMarkers();
                    //}
                    //else if (dataGridView.Rows[_selectedRow].Cells[1].Value?.ToString() == EnumLineType.Arc.ToString())
                    //{
                    //    _dicGraphicsPaths[_selectedRow + 1 + "-1"].ClearMarkers();
                    //    _dicGraphicsPaths[_selectedRow + 1 + "-2"].ClearMarkers();
                    //}
                }
                else
                {
                    //_dicGraphicsPaths.Values.ToList().ForEach(t => t.ClearMarkers());
                    //画点那里会把线条都清掉
                }
            }
            catch
            {
                // ignored
            }
            penRed.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / _dRatio);
            penBlue.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / _dRatio);
            PointF pS = new PointF(), pM = default, pE = default;

            if (false)//bDrawSingle
            {
                if (dataGridView.Rows[0] != null)
                {
                    if (dataGridView.Rows[_selectedRow].Cells[1].Value?.ToString() == EnumLineType.Line.ToString())
                    {
                        if (GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow].Cells[7].Value) &&
                            GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow - 1].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow - 1].Cells[7].Value))
                        {
                            pS.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[_selectedRow - 1].Cells[6].Value) + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                            pS.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[_selectedRow - 1].Cells[7].Value) + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                            pE.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[_selectedRow].Cells[6].Value) + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                            pE.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[_selectedRow].Cells[7].Value) + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                            if (dataGridView.Rows[_selectedRow].Cells[6].Selected || dataGridView.Rows[_selectedRow].Cells[7].Selected)
                            {
                                graph.DrawLine(penBlue, pS, pE);
                            }
                            else
                            {
                                graph.DrawLine(penRed, pS, pE);
                            }
                            GraphicsPath gp = new GraphicsPath();
                            gp.AddLine(pS, pE);
                            _dicGraphicsPaths[(_selectedRow + 1).ToString()] = gp;
                        }
                    }
                    else if (dataGridView.Rows[_selectedRow].Cells[1].Value?.ToString() == EnumLineType.Arc.ToString())
                    {
                        if (GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow].Cells[3].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow].Cells[4].Value) &&
                            GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow].Cells[7].Value) &&
                            GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow - 1].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow - 1].Cells[7].Value))
                        {
                            pS.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[_selectedRow - 1].Cells[6].Value) + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                            pS.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[_selectedRow - 1].Cells[7].Value) + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                            pM.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[_selectedRow].Cells[3].Value) + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                            pM.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[_selectedRow].Cells[4].Value) + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                            pE.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[_selectedRow].Cells[6].Value) + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                            pE.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[_selectedRow].Cells[7].Value) + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                            float[] drawArc = GluePathForXAndY.DrawArc(pS.X, pS.Y, pM.X, pM.Y, pE.X, pE.Y);
                            if (dataGridView.Rows[_selectedRow].Cells[3].Selected || dataGridView.Rows[_selectedRow].Cells[4].Selected ||
                                dataGridView.Rows[_selectedRow].Cells[6].Selected || dataGridView.Rows[_selectedRow].Cells[7].Selected)
                            {
                                graph.DrawArc(penBlue, drawArc[0], drawArc[1], drawArc[2], drawArc[3], drawArc[4], drawArc[5]);
                            }
                            else
                            {
                                graph.DrawArc(penRed, drawArc[0], drawArc[1], drawArc[2], drawArc[3], drawArc[4], drawArc[5]);
                            }
                            GraphicsPath gp = new GraphicsPath();
                            string keyFirst = _selectedRow + 1 + "-1";
                            string keyLast = _selectedRow + 1 + "-2";
                            gp.AddArc(drawArc[0], drawArc[1], drawArc[2], drawArc[3], drawArc[4], drawArc[5]);
                            _dicGraphicsPaths[keyFirst] = gp;
                            _dicGraphicsPaths[keyLast] = gp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i < dataGridView.RowCount; i++)
                {
                    try
                    {
                        if (dataGridView.Rows[0] != null)
                        {
                            if (dataGridView.Rows[i].Cells[1].Value?.ToString() == EnumLineType.Line.ToString())
                            {
                                if (GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[7].Value) &&
                                    GluePathForXAndY.IsNumberic(dataGridView.Rows[i - 1].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i - 1].Cells[7].Value))
                                {
                                    pS.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[6].Value) * 100 + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                                    pS.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[7].Value) * 100 + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                                    pE.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value) * 100 + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                                    pE.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value) * 100 + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                                    if (dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected)
                                    {
                                        graph.DrawLine(penBlue, pS, pE);
                                    }
                                    else
                                    {
                                        graph.DrawLine(penRed, pS, pE);
                                    }
                                    //pS.X = Convert.ToInt64((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[6].Value) * 100 + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                                    //pS.Y = Convert.ToInt64((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[7].Value) * 100 + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                                    //pE.X = Convert.ToInt64((Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value) * 100 + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                                    //pE.Y = Convert.ToInt64((Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value) * 100 + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                                    //if (dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected)
                                    //{
                                    //    graph.DrawBeziers(penBlue, new PointF[]{pS, pE});
                                    //}
                                    //else
                                    //{
                                    //    graph.DrawBeziers(penRed, new PointF[] { pS, pE });
                                    //}
                                    if (isChange)
                                    {
                                        GraphicsPath gp = new GraphicsPath();
                                        string key = (i + 1).ToString();
                                        if (_dicGraphicsPaths.Keys.Contains(key))
                                        {
                                            _dicGraphicsPaths[key] = gp;
                                        }
                                        else
                                        {
                                            gp.AddLine(pS, pE);
                                            _dicGraphicsPaths.Add((i + 1).ToString(), gp);
                                        }
                                    }
                                }
                            }
                            else if (dataGridView.Rows[i].Cells[1].Value?.ToString() == EnumLineType.Arc.ToString())
                            {
                                if (GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[3].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[4].Value) &&
                                    GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[7].Value) &&
                                    GluePathForXAndY.IsNumberic(dataGridView.Rows[i - 1].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i - 1].Cells[7].Value))
                                {
                                    pS.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[6].Value) * 100 + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                                    pS.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i - 1].Cells[7].Value) * 100 + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                                    pM.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value) * 100 + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                                    pM.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value) * 100 + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                                    pE.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value) * 100 + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                                    pE.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value) * 100 + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                                    float[] drawArc = GluePathForXAndY.DrawArc(pS.X, pS.Y, pM.X, pM.Y, pE.X, pE.Y);
                                    if (dataGridView.Rows[i].Cells[3].Selected || dataGridView.Rows[i].Cells[4].Selected ||
                                        dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected)
                                    {
                                        graph.DrawArc(penBlue, drawArc[0], drawArc[1], drawArc[2], drawArc[3], drawArc[4], drawArc[5]);
                                    }
                                    else
                                    {
                                        graph.DrawArc(penRed, drawArc[0], drawArc[1], drawArc[2], drawArc[3], drawArc[4], drawArc[5]);
                                    }
                                    if (isChange)
                                    {
                                        GraphicsPath gp = new GraphicsPath();
                                        string keyFirst = i + 1 + "-1";
                                        string keyLast = i + 1 + "-2";
                                        if (_dicGraphicsPaths.Keys.Contains(keyFirst))
                                        {
                                            _dicGraphicsPaths[keyFirst] = gp;
                                            _dicGraphicsPaths[keyLast] = gp;
                                        }
                                        else
                                        {
                                            gp.AddArc(drawArc[0], drawArc[1], drawArc[2], drawArc[3], drawArc[4], drawArc[5]);
                                            _dicGraphicsPaths.Add(keyFirst, gp);
                                            _dicGraphicsPaths.Add(keyLast, gp);
                                        }
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
        }

        private void DrawGuiPoint(bool isChange = true, bool bDrawSingle = false)
        {
            try
            {
                if (bDrawSingle)
                {
                    pictureBox.Invalidate(_homeRectangle);
                    string strKey = $"{_selectedRow}{(_selectedColumn == 3 ? "-1" : "-2")}";
                    pictureBox.Invalidate(_dicRectangles[strKey]);
                }
                else
                {
                    pictureBox.Refresh();
                    //graph.Clear(Color.White);
                    //_dicRectangles.Values.ToList().ForEach(t => pictureBox.Invalidate(t));
                }
            }
            catch
            {
                // ignored
            }
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
            bool isArc;

            //if (_selectedRow == -1 || _selectedColumn == -1) return;
            if (false)
            {
                if (_lastSelectedRow != -1 && _lastSelectedColumn != -1)
                {
                    int x = Convert.ToInt32(Convert.ToDouble(dataGridView.Rows[_lastSelectedRow].Cells[_lastSelectedColumn].Value)) * 100;
                    int y = Convert.ToInt32(Convert.ToDouble(dataGridView.Rows[_lastSelectedRow].Cells[_lastSelectedColumn + 1].Value)) * 100;
                    pT.X = Convert.ToInt32((x + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                    pT.Y = Convert.ToInt32((y + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                    Rectangle lastEllipse = new Rectangle(pT.X - 2, pT.Y - 2, 10, 10);
                    graph.FillEllipse(Brushes.Red, lastEllipse);
                    graph.DrawString(dataGridView.Rows[_lastSelectedRow].Cells[0].Value + (_lastSelectedColumn == 3 ? "-1" : "-2"),
                        new Font("Verdana", 10), new SolidBrush(Color.Red), new PointF(pT.X, pT.Y - 20));
                }

                if (GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow].Cells[_selectedColumn].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[_selectedRow].Cells[_selectedColumn + 1].Value))
                {
                    int x = Convert.ToInt32(Convert.ToDouble(dataGridView.Rows[_selectedRow].Cells[_selectedColumn].Value));
                    int y = Convert.ToInt32(Convert.ToDouble(dataGridView.Rows[_selectedRow].Cells[_selectedColumn + 1].Value));
                    pT.X = Convert.ToInt32((x + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                    pT.Y = Convert.ToInt32((y + Convert.ToDouble(tbStandardY.Text)) / _dRatio);
                    Rectangle ellipse = new Rectangle(pT.X - 2, pT.Y - 2, 10, 10);

                    if (dataGridView.Rows[_selectedRow].Cells[_selectedColumn].Selected || dataGridView.Rows[_selectedRow].Cells[_selectedColumn + 1].Selected || dataGridView.Rows[_selectedRow].Cells[_selectedColumn + 2].Selected)
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
                    if (GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[3].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[4].Value))
                    {
                        isArc = true;
                        pT.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value) * 100 + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                        pT.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value) * 100 + Convert.ToDouble(tbStandardY.Text)) / _dRatio);

                        Rectangle ellipse = new Rectangle(pT.X - 3, pT.Y - 3, 6, 6);//(pT.X- 2, pT.Y - 2, 10, 10); 
                        if (isChange)
                        {
                            if (!_dicRectangles.Keys.Contains(i + "-1")) _dicRectangles.Add(i + "-1", ellipse);
                            else _dicRectangles[i + "-1"] = ellipse;
                        }

                        if (dataGridView.Rows[i].Cells[3].Selected || dataGridView.Rows[i].Cells[4].Selected || dataGridView.Rows[i].Cells[5].Selected)
                        {
                            graph.FillEllipse(Brushes.Blue, ellipse);
                            graph.DrawString(dataGridView.Rows[i].Cells[0].Value + "-1", new Font("Verdana", 10),
                                new SolidBrush(Color.Blue), new PointF(pT.X, pT.Y));
                        }
                        else
                        {
                            graph.FillEllipse(Brushes.Red, ellipse);
                            graph.DrawString(dataGridView.Rows[i].Cells[0].Value + "-1", new Font("Verdana", 10),
                                new SolidBrush(Color.Red), new PointF(pT.X, pT.Y));
                        }
                    }

                    if (GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[7].Value))
                    {
                        pT.X = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value) * 100 + Convert.ToDouble(tbStandardX.Text)) / _dRatio);
                        pT.Y = Convert.ToInt32((Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value) * 100 + Convert.ToDouble(tbStandardY.Text)) / _dRatio);

                        Rectangle ellipse = new Rectangle(pT.X - 3, pT.Y - 3, 6, 6);// - 2
                        if (isChange)
                        {
                            if (!_dicRectangles.Keys.Contains(i + (isArc ? "-2" : string.Empty)))
                                _dicRectangles.Add(i + (isArc ? "-2" : string.Empty), ellipse);
                            else _dicRectangles[i + (isArc ? "-2" : string.Empty)] = ellipse;
                        }

                        if (dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected || dataGridView.Rows[i].Cells[8].Selected)
                        {
                            graph.FillEllipse(Brushes.Blue, ellipse);
                            graph.DrawString(dataGridView.Rows[i].Cells[0].Value + (isArc ? "-2" : string.Empty),
                                new Font("Verdana", 10), new SolidBrush(Color.Blue), new PointF(pT.X, pT.Y));// - 20
                        }
                        else
                        {
                            graph.FillEllipse(Brushes.Red, ellipse);
                            graph.DrawString(dataGridView.Rows[i].Cells[0].Value + (isArc ? "-2" : string.Empty),
                                new Font("Verdana", 10), new SolidBrush(Color.Red), new PointF(pT.X, pT.Y));
                        }
                    }
                }
            }
        }

        public void DrawGuiLineNew()
        {
            GetPixelsNumberAndPhysicalLength();
            penRed.Width = Convert.ToInt32(tkBGlueWidth.Value) / (float)_dRatio;
            penBlue.Width = Convert.ToInt32(tkBGlueWidth.Value) / (float)_dRatio;
            PointF pS = new PointF(), pM, pE;

            for (int i = 1; i < dataGridView.RowCount; i++)
            {
                try
                {
                    if (dataGridView.Rows[0] != null)
                    {
                        if (dataGridView.Rows[i].Cells[1].Value?.ToString() == EnumLineType.Line.ToString())
                        {
                            if (GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[7].Value) &&
                                GluePathForXAndY.IsNumberic(dataGridView.Rows[i - 1].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i - 1].Cells[7].Value))
                            {
                                pS = GluePathForXAndY.TransformToPixelsF(
                                    Convert.ToDouble(dataGridView.Rows[i - 1].Cells[6].Value),
                                    Convert.ToDouble(dataGridView.Rows[i - 1].Cells[7].Value),
                                    Convert.ToDouble(tbStandardX.Text),
                                    Convert.ToDouble(tbStandardY.Text),
                                    _dRatio);
                                pE = GluePathForXAndY.TransformToPixelsF(
                                    Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value),
                                    Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value),
                                    Convert.ToDouble(tbStandardX.Text),
                                    Convert.ToDouble(tbStandardY.Text),
                                    _dRatio);
                                if (dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected)
                                {
                                    graph.DrawLine(penBlue, pS, pE);
                                }
                                else
                                {
                                    graph.DrawLine(penRed, pS, pE);
                                }

                                GraphicsPath gp = new GraphicsPath();
                                string key = (i + 1).ToString();
                                if (_dicGraphicsPaths.Keys.Contains(key))
                                {
                                    _dicGraphicsPaths[key] = gp;
                                }
                                else
                                {
                                    gp.AddLine(pS, pE);
                                    _dicGraphicsPaths.Add((i + 1).ToString(), gp);
                                }
                            }
                        }
                        else if (dataGridView.Rows[i].Cells[1].Value?.ToString() == EnumLineType.Arc.ToString())
                        {
                            if (GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[3].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[4].Value) &&
                                GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[7].Value) &&
                                GluePathForXAndY.IsNumberic(dataGridView.Rows[i - 1].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i - 1].Cells[7].Value))
                            {
                                pS = GluePathForXAndY.TransformToPixelsF(
                                    Convert.ToDouble(dataGridView.Rows[i - 1].Cells[6].Value),
                                    Convert.ToDouble(dataGridView.Rows[i - 1].Cells[7].Value),
                                    Convert.ToDouble(tbStandardX.Text),
                                    Convert.ToDouble(tbStandardY.Text),
                                    _dRatio);
                                pM = GluePathForXAndY.TransformToPixelsF(
                                    Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value),
                                    Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value),
                                    Convert.ToDouble(tbStandardX.Text),
                                    Convert.ToDouble(tbStandardY.Text),
                                    _dRatio);
                                pE = GluePathForXAndY.TransformToPixelsF(
                                    Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value),
                                    Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value),
                                    Convert.ToDouble(tbStandardX.Text),
                                    Convert.ToDouble(tbStandardY.Text),
                                    _dRatio);
                                float[] drawArc = GluePathForXAndY.DrawArc(pS.X, pS.Y, pM.X, pM.Y, pE.X, pE.Y);
                                if (dataGridView.Rows[i].Cells[3].Selected || dataGridView.Rows[i].Cells[4].Selected ||
                                    dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected)
                                {
                                    graph.DrawArc(penBlue, drawArc[0], drawArc[1], drawArc[2], drawArc[3], drawArc[4], drawArc[5]);
                                }
                                else
                                {
                                    graph.DrawArc(penRed, drawArc[0], drawArc[1], drawArc[2], drawArc[3], drawArc[4], drawArc[5]);
                                }

                                GraphicsPath gp = new GraphicsPath();
                                string keyFirst = i + 1 + "-1";
                                string keyLast = i + 1 + "-2";
                                if (_dicGraphicsPaths.Keys.Contains(keyFirst))
                                {
                                    _dicGraphicsPaths[keyFirst] = gp;
                                    _dicGraphicsPaths[keyLast] = gp;
                                }
                                else
                                {
                                    gp.AddArc(drawArc[0], drawArc[1], drawArc[2], drawArc[3], drawArc[4], drawArc[5]);
                                    _dicGraphicsPaths.Add(keyFirst, gp);
                                    _dicGraphicsPaths.Add(keyLast, gp);
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

        private void DrawGuiPointNew()
        {
            pictureBox.Refresh();
            GetPixelsNumberAndPhysicalLength();

            penRed.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / _dRatio);
            penBlue.Width = Convert.ToInt32(tkBGlueWidth.Value) * (float)(1 / _dRatio);

            float iStandardX = Convert.ToInt64(tbStandardX.Text);
            float iStandardY = Convert.ToInt64(tbStandardY.Text);
            Point pH = GluePathForXAndY.TransformToPixels(0, 0,
                Convert.ToDouble(tbStandardX.Text),
                Convert.ToDouble(tbStandardY.Text),
                _dRatio);
            _homeRectangle = new Rectangle(pH.X, pH.Y, 10, 10);
            graph.FillEllipse(Brushes.Green, _homeRectangle);
            //graph.DrawArc(penGreen, iStandardX - 30, iStandardY - 30, 6, 6, 0, 360);
            graph.DrawString("0", new Font("Verdana", 10), new SolidBrush(Color.Green), new PointF(iStandardX, iStandardY));

            Point pT = new Point();
            bool isArc;
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                isArc = false;
                if (GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[3].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[4].Value))
                {
                    isArc = true;
                    pT = GluePathForXAndY.TransformToPixels(
                        Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value),
                        Convert.ToDouble(dataGridView.Rows[i].Cells[4].Value),
                        Convert.ToDouble(tbStandardX.Text),
                        Convert.ToDouble(tbStandardY.Text),
                        _dRatio);

                    Rectangle ellipse = new Rectangle(pT.X - 2, pT.Y - 2, 6, 6);
                    if (!_dicRectangles.Keys.Contains(i + "-1")) _dicRectangles.Add(i + "-1", ellipse);
                    else _dicRectangles[i + "-1"] = ellipse;

                    if (dataGridView.Rows[i].Cells[3].Selected || dataGridView.Rows[i].Cells[4].Selected || dataGridView.Rows[i].Cells[5].Selected)
                    {
                        graph.FillEllipse(Brushes.Blue, ellipse);
                        graph.DrawString(dataGridView.Rows[i].Cells[0].Value + "-1", new Font("Verdana", 10),
                            new SolidBrush(Color.Blue), new PointF(pT.X, pT.Y));
                    }
                    else
                    {
                        graph.FillEllipse(Brushes.Red, ellipse);
                        graph.DrawString(dataGridView.Rows[i].Cells[0].Value + "-1", new Font("Verdana", 10),
                            new SolidBrush(Color.Red), new PointF(pT.X, pT.Y));
                    }
                }

                if (GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[6].Value) && GluePathForXAndY.IsNumberic(dataGridView.Rows[i].Cells[7].Value))
                {
                    pT = GluePathForXAndY.TransformToPixels(
                        Convert.ToDouble(dataGridView.Rows[i].Cells[6].Value),
                        Convert.ToDouble(dataGridView.Rows[i].Cells[7].Value),
                        Convert.ToDouble(tbStandardX.Text),
                        Convert.ToDouble(tbStandardY.Text),
                        _dRatio);

                    Rectangle ellipse = new Rectangle(pT.X - 2, pT.Y - 2, 6, 6);// - 2
                    if (!_dicRectangles.Keys.Contains(i + (isArc ? "-2" : string.Empty)))
                        _dicRectangles.Add(i + (isArc ? "-2" : string.Empty), ellipse);
                    else _dicRectangles[i + (isArc ? "-2" : string.Empty)] = ellipse;

                    if (dataGridView.Rows[i].Cells[6].Selected || dataGridView.Rows[i].Cells[7].Selected || dataGridView.Rows[i].Cells[8].Selected)
                    {
                        graph.FillEllipse(Brushes.Blue, ellipse);
                        graph.DrawString(dataGridView.Rows[i].Cells[0].Value + (isArc ? "-2" : string.Empty),
                            new Font("Verdana", 10), new SolidBrush(Color.Blue), new PointF(pT.X, pT.Y));// - 20
                    }
                    else
                    {
                        graph.FillEllipse(Brushes.Red, ellipse);
                        graph.DrawString(dataGridView.Rows[i].Cells[0].Value + (isArc ? "-2" : string.Empty),
                            new Font("Verdana", 10), new SolidBrush(Color.Red), new PointF(pT.X, pT.Y));
                    }
                }
            }
        }

        private void GetPixelsNumberAndPhysicalLength()
        {
            try
            {
                GlueVariableDefine.PixelsNumber = Convert.ToInt32(tbPixelsNumber.Text);
                GlueVariableDefine.PhysicalLength = Convert.ToDouble(tbPhyscialLength.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
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
            _selectedRow = e.RowIndex;
            _selectedColumn = e.ColumnIndex;
            DrawGuiPointNew();
            DrawGuiLineNew();
            _lastSelectedRow = _selectedRow;
            _lastSelectedColumn = _selectedColumn;

            if (e.ColumnIndex == 5 || e.ColumnIndex == 8)
            {
                string strLabel;
                if (dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString() == EnumLineType.Line.ToString())
                {
                    strLabel = (e.RowIndex + 1).ToString();
                }
                else
                {
                    strLabel = $"{e.RowIndex + 1}{(e.ColumnIndex == 5 ? "-1" : "-2")}";
                }

                for (int i = 0; i < _listCoorXAndZ.Count; i++)
                {
                    if (_listCoorXAndZ[i].StrLabel == strLabel)
                        _pointIndex = i;
                }
            }
            DrawChartLine();
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
            dgvComboBoxCellOfType.DataSource = Enum.GetValues(typeof(EnumLineType));
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
            dgvComboBoxCellOfType.DataSource = Enum.GetValues(typeof(EnumLineType));
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
            DrawGuiPointNew();
            DrawGuiLineNew();
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
            DrawGuiPointNew();
            DrawGuiLineNew();
        }

        private void ToolStripMenuItem_Clear_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            this.Text = string.Empty;
            pictureBox.Refresh();
        }

        private void tkBTransparency_ValueChanged(object sender, EventArgs e)
        {
            lbTransparency.Text = tkBTransparency.Value.ToString();
            penRed.Color = Color.FromArgb(Convert.ToInt32(tkBTransparency.Value), Color.Red);
            penBlue.Color = Color.FromArgb(Convert.ToInt32(tkBTransparency.Value), Color.Blue);
            penGreen.Color = Color.FromArgb(Convert.ToInt32(tkBTransparency.Value), Color.Green);
            pictureBox.Refresh();
            DrawGuiPointNew();
            DrawGuiLineNew();
        }

        private void tkbGlueWidth_ValueChanged(object sender, EventArgs e)
        {
            lbGlueWidth.Text = tkBGlueWidth.Value.ToString();
            pictureBox.Refresh();
            DrawGuiPointNew();
            DrawGuiLineNew();
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

                    var strings = _listCoorXAndZ[hit.PointIndex].StrLabel.Split('_');
                    int id = Convert.ToInt32(strings[0]) - 1;
                    if (strings.Length == 1 || strings[1] == "2")
                    {
                        dataGridView.Rows[id].Cells[8].Selected = true;
                        dataGridView_CellClick(dataGridView, new DataGridViewCellEventArgs(id, 8));
                    }
                    else
                    {
                        dataGridView.Rows[id].Cells[5].Selected = true;
                        dataGridView_CellClick(dataGridView, new DataGridViewCellEventArgs(id, 5));
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

            if (e.Button == MouseButtons.Left && _pointIndex != -1)
            {
                var strings = _listCoorXAndZ[_pointIndex].StrLabel.Split('_');
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
                DataPoint dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                e.Text = $"({dataPoint.XValue}_{dataPoint.YValues[0]})";
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void chart_Validated(object sender, EventArgs e)
        {

        }
    }
}
