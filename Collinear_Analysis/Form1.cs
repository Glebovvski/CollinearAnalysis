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

        private void Setmatr()
        {
            matr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle styleMiddle = new DataGridViewCellStyle();
            styleMiddle.BackColor = System.Drawing.Color.Orange;

            DataGridViewCellStyle styleHigh = new DataGridViewCellStyle();
            styleHigh.BackColor = System.Drawing.Color.Red;

            DataGridViewCellStyle styleLow = new DataGridViewCellStyle();
            styleLow.BackColor = System.Drawing.Color.Yellow;

            DataGridViewCellStyle styleLowest = new DataGridViewCellStyle();
            styleLowest.BackColor = System.Drawing.Color.LightBlue;

            DataGridViewCellStyle styleLowLow = new DataGridViewCellStyle();
            styleLowLow.BackColor = System.Drawing.Color.LightGray;

            for (int i = 0; i < matr.Rows.Count; i++)
            {
                for (int j = 0; j < matr.Rows[i].Cells.Count; j++)
                {
                    if (double.Parse(matr.Rows[i].Cells[j].Value.ToString()) >= 0.1 && double.Parse(matr.Rows[i].Cells[j].Value.ToString()) <= 0.3)
                        matr.Rows[i].Cells[j].Style = styleLowest;
                    else if (double.Parse(matr.Rows[i].Cells[j].Value.ToString()) > 0.3 && double.Parse(matr.Rows[i].Cells[j].Value.ToString()) < 0.5)
                        matr.Rows[i].Cells[j].Style = styleLow;
                    else if (double.Parse(matr.Rows[i].Cells[j].Value.ToString()) >= 0.5 && double.Parse(matr.Rows[i].Cells[j].Value.ToString()) <= 0.7)
                        matr.Rows[i].Cells[j].Style = styleMiddle;
                    else if (double.Parse(matr.Rows[i].Cells[j].Value.ToString()) > 0.7 && double.Parse(matr.Rows[i].Cells[j].Value.ToString()) <= 1)
                        matr.Rows[i].Cells[j].Style = styleHigh;
                    else matr.Rows[i].Cells[j].Style = styleLowLow;
                }
            }
        }

        private void CollinearBuild_Click(object sender, EventArgs e)
        {

        }


        private void matr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                        koefkorel = Math.Round((avrxy - avrx * avry) / (avrsqrx * avrsqry), 2);
                    }
                    matr.Rows[l].Cells[k].Value = koefkorel;
                }

                matr.Columns[l].HeaderText = dt.Columns[l].HeaderText;
                matr.Rows[l].HeaderCell.Value = dt.Columns[l].HeaderText;

            }

            Setmatr();

            double[,] rez;
            rez = new double[matr.RowCount, matr.ColumnCount];

            for (i = 0; i < matr.RowCount; i++)
            {
                for (j = 0; j < matr.ColumnCount; j++)
                {
                    rez[i, j] = Convert.ToDouble(matr.Rows[i].Cells[j].Value);
                }
            }


            min = rez[1, 0];
            max = rez[1, 0];
            for (i = 0; i < rez.GetLength(0); i++)
            {
                for (j = 0; j < rez.GetLength(1); j++)
                {
                    if (i > j)
                    {
                        if (min > rez[i, j])
                        {
                            min = rez[i, j];
                            mini = i;
                            minj = j;
                        }
                        if (max < rez[i, j])
                        {
                            max = rez[i, j];
                            maxi = i;
                            maxj = j;
                        }
                    }
                }
            }
        }
    }

}


