using Assignment.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Assignment.DataStruct;
using System.Security.Cryptography;
using Assignment.Algorithm;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Runtime.InteropServices.ComTypes;

namespace Assignment
{
    public partial class MainForm : Form
    {
        private Camera _camPara;

        //相机参数全局变量，在进行读取相机参数操作后会刷新 
        //u为像元尺寸，f为相机焦距，xm为像主点位置x，ym为像主点位置y，m为图像宽度，n为图像高度
        double u = 0.006, f = 70.5, xm = 0, ym = 0.12;         
        double m = 11310, n = 17310, l0, h0; 
       

        double[,] l_SamePoint, r_SamePoint;//同名像点
        readonly List<pixel> L_pixels = new List<pixel>();//左影像
        readonly List<pixel> R_pixels = new List<pixel>();//右影像
        List<Algorithm.Point> points = new List<Algorithm.Point>();//地面点坐标
        double[,] a, b;//存储外方位元素大小6*1   
        double[,] dingxiang;//相对定向元素
        double[,] left = new double[6, 1];
        double[,] right = new double[6, 1];

        private void 相对定向ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 后方交会ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 前方交会ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      

        /// <summary>
        /// 加载相机参数按钮
        /// </summary> 
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog(); //显示一个读取文件对话框 
            //string dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //openFileDialog1.InitialDirectory = dir;
            openFileDialog1.Filter = "txt files(*.txt)|*.txt|image files(*.*)|*.*";  //文件扩展名筛选
            openFileDialog1.FilterIndex = 1; //默认设置为txt
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //如果文件被正常读取
            {
                string FileName = openFileDialog1.FileName;
                //string extension = Path.GetExtension(FileName); 
                //string txtfiles = ".txt";
                //bool result = extension.Equals(txtfiles);
                _camPara = new Camera(FileName); //调用Camera.cs读取相机参数
                textBox1.Text = _camPara.WidthPix.ToString("##.0");     //图像宽度文本框
                textBox2.Text = _camPara.HeightPix.ToString("##.0");    //图像高度文本框
                textBox3.Text = _camPara.f.ToString("##.00");           //相机焦距文本框
                textBox4.Text = _camPara.PixSize.ToString("##.000");    //像元尺寸文本框
                textBox5.Text = _camPara.MainPosXPix.ToString("0.00");  //像主点位置x
                textBox6.Text = _camPara.MainPosYPix.ToString("0.00");  //像主点位置y

                //将读取到的数据写入相机参数全局变量
                u = _camPara.PixSize;       //像元尺寸
                f = _camPara.f;             //相机焦距
                xm = _camPara.MainPosXPix;  //像主点位置x
                ym = _camPara.MainPosYPix;  //像主点位置y
                m = _camPara.WidthPix;      //图像宽度
                n = _camPara.HeightPix;     //图像高度
            }
        }


