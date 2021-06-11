
namespace LAB_14
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.ArrayBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.WeightsBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ServerBtn = new System.Windows.Forms.Button();
            this.ClientBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PortBox = new System.Windows.Forms.NumericUpDown();
            this.SeedBox = new System.Windows.Forms.NumericUpDown();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.MessagesChekBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PortBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeedBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ArrayBox
            // 
            this.ArrayBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ArrayBox.Location = new System.Drawing.Point(112, 65);
            this.ArrayBox.Name = "ArrayBox";
            this.ArrayBox.Size = new System.Drawing.Size(623, 26);
            this.ArrayBox.TabIndex = 0;
            this.ArrayBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Arrays";
            // 
            // WeightsBox
            // 
            this.WeightsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.WeightsBox.Location = new System.Drawing.Point(112, 119);
            this.WeightsBox.Name = "WeightsBox";
            this.WeightsBox.ReadOnly = true;
            this.WeightsBox.Size = new System.Drawing.Size(623, 26);
            this.WeightsBox.TabIndex = 27;
            this.WeightsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Weights";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.SetValues);
            // 
            // ServerBtn
            // 
            this.ServerBtn.Location = new System.Drawing.Point(546, 12);
            this.ServerBtn.Name = "ServerBtn";
            this.ServerBtn.Size = new System.Drawing.Size(88, 36);
            this.ServerBtn.TabIndex = 29;
            this.ServerBtn.Text = "Server";
            this.ServerBtn.UseVisualStyleBackColor = true;
            this.ServerBtn.Click += new System.EventHandler(this.ServerBtn_Click);
            // 
            // ClientBtn
            // 
            this.ClientBtn.Location = new System.Drawing.Point(647, 12);
            this.ClientBtn.Name = "ClientBtn";
            this.ClientBtn.Size = new System.Drawing.Size(88, 36);
            this.ClientBtn.TabIndex = 30;
            this.ClientBtn.Text = "Client";
            this.ClientBtn.UseVisualStyleBackColor = true;
            this.ClientBtn.Click += new System.EventHandler(this.ClientBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(189, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(314, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Seed";
            // 
            // PortBox
            // 
            this.PortBox.Location = new System.Drawing.Point(235, 19);
            this.PortBox.Maximum = new decimal(new int[] {
            65325,
            0,
            0,
            0});
            this.PortBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(72, 22);
            this.PortBox.TabIndex = 34;
            this.PortBox.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // SeedBox
            // 
            this.SeedBox.Location = new System.Drawing.Point(367, 19);
            this.SeedBox.Maximum = new decimal(new int[] {
            65325,
            0,
            0,
            0});
            this.SeedBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SeedBox.Name = "SeedBox";
            this.SeedBox.Size = new System.Drawing.Size(72, 22);
            this.SeedBox.TabIndex = 35;
            this.SeedBox.Value = new decimal(new int[] {
            1234,
            0,
            0,
            0});
            // 
            // AddressBox
            // 
            this.AddressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddressBox.Location = new System.Drawing.Point(89, 16);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(94, 26);
            this.AddressBox.TabIndex = 36;
            this.AddressBox.Text = "localhost";
            this.AddressBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MessagesChekBox
            // 
            this.MessagesChekBox.AutoSize = true;
            this.MessagesChekBox.Location = new System.Drawing.Point(446, 20);
            this.MessagesChekBox.Name = "MessagesChekBox";
            this.MessagesChekBox.Size = new System.Drawing.Size(94, 21);
            this.MessagesChekBox.TabIndex = 37;
            this.MessagesChekBox.Text = "Messages";
            this.MessagesChekBox.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 162);
            this.Controls.Add(this.MessagesChekBox);
            this.Controls.Add(this.AddressBox);
            this.Controls.Add(this.SeedBox);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClientBtn);
            this.Controls.Add(this.ServerBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WeightsBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ArrayBox);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PortBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeedBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ArrayBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WeightsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button ServerBtn;
        private System.Windows.Forms.Button ClientBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown PortBox;
        private System.Windows.Forms.NumericUpDown SeedBox;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.CheckBox MessagesChekBox;
    }
}

