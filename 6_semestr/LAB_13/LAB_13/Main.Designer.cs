
namespace LAB_13
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.OriginDocumentBox = new System.Windows.Forms.TextBox();
            this.TextToEncodeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EncodedDocumentBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.EncodeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.DecodeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TextStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DecodedTextBox = new System.Windows.Forms.TextBox();
            this.KeyBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeyBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OriginDocumentBox
            // 
            this.OriginDocumentBox.BackColor = System.Drawing.SystemColors.Window;
            this.OriginDocumentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.OriginDocumentBox.Location = new System.Drawing.Point(15, 62);
            this.OriginDocumentBox.Multiline = true;
            this.OriginDocumentBox.Name = "OriginDocumentBox";
            this.OriginDocumentBox.ReadOnly = true;
            this.OriginDocumentBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OriginDocumentBox.Size = new System.Drawing.Size(313, 164);
            this.OriginDocumentBox.TabIndex = 2;
            this.OriginDocumentBox.DoubleClick += new System.EventHandler(this.OriginDocumentBox_DoubleClick);
            // 
            // TextToEncodeBox
            // 
            this.TextToEncodeBox.BackColor = System.Drawing.SystemColors.Window;
            this.TextToEncodeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TextToEncodeBox.Location = new System.Drawing.Point(15, 267);
            this.TextToEncodeBox.Multiline = true;
            this.TextToEncodeBox.Name = "TextToEncodeBox";
            this.TextToEncodeBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextToEncodeBox.Size = new System.Drawing.Size(313, 164);
            this.TextToEncodeBox.TabIndex = 3;
            this.TextToEncodeBox.TextChanged += new System.EventHandler(this.TextToEncodeBox_TextChanged);
            this.TextToEncodeBox.DoubleClick += new System.EventHandler(this.TextToEncodeBox_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(14, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Origin Document";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(356, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Encoded Document";
            // 
            // EncodedDocumentBox
            // 
            this.EncodedDocumentBox.BackColor = System.Drawing.SystemColors.Window;
            this.EncodedDocumentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.EncodedDocumentBox.Location = new System.Drawing.Point(357, 62);
            this.EncodedDocumentBox.Multiline = true;
            this.EncodedDocumentBox.Name = "EncodedDocumentBox";
            this.EncodedDocumentBox.ReadOnly = true;
            this.EncodedDocumentBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EncodedDocumentBox.Size = new System.Drawing.Size(313, 164);
            this.EncodedDocumentBox.TabIndex = 5;
            this.EncodedDocumentBox.DoubleClick += new System.EventHandler(this.EncodedDocumentBox_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EncodeBtn,
            this.DecodeBtn,
            this.ClearBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(685, 28);
            this.menuStrip1.TabIndex = 7;
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
            // ClearBtn
            // 
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(57, 24);
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.TextStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(685, 26);
            this.statusStrip1.TabIndex = 8;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(21, 20);
            this.StatusLabel.Text = "   ";
            // 
            // TextStatus
            // 
            this.TextStatus.Name = "TextStatus";
            this.TextStatus.Size = new System.Drawing.Size(21, 20);
            this.TextStatus.Text = "   ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(14, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Text To Encode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(356, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Decoded Text";
            // 
            // DecodedTextBox
            // 
            this.DecodedTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.DecodedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DecodedTextBox.Location = new System.Drawing.Point(357, 267);
            this.DecodedTextBox.Multiline = true;
            this.DecodedTextBox.Name = "DecodedTextBox";
            this.DecodedTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DecodedTextBox.Size = new System.Drawing.Size(313, 164);
            this.DecodedTextBox.TabIndex = 10;
            this.DecodedTextBox.DoubleClick += new System.EventHandler(this.DecodedTextBox_DoubleClick);
            // 
            // KeyBox
            // 
            this.KeyBox.Location = new System.Drawing.Point(593, 235);
            this.KeyBox.Maximum = new decimal(new int[] {
            -1963639296,
            289,
            0,
            0});
            this.KeyBox.Name = "KeyBox";
            this.KeyBox.Size = new System.Drawing.Size(77, 22);
            this.KeyBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label5.Location = new System.Drawing.Point(506, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Key (Bytes)";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 471);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.KeyBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DecodedTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EncodedDocumentBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextToEncodeBox);
            this.Controls.Add(this.OriginDocumentBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "MS Word Stego";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeyBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox OriginDocumentBox;
        private System.Windows.Forms.TextBox TextToEncodeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EncodedDocumentBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem EncodeBtn;
        private System.Windows.Forms.ToolStripMenuItem DecodeBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DecodedTextBox;
        private System.Windows.Forms.ToolStripStatusLabel TextStatus;
        private System.Windows.Forms.ToolStripMenuItem ClearBtn;
        private System.Windows.Forms.NumericUpDown KeyBox;
        private System.Windows.Forms.Label label5;
    }
}

