
namespace LAB_11
{
    partial class Task2
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
            this.TextContainer = new System.Windows.Forms.TextBox();
            this.EncryptedPointsContainer = new System.Windows.Forms.TextBox();
            this.DecryptedTextContainer = new System.Windows.Forms.TextBox();
            this.PrivateKeysContainer = new System.Windows.Forms.TextBox();
            this.PublicKeysContainer = new System.Windows.Forms.TextBox();
            this.EncryptBtn = new System.Windows.Forms.Button();
            this.DecryptBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GenerateKeysBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextContainer
            // 
            this.TextContainer.Location = new System.Drawing.Point(13, 13);
            this.TextContainer.Multiline = true;
            this.TextContainer.Name = "TextContainer";
            this.TextContainer.Size = new System.Drawing.Size(210, 260);
            this.TextContainer.TabIndex = 0;
            // 
            // EncryptedPointsContainer
            // 
            this.EncryptedPointsContainer.Location = new System.Drawing.Point(264, 13);
            this.EncryptedPointsContainer.Multiline = true;
            this.EncryptedPointsContainer.Name = "EncryptedPointsContainer";
            this.EncryptedPointsContainer.ReadOnly = true;
            this.EncryptedPointsContainer.Size = new System.Drawing.Size(210, 260);
            this.EncryptedPointsContainer.TabIndex = 1;
            // 
            // DecryptedTextContainer
            // 
            this.DecryptedTextContainer.Location = new System.Drawing.Point(514, 13);
            this.DecryptedTextContainer.Multiline = true;
            this.DecryptedTextContainer.Name = "DecryptedTextContainer";
            this.DecryptedTextContainer.Size = new System.Drawing.Size(210, 260);
            this.DecryptedTextContainer.TabIndex = 2;
            // 
            // PrivateKeysContainer
            // 
            this.PrivateKeysContainer.Location = new System.Drawing.Point(10, 313);
            this.PrivateKeysContainer.Multiline = true;
            this.PrivateKeysContainer.Name = "PrivateKeysContainer";
            this.PrivateKeysContainer.ReadOnly = true;
            this.PrivateKeysContainer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PrivateKeysContainer.Size = new System.Drawing.Size(346, 120);
            this.PrivateKeysContainer.TabIndex = 3;
            // 
            // PublicKeysContainer
            // 
            this.PublicKeysContainer.Location = new System.Drawing.Point(378, 313);
            this.PublicKeysContainer.Multiline = true;
            this.PublicKeysContainer.Name = "PublicKeysContainer";
            this.PublicKeysContainer.ReadOnly = true;
            this.PublicKeysContainer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PublicKeysContainer.Size = new System.Drawing.Size(346, 120);
            this.PublicKeysContainer.TabIndex = 4;
            // 
            // EncryptBtn
            // 
            this.EncryptBtn.Location = new System.Drawing.Point(230, 13);
            this.EncryptBtn.Name = "EncryptBtn";
            this.EncryptBtn.Size = new System.Drawing.Size(28, 260);
            this.EncryptBtn.TabIndex = 5;
            this.EncryptBtn.Text = "> Encrypt >";
            this.EncryptBtn.UseVisualStyleBackColor = true;
            this.EncryptBtn.Click += new System.EventHandler(this.EncryptBtn_Click);
            // 
            // DecryptBtn
            // 
            this.DecryptBtn.Location = new System.Drawing.Point(480, 12);
            this.DecryptBtn.Name = "DecryptBtn";
            this.DecryptBtn.Size = new System.Drawing.Size(28, 260);
            this.DecryptBtn.TabIndex = 6;
            this.DecryptBtn.Text = "> Decrypt >";
            this.DecryptBtn.UseVisualStyleBackColor = true;
            this.DecryptBtn.Click += new System.EventHandler(this.DecryptBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Private Keys";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Public Keys";
            // 
            // GenerateKeysBtn
            // 
            this.GenerateKeysBtn.Location = new System.Drawing.Point(10, 443);
            this.GenerateKeysBtn.Name = "GenerateKeysBtn";
            this.GenerateKeysBtn.Size = new System.Drawing.Size(714, 25);
            this.GenerateKeysBtn.TabIndex = 11;
            this.GenerateKeysBtn.Text = "Generate Keys";
            this.GenerateKeysBtn.UseVisualStyleBackColor = true;
            this.GenerateKeysBtn.Click += new System.EventHandler(this.GenerateKeysBtn_Click);
            // 
            // Task2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 484);
            this.Controls.Add(this.GenerateKeysBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DecryptBtn);
            this.Controls.Add(this.EncryptBtn);
            this.Controls.Add(this.PublicKeysContainer);
            this.Controls.Add(this.PrivateKeysContainer);
            this.Controls.Add(this.DecryptedTextContainer);
            this.Controls.Add(this.EncryptedPointsContainer);
            this.Controls.Add(this.TextContainer);
            this.Name = "Task2";
            this.Text = "Task2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextContainer;
        private System.Windows.Forms.TextBox EncryptedPointsContainer;
        private System.Windows.Forms.TextBox DecryptedTextContainer;
        private System.Windows.Forms.TextBox PrivateKeysContainer;
        private System.Windows.Forms.TextBox PublicKeysContainer;
        private System.Windows.Forms.Button EncryptBtn;
        private System.Windows.Forms.Button DecryptBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GenerateKeysBtn;
    }
}