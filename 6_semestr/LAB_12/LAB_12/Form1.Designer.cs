
namespace LAB_12
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OriginImageBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.EncodeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.DecodeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.LSBBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.EncodedImageBox = new System.Windows.Forms.PictureBox();
            this.LSBImageBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.TextToEncode = new System.Windows.Forms.TextBox();
            this.DecodedText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.SpectrumBox = new System.Windows.Forms.ComboBox();
            this.KeyBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LesserBitsBox = new System.Windows.Forms.NumericUpDown();
            this.CanBeEncodedBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.OriginImageBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EncodedImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LSBImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LesserBitsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OriginImageBox
            // 
            this.OriginImageBox.BackColor = System.Drawing.SystemColors.Window;
            this.OriginImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginImageBox.Location = new System.Drawing.Point(14, 64);
            this.OriginImageBox.Name = "OriginImageBox";
            this.OriginImageBox.Size = new System.Drawing.Size(235, 258);
            this.OriginImageBox.TabIndex = 0;
            this.OriginImageBox.TabStop = false;
            this.OriginImageBox.DoubleClick += new System.EventHandler(this.OriginImageBox_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EncodeBtn,
            this.DecodeBtn,
            this.LSBBtn,
            this.ClearBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // EncodeBtn
            // 
            this.EncodeBtn.Name = "EncodeBtn";
            this.EncodeBtn.Size = new System.Drawing.Size(72, 24);
            this.EncodeBtn.Text = "Encode";
            this.EncodeBtn.Click += new System.EventHandler(this.EncodeBtn_Click);
            // 
            // DecodeBtn
            // 
            this.DecodeBtn.Name = "DecodeBtn";
            this.DecodeBtn.Size = new System.Drawing.Size(75, 24);
            this.DecodeBtn.Text = "Decode";
            this.DecodeBtn.Click += new System.EventHandler(this.DecodeBtn_Click);
            // 
            // LSBBtn
            // 
            this.LSBBtn.Name = "LSBBtn";
            this.LSBBtn.Size = new System.Drawing.Size(47, 24);
            this.LSBBtn.Text = "LSB";
            this.LSBBtn.Click += new System.EventHandler(this.LSBBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(57, 24);
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // EncodedImageBox
            // 
            this.EncodedImageBox.BackColor = System.Drawing.SystemColors.Window;
            this.EncodedImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EncodedImageBox.Location = new System.Drawing.Point(281, 64);
            this.EncodedImageBox.Name = "EncodedImageBox";
            this.EncodedImageBox.Size = new System.Drawing.Size(235, 258);
            this.EncodedImageBox.TabIndex = 2;
            this.EncodedImageBox.TabStop = false;
            this.EncodedImageBox.DoubleClick += new System.EventHandler(this.EncodedImageBox_DoubleClick);
            // 
            // LSBImageBox
            // 
            this.LSBImageBox.BackColor = System.Drawing.SystemColors.Window;
            this.LSBImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LSBImageBox.Location = new System.Drawing.Point(555, 64);
            this.LSBImageBox.Name = "LSBImageBox";
            this.LSBImageBox.Size = new System.Drawing.Size(235, 258);
            this.LSBImageBox.TabIndex = 3;
            this.LSBImageBox.TabStop = false;
            this.LSBImageBox.DoubleClick += new System.EventHandler(this.LSBImageBox_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(10, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Origin Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(277, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Encoded Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(551, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "LSB Image";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(14, 563);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(776, 30);
            this.ProgressBar.TabIndex = 7;
            // 
            // TextToEncode
            // 
            this.TextToEncode.Location = new System.Drawing.Point(12, 360);
            this.TextToEncode.Multiline = true;
            this.TextToEncode.Name = "TextToEncode";
            this.TextToEncode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextToEncode.Size = new System.Drawing.Size(376, 137);
            this.TextToEncode.TabIndex = 8;
            this.TextToEncode.DoubleClick += new System.EventHandler(this.TextToEncode_DoubleClick);
            // 
            // DecodedText
            // 
            this.DecodedText.Location = new System.Drawing.Point(411, 360);
            this.DecodedText.Multiline = true;
            this.DecodedText.Name = "DecodedText";
            this.DecodedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DecodedText.Size = new System.Drawing.Size(377, 137);
            this.DecodedText.TabIndex = 9;
            this.DecodedText.DoubleClick += new System.EventHandler(this.DecodedText_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(12, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Text To Encode";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label.Location = new System.Drawing.Point(412, 337);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(113, 20);
            this.label.TabIndex = 11;
            this.label.Text = "Decoded Text";
            // 
            // SpectrumBox
            // 
            this.SpectrumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SpectrumBox.FormattingEnabled = true;
            this.SpectrumBox.Location = new System.Drawing.Point(108, 518);
            this.SpectrumBox.Name = "SpectrumBox";
            this.SpectrumBox.Size = new System.Drawing.Size(151, 28);
            this.SpectrumBox.TabIndex = 12;
            this.SpectrumBox.SelectedIndexChanged += new System.EventHandler(this.BytesCanBeEncoded);
            // 
            // KeyBox
            // 
            this.KeyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyBox.Location = new System.Drawing.Point(659, 519);
            this.KeyBox.Maximum = new decimal(new int[] {
            65325,
            0,
            0,
            0});
            this.KeyBox.Name = "KeyBox";
            this.KeyBox.Size = new System.Drawing.Size(129, 26);
            this.KeyBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(10, 521);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Spectrum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(543, 521);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Key (Bytes)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(300, 521);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Lesser Bits";
            // 
            // LesserBitsBox
            // 
            this.LesserBitsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LesserBitsBox.Location = new System.Drawing.Point(411, 519);
            this.LesserBitsBox.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.LesserBitsBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LesserBitsBox.Name = "LesserBitsBox";
            this.LesserBitsBox.Size = new System.Drawing.Size(87, 26);
            this.LesserBitsBox.TabIndex = 16;
            this.LesserBitsBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LesserBitsBox.ValueChanged += new System.EventHandler(this.BytesCanBeEncoded);
            // 
            // CanBeEncodedBox
            // 
            this.CanBeEncodedBox.BackColor = System.Drawing.SystemColors.Control;
            this.CanBeEncodedBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CanBeEncodedBox.Location = new System.Drawing.Point(14, 605);
            this.CanBeEncodedBox.Name = "CanBeEncodedBox";
            this.CanBeEncodedBox.Size = new System.Drawing.Size(772, 15);
            this.CanBeEncodedBox.TabIndex = 18;
            this.CanBeEncodedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 632);
            this.Controls.Add(this.CanBeEncodedBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LesserBitsBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.KeyBox);
            this.Controls.Add(this.SpectrumBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DecodedText);
            this.Controls.Add(this.TextToEncode);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LSBImageBox);
            this.Controls.Add(this.EncodedImageBox);
            this.Controls.Add(this.OriginImageBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LSB";
            ((System.ComponentModel.ISupportInitialize)(this.OriginImageBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EncodedImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LSBImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LesserBitsBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OriginImageBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem EncodeBtn;
        private System.Windows.Forms.ToolStripMenuItem DecodeBtn;
        private System.Windows.Forms.ToolStripMenuItem LSBBtn;
        private System.Windows.Forms.PictureBox EncodedImageBox;
        private System.Windows.Forms.PictureBox LSBImageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripMenuItem ClearBtn;
        private System.Windows.Forms.TextBox TextToEncode;
        private System.Windows.Forms.TextBox DecodedText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox SpectrumBox;
        private System.Windows.Forms.NumericUpDown KeyBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown LesserBitsBox;
        private System.Windows.Forms.TextBox CanBeEncodedBox;
    }
}

