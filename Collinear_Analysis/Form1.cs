﻿using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;
using ExcelObj = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Data = System.Collections.Generic.KeyValuePair<int, int>;

namespace Collinear_Analysis
{
    public partial class Form1 : Form
    {
        double[,] rez;
        int sumRow = 0;

        double[,] correlationMat = new double[5, 5];

        double min = 0;
        double max = 0;
        int mini = 0, minj = 0;
        int maxi = 0, maxj = 0;


        double[,] matrs;

        public Form1()
        {
            InitializeComponent();
        }

        private void GetFile_Click(object sender, EventArgs e)
        {
            
        }

        private void Setmatr()
        {
            matr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle styleMiddle = new DataGridViewCellStyle();
            styleMiddle.BackColor = System.Drawing.Color.Orange;

            DataGridViewCellStyle styleHigh = new DataGridViewCellStyle();
            styleHigh.BackColor = System.Drawing.Color.OrangeRed;

            DataGridViewCellStyle styleVeryHigh = new DataGridViewCellStyle();
            styleVeryHigh.BackColor = System.Drawing.Color.Red;

            DataGridViewCellStyle styleLow = new DataGridViewCellStyle();
            styleLow.BackColor = System.Drawing.Color.Yellow;

            DataGridViewCellStyle styleLowest = new DataGridViewCellStyle();
            styleLowest.BackColor = System.Drawing.Color.LightBlue;

            DataGridViewCellStyle styleLowLow = new DataGridViewCellStyle();
            styleLowLow.BackColor = System.Drawing.Color.LightGray;

            DataGridViewCellStyle styleFunc = new DataGridViewCellStyle();
            styleFunc.BackColor = System.Drawing.Color.Purple;

            for (int i = 0; i < matr.Rows.Count; i++)
            {
                for (int j = 0; j < matr.Rows[i].Cells.Count; j++)
                {
                    double cell = double.Parse(matr.Rows[i].Cells[j].Value.ToString());
                    if ((cell >= 0.1 && cell <= 0.3) || (cell >= -0.3 && cell <= -0.1))
                        matr.Rows[i].Cells[j].Style = styleLowest;
                    else if ((cell > 0.3 && cell < 0.5) || (cell < -0.3 && cell > -0.5))
                        matr.Rows[i].Cells[j].Style = styleLow;
                    else if ((cell >= 0.5 && cell <= 0.7) || (cell <= -0.5 && cell >= -0.7))
                        matr.Rows[i].Cells[j].Style = styleMiddle;
                    else if ((cell > 0.7 && cell <= 0.9) || (cell < -0.7 && cell >= -0.9))
                        matr.Rows[i].Cells[j].Style = styleHigh;
                    else if ((cell > 0.9 && cell <= 0.99) || (cell < -0.9 && cell >= -0.99))
                        matr.Rows[i].Cells[j].Style = styleVeryHigh;
                    else if ((cell > 0.99 && cell <= 1) || (cell < -0.99 && cell >= -1))
                        matr.Rows[i].Cells[j].Style = styleVeryHigh;
                    else matr.Rows[i].Cells[j].Style = styleLowLow;
                }
            }
        }

        private void CollinearBuild_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void matr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dt.DataSource = string.Empty;
            matr.Columns.Clear();


            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Файл Excel|*.XLSX;*.XLS"; ;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
                OleDbConnection connection = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", dialog.FileName));
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Лист1$]", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dt.DataSource = table;
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            matrs = new double[dt.RowCount, dt.ColumnCount];

            //Input values from stats
            for (i = 0; i < dt.RowCount; i++)
            {
                for (j = 0; j < dt.ColumnCount; j++)
                {
                    matrs[i, j] = Convert.ToDouble(dt.Rows[i].Cells[j].Value);
                }
            }

            double[,] x;
            double[,] y;
            x = new double[matrs.GetLength(0), 1];
            y = new double[matrs.GetLength(0), 1];
            int k = 0;
            int l = 0;
            int sumRow = matrs.GetLength(0) - 1;
            double sumx = 0;
            double sumy = 0;
            double sumxy = 0;
            double sumxx = 0;
            double sumyy = 0;
            double avrx = 0;
            double avry = 0;
            double avrxy = 0;
            double dispx = 0;
            double dispy = 0;
            double avrsqrx = 0;
            double avrsqry = 0;
            double koefkorel = 0;
            matr.RowCount = matrs.GetLength(1);
            matr.ColumnCount = matrs.GetLength(1);

