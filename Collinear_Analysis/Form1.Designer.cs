﻿namespace Collinear_Analysis
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.matr = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.analysisTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dt = new System.Windows.Forms.DataGridView();
            this.FilePath_Tb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Collinear = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.Fishers_Tb = new System.Windows.Forms.TextBox();
            this.StudentAnalysisTb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Partial = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.FisherTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.StudentTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Student = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.InverseMatrix = new System.Windows.Forms.DataGridView();
            this.CompareXi = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.XiTable_Tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Xi_Tb = new System.Windows.Forms.TextBox();
            this.Det_Tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.normDt = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.formula_Tb = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.CoefReg = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.matr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Collinear.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Partial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Student)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InverseMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.normDt)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoefReg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(911, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Collinear Matrix";
            // 
            // matr
            // 
            this.matr.AllowUserToAddRows = false;
            this.matr.AllowUserToDeleteRows = false;
            this.matr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matr.Location = new System.Drawing.Point(573, 326);
            this.matr.MultiSelect = false;
            this.matr.Name = "matr";
            this.matr.ReadOnly = true;
            this.matr.RowTemplate.Height = 24;
            this.matr.Size = new System.Drawing.Size(788, 352);
            this.matr.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(993, 65);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(368, 130);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // analysisTb
            // 
            this.analysisTb.Location = new System.Drawing.Point(565, 65);
            this.analysisTb.Multiline = true;
            this.analysisTb.Name = "analysisTb";
            this.analysisTb.Size = new System.Drawing.Size(411, 130);
            this.analysisTb.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1112, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Chaddock Scale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(737, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Analysis";
            // 
            // dt
            // 
            this.dt.AllowUserToAddRows = false;
            this.dt.AllowUserToDeleteRows = false;
            this.dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt.Location = new System.Drawing.Point(19, 36);
            this.dt.Name = "dt";
            this.dt.ReadOnly = true;
            this.dt.RowTemplate.Height = 24;
            this.dt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dt.ShowEditingIcon = false;
            this.dt.Size = new System.Drawing.Size(540, 642);
            this.dt.TabIndex = 0;
            // 
            // FilePath_Tb
            // 
            this.FilePath_Tb.Location = new System.Drawing.Point(19, 8);
            this.FilePath_Tb.Name = "FilePath_Tb";
            this.FilePath_Tb.Size = new System.Drawing.Size(293, 22);
            this.FilePath_Tb.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(399, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Collinear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Collinear);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1390, 741);
            this.tabControl1.TabIndex = 14;
            // 
            // Collinear
            // 
            this.Collinear.Controls.Add(this.button5);
            this.Collinear.Controls.Add(this.dt);
            this.Collinear.Controls.Add(this.button2);
            this.Collinear.Controls.Add(this.label1);
            this.Collinear.Controls.Add(this.button1);
            this.Collinear.Controls.Add(this.matr);
            this.Collinear.Controls.Add(this.FilePath_Tb);
            this.Collinear.Controls.Add(this.textBox2);
            this.Collinear.Controls.Add(this.label2);
            this.Collinear.Controls.Add(this.analysisTb);
            this.Collinear.Controls.Add(this.label3);
            this.Collinear.Location = new System.Drawing.Point(4, 25);
            this.Collinear.Name = "Collinear";
            this.Collinear.Padding = new System.Windows.Forms.Padding(3);
            this.Collinear.Size = new System.Drawing.Size(1382, 712);
            this.Collinear.TabIndex = 0;
            this.Collinear.Text = "Collinear Analysis";
            this.Collinear.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(484, 7);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.Fishers_Tb);
            this.tabPage2.Controls.Add(this.StudentAnalysisTb);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.Partial);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.FisherTB);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.StudentTb);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.Student);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.InverseMatrix);
            this.tabPage2.Controls.Add(this.CompareXi);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.XiTable_Tb);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.Xi_Tb);
            this.tabPage2.Controls.Add(this.Det_Tb);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.normDt);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1382, 712);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Multilollinear analysis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(1182, 383);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 29);
            this.label14.TabIndex = 32;
            this.label14.Text = "Analysis";
            // 
            // Fishers_Tb
            // 
            this.Fishers_Tb.Location = new System.Drawing.Point(1092, 95);
            this.Fishers_Tb.Multiline = true;
            this.Fishers_Tb.Name = "Fishers_Tb";
            this.Fishers_Tb.Size = new System.Drawing.Size(278, 285);
            this.Fishers_Tb.TabIndex = 31;
            // 
            // StudentAnalysisTb
            // 
            this.StudentAnalysisTb.Location = new System.Drawing.Point(1092, 415);
            this.StudentAnalysisTb.Multiline = true;
            this.StudentAnalysisTb.Name = "StudentAnalysisTb";
            this.StudentAnalysisTb.Size = new System.Drawing.Size(278, 253);
            this.StudentAnalysisTb.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(694, 284);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(166, 25);
            this.label13.TabIndex = 30;
            this.label13.Text = "partial coefficients";
            // 
            // Partial
            // 
            this.Partial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Partial.Location = new System.Drawing.Point(508, 312);
            this.Partial.Name = "Partial";
            this.Partial.RowTemplate.Height = 24;
            this.Partial.Size = new System.Drawing.Size(553, 178);
            this.Partial.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(1182, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(188, 29);
            this.label12.TabIndex = 28;
            this.label12.Text = "Fisher\'s criterias";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(1020, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 25);
            this.label11.TabIndex = 17;
            this.label11.Text = "Fisher factor";
            // 
            // FisherTB
            // 
            this.FisherTB.Location = new System.Drawing.Point(1025, 38);
            this.FisherTB.Name = "FisherTB";
            this.FisherTB.Size = new System.Drawing.Size(115, 22);
            this.FisherTB.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(881, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 25);
            this.label10.TabIndex = 15;
            this.label10.Text = "Student factor";
            // 
            // StudentTb
            // 
            this.StudentTb.Location = new System.Drawing.Point(886, 38);
            this.StudentTb.Name = "StudentTb";
            this.StudentTb.Size = new System.Drawing.Size(115, 22);
            this.StudentTb.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(694, 503);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 25);
            this.label9.TabIndex = 13;
            this.label9.Text = "Student\'s t-test";
            // 
            // Student
            // 
            this.Student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Student.Location = new System.Drawing.Point(508, 531);
            this.Student.Name = "Student";
            this.Student.RowTemplate.Height = 24;
            this.Student.Size = new System.Drawing.Size(553, 178);
            this.Student.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(694, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "Inverse Matrix";
            // 
            // InverseMatrix
            // 
            this.InverseMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InverseMatrix.Location = new System.Drawing.Point(508, 95);
            this.InverseMatrix.Name = "InverseMatrix";
            this.InverseMatrix.RowTemplate.Height = 24;
            this.InverseMatrix.Size = new System.Drawing.Size(553, 178);
            this.InverseMatrix.TabIndex = 10;
            // 
            // CompareXi
            // 
            this.CompareXi.AutoSize = true;
            this.CompareXi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CompareXi.Location = new System.Drawing.Point(749, 38);
            this.CompareXi.Name = "CompareXi";
            this.CompareXi.Size = new System.Drawing.Size(0, 25);
            this.CompareXi.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(783, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Xi table";
            // 
            // XiTable_Tb
            // 
            this.XiTable_Tb.Location = new System.Drawing.Point(774, 38);
            this.XiTable_Tb.Name = "XiTable_Tb";
            this.XiTable_Tb.Size = new System.Drawing.Size(100, 22);
            this.XiTable_Tb.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(672, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Xi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(503, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Determinant";
            // 
            // Xi_Tb
            // 
            this.Xi_Tb.Location = new System.Drawing.Point(643, 38);
            this.Xi_Tb.Name = "Xi_Tb";
            this.Xi_Tb.Size = new System.Drawing.Size(100, 22);
            this.Xi_Tb.TabIndex = 4;
            // 
            // Det_Tb
            // 
            this.Det_Tb.Location = new System.Drawing.Point(508, 38);
            this.Det_Tb.Name = "Det_Tb";
            this.Det_Tb.Size = new System.Drawing.Size(100, 22);
            this.Det_Tb.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(133, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Normalized values";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(311, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(189, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Calculate multicollinearity ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // normDt
            // 
            this.normDt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.normDt.Location = new System.Drawing.Point(8, 35);
            this.normDt.Name = "normDt";
            this.normDt.RowTemplate.Height = 24;
            this.normDt.Size = new System.Drawing.Size(459, 674);
            this.normDt.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.formula_Tb);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.CoefReg);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1382, 712);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Regression analysis";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // formula_Tb
            // 
            this.formula_Tb.Location = new System.Drawing.Point(526, 36);
            this.formula_Tb.Name = "formula_Tb";
            this.formula_Tb.Size = new System.Drawing.Size(833, 22);
            this.formula_Tb.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(138, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(162, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Regression Analysis";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // CoefReg
            // 
            this.CoefReg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoefReg.Location = new System.Drawing.Point(3, 36);
            this.CoefReg.Name = "CoefReg";
            this.CoefReg.RowTemplate.Height = 24;
            this.CoefReg.Size = new System.Drawing.Size(471, 250);
            this.CoefReg.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 741);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Лабораторна робота №2";
            ((System.ComponentModel.ISupportInitialize)(this.matr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Collinear.ResumeLayout(false);
            this.Collinear.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Partial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Student)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InverseMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.normDt)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoefReg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView matr;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox analysisTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dt;
        private System.Windows.Forms.TextBox FilePath_Tb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Collinear;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView normDt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Xi_Tb;
        private System.Windows.Forms.TextBox Det_Tb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox XiTable_Tb;
        private System.Windows.Forms.Label CompareXi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView InverseMatrix;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView Student;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox FisherTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox StudentTb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView Partial;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox StudentAnalysisTb;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView CoefReg;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Fishers_Tb;
        private System.Windows.Forms.TextBox formula_Tb;
        private System.Windows.Forms.Button button5;
    }
}

