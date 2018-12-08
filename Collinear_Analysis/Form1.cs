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
using System.Drawing;
using Data = System.Collections.Generic.KeyValuePair<int, int>;
using static alglib;

namespace Collinear_Analysis
{
    public partial class Form1 : Form
    {
        double[,] rez;
        int sumRow = 0;

        double[,] correlationMat;// = new double[5, 5];

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
                //dt.SortMode = DataGridViewColumnSortMode.NotSortable;
                dt.DataSource = table;
                foreach (DataGridViewColumn item in dt.Columns)
                {
                    item.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dt.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;

            int colCount = 0;
            int rowCount = 0;

            if (dt.SelectedCells.Count > 0)
            {
                matrs = new double[dt.RowCount, dt.SelectedColumns.Count];
                colCount = dt.SelectedColumns.Count;
                rowCount = dt.RowCount;
            }
            else
            {
                matrs = new double[dt.RowCount, dt.ColumnCount - 1];
                colCount = dt.ColumnCount - 1;
                rowCount = dt.RowCount;
            }
            

            //Input values from stats
            //with all columns
            if (dt.SelectedColumns.Count == 0)
            {
                for (i = 0; i < rowCount; i++)
                {
                    for (j = 0; j < colCount; j++)
                    {
                        //if(j!=0)
                        matrs[i, j] = Convert.ToDouble(dt.Rows[i].Cells[j+1].Value);
                    }
                }
            }
            //with selected columns
            else
            {
                foreach (DataGridViewRow row in dt.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Selected)
                        {
                            matrs[i, j] = Convert.ToDouble(cell.Value);
                            j++;
                            if (j >= matrs.GetLength(1))
                            {
                                j = 0;
                                i++;
                            }
                            if (j >= dt.SelectedColumns.Count) i++;
                        }
                    }
                }
            }

            correlationMat = new double[colCount, colCount];

            double[,] x;
            double[,] y;
            x = new double[matrs.GetLength(0), 1];
            y = new double[matrs.GetLength(0), 1];
            int k = 0;
            int l = 0;
            int sumRow = matrs.GetLength(0);// - 1;
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

                matr.Columns[l].HeaderText = dt.Columns[l + 1].HeaderText;
                matr.Rows[l].HeaderCell.Value = dt.Columns[l + 1].HeaderText;

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
            matrs = new double[dt.RowCount - 1, dt.ColumnCount - 1];

            for (i = 0; i < matrs.GetLength(0); i++)
            {
                for (j = 0; j < matrs.GetLength(1); j++)
                {
                    matrs[i, j] = Convert.ToDouble(dt.Rows[i].Cells[j + 1].Value);
                }
            }

