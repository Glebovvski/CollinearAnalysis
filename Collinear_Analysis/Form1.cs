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
        List<double> first = new List<double>();
        List<double> second = new List<double>();
        List<double> third = new List<double>();
        List<double> fourth = new List<double>();
        List<double> fifth = new List<double>();

        public Form1()
        {
            InitializeComponent();
        }

        private void GetFile_Click(object sender, EventArgs e)
        {
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

        private void CollinearBuild_Click(object sender, EventArgs e)
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

            if (dt.DataSource == null)
                MessageBox.Show("Open excel file with data");

            else
            {
                GetData();

                Kv_Kv = Correlation(first, first);
                Kv_Ibp = Correlation(first, second);
                Kv_Isc = Correlation(first, third);
                Kv_Zp = Correlation(first, fourth);
                Kv_Vzr = Correlation(first, fifth);

                Ibp_Ibp = Correlation(second, second);
                Ibp_Isc = Correlation(second, third);
                Ibp_Zp = Correlation(second, fourth);
                Ibp_Vzr = Correlation(second, fifth);

                Zp_Zp = Correlation(fourth, fourth);
                Zp_Isc = Correlation(fourth, third);
                Zp_Vzr = Correlation(fourth, fifth);

                Isc_Isc = Correlation(third, third);
                Isc_Vzr = Correlation(third, fifth);

                Vzr_Vzr = Correlation(fifth, fifth);
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
