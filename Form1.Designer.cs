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
            SuspendLayout();
            // 
            // save_Derypt_file
            // 
            save_Derypt_file.Location = new Point(570, 39);
            save_Derypt_file.Name = "save_Derypt_file";
            save_Derypt_file.Size = new Size(112, 45);
            save_Derypt_file.TabIndex = 1;
            save_Derypt_file.Text = "Save Decrypted File";
            save_Derypt_file.UseVisualStyleBackColor = true;
            save_Derypt_file.Click += save_file_Click;
            // 
            // browse
            // 
            browse.Location = new Point(400, 44);
            browse.Name = "browse";
            browse.Size = new Size(75, 34);
            browse.TabIndex = 2;
            browse.Text = "Browse";
            browse.UseVisualStyleBackColor = true;
            browse.Click += browse_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(899, 137);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // save_iv
            // 
            save_iv.Location = new Point(945, 44);
            save_iv.Name = "save_iv";
            save_iv.Size = new Size(75, 34);
            save_iv.TabIndex = 4;
            save_iv.Text = "Save IV";
            save_iv.UseVisualStyleBackColor = true;
            save_iv.Click += save_iv_Click;
            // 
            // save_encrypt_file
            // 
            save_encrypt_file.Location = new Point(733, 39);
            save_encrypt_file.Name = "save_encrypt_file";
            save_encrypt_file.Size = new Size(138, 45);
            save_encrypt_file.TabIndex = 5;
            save_encrypt_file.Text = "Save Encrypted File As Text File";
            save_encrypt_file.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 634);
            Controls.Add(save_encrypt_file);
            Controls.Add(save_iv);
            Controls.Add(comboBox1);
            Controls.Add(browse);
            Controls.Add(save_Derypt_file);
            Name = "Form1";
            Text = "FIle Enctyption";
            ResumeLayout(false);
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Button save_Derypt_file;
        private Button browse;
        private SaveFileDialog saveFileDialog1;
        private ComboBox comboBox1;
        private Button save_iv;
        private Button save_encrypt_file;
    }
}
