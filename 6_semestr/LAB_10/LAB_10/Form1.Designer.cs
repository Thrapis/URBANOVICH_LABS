
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
            this.OriginText = new System.Windows.Forms.TextBox();
            this.EDSText = new System.Windows.Forms.TextBox();
            this.GetEDS = new System.Windows.Forms.Button();
            this.VerifyEDS = new System.Windows.Forms.Button();
            this.StatusPic = new System.Windows.Forms.PictureBox();
            this.OpenKeys = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PrivateKeys = new System.Windows.Forms.TextBox();
            this.FormatO = new System.Windows.Forms.Label();
            this.FormatP = new System.Windows.Forms.Label();
            this.CopyPK = new System.Windows.Forms.Button();
            this.PastePK = new System.Windows.Forms.Button();
            this.EDSTypes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPic)).BeginInit();
            this.SuspendLayout();
            // 
            // OriginText
            // 
            this.OriginText.Location = new System.Drawing.Point(12, 12);
            this.OriginText.MaxLength = 2000000;
            this.OriginText.Multiline = true;
            this.OriginText.Name = "OriginText";
            this.OriginText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OriginText.Size = new System.Drawing.Size(261, 278);
            this.OriginText.TabIndex = 0;
            this.OriginText.DoubleClick += new System.EventHandler(this.OriginText_DoubleClick);
            // 
            // EDSText
            // 
            this.EDSText.Location = new System.Drawing.Point(360, 12);
            this.EDSText.MaxLength = 2000000;
            this.EDSText.Multiline = true;
            this.EDSText.Name = "EDSText";
            this.EDSText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EDSText.Size = new System.Drawing.Size(261, 278);
            this.EDSText.TabIndex = 1;
            this.EDSText.DoubleClick += new System.EventHandler(this.EDSText_DoubleClick);
            // 
            // GetEDS
            // 
            this.GetEDS.Location = new System.Drawing.Point(279, 13);
            this.GetEDS.Name = "GetEDS";
            this.GetEDS.Size = new System.Drawing.Size(75, 277);
            this.GetEDS.TabIndex = 2;
            this.GetEDS.Text = "Get EDS";
            this.GetEDS.UseVisualStyleBackColor = true;
            this.GetEDS.Click += new System.EventHandler(this.GetEDS_Click);
            // 
            // VerifyEDS
            // 
            this.VerifyEDS.Location = new System.Drawing.Point(627, 13);
            this.VerifyEDS.Name = "VerifyEDS";
            this.VerifyEDS.Size = new System.Drawing.Size(75, 277);
            this.VerifyEDS.TabIndex = 3;
            this.VerifyEDS.Text = "Verify EDS";
            this.VerifyEDS.UseVisualStyleBackColor = true;
            this.VerifyEDS.Click += new System.EventHandler(this.VerifyEDS_Click);
            // 
            // StatusPic
            // 
            this.StatusPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusPic.Location = new System.Drawing.Point(735, 104);
            this.StatusPic.Name = "StatusPic";
            this.StatusPic.Size = new System.Drawing.Size(100, 100);
            this.StatusPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.StatusPic.TabIndex = 4;
            this.StatusPic.TabStop = false;
            // 
            // OpenKeys
            // 
            this.OpenKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.OpenKeys.Location = new System.Drawing.Point(433, 304);
            this.OpenKeys.Name = "OpenKeys";
            this.OpenKeys.Size = new System.Drawing.Size(188, 26);
            this.OpenKeys.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "PKeys";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(360, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "OKeys";
            // 
            // PrivateKeys
            // 
            this.PrivateKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.PrivateKeys.Location = new System.Drawing.Point(85, 307);
            this.PrivateKeys.Name = "PrivateKeys";
            this.PrivateKeys.Size = new System.Drawing.Size(188, 26);
            this.PrivateKeys.TabIndex = 7;
            // 
            // FormatO
            // 
            this.FormatO.AutoSize = true;
            this.FormatO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormatO.Location = new System.Drawing.Point(429, 344);
            this.FormatO.Name = "FormatO";
            this.FormatO.Size = new System.Drawing.Size(81, 20);
            this.FormatO.TabIndex = 9;
            this.FormatO.Text = "________";
            // 
            // FormatP
            // 
            this.FormatP.AutoSize = true;
            this.FormatP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormatP.Location = new System.Drawing.Point(81, 344);
            this.FormatP.Name = "FormatP";
            this.FormatP.Size = new System.Drawing.Size(81, 20);
            this.FormatP.TabIndex = 10;
            this.FormatP.Text = "________";
            // 
            // CopyPK
            // 
            this.CopyPK.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.CopyPK.Location = new System.Drawing.Point(204, 341);
            this.CopyPK.Name = "CopyPK";
            this.CopyPK.Size = new System.Drawing.Size(69, 23);
            this.CopyPK.TabIndex = 11;
            this.CopyPK.Text = "Copy OK";
            this.CopyPK.UseVisualStyleBackColor = true;
            this.CopyPK.Click += new System.EventHandler(this.CopyPK_Click);
            // 
            // PastePK
            // 
            this.PastePK.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.PastePK.Location = new System.Drawing.Point(552, 341);
            this.PastePK.Name = "PastePK";
            this.PastePK.Size = new System.Drawing.Size(69, 23);
            this.PastePK.TabIndex = 12;
            this.PastePK.Text = "Paste OK";
            this.PastePK.UseVisualStyleBackColor = true;
            this.PastePK.Click += new System.EventHandler(this.PastePK_Click);
            // 
            // EDSTypes
            // 
            this.EDSTypes.FormattingEnabled = true;
            this.EDSTypes.Location = new System.Drawing.Point(735, 337);
            this.EDSTypes.Name = "EDSTypes";
            this.EDSTypes.Size = new System.Drawing.Size(121, 24);
            this.EDSTypes.TabIndex = 13;
            this.EDSTypes.SelectedIndexChanged += new System.EventHandler(this.EDSTypes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(731, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "EDS Type";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(735, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 373);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EDSTypes);
            this.Controls.Add(this.PastePK);
            this.Controls.Add(this.CopyPK);
            this.Controls.Add(this.FormatP);
            this.Controls.Add(this.FormatO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PrivateKeys);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OpenKeys);
            this.Controls.Add(this.StatusPic);
            this.Controls.Add(this.VerifyEDS);
            this.Controls.Add(this.GetEDS);
            this.Controls.Add(this.EDSText);
            this.Controls.Add(this.OriginText);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.StatusPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OriginText;
        private System.Windows.Forms.TextBox EDSText;
        private System.Windows.Forms.Button GetEDS;
        private System.Windows.Forms.Button VerifyEDS;
        private System.Windows.Forms.PictureBox StatusPic;
        private System.Windows.Forms.TextBox OpenKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PrivateKeys;
        private System.Windows.Forms.Label FormatO;
        private System.Windows.Forms.Label FormatP;
        private System.Windows.Forms.Button CopyPK;
        private System.Windows.Forms.Button PastePK;
        private System.Windows.Forms.ComboBox EDSTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