            double[] avr;
            double[] sumkv;
            double[] disp;
            double[,] matrs2;
            matrs2 = new double[dt.RowCount - 1, dt.ColumnCount];
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

            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[1].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[2].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[3].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[4].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            normDt.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[5].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });

            int n = matrs.GetLength(0);
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < matrs.GetLength(1); j++)
                {
                    matrs2[i, j] = (matrs[i, j] - avr[j]) / Math.Sqrt(disp[j] * sumRow);
                    if (j == 0) normDt.Rows.Add();
                    normDt.Rows[i].Cells[j].Value = Math.Round(matrs2[i, j] * 1000, 2) / 1000.0;
                }

            }

            rez = new double[matr.RowCount, matr.ColumnCount];
            for (i = 0; i < matr.RowCount; i++)
            {
                for (j = 0; j < matr.ColumnCount; j++)
                {
                    rez[i, j] = Math.Round(Convert.ToDouble(matr.Rows[i].Cells[j].Value), 1);
                }
            }
            var xiii = Math.Round(invchisquaredistribution(matr.ColumnCount, 0.55), 2);//chisquaredistribution(10, 0.05);
            const double xitable = 3.9403;
            XiTable_Tb.Text = xiii.ToString();//xitable.ToString();
            double det = Math.Round(DetGauss(rez), 2);
            Det_Tb.Text = det.ToString();
            double xi = -(sumRow - 1 - (2 * 5 + 5) / 5) * Math.Log(det, Math.E);
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
            //button3.Enabled = false;


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

                if (Math.Abs(M[k, i]) < E)
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
                M[row2, i] = s;
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

        public static double[,] Inversing(double[,] matrix, int len)
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
                            ob[i, i1] = Math.Round(ob[i, i1] / arg_2, 2);
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

            for (int i = 0; i < fisher.Length; i++)
            {
                Fishers_Tb.Text += InverseMatrix.Columns[i].HeaderText + ": " + fisher[i] + "\r\n";
            }

            for (int i = 0; i < InverseMatrix.RowCount - 1; i++)
            {
                if (fisher[i] > fish)
                    return true;
            }
            return false;

        }

        private void StudentFunc()
        {
            //Обернена матриця
            double[,] ober = Inversing(correlationMat, correlationMat.GetLength(0));

            //InverseMatrix.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[1].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            //InverseMatrix.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[2].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            //InverseMatrix.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[3].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            //InverseMatrix.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[4].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });
            //InverseMatrix.Columns.Add(new DataGridViewColumn() { HeaderText = dt.Columns[5].HeaderText, CellTemplate = new DataGridViewTextBoxCell() });

            for (int i = 0; i < correlationMat.GetLength(0); i++)
            {
                for (int j = 0; j < correlationMat.GetLength(1); j++)
                {
                    if (i == 0)
                        InverseMatrix.Columns.Add("col",dt.Columns[j+1].HeaderText);
                    if (j == 0)
                        InverseMatrix.Rows.Add();
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
            for (int i = 0; i < InverseMatrix.RowCount - 1; i++)
            {
                for (int j = 0; j < InverseMatrix.ColumnCount; j++)
                {
                    if (i == 0)
                    {
                        Partial.Columns.Add("col" + j, dt.Columns[j + 1].HeaderText);
                    }
                    matrparkoef[i, j] = Math.Round(-rez[i, j] / (Math.Sqrt(rez[i, i] * rez[j, j])), 2);
                    if (j == 0) Partial.Rows.Add();
                    Partial.Rows[i].Cells[j].Value = matrparkoef[i, j];
                }
            }

            double[,] krst = new double[rez.GetLength(0), rez.GetLength(1)];
            //label8.Text = "Матриця критеріїв Стьюдента";
            const double st = 2.08596;
            StudentTb.Text = st.ToString();

            DataGridViewCellStyle styleMiddle = new DataGridViewCellStyle();
            styleMiddle.BackColor = System.Drawing.Color.Orange;

            for (int i = 0; i < Partial.RowCount - 1; i++)
            {
                for (int j = 0; j < Partial.ColumnCount; j++)
                {
                    if (i == 0)
                        Student.Columns.Add("col" + j, dt.Columns[j + 1].HeaderText);
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
                    foreach (var item in dependants)
                    {
                        if (toThrowAway.Count > 0)
                        {
                            if (temp != item.Value)
                            {
                                checksThatExist++;
                            }
                            if (temp == item.Value && item.Key == 0)
                            {
                                checkThatNotMain++;
                            }
                        }
                    }
                    if (checksThatExist == dependants.Count - 1 /*&& checksThatExist>=checkThatNotMain*/)
                        toThrowAway.Remove(temp);
                    checksThatExist = 0;
                }
            }

            //var sd = matrs;
            RegressionAnalysis(toThrowAway);
        }

        private void RegressionAnalysis(List<int> toThrowAway)
        {
            List<double[,]> matrixList = new List<double[,]>();
            double[,] yMat = new double[1, dt.RowCount - 1];
            double[,] x1Mat = new double[1, dt.RowCount - 1];
            double[,] x2Mat = new double[1, dt.RowCount - 1];
            double[,] x3Mat = new double[1, dt.RowCount - 1];
            double[,] x4Mat = new double[1, dt.RowCount - 1];
            int i = 0;
            int j0 = 0, j1 = 0, j2 = 0, j3 = 0, j4 = 0;

            foreach (DataGridViewRow item in dt.Rows)
            {
                foreach (DataGridViewCell cell in item.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (cell.ColumnIndex == 0)
                        {
                            if (j0 != dt.Rows.Count - 1)
                            {
                                yMat[0, j0] = double.Parse(cell.Value.ToString());
                                j0++;
                            }
                        }
                        if (cell.ColumnIndex == 1 && !toThrowAway.Contains(i))
                        {
                            if (j1 != dt.Rows.Count - 1)
                            {
                                x1Mat[0, j1] = double.Parse(cell.Value.ToString());
                                j1++;
                            }
                        }
                        if (cell.ColumnIndex == 2 && !toThrowAway.Contains(i))
                        {
                            if (j2 != dt.Rows.Count - 1)
                            {
                                x2Mat[0, j2] = double.Parse(cell.Value.ToString());
                                j2++;
                            }
                        }
                        if (cell.ColumnIndex == 3 && !toThrowAway.Contains(i))
                        {
                            if (j3 != dt.Rows.Count - 1)
                            {
                                x3Mat[0, j3] = double.Parse(cell.Value.ToString());
                                j3++;
                            }
                        }
                        if (cell.ColumnIndex == 4 && !toThrowAway.Contains(i))
                        {
                            if (j4 != dt.Rows.Count - 1)
                            {
                                x4Mat[0, j4] = double.Parse(cell.Value.ToString());
                                j4++;
                            }
                        }
                        i++;
                        if (i > dt.Columns.Count - 1)
                            i = 0;
                    }
                }
            }

            matrixList.Add(x1Mat);
            matrixList.Add(x2Mat);
            matrixList.Add(x3Mat);
            matrixList.Add(x4Mat);

            //Xt*X
            double[,] x1Mult = Multiplication(Transposition(x1Mat), x1Mat);
            double[,] x2Mult = Multiplication(Transposition(x2Mat), x2Mat);
            double[,] x3Mult = Multiplication(Transposition(x3Mat), x3Mat);
            double[,] x4Mult = Multiplication(Transposition(x4Mat), x4Mat);

            //(Xt*X)^(-1)
            double[,] x1Reversed = Inversing(x1Mult, x1Mult.GetLength(0));
            double[,] x2Reversed = Inversing(x2Mult, x2Mult.GetLength(0));
            double[,] x3Reversed = Inversing(x3Mult, x3Mult.GetLength(0));
            double[,] x4Reversed = Inversing(x4Mult, x4Mult.GetLength(0));

            //(Xt*X)^(-1)*Xt
            double[,] x1 = Multiplication(x1Reversed, Transposition(x1Mat));
            double[,] x2 = Multiplication(x2Reversed, Transposition(x2Mat));
            double[,] x3 = Multiplication(x3Reversed, Transposition(x3Mat));
            double[,] x4 = Multiplication(x4Reversed, Transposition(x4Mat));

            //(Xt*X)^(-1)*Xt*Y
            var b1 = Multiplication(x1, yMat);
            var b2 = Multiplication(x2, yMat);
            var b3 = Multiplication(x3, yMat);
            var b4 = Multiplication(x4, yMat);

            //var beta1 =PearsonCorrelation.GetSimilarityScore(rez, rez);
        }

        private void dt_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dt.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            dt.MultiSelect = true;
        }

        private static double[,] Transposition(double[,] matr)
        {
            double[,] trans = new double[matr.GetLength(1), matr.GetLength(0)];
            for (int i = 0; i < matr.GetLength(1); i++)
            {
                for (int j = 0; j < matr.GetLength(0); j++)
                {
                    trans[i, j] = matr[j, i];
                }
            }
            return trans;
        }


        static double[,] Multiplication(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += Math.Round(a[i, k] * b[k, j], 1);
                    }
                }
            }
            return r;
        }
    }
}