        /// <summary>
        /// 打开控制点文件按钮
        /// </summary> 
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //如果检测到文本框为空，说明相机参数未被读取，需提示用户读取相机参数
            if (textBox1.Text == String.Empty)  
            {
                MessageBox.Show("未加载相机参数");
            }
            else
            {
                //读取控制点数据
                open();
            }
           
        }
        /// <summary>
        /// 判断DataGridView是否为空
        /// </summary> 
        private bool isEmptydataGridView(DataGridView dg)
        {
            string s;
            int intRowCount = dg.Rows.Count;
            int intColCount = dg.Columns.Count;
            for (int i = 0; i < intRowCount; i++)
                for (int j = 0; j < intColCount; j++)
                {
                    s = Convert.ToString(dg.Rows[i].Cells[j].Value);
                    if (!string.IsNullOrEmpty(s))
                    { return false; }

                }
            return true;
        }

        /// <summary>
        /// 打开真值文件并进行误差值计算
        /// </summary> 
        private void 误差值计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isEmpty= isEmptydataGridView(dataGridView1);
            if (isEmpty)
            {
                MessageBox.Show("请先进行后方交会");
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "打开真值文件";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //打开文件
                    string path = openFileDialog.FileName;
                    StreamReader truth = new StreamReader(path, Encoding.Default);
                    //行数统计临时值k
                    int k = 0;
                    //tr数组为真值数组，大小6*2  
                    double[,] tr = new double[6, 2];
                    //cr数组为计算值数组，大小6*2  
                    double[,] cr = new double[6, 2];
                    //将计算出来的左右影像的大小6*1的外方位元素a，b存入cr数组
                    for (int i = 0; i < 6; i++)
                    {
                        cr[i, 0] = a[i, 0];
                        cr[i, 1] = b[i, 0];
                    }
                    //误差值数组rr，大小6*2
                    double[,] rr = new double[6, 2];
                    //读取真值文本文件
                    while (!truth.EndOfStream)
                    {
                        string[] tru = truth.ReadLine().Split(',');
                        for (int i = 0; i < 6; i++)
                        {
                            tr[i, k] = Convert.ToDouble(tru[i]);
                        }
                        k++;
                    }
                    //遍历数组计算误差值
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            rr[i, j] = cr[i, j] - tr[i, j];
                        }
                    }
                    //清除dataGridView里的原有数据
                    dataGridView1.Columns.Clear();
                    //为dataGridView写入指定列
                    dataGridView1.Columns.Add("外方位元素", "外方位元素");
                    string[] elements = { "Xs", "Ys", "Zs", "航向倾角φ", "旁向倾角ω", "像片旋角κ" };
                    dataGridView1.Columns.Add("左影像", "左影像");
                    dataGridView1.Columns.Add("右影像", "右影像");
                    dataGridView1.Columns.Add("左影像真值", "左影像真值");
                    dataGridView1.Columns.Add("右影像真值", "右影像真值");
                    dataGridView1.Columns.Add("左影像误差", "左影像误差");
                    dataGridView1.Columns.Add("右影像误差", "右影像误差");
                    //输出计算值、真值、误差值               
                    for (int i = 0; i < 6; i++)
                    {
                        dataGridView1.Rows.Add(elements[i], a[i, 0], b[i, 0], tr[i, 0], tr[i, 1], rr[i, 0], rr[i, 1]);
                    }
                }
            }
            
        }

        /// <summary>
        /// 后方交会按钮
        /// </summary> 
        private void 进行后方交会ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (points.Count != 0)
            {
                //计算外方位元素，并存入全局变量a,b
                a = JiaoHui.HouFangJiaoHui(L_pixels, points, f);
                b = JiaoHui.HouFangJiaoHui(R_pixels, points, f);

                //清除dataGridView里的原有数据
                dataGridView1.Columns.Clear();
                //填满右panel
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //为dataGridView写入指定列
                dataGridView1.Columns.Add("外方位元素", "外方位元素");
                string[] elements = { "Xs", "Ys", "Zs", "航向倾角φ", "旁向倾角ω", "像片旋角κ" };
                dataGridView1.Columns.Add("左影像", "左影像"); 
                dataGridView1.Columns.Add("右影像", "右影像");
                //输出外方位元素
                for (int i = 0; i < 6; i++)
                {
                    dataGridView1.Rows.Add(elements[i], a[i, 0], b[i, 0]);
                }
                
            }
            else
            {
                MessageBox.Show("没有数据");
            }
        }

        /// <summary>
        /// 前方交会按钮
        /// </summary> 
        private void 进行前方交会ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //计算外方位元素大小，并存入全局变量a,b
            a = JiaoHui.HouFangJiaoHui(L_pixels, points, f);
            b = JiaoHui.HouFangJiaoHui(R_pixels, points, f);
            OpenFileDialog open = new OpenFileDialog();
            double[,] xyz;
            double[,] c, d;
            c = a;
            d = b;
            

            if (open.ShowDialog() == DialogResult.OK)
            {
                //像主点行列号
                l0 = ((m - 1) / 2 + xm / u);
                h0 = ((n - 1) / 2 - ym / u);

                //统计txt行数
                int lines = 0;  
                StreamReader sr = new StreamReader(open.FileName);
                while (sr.ReadLine() != null)
                {
                    lines++;
                }
                sr.Close();
                //统计txt行数完毕，关闭文件

                //读取前方交会文件
                StreamReader reader = new StreamReader(open.FileName);
                string[] a = reader.ReadLine().Split(',');

                int count = lines - 1;  //需要减去首行说明文字

                double[,] l_pixel = new double[count, 4];
                int i = 0;
                while (!reader.EndOfStream)
                {
                    string[] aa = reader.ReadLine().Split(',');

                    l_pixel[i, 0] = (Convert.ToDouble(aa[2]) - l0) * u;
                    l_pixel[i, 1] = (h0 - Convert.ToDouble(aa[1])) * u;
                    l_pixel[i, 2] = (Convert.ToDouble(aa[4]) - l0) * u;
                    l_pixel[i, 3] = (h0 - Convert.ToDouble(aa[3])) * u;
                    i++;

                }
                double[,] xyf1 = new double[3, l_pixel.GetLength(0)];
                double[,] xyf2 = new double[3, l_pixel.GetLength(0)];
                for (int j = 0; j < i; j++)
                {
                    xyf1[0, j] = l_pixel[j, 0];
                    xyf1[1, j] = l_pixel[j, 1];
                    xyf1[2, j] = -f;
                    xyf2[0, j] = l_pixel[j, 2];
                    xyf2[1, j] = l_pixel[j, 3];
                    xyf2[2, j] = -f;
                }

                xyz = JiaoHui.qianfangjiaohui(c, d, xyf1, xyf2);
              
                dataGridView1.Columns.Clear();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns.Add("x", "x");
                dataGridView1.Columns.Add("y", "y");
                dataGridView1.Columns.Add("z", "z");
                for (int j = 0; j < i; j++)
                {
                    dataGridView1.Rows.Add(xyz[0, j].ToString(), xyz[1, j].ToString(), xyz[2, j].ToString());
                }


            }
        }

        /// <summary>
        /// 打开控制点文件按钮
        /// </summary> 
        private void 打开控制点文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("未加载相机参数");
            }
            else
            {
                //读取控制点数据
                open();
            }
        }

        /// <summary>
        /// 打开同名像点文件按钮
        /// </summary> 
        private void 打开相对定向文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("未加载相机参数");
            }
            else
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Title = "相对定向";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    StreamReader stream = new StreamReader(open.FileName);
                    int count = Convert.ToInt32(stream.ReadLine());
                    //同名像点
                    l_SamePoint = new double[3, count];
                    r_SamePoint = new double[3, count];
                    int i = 0;
                    //像主点行列号
                    l0 = ((m - 1) / 2 + xm / u);
                    h0 = ((n - 1) / 2 - ym / u);

                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.Columns.Add("同名像点在左影像上的行号", "同名像点在左影像上的行号");
                    dataGridView1.Columns.Add("同名像点在左影像上的列号", "同名像点在左影像上的列号");
                    dataGridView1.Columns.Add("同名像点在右影像上的行号", "同名像点在右影像上的行号");
                    dataGridView1.Columns.Add("同名像点在右影像上的列号", "同名像点在右影像上的列号");

                    //读取同名像点
                    while (!stream.EndOfStream)
                    {
                        string[] a = stream.ReadLine().Split(',');
                        //输出读取值看读取是否成功
                        dataGridView1.Rows.Add(a[0], a[1], a[2], a[3]);

                        l_SamePoint[0, i] = (Convert.ToDouble(a[1]) - l0) * u;
                        l_SamePoint[1, i] = (h0 - Convert.ToDouble(a[0])) * u;
                        l_SamePoint[2, i] = -f;
                        r_SamePoint[0, i] = (Convert.ToDouble(a[3]) - l0) * u;
                        r_SamePoint[1, i] = (h0 - Convert.ToDouble(a[2])) * u;
                        r_SamePoint[2, i] = -f;
                        i++;
                    }                    
                   
                }
            }
            

        }

        /// <summary>
        /// 进行相对定向按钮
        /// </summary> 
        private void 进行相对定向ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (l_SamePoint != null)
            {
                //进行相对定向
                dingxiang = DingXiang.XiangDuiDIngXiang(l_SamePoint, r_SamePoint,f);
                //左、右图像外方位元素
                left[3, 0] = dingxiang[0, 0];
                left[5, 0] = dingxiang[2, 0];
                right[0, 0] = 22.776;
                right[3, 0] = dingxiang[3, 0];
                right[4, 0] = dingxiang[4, 0];
                right[5, 0] = dingxiang[5, 0];
                //显示
                dataGridView1.Columns.Clear();               
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns.Add("相对定向元素", "相对定向元素");
                for (int i = 0; i < 6; i++)
                {
                    dataGridView1.Rows.Add(dingxiang[i, 0]);
                }               
            }
            else
            {
                MessageBox.Show("没有数据");
            }
        }



        /// <summary>
        /// 打开控制点文件函数
        /// </summary> 
        public void open()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开控制点文件";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                //打开文件
                string path = openFileDialog.FileName;
                StreamReader reader = new StreamReader(path, Encoding.Default);
                string[] a = reader.ReadLine().Split(',');
                dataGridView1.Columns.Clear();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //这里a为局部变量，读取txt第一行作为列名
                foreach (string i in a)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.Name = i;
                    column.HeaderText = i;                    
                    dataGridView1.Columns.Add(column);
                }

                //求像方坐标，并读取数据
                //像主点行列号
                l0 = ((m - 1) / 2 + xm / u);
                h0 = ((n - 1) / 2 - ym / u);
                while (!reader.EndOfStream)
                {
                    pixel pixels1 = new pixel(), pixels2 = new pixel();
                    Algorithm.Point point = new Algorithm.Point();
                    string[] temp = reader.ReadLine().Split(',');
                    point.ID = pixels1.ID = pixels2.ID = Convert.ToInt32(temp[0]);
                    //求出像平面坐标
                    pixels1.x = (Convert.ToDouble(temp[2]) - l0) * u;
                    pixels1.y = (h0 - Convert.ToDouble(temp[1])) * u;
                    pixels1.z = 0.0f;
                    L_pixels.Add(pixels1);//左影像

                    pixels2.x = (Convert.ToDouble(temp[4]) - l0) * u;
                    pixels2.y = (h0 - Convert.ToDouble(temp[3])) * u;
                    pixels2.z = 0.0f;
                    R_pixels.Add(pixels2);//右影像
                    point.X = Convert.ToDouble(temp[5]);
                    point.Y = Convert.ToDouble(temp[6]);
                    point.Z = Convert.ToDouble(temp[7]);
                    points.Add(point);//地面点

                }

                //输出坐标
                for (int i = 0; i < points.Count(); i++)
                {
                    string[] rows = new string[]
                    { L_pixels[i].ID.ToString(), L_pixels[i].x.ToString(), L_pixels[i].y.ToString(),
                     R_pixels[i].x.ToString(),R_pixels[i].y.ToString(),
                    points[i].X.ToString(),points[i].Y.ToString(),points[i].Z.ToString()};
                    
                    dataGridView1.Rows.Add(rows);
                }
             


            }
        }
        public MainForm()
        {
            InitializeComponent();
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

       
    }
}
