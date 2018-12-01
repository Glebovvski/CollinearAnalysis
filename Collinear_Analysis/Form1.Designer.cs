namespace Collinear_Analysis
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
            this.dt = new System.Windows.Forms.DataGridView();
            this.GetFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CollinearBuild = new System.Windows.Forms.Button();
            this.CollinearMatrix = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollinearMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // dt
            // 
            this.dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt.Location = new System.Drawing.Point(12, 60);
            this.dt.Name = "dt";
            this.dt.RowTemplate.Height = 24;
            this.dt.Size = new System.Drawing.Size(469, 562);
            this.dt.TabIndex = 0;
            // 
            // GetFile
            // 
            this.GetFile.Location = new System.Drawing.Point(406, 11);
            this.GetFile.Name = "GetFile";
            this.GetFile.Size = new System.Drawing.Size(75, 23);
            this.GetFile.TabIndex = 1;
            this.GetFile.Text = "File";
            this.GetFile.UseVisualStyleBackColor = true;
            this.GetFile.Click += new System.EventHandler(this.GetFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(388, 22);
            this.textBox1.TabIndex = 2;
            // 
            // CollinearBuild
            // 
            this.CollinearBuild.Location = new System.Drawing.Point(487, 11);
            this.CollinearBuild.Name = "CollinearBuild";
            this.CollinearBuild.Size = new System.Drawing.Size(136, 45);
            this.CollinearBuild.TabIndex = 3;
            this.CollinearBuild.Text = "Build Collinear matrix";
            this.CollinearBuild.UseVisualStyleBackColor = true;
            this.CollinearBuild.Click += new System.EventHandler(this.CollinearBuild_Click);
            // 
            // CollinearMatrix
            // 
            this.CollinearMatrix.AllowUserToAddRows = false;
            this.CollinearMatrix.AllowUserToDeleteRows = false;
            this.CollinearMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CollinearMatrix.Location = new System.Drawing.Point(496, 95);
            this.CollinearMatrix.MultiSelect = false;
            this.CollinearMatrix.Name = "CollinearMatrix";
            this.CollinearMatrix.ReadOnly = true;
            this.CollinearMatrix.RowTemplate.Height = 24;
            this.CollinearMatrix.Size = new System.Drawing.Size(420, 196);
            this.CollinearMatrix.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(594, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Collinear Matrix";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 626);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CollinearMatrix);
            this.Controls.Add(this.CollinearBuild);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GetFile);
            this.Controls.Add(this.dt);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollinearMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dt;
        private System.Windows.Forms.Button GetFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CollinearBuild;
        private System.Windows.Forms.DataGridView CollinearMatrix;
        private System.Windows.Forms.Label label1;
    }
}