            for (l = 0; l < matrs.GetLength(1); l++)
            {
                for (k = 0; k < matrs.GetLength(1); k++)
                {
                    sumx = 0;
                    sumy = 0;
                    sumxy = 0;
                    sumxx = 0;
                    sumyy = 0;
                    avrx = 0;
                    avry = 0;
                    avrxy = 0;
                    dispx = 0;
                    dispy = 0;
                    avrsqrx = 0;
                    avrsqry = 0;
                    koefkorel = 0;
                    for (i = 0; i < sumRow; i++)
                    {
                        for (j = 0; j < 1; j++)
                        {
                            x[i, j] = matrs[i, l];
                            sumx = sumx + x[i, j];
                            y[i, j] = matrs[i, k];
                            sumy = sumy + y[i, j];
                            sumxy = sumxy + x[i, j] * y[i, j];
                            sumxx = sumxx + x[i, j] * x[i, j];
                            sumyy = sumyy + y[i, j] * y[i, j];
                        }
                        avrx = sumx / sumRow;
                        avry = sumy / sumRow;
                        avrxy = sumxy / sumRow;
                        dispx = sumxx / sumRow - avrx * avrx;
                        dispy = sumyy / sumRow - avry * avry;
                        avrsqrx = Math.Sqrt(dispx);
                        avrsqry = Math.Sqrt(dispy);
                        koefkorel = Math.Round((avrxy - avrx * avry) / (avrsqrx * avrsqry), 1);
                    }
                    matr.Rows[l].Cells[k].Value = koefkorel;
                    correlationMat[l, k] = double.Parse(matr.Rows[l].Cells[k].Value.ToString());
                }

                matr.Columns[l].HeaderText = dt.Columns[l].HeaderText;
                matr.Rows[l].HeaderCell.Value = dt.Columns[l].HeaderText;

            }

            Setmatr();

            double[,] rez;
            rez = new double[1, matr.ColumnCount];

            for (i = 0; i < 1; i++)
            {
                for (j = 0; j < matr.ColumnCount; j++)
                {
                    rez[i, j] = Convert.ToDouble(matr.Rows[i].Cells[j].Value);
                }
            }


            min = 10;
            max = 0;
            for (i = 0; i < rez.GetLength(0); i++)
            {
                for (j = 0; j < rez.GetLength(1); j++)
                {
                    if (min > rez[i, j] && rez[i, j] >= 0 && rez[i, j] < 1)
                    {
                        min = rez[i, j];
                        mini = i;
                        minj = j;
                    }
                    if (max < rez[i, j] && rez[i, j] >= 0 && rez[i, j] < 1)
                    {
                        max = rez[i, j];
                        maxi = i;
                        maxj = j;
                    }
                }
            }

            Analysis();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            double[,] matrs;
            matrs = new double[dt.RowCount-1, dt.ColumnCount];

            for (i = 0; i < matrs.GetLength(0); i++)
            {
                for (j = 0; j < matrs.GetLength(1); j++)
                {
                    matrs[i, j] = Convert.ToDouble(dt.Rows[i].Cells[j].Value);
                }
            }

