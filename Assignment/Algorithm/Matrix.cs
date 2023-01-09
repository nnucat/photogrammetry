using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Algorithm
{
    public class pixel//像平面坐标
    {
        public int ID;
        public double x;
        public double y;
        public double z;        

    }

    public class Point //地面点坐标
    {
        public int ID;
        public double X;
        public double Y;
        public double Z;       
    }
    /// <summary>
    /// 矩阵类
    /// </summary>
    public class matrix
    {

        /// 方阵求逆函数1,Psr为输入方阵，N为方阵的大小,P为返回的逆矩阵
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public static double[,] juzhqn1(double[,] Psr)
        {
            double[,] P;
            double d = 0.0;
            double temp = 0.0;
            int N, N1;
            N = Psr.GetLength(0);
            N1 = Psr.GetLength(1);
            P = new double[N, N1];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N1; j++)
                    P[i, j] = Psr[i, j];
            int[] main_row = new int[N];
            int[] main_col = new int[N];
            if (N == N1)
            {
                for (int k = 0; k <= N - 1; k++)
                {
                    d = 0.0;
                    for (int i = k; i <= N - 1; i++)
                    {
                        for (int j = k; j <= N - 1; j++)
                        {
                            temp = Math.Abs(P[i, j]);
                            if (temp > d)
                            {
                                d = temp; main_row[k] = i; main_col[k] = j;
                            }
                        }
                    }
                    if (main_row[k] != k)
                    {
                        for (int j = 0; j <= N - 1; j++)
                        {
                            temp = P[main_row[k], j]; P[main_row[k], j] = P[k, j]; P[k, j] = temp;
                        }
                    }
                    if (main_col[k] != k)
                    {
                        for (int i = 0; i <= N - 1; i++)
                        {
                            temp = P[i, main_col[k]]; P[i, main_col[k]] = P[i, k]; P[i, k] = temp;
                        }
                    }
                    P[k, k] = 1.0 / P[k, k];
                    for (int j = 0; j <= N - 1; j++)
                    {
                        if (j != k)
                        {
                            P[k, j] *= P[k, k];
                        }
                    }

                    for (int i = 0; i <= N - 1; i++)
                    {
                        if (i != k)
                        {
                            for (int j = 0; j <= N - 1; j++)
                            {
                                if (j != k)
                                {
                                    P[i, j] -= P[i, k] * P[k, j];
                                }
                            }
                        }
                    }
                    for (int i = 0; i <= N - 1; i++)
                    {
                        if (i != k)
                        {
                            P[i, k] = -P[i, k] * P[k, k];
                        }
                    }
                }
                for (int k = N - 1; k >= 0; k--)
                {
                    if (main_col[k] != k)
                    {
                        for (int j = 0; j <= N - 1; j++)
                        {
                            temp = P[k, j]; P[k, j] = P[main_col[k], j]; P[main_col[k], j] = temp;
                        }
                    }
                    if (main_row[k] != k)
                    {
                        for (int i = 0; i <= N - 1; i++)
                        {
                            temp = P[i, k]; P[i, k] = P[i, main_row[k]]; P[i, main_row[k]] = temp;
                        }
                    }
                }
            }
            return P;

        }
        /// <summary>
        /// 矩阵转置
        /// </summary>
        /// <param name="a">要转置的矩阵</param>
        /// <param name="m">行</param>
        /// <param name="n">列</param>
        /// <returns></returns>
        public static double[,] T(double[,] a, int m, int n)
        {
            double[,] b = new double[n, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    b[j, i] = a[i, j];
                }
            }
            return b;
        }
        /// <summary>
        /// 旋转矩阵
        /// </summary>
        /// <param name="phi">外方位元素数组</param>
        /// <returns>旋转矩阵</returns>
        public static double[,] xuanzhuanjuzhen(double[,] phi)
        {
            double[,] a = new double[3, 3];//旋转矩阵
            a[0, 0] = Math.Cos(phi[3, 0]) * Math.Cos(phi[5, 0]) - Math.Sin(phi[3, 0]) * Math.Sin(phi[4, 0]) * Math.Sin(phi[5, 0]);
            a[1, 0] = -1 * Math.Cos(phi[3, 0]) * Math.Sin(phi[5, 0]) - Math.Sin(phi[3, 0]) * Math.Sin(phi[4, 0]) * Math.Cos(phi[5, 0]);
            a[2, 0] = -1 * Math.Sin(phi[3, 0]) * Math.Cos(phi[4, 0]);
            a[0, 1] = Math.Cos(phi[4, 0]) * Math.Sin(phi[5, 0]);
            a[1, 1] = Math.Cos(phi[4, 0]) * Math.Cos(phi[5, 0]);
            a[2, 1] = -1 * Math.Sin(phi[4, 0]);
            a[0, 2] = Math.Sin(phi[3, 0]) * Math.Cos(phi[5, 0]) + Math.Cos(phi[3, 0]) * Math.Sin(phi[4, 0]) * Math.Sin(phi[5, 0]);
            a[1, 2] = -1 * Math.Sin(phi[3, 0]) * Math.Sin(phi[5, 0]) + Math.Cos(phi[3, 0]) * Math.Sin(phi[4, 0]) * Math.Cos(phi[5, 0]);
            a[2, 2] = Math.Cos(phi[3, 0]) * Math.Cos(phi[4, 0]);
            return a;
        }
        /// <summary>
        /// 旋转矩阵
        /// </summary>
        /// <param name="phi"></param>
        /// <param name="w"></param>
        /// <param name="k"></param>
        /// <returns>旋转矩阵</returns>
        public static double[,] xuanzhuanjuzhen(double phi, double w, double k)

        {
            double[,] a = new double[3, 3];//旋转矩阵
            a[0, 0] = Math.Cos(phi) * Math.Cos(k) - Math.Sin(phi) * Math.Sin(w) * Math.Sin(k);
            a[1, 0] = -1 * Math.Cos(phi) * Math.Sin(k) - Math.Sin(phi) * Math.Sin(w) * Math.Cos(k);
            a[2, 0] = -1 * Math.Sin(phi) * Math.Cos(w);
            a[0, 1] = Math.Cos(w) * Math.Sin(k);
            a[1, 1] = Math.Cos(w) * Math.Cos(k);
            a[2, 1] = -1 * Math.Sin(w);
            a[0, 2] = Math.Sin(phi) * Math.Cos(k) + Math.Cos(phi) * Math.Sin(w) * Math.Sin(k);
            a[1, 2] = -1 * Math.Sin(phi) * Math.Sin(k) + Math.Cos(phi) * Math.Sin(w) * Math.Cos(k);
            a[2, 2] = Math.Cos(phi) * Math.Cos(w);
            return a;
        }
        /// <summary>
        /// 矩阵乘法a[]*b[]
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double[,] MatrixMulti(double[,] a, double[,] b)
        {
            int mm = a.GetLength(0), nn = a.GetLength(1), pp = b.GetLength(1);
            double[,] c = new double[mm, pp];
            for (int i = 0; i < mm; i++)
            {
                for (int j = 0; j < pp; j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < nn; k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return c;
        }
    }
    /// <summary>
    /// 前方交会后方交会
    /// </summary> 
    class JiaoHui
    {
        /// <summary>
        /// 后方交会
        /// </summary>
        /// <param name="L_pixels">像平面坐标</param>
        /// <param name="points">地面点坐标</param>
        public static double[,] HouFangJiaoHui(List<pixel> L_pixels, List<Point> points, double f)
        {
            double q = 0, k = 0, w = 0, XS0 = 0, YS0 = 0, ZS0 = 0;
            for (int i = 0; i < points.Count(); i++)
            {
                XS0 += points[i].X;
                YS0 += points[i].Y;
                ZS0 += points[i].Z;
            }
            XS0 /= points.Count();
            YS0 /= points.Count();
            ZS0 /= points.Count();

            double h = 3718;//航高
            double[,] phi = new double[6, 1];//存储外方位元素
            ZS0 += h;
            phi[0, 0] = XS0;
            phi[1, 0] = YS0;
            phi[2, 0] = ZS0;
            phi[3, 0] = q;
            phi[4, 0] = w;
            phi[5, 0] = k;


            double max = 100000000000;//迭代误差


            while (max > 1e-6)
            {
                double[,] a;//旋转矩阵
                double[,] L_equation = new double[2 * points.Count(), 6];//系数A
                double[,] L_L = new double[2 * points.Count(), 1];//L
                double[] _x = new double[points.Count()];//共线方程近似解
                double[] _y = new double[points.Count()];//共线方程近似解
                double[] _z = new double[points.Count()];//共线方程近似解

                a = matrix.xuanzhuanjuzhen(phi);


                //近似坐标赋值
                for (int i = 0; i < points.Count(); i++)
                {
                    _z[i] = (a[2, 0] * (points[i].X - phi[0, 0]) + a[2, 1] * (points[i].Y - phi[1, 0]) + a[2, 2] * (points[i].Z - phi[2, 0]));
                    _x[i] = -f * (a[0, 0] * (points[i].X - phi[0, 0]) + a[0, 1] * (points[i].Y - phi[1, 0]) + a[0, 2] * (points[i].Z - phi[2, 0])) / _z[i];
                    _y[i] = -f * (a[1, 0] * (points[i].X - phi[0, 0]) + a[1, 1] * (points[i].Y - phi[1, 0]) + a[1, 2] * (points[i].Z - phi[2, 0])) / _z[i];
                }

                //系数阵赋值
                for (int i = 0; i < points.Count(); i++)
                {

                    L_equation[2 * i, 0] = 1.0 / _z[i] * (a[0, 0] * f + a[2, 0] * L_pixels[i].x);
                    L_equation[2 * i, 1] = 1.0 / _z[i] * (a[0, 1] * f + a[2, 1] * L_pixels[i].x);
                    L_equation[2 * i, 2] = 1.0 / _z[i] * (a[0, 2] * f + a[2, 2] * L_pixels[i].x);

                    L_equation[2 * i, 3] = (L_pixels[i].y * Math.Sin(phi[4, 0])) - Math.Cos(phi[4, 0]) * ((L_pixels[i].x / f) * ((L_pixels[i].x * Math.Cos(phi[5, 0]))
                                             - (L_pixels[i].y * Math.Sin(phi[5, 0]))) + (f * Math.Cos(phi[5, 0])));
                    L_equation[2 * i, 4] = (-f * Math.Sin(phi[5, 0])) -
                                            (L_pixels[i].x / f) * (L_pixels[i].x * Math.Sin(phi[5, 0]) + L_pixels[i].y * Math.Cos(phi[5, 0]));
                    L_equation[2 * i, 5] = L_pixels[i].y;
                    L_equation[2 * i + 1, 0] = 1.0 / _z[i] * (a[1, 0] * f + a[2, 0] * L_pixels[i].y);
                    L_equation[2 * i + 1, 1] = 1.0 / _z[i] * (a[1, 1] * f + a[2, 1] * L_pixels[i].y);
                    L_equation[2 * i + 1, 2] = 1.0 / _z[i] * (a[1, 2] * f + a[2, 2] * L_pixels[i].y);
                    L_equation[2 * i + 1, 3] = -L_pixels[i].x * Math.Sin(phi[4, 0]) - (L_pixels[i].y / f *
                                                (L_pixels[i].x * Math.Cos(phi[5, 0]) - L_pixels[i].y * Math.Sin(phi[5, 0]))
                                                - f * Math.Sin(phi[5, 0])) * Math.Cos(phi[4, 0]);
                    L_equation[2 * i + 1, 4] = -f * Math.Cos(phi[5, 0]) - L_pixels[i].y / f *
                                                (L_pixels[i].x * Math.Sin(phi[5, 0]) +
                                                L_pixels[i].y * Math.Cos(phi[5, 0]));
                    L_equation[2 * i + 1, 5] = -L_pixels[i].x;
                    L_L[2 * i, 0] = (L_pixels[i].x - _x[i]);
                    L_L[2 * i + 1, 0] = (L_pixels[i].y - _y[i]);
                }

                //求解误差方程
                double[,] aT, ata, ata_1, ata_1at, result;
                aT = matrix.T(L_equation, 2 * points.Count(), 6);
                ata = matrix.MatrixMulti(aT, L_equation);
                ata_1 = matrix.juzhqn1(ata);
                ata_1at = matrix.MatrixMulti(ata_1, aT);
                result = matrix.MatrixMulti(ata_1at, L_L);


                //迭代标准
                max = Math.Abs(result[3, 0]);
                //改正
                for (int i = 0; i < 6; i++)
                {
                    phi[i, 0] += result[i, 0];
                }


                for (int i = 0; i < 6; i++)
                {
                    if (max < Math.Abs(result[i, 0]))
                    {
                        max = Math.Abs(result[i, 0]);
                    }

                }

            }
            return phi;
        }
        /// <summary>
        /// 前方交会
        /// </summary>
        /// <param name="c">左像外方位元素</param>
        /// <param name="d">右像外方位元素</param>
        /// <param name="xyf1">左像像空间坐标</param>
        /// <param name="xyf2">右像像空间坐标</param>
        /// <returns>待求点坐标</returns>
        public static double[,] qianfangjiaohui(double[,] c, double[,] d, double[,] xyf1, double[,] xyf2)
        {
            double Bu = d[0, 0] - c[0, 0];
            double Bv = d[1, 0] - c[1, 0];
            double Bw = d[2, 0] - c[2, 0];
            double N1, N2;
            double[,] u1v1w1, u2v2w2;
            double[,] left_R, right_R;
            int length = xyf1.GetLength(1);
            double[,] XAYAZA = new double[3, length];

            for (int i = 0; i < length; i++)
            {
                double[,] xyz1 = new double[3, 1];
                double[,] xyz2 = new double[3, 1];
                for (int j = 0; j < 3; j++)
                {
                    xyz1[0, 0] = xyf1[0, i];
                    xyz1[1, 0] = xyf1[1, i];
                    xyz1[2, 0] = xyf1[2, i];
                    xyz2[0, 0] = xyf2[0, i];
                    xyz2[1, 0] = xyf2[1, i];
                    xyz2[2, 0] = xyf2[2, i];
                }
                left_R = matrix.T(matrix.xuanzhuanjuzhen(c), 3, 3);
                right_R = matrix.T(matrix.xuanzhuanjuzhen(d), 3, 3);

                u1v1w1 = matrix.MatrixMulti(left_R, xyz1);
                u2v2w2 = matrix.MatrixMulti(right_R, xyz2);
                N1 = (Bu * u2v2w2[2, 0] - Bw * u2v2w2[0, 0])
                    / (u1v1w1[0, 0] * u2v2w2[2, 0] - u2v2w2[0, 0] * u1v1w1[2, 0]);
                N2 = (Bu * u1v1w1[2, 0] - Bw * u1v1w1[0, 0])
                    / (u1v1w1[0, 0] * u2v2w2[2, 0] - u2v2w2[0, 0] * u1v1w1[2, 0]);
                XAYAZA[0, i] = c[0, 0] + N1 * u1v1w1[0, 0];
                XAYAZA[1, i] = ((c[1, 0] + N1 * u1v1w1[1, 0]) + (d[1, 0] + N2 * u2v2w2[1, 0])) / 2;
                XAYAZA[2, i] = c[2, 0] + N1 * u1v1w1[2, 0];

            }
            return XAYAZA;
        }

    }
    /// <summary>
    /// 相对定向
    /// </summary>
    public class DingXiang
    {        
        /// <summary>
        /// 相对定向
        /// </summary>
        /// <param name="l_SamePoint">左同名像点</param>
        /// <param name="r_SamePoint">右同名像点</param>
        /// <returns>相对定向元素</returns>
        public static double[,] XiangDuiDIngXiang(double[,] l_SamePoint, double[,] r_SamePoint, double f)
        {
            double phi1 = 0, w1 = 0, k1 = 0, phi2 = 0, w2 = 0, k2 = 0;
            double[,] left, right, dingxiang, u1v1w1, u2v2w2, Xishu, Q;
            dingxiang = new double[6, 1];
            double wucha = 1000;
            int count = l_SamePoint.GetLength(1);
            while (wucha > 1e-6)
            {

                left = matrix.T(matrix.xuanzhuanjuzhen(phi1, w1, k1), 3, 3);
                right = matrix.T(matrix.xuanzhuanjuzhen(phi2, w2, k2), 3, 3);
                u1v1w1 = matrix.MatrixMulti(left, l_SamePoint);
                u2v2w2 = matrix.MatrixMulti(right, r_SamePoint);
                Xishu = new double[count, 5];
                Q = new double[count, 1];
                for (int j = 0; j < count; j++)
                {
                    Xishu[j, 0] = u1v1w1[0, j] * u2v2w2[1, j] / u2v2w2[2, j];
                    Xishu[j, 1] = -u2v2w2[0, j] * u1v1w1[1, j] / u1v1w1[2, j];
                    Xishu[j, 2] = f * (1 + u1v1w1[1, j] * u2v2w2[1, j] / (u1v1w1[2, j] * u2v2w2[2, j]));
                    Xishu[j, 3] = -u1v1w1[0, j];
                    Xishu[j, 4] = u2v2w2[0, j];
                    Q[j, 0] = -f * u1v1w1[1, j] / u1v1w1[2, j] + f * u2v2w2[1, j] / u2v2w2[2, j];


                }
                double[,] AT, ATA, ATA_1, ATA_1AT, result;
                AT = matrix.T(Xishu, count, 5);
                ATA = matrix.MatrixMulti(AT, Xishu);
                ATA_1 = matrix.juzhqn1(ATA);
                ATA_1AT = matrix.MatrixMulti(ATA_1, AT);
                result = matrix.MatrixMulti(ATA_1AT, Q);
                phi1 += result[0, 0];
                phi2 += result[1, 0];
                w2 += result[2, 0];
                k1 += result[3, 0];
                k2 += result[4, 0];
                dingxiang[0, 0] = phi1;
                dingxiang[1, 0] = w1;
                dingxiang[2, 0] = k1;
                dingxiang[3, 0] = phi2;
                dingxiang[4, 0] = w2;
                dingxiang[5, 0] = k2;
                wucha = result[0, 0];
                for (int j = 0; j < 5; j++)
                {
                    if (wucha < result[j, 0])
                    {
                        wucha = result[j, 0];
                    }
                }
            }
            return dingxiang;
        }
    }
}
