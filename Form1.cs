using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace VIZ_N3
{
    public partial class Form1 : Form
    {
        public int keysize;
        public byte[] fileBytes;
        public byte[] aesBytes;
        public string fileType;
        public byte[] aesKey;
        public byte[] iv;
        public byte[] decrypted;


        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("key size:");
            comboBox1.Items.Add("128 bytes");
            comboBox1.Items.Add("192 bytes");
            comboBox1.Items.Add("256 bytes");
            comboBox1.Items.Add("1024 bytes");
            comboBox1.Items.Add("2048 bytes");

            encryption_box.Items.Add("AES");
            encryption_box.Items.Add("RSA");
            save_Derypt_file.Enabled = false;

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "128 bytes")
            {
                if (encryption_box.SelectedItem == "RSA")
                    comboBox1.SelectedItem = "key size:";
                else
                    keysize = 128;
            }
            else if (comboBox1.SelectedItem == "192 bytes")
            {
                if (encryption_box.SelectedItem == "RSA")
                    comboBox1.SelectedItem = "key size:";
                else
                    keysize = 192;
            }
            else if (comboBox1.SelectedItem == "256 bytes")
            {
                if (encryption_box.SelectedItem == "RSA")
                    comboBox1.SelectedItem = "key size:";
                else
                    keysize = 256;

            }
            else if (comboBox1.SelectedItem == "1024 bytes")
            {
                if (encryption_box.SelectedItem == "AES")
                    comboBox1.SelectedItem = "key size:";
                else
                    keysize = 1024;

            }
            else if (comboBox1.SelectedItem == "2048 bytes")
            {
                if (encryption_box.SelectedItem == "AES")
                    comboBox1.SelectedItem = "key size:";
                else
                    keysize = 2048;
            }
            if (comboBox1.SelectedItem == "key size:")
                save_Derypt_file.Enabled = false;
            else
                save_Derypt_file.Enabled = true;
        }
        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            DialogResult userClickedOK = openFileDialog1.ShowDialog();


            if (userClickedOK == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                fileBytes = File.ReadAllBytes(filePath);
                string fileString = Encoding.UTF8.GetString(fileBytes);
                Console.WriteLine(filePath);
                fileType = viz3.FileTypeFromPath(filePath);
                Console.WriteLine(fileType);
            }
           
            aesBytes = viz3.EncryptAes(fileBytes, out aesKey,out iv, keysize);
            foreach (byte b in aesKey)
            {
                Console.WriteLine(b);
            }
            

        }
        private void save_iv_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = "test.txt";

            DialogResult userClickedOK = saveFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                File.WriteAllBytes(filePath, iv);
                MessageBox.Show("File saved successfully.");
            }
        }
        private void save_file_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = $"testtest123{fileType}";

            DialogResult userClickedOK = saveFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                decrypted = viz3.DecryptAes(aesBytes, aesKey, iv, keysize);

                int fileSize = decrypted.Length;
                byte[] noPadding = viz3.AdjustByteArraySize(decrypted, fileSize);

                File.WriteAllBytes(filePath, decrypted);
                MessageBox.Show("File saved successfully.");
            }
        }
        private void save_encrypt_file_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = $"testtest123.txt";

            DialogResult userClickedOK = saveFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                File.WriteAllBytes(filePath, aesBytes);
                MessageBox.Show("File saved successfully.");
            }
        }
    }
}
