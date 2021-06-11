
namespace LAB_11
{
    partial class Task1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.A = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.B = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.PX = new System.Windows.Forms.NumericUpDown();
            this.PY = new System.Windows.Forms.NumericUpDown();
            this.QY = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.QX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.L = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.K = new System.Windows.Forms.NumericUpDown();
            this.RY = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.RX = new System.Windows.Forms.NumericUpDown();
            this.calculate_button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.KP = new System.Windows.Forms.TextBox();
            this.PQ = new System.Windows.Forms.TextBox();
            this.KPLQR = new System.Windows.Forms.TextBox();
            this.PQR = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.MOD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.K)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MOD)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.YValuesPerPoint = 2;
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(677, 300);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // A
            // 
            this.A.Location = new System.Drawing.Point(34, 335);
            this.A.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.A.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(72, 22);
            this.A.TabIndex = 2;
            this.A.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "a";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "b";
            // 
            // B
            // 
            this.B.Location = new System.Drawing.Point(141, 335);
            this.B.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.B.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(72, 22);
            this.B.TabIndex = 4;
            this.B.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "P (x, y) =";
            // 
            // PX
            // 
            this.PX.Location = new System.Drawing.Point(302, 335);
            this.PX.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.PX.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.PX.Name = "PX";
            this.PX.Size = new System.Drawing.Size(72, 22);
            this.PX.TabIndex = 6;
            this.PX.Value = new decimal(new int[] {
            74,
            0,
            0,
            0});
            // 
            // PY
            // 
            this.PY.Location = new System.Drawing.Point(380, 335);
            this.PY.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.PY.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.PY.Name = "PY";
            this.PY.Size = new System.Drawing.Size(72, 22);
            this.PY.TabIndex = 8;
            this.PY.Value = new decimal(new int[] {
            170,
            0,
            0,
            0});
            // 
            // QY
            // 
            this.QY.Location = new System.Drawing.Point(617, 335);
            this.QY.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.QY.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.QY.Name = "QY";
            this.QY.Size = new System.Drawing.Size(72, 22);
            this.QY.TabIndex = 11;
            this.QY.Value = new decimal(new int[] {
            716,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Q (x, y) =";
            // 
            // QX
            // 
            this.QX.Location = new System.Drawing.Point(539, 335);
            this.QX.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.QX.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.QX.Name = "QX";
            this.QX.Size = new System.Drawing.Size(72, 22);
            this.QX.TabIndex = 9;
            this.QX.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(595, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "l";
            // 
            // L
            // 
            this.L.Location = new System.Drawing.Point(617, 365);
            this.L.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.L.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.L.Name = "L";
            this.L.Size = new System.Drawing.Size(72, 22);
            this.L.TabIndex = 14;
            this.L.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(485, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "k";
            // 
            // K
            // 
            this.K.Location = new System.Drawing.Point(507, 365);
            this.K.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.K.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.K.Name = "K";
            this.K.Size = new System.Drawing.Size(72, 22);
            this.K.TabIndex = 12;
            this.K.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // RY
            // 
            this.RY.Location = new System.Drawing.Point(380, 365);
            this.RY.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.RY.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.RY.Name = "RY";
            this.RY.Size = new System.Drawing.Size(72, 22);
            this.RY.TabIndex = 18;
            this.RY.Value = new decimal(new int[] {
            267,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "R (x, y) =";
            // 
            // RX
            // 
            this.RX.Location = new System.Drawing.Point(302, 365);
            this.RX.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.RX.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.RX.Name = "RX";
            this.RX.Size = new System.Drawing.Size(72, 22);
            this.RX.TabIndex = 16;
            this.RX.Value = new decimal(new int[] {
            102,
            0,
            0,
            0});
            // 
            // calculate_button
            // 
            this.calculate_button.Location = new System.Drawing.Point(15, 364);
            this.calculate_button.Name = "calculate_button";
            this.calculate_button.Size = new System.Drawing.Size(198, 23);
            this.calculate_button.TabIndex = 19;
            this.calculate_button.Text = "Calculate";
            this.calculate_button.UseVisualStyleBackColor = true;
            this.calculate_button.Click += new System.EventHandler(this.calculate_button_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "kP =";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 430);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "P + Q =";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(295, 430);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "P - Q + R =";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(295, 399);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "kP + lQ - R =";
            // 
            // KP
            // 
            this.KP.Location = new System.Drawing.Point(98, 400);
            this.KP.Name = "KP";
            this.KP.ReadOnly = true;
            this.KP.Size = new System.Drawing.Size(181, 22);
            this.KP.TabIndex = 24;
            // 
            // PQ
            // 
            this.PQ.Location = new System.Drawing.Point(98, 428);
            this.PQ.Name = "PQ";
            this.PQ.ReadOnly = true;
            this.PQ.Size = new System.Drawing.Size(181, 22);
            this.PQ.TabIndex = 25;
            // 
            // KPLQR
            // 
            this.KPLQR.Location = new System.Drawing.Point(390, 396);
            this.KPLQR.Name = "KPLQR";
            this.KPLQR.ReadOnly = true;
            this.KPLQR.Size = new System.Drawing.Size(175, 22);
            this.KPLQR.TabIndex = 26;
            // 
            // PQR
            // 
            this.PQR.Location = new System.Drawing.Point(390, 427);
            this.PQR.Name = "PQR";
            this.PQR.ReadOnly = true;
            this.PQR.Size = new System.Drawing.Size(175, 22);
            this.PQR.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(576, 415);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 17);
            this.label12.TabIndex = 29;
            this.label12.Text = "mod";
            // 
            // MOD
            // 
            this.MOD.Location = new System.Drawing.Point(617, 413);
            this.MOD.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.MOD.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.MOD.Name = "MOD";
            this.MOD.Size = new System.Drawing.Size(72, 22);
            this.MOD.TabIndex = 28;
            this.MOD.Value = new decimal(new int[] {
            751,
            0,
            0,
            0});
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 458);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.MOD);
            this.Controls.Add(this.PQR);
            this.Controls.Add(this.KPLQR);
            this.Controls.Add(this.PQ);
            this.Controls.Add(this.KP);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.calculate_button);
            this.Controls.Add(this.RY);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.L);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.K);
            this.Controls.Add(this.QY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.QX);
            this.Controls.Add(this.PY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.B);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.A);
            this.Controls.Add(this.chart1);
            this.Name = "Task1";
            this.Text = "Task1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.K)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MOD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown A;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown B;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown PX;
        private System.Windows.Forms.NumericUpDown PY;
        private System.Windows.Forms.NumericUpDown QY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown QX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown L;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown K;
        private System.Windows.Forms.NumericUpDown RY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown RX;
        private System.Windows.Forms.Button calculate_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox KP;
        private System.Windows.Forms.TextBox PQ;
        private System.Windows.Forms.TextBox KPLQR;
        private System.Windows.Forms.TextBox PQR;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown MOD;
    }
}