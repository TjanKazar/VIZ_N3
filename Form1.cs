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

        //AES vars
        public byte[] fileBytes;
        public byte[] aesKey;
        public byte[] iv;
        public string fileType;
        public byte[] aesBytes;
        public byte[] decrypted;

        //RSA vars
        public string RSAPublicKey;
        public string RSAPrivateKey;
        public byte[] rsaEncrypted;
        public byte[] rsaFileBytes;

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

            viz3.RSAGetKeys(out RSAPublicKey, out RSAPrivateKey, keysize);
        }

        // AES part naloge

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
                Console.WriteLine(filePath);
                fileType = viz3.FileTypeFromPath(filePath);
                Console.WriteLine(fileType);
            }
            aesBytes = viz3.EncryptAes(fileBytes, out aesKey, out iv, keysize);
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
            saveFileDialog1.FileName = $"Decrypted{fileType}";

            DialogResult userClickedOK = saveFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                decrypted = viz3.DecryptAes(aesBytes, aesKey, iv, keysize);

                File.WriteAllBytes(filePath, decrypted);
                MessageBox.Show("File saved successfully.");
            }
        }
        private void save_encrypt_file_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = $"Encrypted.txt";


            DialogResult userClickedOK = saveFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                File.WriteAllBytes(filePath, aesBytes);
                MessageBox.Show("File saved successfully.");
            }
        }
        private void browse_decrypt_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            DialogResult userClickedOK = openFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                fileBytes = File.ReadAllBytes(filePath);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = $"decrypt_key.txt";

            DialogResult userClickedOK = saveFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                File.WriteAllBytes(filePath, aesKey);
                MessageBox.Show("Key saved successfully.");
            }
        }
        private void decrypt_key_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            DialogResult userClickedOK = openFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                aesKey = File.ReadAllBytes(filePath);
            }
        }
        private void saveRSA_Decrypted_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = $"DecryptedRsa{fileType}";

            DialogResult userClickedOK = saveFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                decrypted = viz3.DecryptRSA(rsaEncrypted, RSAPrivateKey, keysize);

                File.WriteAllBytes(filePath, decrypted);
                MessageBox.Show("File saved successfully.");
            }
        }
        private void browseRSA_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            DialogResult userClickedOK = openFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                rsaFileBytes = File.ReadAllBytes(filePath);
                Console.WriteLine(filePath);
                fileType = viz3.FileTypeFromPath(filePath);
                Console.WriteLine(fileType);
            }
            rsaEncrypted = viz3.EncryptRSA(rsaFileBytes, RSAPublicKey, keysize);
        }

        private void saveRSA_Encrypted_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = $"EncryptedRSA.txt";


            DialogResult userClickedOK = saveFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                File.WriteAllBytes(filePath, rsaEncrypted);
                MessageBox.Show("File saved successfully.");
            }
        }

        private void save_rsa_key_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = $"public_key_rsa.txt";

            DialogResult userClickedOK = saveFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                File.WriteAllBytes(filePath, Encoding.UTF8.GetBytes(RSAPublicKey)); ;
                MessageBox.Show("Key saved successfully.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = $"public_key_rsa.txt";

            DialogResult userClickedOK = saveFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                File.WriteAllBytes(filePath, Encoding.UTF8.GetBytes(RSAPrivateKey)); ;
                MessageBox.Show("Key saved successfully.");
            }
        }

        private void Rsa_change_pub_key_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            DialogResult userClickedOK = openFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                byte[] RSAPublicKeybytes = File.ReadAllBytes(filePath);
                RSAPublicKey = Encoding.UTF8.GetString(RSAPublicKeybytes);
            }
        }

        private void Rsa_change_priv_key_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            DialogResult userClickedOK = openFileDialog1.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                byte[] RSAPublicKeybytes = File.ReadAllBytes(filePath);
                RSAPrivateKey = Encoding.UTF8.GetString(RSAPublicKeybytes);
            }
        }

        // RSA part naloge



    }
}