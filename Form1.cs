using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace VIZ_N3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add(128);
            comboBox1.Items.Add(192);
            comboBox1.Items.Add(256);
            comboBox1.Items.Add(1024);
            comboBox1.Items.Add(2048);
        }
        public int keysize;
        public byte[] fileBytes;
        public string fileType;
        byte[] iv = Encoding.UTF8.GetBytes("Hello wrld");


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            keysize = (int)comboBox1.SelectedItem;
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
                fileType = FileTypeFromPath(filePath);
                Console.WriteLine(fileType);

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
                string ivString = Encoding.UTF8.GetString(iv);

                File.WriteAllText(filePath, ivString);
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

                File.WriteAllBytes(filePath, fileBytes);
                MessageBox.Show("File saved successfully.");
            }
        }

        public static byte[] InicializaciskiVektor()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] iv = new byte[16];
                rng.GetBytes(iv);
                Debug.WriteLine(Convert.ToBase64String(iv));
                return iv;
            }
        }
        public byte[] EncryptAes(byte[] data, byte[] key, byte[] iv, int keySize)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.KeySize = keySize;
                aes.Padding = PaddingMode.Zeros;
                aes.BlockSize = keySize;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using MemoryStream msEncrypt = new MemoryStream();
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(data, 0, data.Length);
                    csEncrypt.FlushFinalBlock();
                }
                return msEncrypt.ToArray();
            }
        }
        public string FileTypeFromPath(string filePath)
        {
            int extentionIndex = filePath.LastIndexOf('.');
            if (extentionIndex != -1)
            {
                string result = filePath.Substring(extentionIndex);
                return result;
            }
            else
            {
                return ".idk";
            }
        }

        public byte[] DecryptAes(byte[] encryptedData, byte[] sharedSecret, byte[] userIV)
        {
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = sharedSecret;
                aesAlg.IV = userIV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(encryptedData))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (MemoryStream decryptedStream = new MemoryStream())
                {
                    csDecrypt.CopyTo(decryptedStream);

                    return decryptedStream.ToArray();
                }
            }
        }
    }
}

