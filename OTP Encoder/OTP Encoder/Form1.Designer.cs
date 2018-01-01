namespace OTP_Encoder
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.Encrypt_File = new System.Windows.Forms.Button();
            this.Decrypt_File = new System.Windows.Forms.Button();
            this.Text_Box = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Encrypt_File
            // 
            this.Encrypt_File.Location = new System.Drawing.Point(12, 23);
            this.Encrypt_File.Name = "Encrypt_File";
            this.Encrypt_File.Size = new System.Drawing.Size(75, 23);
            this.Encrypt_File.TabIndex = 1;
            this.Encrypt_File.Text = "Encrypt File";
            this.Encrypt_File.UseVisualStyleBackColor = true;
            this.Encrypt_File.Click += new System.EventHandler(this.Encrypt_File_Click);
            // 
            // Decrypt_File
            // 
            this.Decrypt_File.Location = new System.Drawing.Point(12, 66);
            this.Decrypt_File.Name = "Decrypt_File";
            this.Decrypt_File.Size = new System.Drawing.Size(75, 23);
            this.Decrypt_File.TabIndex = 2;
            this.Decrypt_File.Text = "Decrypt File";
            this.Decrypt_File.UseVisualStyleBackColor = true;
            this.Decrypt_File.Click += new System.EventHandler(this.Decrypt_File_Click);
            // 
            // Text_Box
            // 
            this.Text_Box.Location = new System.Drawing.Point(109, 23);
            this.Text_Box.Name = "Text_Box";
            this.Text_Box.Size = new System.Drawing.Size(355, 209);
            this.Text_Box.TabIndex = 3;
            this.Text_Box.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 247);
            this.Controls.Add(this.Text_Box);
            this.Controls.Add(this.Decrypt_File);
            this.Controls.Add(this.Encrypt_File);
            this.Name = "Form1";
            this.Text = "OTP Encryptor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Encrypt_File;
        private System.Windows.Forms.Button Decrypt_File;
        private System.Windows.Forms.RichTextBox Text_Box;
    }
}

