
namespace LAB_10
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
            this.button1 = new System.Windows.Forms.Button();
            this.Path = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DeconvertedMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ConvertedMessage = new System.Windows.Forms.TextBox();
            this.DecryptedMessage = new System.Windows.Forms.TextBox();
            this.Decrypt = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.EncryptedMessage = new System.Windows.Forms.TextBox();
            this.Encrypt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(319, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 37);
            this.button1.TabIndex = 33;
            this.button1.Text = "Choice";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Path
            // 
            this.Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Path.Location = new System.Drawing.Point(85, 14);
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            this.Path.Size = new System.Drawing.Size(228, 26);
            this.Path.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "FileName";
            // 
            // DeconvertedMessage
            // 
            this.DeconvertedMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DeconvertedMessage.Location = new System.Drawing.Point(13, 473);
            this.DeconvertedMessage.Multiline = true;
            this.DeconvertedMessage.Name = "DeconvertedMessage";
            this.DeconvertedMessage.ReadOnly = true;
            this.DeconvertedMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DeconvertedMessage.Size = new System.Drawing.Size(837, 85);
            this.DeconvertedMessage.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(609, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(507, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "n2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "n1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Message";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numericUpDown2.Location = new System.Drawing.Point(510, 20);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            35840,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(86, 26);
            this.numericUpDown2.TabIndex = 25;
            this.numericUpDown2.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numericUpDown1.Location = new System.Drawing.Point(414, 20);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            35840,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(90, 26);
            this.numericUpDown1.TabIndex = 24;
            this.numericUpDown1.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // ConvertedMessage
            // 
            this.ConvertedMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ConvertedMessage.Location = new System.Drawing.Point(13, 156);
            this.ConvertedMessage.Multiline = true;
            this.ConvertedMessage.Name = "ConvertedMessage";
            this.ConvertedMessage.ReadOnly = true;
            this.ConvertedMessage.Size = new System.Drawing.Size(837, 26);
            this.ConvertedMessage.TabIndex = 23;
            // 
            // DecryptedMessage
            // 
            this.DecryptedMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DecryptedMessage.Location = new System.Drawing.Point(13, 345);
            this.DecryptedMessage.Multiline = true;
            this.DecryptedMessage.Name = "DecryptedMessage";
            this.DecryptedMessage.ReadOnly = true;
            this.DecryptedMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DecryptedMessage.Size = new System.Drawing.Size(837, 94);
            this.DecryptedMessage.TabIndex = 22;
            // 
            // Decrypt
            // 
            this.Decrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Decrypt.Location = new System.Drawing.Point(12, 306);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(838, 33);
            this.Decrypt.TabIndex = 21;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(612, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 20;
            // 
            // EncryptedMessage
            // 
            this.EncryptedMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.EncryptedMessage.Location = new System.Drawing.Point(12, 204);
            this.EncryptedMessage.Multiline = true;
            this.EncryptedMessage.Name = "EncryptedMessage";
            this.EncryptedMessage.ReadOnly = true;
            this.EncryptedMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EncryptedMessage.Size = new System.Drawing.Size(838, 96);
            this.EncryptedMessage.TabIndex = 19;
            // 
            // Encrypt
            // 
            this.Encrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Encrypt.Location = new System.Drawing.Point(739, 11);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(111, 37);
            this.Encrypt.TabIndex = 18;
            this.Encrypt.Text = "Encrypt";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox1.Location = new System.Drawing.Point(13, 64);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(837, 75);
            this.textBox1.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 453);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "Decrypted Text";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 566);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DeconvertedMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.ConvertedMessage);
            this.Controls.Add(this.DecryptedMessage);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.EncryptedMessage);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DeconvertedMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox ConvertedMessage;
        private System.Windows.Forms.TextBox DecryptedMessage;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox EncryptedMessage;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
    }
}

