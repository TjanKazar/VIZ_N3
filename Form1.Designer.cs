namespace VIZ_N3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            save_Derypt_file = new Button();
            browse = new Button();
            saveFileDialog1 = new SaveFileDialog();
            comboBox1 = new ComboBox();
            save_iv = new Button();
            save_encrypt_file = new Button();
            label1 = new Label();
            encryption_box = new ComboBox();
            label2 = new Label();
            browse_decrypt = new Button();
            decrypt_key = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            browseRSA = new Button();
            saveRSA_Decrypted = new Button();
            saveRSA_Encrypted = new Button();
            button2 = new Button();
            save_rsa_key = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // save_Derypt_file
            // 
            save_Derypt_file.Location = new Point(610, 18);
            save_Derypt_file.Name = "save_Derypt_file";
            save_Derypt_file.Size = new Size(112, 45);
            save_Derypt_file.TabIndex = 1;
            save_Derypt_file.Text = "Save AES Decrypted File";
            save_Derypt_file.UseVisualStyleBackColor = true;
            save_Derypt_file.Click += save_file_Click;
            // 
            // browse
            // 
            browse.Location = new Point(12, 75);
            browse.Name = "browse";
            browse.Size = new Size(100, 51);
            browse.TabIndex = 2;
            browse.Text = "Browse file to Encrypt";
            browse.UseVisualStyleBackColor = true;
            browse.Click += browse_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1005, 340);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // save_iv
            // 
            save_iv.Location = new Point(872, 18);
            save_iv.Name = "save_iv";
            save_iv.Size = new Size(75, 45);
            save_iv.TabIndex = 4;
            save_iv.Text = "Save IV";
            save_iv.UseVisualStyleBackColor = true;
            save_iv.Click += save_iv_Click;
            // 
            // save_encrypt_file
            // 
            save_encrypt_file.Location = new Point(728, 18);
            save_encrypt_file.Name = "save_encrypt_file";
            save_encrypt_file.Size = new Size(138, 45);
            save_encrypt_file.TabIndex = 5;
            save_encrypt_file.Text = "Save AES Encrypted File As Text File";
            save_encrypt_file.UseVisualStyleBackColor = true;
            save_encrypt_file.Click += save_encrypt_file_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1025, 322);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 6;
            label1.Text = "Select key size:";
            // 
            // encryption_box
            // 
            encryption_box.FormattingEnabled = true;
            encryption_box.Location = new Point(1005, 265);
            encryption_box.Name = "encryption_box";
            encryption_box.Size = new Size(121, 23);
            encryption_box.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1005, 247);
            label2.Name = "label2";
            label2.Size = new Size(127, 15);
            label2.TabIndex = 8;
            label2.Text = "Select enctyption type:";
            // 
            // browse_decrypt
            // 
            browse_decrypt.Location = new Point(12, 132);
            browse_decrypt.Name = "browse_decrypt";
            browse_decrypt.Size = new Size(100, 51);
            browse_decrypt.TabIndex = 9;
            browse_decrypt.Text = "Browse file to Decrypt";
            browse_decrypt.UseVisualStyleBackColor = true;
            browse_decrypt.Click += browse_decrypt_Click;
            // 
            // decrypt_key
            // 
            decrypt_key.Location = new Point(12, 189);
            decrypt_key.Name = "decrypt_key";
            decrypt_key.Size = new Size(100, 51);
            decrypt_key.TabIndex = 10;
            decrypt_key.Text = "Enter Decryption key";
            decrypt_key.UseVisualStyleBackColor = true;
            decrypt_key.Click += decrypt_key_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 296);
            label3.Name = "label3";
            label3.Size = new Size(967, 15);
            label3.TabIndex = 11;
            label3.Text = "________________________________________________________________________________________________________________________________________________________________________________________________";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 35F);
            label4.Location = new Point(118, 1);
            label4.Name = "label4";
            label4.Size = new Size(341, 62);
            label4.TabIndex = 12;
            label4.Text = "AES Encryption";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 35F);
            label5.Location = new Point(118, 312);
            label5.Name = "label5";
            label5.Size = new Size(345, 62);
            label5.TabIndex = 13;
            label5.Text = "RSA Encryption";
            // 
            // button1
            // 
            button1.Location = new Point(953, 21);
            button1.Name = "button1";
            button1.Size = new Size(100, 42);
            button1.TabIndex = 14;
            button1.Text = "Save Encryption key";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // browseRSA
            // 
            browseRSA.Location = new Point(12, 398);
            browseRSA.Name = "browseRSA";
            browseRSA.Size = new Size(100, 51);
            browseRSA.TabIndex = 15;
            browseRSA.Text = "Browse file to encrypt";
            browseRSA.UseVisualStyleBackColor = true;
            browseRSA.Click += browseRSA_Click;
            // 
            // saveRSA_Decrypted
            // 
            saveRSA_Decrypted.Location = new Point(469, 336);
            saveRSA_Decrypted.Name = "saveRSA_Decrypted";
            saveRSA_Decrypted.Size = new Size(112, 45);
            saveRSA_Decrypted.TabIndex = 16;
            saveRSA_Decrypted.Text = "Save RSA Decrypted File";
            saveRSA_Decrypted.UseVisualStyleBackColor = true;
            saveRSA_Decrypted.Click += saveRSA_Decrypted_Click;
            // 
            // saveRSA_Encrypted
            // 
            saveRSA_Encrypted.Location = new Point(587, 336);
            saveRSA_Encrypted.Name = "saveRSA_Encrypted";
            saveRSA_Encrypted.Size = new Size(138, 45);
            saveRSA_Encrypted.TabIndex = 17;
            saveRSA_Encrypted.Text = "Save RSA Encrypted File";
            saveRSA_Encrypted.UseVisualStyleBackColor = true;
            saveRSA_Encrypted.Click += saveRSA_Encrypted_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1156, 134);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 18;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // save_rsa_key
            // 
            save_rsa_key.Location = new Point(857, 336);
            save_rsa_key.Name = "save_rsa_key";
            save_rsa_key.Size = new Size(122, 45);
            save_rsa_key.TabIndex = 19;
            save_rsa_key.Text = "Save RSA Public Key";
            save_rsa_key.UseVisualStyleBackColor = true;
            save_rsa_key.Click += save_rsa_key_Click;
            // 
            // button3
            // 
            button3.Location = new Point(730, 336);
            button3.Name = "button3";
            button3.Size = new Size(121, 45);
            button3.TabIndex = 20;
            button3.Text = "Save RSA Private Key";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 634);
            Controls.Add(button3);
            Controls.Add(save_rsa_key);
            Controls.Add(button2);
            Controls.Add(saveRSA_Encrypted);
            Controls.Add(saveRSA_Decrypted);
            Controls.Add(browseRSA);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(decrypt_key);
            Controls.Add(browse_decrypt);
            Controls.Add(label2);
            Controls.Add(encryption_box);
            Controls.Add(label1);
            Controls.Add(save_encrypt_file);
            Controls.Add(save_iv);
            Controls.Add(comboBox1);
            Controls.Add(browse);
            Controls.Add(save_Derypt_file);
            Name = "Form1";
            Text = "FIle Enctyption";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Button save_Derypt_file;
        private Button browse;
        private SaveFileDialog saveFileDialog1;
        private ComboBox comboBox1;
        private Button save_iv;
        private Button save_encrypt_file;
        private Label label1;
        private ComboBox encryption_box;
        private Label label2;
        private Button browse_decrypt;
        private Button decrypt_key;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button browseRSA;
        private Button saveRSA_Decrypted;
        private Button saveRSA_Encrypted;
        private Button button2;
        private Button save_rsa_key;
        private Button button3;
    }
}
