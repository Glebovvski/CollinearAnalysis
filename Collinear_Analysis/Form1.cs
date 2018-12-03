using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;
using ExcelObj = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Linq;

namespace Collinear_Analysis
{
    public partial class Form1 : Form
    {
        double[,] rez;
        int sumRow = 0;
        
        double min = 0;
        double max = 0;
        int mini = 0, minj = 0;
        int maxi = 0, maxj = 0;

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
            double[,] matrs;
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
                    matrs[i, j] = Convert.ToDouble(dt.Rows[i].Cells[j /*+ 1*/].Value);
                }
            }

            double[] avr;
            double[] sumkv;
            double[] disp;
            double[,] matrs2;
            matrs2 = new double[dt.RowCount-1, dt.ColumnCount];
            sumRow = matrs.GetLength(0);// - 1;
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
                for (i = 0; i < matrs.GetLength(0) /*- 1*/; i++)
                {
                    summ += (matrs[i, j] - avr[j]) * (matrs[i, j] - avr[j]);
                }
                disp[j] = summ / sumRow;
            }
            for (j = 0; j < matrs.GetLength(1); j++)
                Console.WriteLine(" di ={0}", disp[j]);
            // Матриця кореляції
            //label9.Text = "Матриця стандартизованих незалежних змінних"; ;\\

            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[0].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[1].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[2].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[3].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[4].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });

            int n = matrs.GetLength(0);// - 1;
            for (i = 0; i < n/*matrs.GetLength(0) - 1*/; i++)
            {
                for (j = 0; j < matrs.GetLength(1); j++)
                {
                    matrs2[i, j] = (matrs[i, j] - avr[j]) / Math.Sqrt(disp[j] * sumRow);
                    normDt.Rows.Add();
                    normDt.Rows[i].Cells[j].Value = Math.Round(matrs2[i, j] * 1000,2) / 1000.0;
                }

            }
            
            //label8.Text = "Кореляційна матриця";
            //int k = 0;
            //int l = 0;
            //double sumxy = 0;
            //double avrxy = 0;
            //double koefkorel = 0;
            //dataGridView2.RowCount = matrs.GetLength(1);
            //dataGridView2.ColumnCount = matrs.GetLength(1);
            //for (l = 0; l < matrs.GetLength(1); l++)
            //{
            //    for (k = 0; k < matrs.GetLength(1); k++)
            //    {
            //        sumxy = 0;
            //        for (i = 0; i < sumRow; i++)
            //        {
            //            sumxy = sumxy + matrs[i, l] * matrs[i, k];
            //        }
            //        avrxy = sumxy / sumRow;
            //        koefkorel = (avrxy - avr[k] * avr[l]) / (Math.Sqrt(disp[l]) * Math.Sqrt(disp[k]));
            //        dataGridView2.Rows[l].Cells[k].Value = koefkorel;
            //    }
            //    dataGridView2.Columns[l].HeaderText = dataGridView1.Columns[l + 1].HeaderText;
            //    dataGridView2.Rows[l].HeaderCell.Value = dataGridView1.Columns[l + 1].HeaderText;
            //}

            rez = new double[matr.RowCount, matr.ColumnCount];
            for (i = 0; i < matr.RowCount; i++)
            {
                for (j = 0; j < matr.ColumnCount; j++)
                {
                    rez[i, j] = Convert.ToDouble(matr.Rows[i].Cells[j].Value);
                }
            }
            // Визначник матриці, ХІ - квадрат

            const double xitable = 24.996;
            double det = Determ(rez);
            Console.WriteLine(det);
            //textBox3.Text = Convert.ToString(det);
            MessageBox.Show("determinant: "+det.ToString());
            double xi = -(sumRow - 1 - 1 / 6 * (2 * matrs.GetLength(1) + 5)) * Math.Log(det, Math.E);
            //textBox4.Text = Convert.ToString(xi);
            MessageBox.Show("xi: " + xi.ToString());
            if (xi > xitable)
            {
                textBox1.Text = "В масиві незалежних змінних існує мультиколінеарність.";
                //button5.Enabled = true;
                MessageBox.Show("something to turn on");
            }
            else
            {
                MessageBox.Show("Аналіз завершено. Мультиколінеарності неіснує!");
            }
            button3.Enabled = false;

        }


        public static double[,] GetMinor(double[,] matrix, int row, int column)
        {
            double[,] buf = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i != row) || (j != column))
                    {
                        if (i > row && j < column) buf[i - 1, j] = matrix[i, j];
                        if (i < row && j > column) buf[i, j - 1] = matrix[i, j];
                        if (i > row && j > column) buf[i - 1, j - 1] = matrix[i, j];
                        if (i < row && j < column) buf[i, j] = matrix[i, j];
                    }
                }
            return buf;
        }

        public static double Determ(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new Exception(" Число строк в матрице не совпадает с числом столбцов");
            double det = 0;
            int Rank = matrix.GetLength(0);
            if (Rank == 1) det = matrix[0, 0];
            if (Rank == 2) det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            if (Rank > 2)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    det += Math.Pow(-1, 0 + j) * matrix[0, j] * Determ(GetMinor(matrix, 0, j));
                }
            }
            return det;
        }



        private void Analysis()
        {
            analysisTb.Text = "The smallest correlation coefficient is: " + min + " of " + matr.Rows[mini].HeaderCell.Value + " to " + matr.Rows[minj].HeaderCell.Value + "\n" +
                "The highest correlation coefficient is: " + max + " of " + matr.Rows[maxi].HeaderCell.Value + " to " + matr.Rows[maxj].HeaderCell.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }

}


