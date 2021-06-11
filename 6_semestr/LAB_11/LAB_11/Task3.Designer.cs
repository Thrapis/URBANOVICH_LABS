
namespace LAB_11
{
    partial class Task3
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
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.StatusPic = new System.Windows.Forms.PictureBox();
            this.VerifyEDS = new System.Windows.Forms.Button();
            this.GetEDS = new System.Windows.Forms.Button();
            this.EDSText = new System.Windows.Forms.TextBox();
            this.OriginText = new System.Windows.Forms.TextBox();
            this.GenerateKeysBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PublicKeysContainer = new System.Windows.Forms.TextBox();
            this.PrivateKeysContainer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPic)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(735, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(742, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "ЕСDSA EDS";
            // 
            // StatusPic
            // 
            this.StatusPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusPic.Location = new System.Drawing.Point(735, 104);
            this.StatusPic.Name = "StatusPic";
            this.StatusPic.Size = new System.Drawing.Size(100, 100);
            this.StatusPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.StatusPic.TabIndex = 20;
            this.StatusPic.TabStop = false;
            // 
            // VerifyEDS
            // 
            this.VerifyEDS.Location = new System.Drawing.Point(627, 13);
            this.VerifyEDS.Name = "VerifyEDS";
            this.VerifyEDS.Size = new System.Drawing.Size(75, 277);
            this.VerifyEDS.TabIndex = 19;
            this.VerifyEDS.Text = "Verify EDS";
            this.VerifyEDS.UseVisualStyleBackColor = true;
            this.VerifyEDS.Click += new System.EventHandler(this.VerifyEDS_Click);
            // 
            // GetEDS
            // 
            this.GetEDS.Location = new System.Drawing.Point(279, 13);
            this.GetEDS.Name = "GetEDS";
            this.GetEDS.Size = new System.Drawing.Size(75, 277);
            this.GetEDS.TabIndex = 18;
            this.GetEDS.Text = "Get EDS";
            this.GetEDS.UseVisualStyleBackColor = true;
            this.GetEDS.Click += new System.EventHandler(this.GetEDS_Click);
            // 
            // EDSText
            // 
            this.EDSText.Location = new System.Drawing.Point(360, 12);
            this.EDSText.MaxLength = 2000000;
            this.EDSText.Multiline = true;
            this.EDSText.Name = "EDSText";
            this.EDSText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EDSText.Size = new System.Drawing.Size(261, 278);
            this.EDSText.TabIndex = 17;
            // 
            // OriginText
            // 
            this.OriginText.Location = new System.Drawing.Point(12, 12);
            this.OriginText.MaxLength = 2000000;
            this.OriginText.Multiline = true;
            this.OriginText.Name = "OriginText";
            this.OriginText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OriginText.Size = new System.Drawing.Size(261, 278);
            this.OriginText.TabIndex = 16;
            this.OriginText.DoubleClick += new System.EventHandler(this.OriginText_DoubleClick);
            // 
            // GenerateKeysBtn
            // 
            this.GenerateKeysBtn.Location = new System.Drawing.Point(12, 453);
            this.GenerateKeysBtn.Name = "GenerateKeysBtn";
            this.GenerateKeysBtn.Size = new System.Drawing.Size(690, 25);
            this.GenerateKeysBtn.TabIndex = 36;
            this.GenerateKeysBtn.Text = "Generate Keys";
            this.GenerateKeysBtn.UseVisualStyleBackColor = true;
            this.GenerateKeysBtn.Click += new System.EventHandler(this.GenerateKeysBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Public Keys";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 34;
            this.label1.Text = "Private Keys";
            // 
            // PublicKeysContainer
            // 
            this.PublicKeysContainer.Location = new System.Drawing.Point(360, 327);
            this.PublicKeysContainer.Multiline = true;
            this.PublicKeysContainer.Name = "PublicKeysContainer";
            this.PublicKeysContainer.ReadOnly = true;
            this.PublicKeysContainer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PublicKeysContainer.Size = new System.Drawing.Size(342, 120);
            this.PublicKeysContainer.TabIndex = 33;
            // 
            // PrivateKeysContainer
            // 
            this.PrivateKeysContainer.Location = new System.Drawing.Point(12, 327);
            this.PrivateKeysContainer.Multiline = true;
            this.PrivateKeysContainer.Name = "PrivateKeysContainer";
            this.PrivateKeysContainer.ReadOnly = true;
            this.PrivateKeysContainer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PrivateKeysContainer.Size = new System.Drawing.Size(342, 120);
            this.PrivateKeysContainer.TabIndex = 32;
            // 
            // Task3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 492);
            this.Controls.Add(this.GenerateKeysBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PublicKeysContainer);
            this.Controls.Add(this.PrivateKeysContainer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StatusPic);
            this.Controls.Add(this.VerifyEDS);
            this.Controls.Add(this.GetEDS);
            this.Controls.Add(this.EDSText);
            this.Controls.Add(this.OriginText);
            this.Name = "Task3";
            this.Text = "Task3";
            ((System.ComponentModel.ISupportInitialize)(this.StatusPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox StatusPic;
        private System.Windows.Forms.Button VerifyEDS;
        private System.Windows.Forms.Button GetEDS;
        private System.Windows.Forms.TextBox EDSText;
        private System.Windows.Forms.TextBox OriginText;
        private System.Windows.Forms.Button GenerateKeysBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PublicKeysContainer;
        private System.Windows.Forms.TextBox PrivateKeysContainer;
    }
}