            double[] avr;
            double[] sumkv;
            double[] disp;
            double[,] matrs2;
            matrs2 = new double[dt.RowCount-1, dt.ColumnCount];
            sumRow = matrs.GetLength(0);
            avr = new double[matrs.GetLength(1)];
            sumkv = new double[matrs.GetLength(1)];
            disp = new double[matrs.GetLength(1)];
            double summ = 0;
            // Середнє
            for (j = 0; j < matrs.GetLength(1); j++)
            {
                summ = 0;
                for (i = 0; i < matrs.GetLength(0); i++)
                {
                    summ += matrs[i, j];
                }
                avr[j] = summ / sumRow;
            }
            // Дисперсія
            for (j = 0; j < matrs.GetLength(1); j++)
            {
                summ = 0;
                for (i = 0; i < matrs.GetLength(0); i++)
                {
                    summ += (matrs[i, j] - avr[j]) * (matrs[i, j] - avr[j]);
                }
                disp[j] = summ / sumRow;
            }

            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[0].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[1].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[2].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[3].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[4].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });

            int n = matrs.GetLength(0);
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < matrs.GetLength(1); j++)
                {
                    matrs2[i, j] = (matrs[i, j] - avr[j]) / Math.Sqrt(disp[j] * sumRow);
                    if (j == 0) normDt.Rows.Add();
                    normDt.Rows[i].Cells[j].Value = Math.Round(matrs2[i, j] * 1000,2) / 1000.0;
                }

            }

            rez = new double[matr.RowCount, matr.ColumnCount];
            for (i = 0; i < matr.RowCount; i++)
            {
                for (j = 0; j < matr.ColumnCount; j++)
                {
                    rez[i, j] = Math.Round(Convert.ToDouble(matr.Rows[i].Cells[j].Value),1);
                }
            }

            const double xitable = 3.9403;
            XiTable_Tb.Text = xitable.ToString();
            double det = Math.Round(DetGauss(rez),2);
            Det_Tb.Text = det.ToString();
            double xi = -(sumRow - 1 - (2*5 +5)/5) * Math.Log(det, Math.E);
            Xi_Tb.Text = xi.ToString();
            
            if (xi > xitable)
            {
                CompareXi.Text = ">";
                StudentFunc();
            }
            else
            {
                MessageBox.Show("Аналіз завершено. Мультиколінеарності неіснує!");
                CompareXi.Text = "<";
            }
            button3.Enabled = false;


        }

        public double DetGauss(double[,] M)
        {
            double det = 1; // Хранит определитель, который вернёт функция
            int n = M.GetLength(0); // Размерность матрицы
            int k = 0;
            const double E = 1E-9; // Погрешность вычислений

            for (int i = 0; i < n; i++)
            {
                k = i;
                for (int j = i + 1; j < n; j++)
                    if (Math.Abs(M[j, i]) > Math.Abs(M[k, i]))
                        k = j;

                if (Math.Abs(M[k,i]) < E)
                {
                    det = 0;
                    break;
                }
                Swap(ref M, i, k);

                if (i != k) det *= -1;

                det *= M[i, i];

                for (int j = i + 1; j < n; j++)
                    M[i, j] /= M[i, i];

                for (int j = 0; j < n; j++)
                    if ((j != i) && (Math.Abs(M[j, i]) > E))
                        for (k = i + 1; k < n; k++)
                            M[j, k] -= M[i, k] * M[j, i];
            }
            return det;
        }

        public void Swap(ref double[,] M, int row1, int row2)
        {
            double s = 0;

            for (int i = 0; i < M.GetLength(1); i++)
            {
                s = M[row1, i];
                M[row1, i] = M[row2, i];
                M[row2,i] = s;
            }
        }

        private void Analysis()
        {
            analysisTb.Text = "The smallest correlation coefficient is: " + min + " of " + matr.Rows[mini].HeaderCell.Value + " to " + matr.Rows[minj].HeaderCell.Value + "\n" +
                "The highest correlation coefficient is: " + max + " of " + matr.Rows[maxi].HeaderCell.Value + " to " + matr.Rows[maxj].HeaderCell.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void matr_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public static double[,] One1(double[,] matrix, int len)
        {
            double[,] ob = new double[len, len];

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i == j)
                    { ob[i, j] = 1; }
                    else
                    { ob[i, j] = 0; }

                }

            }

            double arg;
            int i1;

            for (int j = 0; j < len;)
            {
                for (int i = 0; i < len;)
                {
                    if (i != j)
                    {
                        arg = matrix[i, j] / matrix[j, j];
                        for (i1 = 0; i1 < len;)
                        {
                            matrix[i, i1] = matrix[i, i1] - matrix[j, i1] * arg;
                            ob[i, i1] = ob[i, i1] - ob[j, i1] * arg;
                            i1++;
                        }
                    }
                    i++;
                }
                j++;
            }

            for (int j = 0; j < len; j++)
            {
                for (int i = 0; i < len; i++)
                {
                    double arg_2;
                    if (i == j)
                    {
                        arg_2 = matrix[i, j];
                        for (i1 = 0; i1 < len;)
                        {
                            matrix[i, i1] = matrix[i, i1] / arg_2;
                            ob[i, i1] = ob[i, i1] / arg_2;
                            i1++;
                        }
                    }

                }
            }
            return ob;
        }

        

        private bool Fisher(double[,] ober)
        {

            const double fish = 2.866;
            FisherTB.Text = fish.ToString();

            double[] fisher = new double[rez.GetLength(0)];
            for (int i = 0; i < InverseMatrix.RowCount - 1; i++)
            {
                fisher[i] = Math.Round((ober[i, i] - 1) * (sumRow - rez.GetLength(0)) / (rez.GetLength(0) - 1), 2);
            }

            Fisher1.Text = InverseMatrix.Columns[0].HeaderText;
            Fisher1_tb.Text = fisher[0].ToString();
            if (fisher[0] > fish) Fisher1_tb.BackColor = Color.Blue;
            Fisher2.Text = InverseMatrix.Columns[1].HeaderText;
            Fisher2_tb.Text = fisher[1].ToString();
            if (fisher[1] > fish) Fisher2_tb.BackColor = Color.Blue;
            Fisher3.Text = InverseMatrix.Columns[2].HeaderText;
            Fisher3_tb.Text = fisher[2].ToString();
            if (fisher[2] > fish) Fisher3_tb.BackColor = Color.Blue;
            Fisher4.Text = InverseMatrix.Columns[3].HeaderText;
            Fisher4_tb.Text = fisher[3].ToString();
            if (fisher[3] > fish) Fisher4_tb.BackColor = Color.Blue;
            Fisher5.Text = InverseMatrix.Columns[4].HeaderText;
            Fisher5_tb.Text = fisher[4].ToString();
            if (fisher[4] > fish) Fisher5_tb.BackColor = Color.Blue;
            
            for (int i = 0; i < InverseMatrix.RowCount - 1; i++)
            {
                if (fisher[i] > fish)
                    return true;
            }
            return false;
            
        }

        private void StudentFunc()
        {
            textBox1.Text = " ";
            //Обернена матриця
            double[,] ober = One1(correlationMat, correlationMat.GetLength(0));

            InverseMatrix.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[0].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            InverseMatrix.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[1].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            InverseMatrix.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[2].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            InverseMatrix.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[3].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            InverseMatrix.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[4].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });

            for (int i = 0; i < correlationMat.GetLength(0); i++)
            {
                InverseMatrix.Rows.Add();
                for (int j = 0; j < correlationMat.GetLength(1); j++)
                {
                    InverseMatrix.Rows[i].Cells[j].Value = ober[i, j];
                    rez[i, j] = ober[i, j];
                }
            }

            //Коефіцієнти фішера
            
            if (!Fisher(ober))
            {
                MessageBox.Show("Аналіз завершено. Мультиколінеарності неіснує!");
            }
            
            double[,] matrparkoef = new double[rez.GetLength(0), rez.GetLength(1)];
            for (int i = 0; i < InverseMatrix.RowCount-1; i++)
            {
                for (int j = 0; j < InverseMatrix.ColumnCount; j++)
                {
                    if (i == 0)
                    {
                        Partial.Columns.Add("col" + j, dt.Columns[j].HeaderText);
                    }
                    matrparkoef[i, j] = Math.Round(-rez[i, j] / (Math.Sqrt(rez[i, i] * rez[j, j])), 2);
                    if (j==0) Partial.Rows.Add();
                    Partial.Rows[i].Cells[j].Value = matrparkoef[i, j];
                }
            }

            double[,] krst = new double[rez.GetLength(0), rez.GetLength(1)];
            //label8.Text = "Матриця критеріїв Стьюдента";
            const double st = 2.08596;
            StudentTb.Text = st.ToString();

            DataGridViewCellStyle styleMiddle = new DataGridViewCellStyle();
            styleMiddle.BackColor = System.Drawing.Color.Orange;

            for (int i = 0; i < Partial.RowCount; i++)
            {
                for (int j = 0; j < Partial.ColumnCount; j++)
                {
                    if (i == 0)
                        Student.Columns.Add("col" + j, dt.Columns[j].HeaderText);
                    if (j == 0)
                        Student.Rows.Add();
                    if (j > i)
                    {
                        krst[i, j] = matrparkoef[i, j] * Math.Sqrt(sumRow - rez.GetLength(0)) / Math.Sqrt(1 - matrparkoef[i, j] * matrparkoef[i, j]);
                        Student.Rows[i].Cells[j].Value = krst[i, j];
                        if (krst[i, j] > st)
                        {
                            dependants.Add(new Data(i, j));
                            Student.Rows[i].Cells[j].Style = styleMiddle;
                            StudentAnalysisTb.Text += "There is multicollinearity between independent variables: " + Student.Columns[i].HeaderText + " and " + Student.Columns[j].HeaderText + " \r\n";
                        }
                    }

                }
            }
        }

        List<Data> dependants = new List<Data>();
        private void button4_Click(object sender, EventArgs e)
        {
            //dependants.RemoveAt(2);
            List<int> toThrowAway = new List<int>();
            int checksThatExist = 0;
            int checkThatNotMain = 0;
            for (int i = 0; i < dependants.Count; i++)
            {
                if (dependants[i].Key == 0)
                {
                    int temp = dependants[i].Value;
                    toThrowAway.Add(dependants[i].Value);
                    foreach(var item in dependants)
                    {
                        if (toThrowAway.Count > 0)
                        {
                            if (temp != item.Value)
                            {
                                checksThatExist++;
                            }
                            if(temp == item.Value && item.Key == 0)
                            {
                                checkThatNotMain++;
                            }
                        }
                    }
                    if (checksThatExist == dependants.Count-1 /*&& checksThatExist>=checkThatNotMain*/)
                        toThrowAway.Remove(temp);
                    checksThatExist = 0;
                }
            }
            
            //var sd = matrs;

        }
    }
}



