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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Collinear = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.normDt = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.matr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Collinear.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.normDt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1095, 299);
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
            this.matr.Location = new System.Drawing.Point(757, 327);
            this.matr.MultiSelect = false;
            this.matr.Name = "matr";
            this.matr.ReadOnly = true;
            this.matr.RowTemplate.Height = 24;
            this.matr.Size = new System.Drawing.Size(788, 238);
            this.matr.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1177, 65);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(368, 130);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // analysisTb
            // 
            this.analysisTb.Location = new System.Drawing.Point(757, 65);
            this.analysisTb.Multiline = true;
            this.analysisTb.Name = "analysisTb";
            this.analysisTb.Size = new System.Drawing.Size(411, 130);
            this.analysisTb.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1296, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Chaddock Scale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(929, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Analysis";
            // 
            // dt
            // 
            this.dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt.Location = new System.Drawing.Point(19, 36);
            this.dt.Name = "dt";
            this.dt.RowTemplate.Height = 24;
            this.dt.Size = new System.Drawing.Size(722, 548);
            this.dt.TabIndex = 0;
            this.dt.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_CellContentClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(293, 22);
            this.textBox1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(413, 7);
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
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1610, 657);
            this.tabControl1.TabIndex = 14;
            // 
            // Collinear
            // 
            this.Collinear.Controls.Add(this.dt);
            this.Collinear.Controls.Add(this.button2);
            this.Collinear.Controls.Add(this.label1);
            this.Collinear.Controls.Add(this.button1);
            this.Collinear.Controls.Add(this.matr);
            this.Collinear.Controls.Add(this.textBox1);
            this.Collinear.Controls.Add(this.textBox2);
            this.Collinear.Controls.Add(this.label2);
            this.Collinear.Controls.Add(this.analysisTb);
            this.Collinear.Controls.Add(this.label3);
            this.Collinear.Location = new System.Drawing.Point(4, 25);
            this.Collinear.Name = "Collinear";
            this.Collinear.Padding = new System.Windows.Forms.Padding(3);
            this.Collinear.Size = new System.Drawing.Size(1602, 628);
            this.Collinear.TabIndex = 0;
            this.Collinear.Text = "Collinear Analysis";
            this.Collinear.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.normDt);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1602, 628);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Multilollinear analysis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(654, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // normDt
            // 
            this.normDt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.normDt.Location = new System.Drawing.Point(8, 35);
            this.normDt.Name = "normDt";
            this.normDt.RowTemplate.Height = 24;
            this.normDt.Size = new System.Drawing.Size(590, 585);
            this.normDt.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(200, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Normalized values";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1610, 657);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.matr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Collinear.ResumeLayout(false);
            this.Collinear.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.normDt)).EndInit();
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Collinear;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView normDt;
        private System.Windows.Forms.Label label4;
    }
}

