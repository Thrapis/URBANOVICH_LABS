
namespace LAB_8
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
            this.textBoxNow = new System.Windows.Forms.TextBox();
            this.buttonLast = new System.Windows.Forms.Button();
            this.richTextBoxB1 = new System.Windows.Forms.RichTextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.richTextBoxW2 = new System.Windows.Forms.RichTextBox();
            this.richTextBoxW1 = new System.Windows.Forms.RichTextBox();
            this.buttonGen = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxNow
            // 
            this.textBoxNow.Location = new System.Drawing.Point(480, 274);
            this.textBoxNow.Name = "textBoxNow";
            this.textBoxNow.ReadOnly = true;
            this.textBoxNow.Size = new System.Drawing.Size(138, 22);
            this.textBoxNow.TabIndex = 19;
            // 
            // buttonLast
            // 
            this.buttonLast.Location = new System.Drawing.Point(283, 273);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(119, 24);
            this.buttonLast.TabIndex = 18;
            this.buttonLast.Text = "To The End";
            this.buttonLast.UseVisualStyleBackColor = true;
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // richTextBoxB1
            // 
            this.richTextBoxB1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxB1.Location = new System.Drawing.Point(12, 307);
            this.richTextBoxB1.Name = "richTextBoxB1";
            this.richTextBoxB1.ReadOnly = true;
            this.richTextBoxB1.Size = new System.Drawing.Size(606, 194);
            this.richTextBoxB1.TabIndex = 17;
            this.richTextBoxB1.Text = "";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(174, 273);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(103, 24);
            this.buttonBack.TabIndex = 16;
            this.buttonBack.Text = "Next Step";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(57, 274);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.ReadOnly = true;
            this.textBoxK.Size = new System.Drawing.Size(100, 22);
            this.textBoxK.TabIndex = 15;
            // 
            // textBoxM
            // 
            this.textBoxM.Location = new System.Drawing.Point(57, 233);
            this.textBoxM.Name = "textBoxM";
            this.textBoxM.ReadOnly = true;
            this.textBoxM.Size = new System.Drawing.Size(561, 22);
            this.textBoxM.TabIndex = 14;
            // 
            // richTextBoxW2
            // 
            this.richTextBoxW2.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxW2.Location = new System.Drawing.Point(318, 42);
            this.richTextBoxW2.Name = "richTextBoxW2";
            this.richTextBoxW2.ReadOnly = true;
            this.richTextBoxW2.Size = new System.Drawing.Size(300, 185);
            this.richTextBoxW2.TabIndex = 13;
            this.richTextBoxW2.Text = "";
            // 
            // richTextBoxW1
            // 
            this.richTextBoxW1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxW1.Location = new System.Drawing.Point(12, 41);
            this.richTextBoxW1.Name = "richTextBoxW1";
            this.richTextBoxW1.ReadOnly = true;
            this.richTextBoxW1.Size = new System.Drawing.Size(300, 186);
            this.richTextBoxW1.TabIndex = 12;
            this.richTextBoxW1.Text = "";
            // 
            // buttonGen
            // 
            this.buttonGen.Location = new System.Drawing.Point(519, 12);
            this.buttonGen.Name = "buttonGen";
            this.buttonGen.Size = new System.Drawing.Size(99, 24);
            this.buttonGen.TabIndex = 11;
            this.buttonGen.Text = "Generate";
            this.buttonGen.UseVisualStyleBackColor = true;
            this.buttonGen.Click += new System.EventHandler(this.buttonGen_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(12, 12);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(501, 22);
            this.textBoxInput.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Msg: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(420, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Round:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Pos: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 514);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNow);
            this.Controls.Add(this.buttonLast);
            this.Controls.Add(this.richTextBoxB1);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.textBoxK);
            this.Controls.Add(this.textBoxM);
            this.Controls.Add(this.richTextBoxW2);
            this.Controls.Add(this.richTextBoxW1);
            this.Controls.Add(this.buttonGen);
            this.Controls.Add(this.textBoxInput);
            this.Name = "Form1";
            this.Text = "BWT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNow;
        private System.Windows.Forms.Button buttonLast;
        private System.Windows.Forms.RichTextBox richTextBoxB1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.TextBox textBoxM;
        private System.Windows.Forms.RichTextBox richTextBoxW2;
        private System.Windows.Forms.RichTextBox richTextBoxW1;
        private System.Windows.Forms.Button buttonGen;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

