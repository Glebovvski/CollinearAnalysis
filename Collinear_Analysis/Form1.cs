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
        double Kv_Kv = 0;
        double Kv_Ibp = 0;
        double Kv_Zp = 0;
        double Kv_Isc = 0;
        double Kv_Vzr = 0;

        double Ibp_Ibp = 0;
        double Ibp_Zp = 0;
        double Ibp_Isc = 0;
        double Ibp_Vzr = 0;

        double Zp_Zp = 0;
        double Zp_Isc = 0;
        double Zp_Vzr = 0;

        double Isc_Isc = 0;
        double Isc_Vzr = 0;
        double Vzr_Vzr = 0;

        List<double> first = new List<double>();
        List<double> second = new List<double>();
        List<double> third = new List<double>();
        List<double> fourth = new List<double>();
        List<double> fifth = new List<double>();

        List<string> names = new List<string>()
                {
                    "КВ осіб",
                    "ІБП %",
                    "ІСЦ",
                    "ЗП грн",
                    "ВЗР тис.т"
                };

        public Form1()
        {
            InitializeComponent();
        }

        private void GetFile_Click(object sender, EventArgs e)
        {
            dt.DataSource = string.Empty;
            CollinearMatrix.Columns.Clear();
            

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

        private void GetData()
        {
            var data = dt.Rows.OfType<DataGridViewRow>().Where(x => x.Cells[0].Value != null).Select(
                            r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value).ToArray()).ToList();

            foreach (var item in data)
            {
                first.Add(double.Parse(item[0].ToString()));
                second.Add(double.Parse(item[1].ToString()));
                third.Add(double.Parse(item[2].ToString()));
                fourth.Add(double.Parse(item[3].ToString()));
                fifth.Add(double.Parse(item[4].ToString()));
            }
        }

        private void SetCollinearMatrix()
        {
            CollinearMatrix.ColumnCount = 6;
            CollinearMatrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CollinearMatrix.Columns[0].Name = "";
            CollinearMatrix.Columns[1].Name = names[0];
            CollinearMatrix.Columns[2].Name = names[1];
            CollinearMatrix.Columns[3].Name = names[2];
            CollinearMatrix.Columns[4].Name = names[3];
            CollinearMatrix.Columns[5].Name = names[4];

            CollinearMatrix.Rows.Add(names[0], Kv_Kv);
            CollinearMatrix.Rows.Add(names[1], Kv_Ibp, Ibp_Ibp);
            CollinearMatrix.Rows.Add(names[2], Kv_Isc, Ibp_Isc, Isc_Isc);
            CollinearMatrix.Rows.Add(names[3], Kv_Zp, Ibp_Zp, Zp_Isc, Zp_Zp);
            CollinearMatrix.Rows.Add(names[4], Kv_Vzr, Ibp_Vzr, Isc_Vzr, Zp_Vzr, Vzr_Vzr);

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = System.Drawing.Color.Red;

            for(int i=0;i<CollinearMatrix.Rows.Count; i++)
            {
                for (int j = 1; j < CollinearMatrix.Rows[i].Cells.Count;j++)
                {
                    if (CollinearMatrix.Rows[i].Cells[j].Value != null)
                    {
                        if (double.Parse(CollinearMatrix.Rows[i].Cells[j].Value.ToString()) >= 0.5)
                            CollinearMatrix.Rows[i].Cells[j].Style = style;
                    }
                }
            }
        }

        private void CollinearBuild_Click(object sender, EventArgs e)
        {
            if (dt.DataSource == null)
                MessageBox.Show("Open excel file with data");

            else
            {
                GetData();

                Kv_Kv = Math.Round(Correlation(first, first),2);
                Kv_Ibp = Math.Round(Correlation(first, second),2);
                Kv_Isc = Math.Round(Correlation(first, third),2);
                Kv_Zp = Math.Round(Correlation(first, fourth),2);
                Kv_Vzr = Math.Round(Correlation(first, fifth),2);

                Ibp_Ibp = Math.Round(Correlation(second, second),2);
                Ibp_Isc = Math.Round(Correlation(second, third),2);
                Ibp_Zp = Math.Round(Correlation(second, fourth),2);
                Ibp_Vzr = Math.Round(Correlation(second, fifth),2);

                Zp_Zp = Math.Round(Correlation(fourth, fourth),2);
                Zp_Isc = Math.Round(Correlation(fourth, third),2);
                Zp_Vzr = Math.Round(Correlation(fourth, fifth),2);

                Isc_Isc = Math.Round(Correlation(third, third),2);
                Isc_Vzr = Math.Round(Correlation(third, fifth),2);

                Vzr_Vzr = Math.Round(Correlation(fifth, fifth),2);

                SetCollinearMatrix();
            }
        }

        private double Correlation(List<double> first, List<double> second)
        {
            double[] array_xy = new double[first.Count];
            double[] array_xp2 = new double[first.Count];
            double[] array_yp2 = new double[first.Count];
            for (int i = 0; i < first.Count; i++)
                array_xy[i] = first[i] * second[i];
            for (int i = 0; i < first.Count; i++)
                array_xp2[i] = Math.Pow(first[i], 2.0);
            for (int i = 0; i < first.Count; i++)
                array_yp2[i] = Math.Pow(second[i], 2.0);
            double sum_x = 0;
            double sum_y = 0;
            foreach (double n in first)
                sum_x += n;
            foreach (double n in second)
                sum_y += n;
            double sum_xy = 0;
            foreach (double n in array_xy)
                sum_xy += n;
            double sum_xpow2 = 0;
            foreach (double n in array_xp2)
                sum_xpow2 += n;
            double sum_ypow2 = 0;
            foreach (double n in array_yp2)
                sum_ypow2 += n;
            double Ex2 = Math.Pow(sum_x, 2.00);
            double Ey2 = Math.Pow(sum_y, 2.00);

            double Correl =
            (first.Count * sum_xy - sum_x * sum_y) /
            Math.Sqrt((first.Count * sum_xpow2 - Ex2) * (first.Count * sum_ypow2 - Ey2));

            return Correl;
        }
    }
}
