using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace program_encrpyter
{
    using System.Net.Json;

    public partial class timer : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private double second_info;
        private string password;
        private string user_id;
        private string[] decrypt_file_names;

        public timer(int total_sec, string[] encrypt_file_names, string other_user_id, string key)
        {
            InitializeComponent();
            user_id = other_user_id;
            second_info = total_sec;
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 1000;
            setTimerLabel();
            decrypt_file_names = new string[encrypt_file_names.Length];
            encrypt_file_names.CopyTo(decrypt_file_names, 0);
            password = String.Copy(key);
            myTimer.Start();
        }

        private void setTimerLabel() {
            TimeSpan time = TimeSpan.FromSeconds(second_info);
            //here backslash is must to tell that colon is
            //not the part of format, it just a character that we want in output
            string str = time.ToString(@"hh\:mm\:ss\:fff");
            timer_label.Text = str;
        }

        private void decryptAllFiles() {
            for (int i = 0; i < decrypt_file_names.Length; i++)
            {
                DecryptFile(decrypt_file_names[i], password);
            }
        }

        // This is the method to run when the timer is raised.
        private void TimerEventProcessor(Object myObject,EventArgs myEventArgs)
        {
            second_info -= 1;
            setTimerLabel();
            if (second_info == 0)
            {
                decryptAllFiles();
                this.DialogResult = DialogResult.OK;
            }
                
        }


        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {

                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();


                }
            }

            return decryptedBytes;
        }

        private string RSA_encrypt(string plaintext)
        {

            ProcessStartInfo proInfo = new ProcessStartInfo();
            Process p = new Process();

            // Redirect the output stream of the child process.
            proInfo.FileName = @"cmd";
            proInfo.CreateNoWindow = true;
            proInfo.UseShellExecute = false;
            proInfo.RedirectStandardOutput = true;
            proInfo.RedirectStandardInput = true;
            proInfo.RedirectStandardError = true;

            p.StartInfo = proInfo;
            p.Start();

            string cdCmd = "cd RSA_module";
            string execCmd = "node rsa_encrypt.js 0086fa9ba066685845fc03833a9699c8baefb53cfbf19052a7f10f1eaa30488cec1ceb752bdff2df9fad6c64b3498956e7dbab4035b4823c99a44cc57088a23783 65537 " + plaintext;

            string completeCmd = cdCmd + " && " + execCmd;
            p.StandardInput.Write(@completeCmd + Environment.NewLine);
            p.StandardInput.Close();

            string line;
            StreamReader outputReader = p.StandardOutput;
            p.WaitForExit();
            p.Close();

            string cipher = "";

            while ((line = outputReader.ReadLine()) != null)
            {
                if (line.Contains("encrypted:"))
                {
                    int start_idx = line.IndexOf(':') + 1;
                    int end_idx = line.Length - 1;
                    int cipher_len = end_idx - start_idx + 1;
                    cipher = line.Substring(start_idx, cipher_len);
                    break;
                }

            }

            return cipher;
        }

        string GetJsonString(JsonObjectCollection col, string field)
        {
            try
            {
                return Convert.ToString(col[field].GetValue());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(" {0} : [ {1} ] ", ex.Message, field));
            }
        }

        public bool requestToServer(string id, string encrypted_key)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:3000/api/validateKey");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"username\":\"" + id + "\"," +
                              "\"encrypted_key\":\"" + encrypted_key + "\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());

                var result = streamReader.ReadToEnd();
                JsonTextParser parser = new JsonTextParser();
                JsonObject obj = parser.Parse(result);
                JsonObjectCollection col = (JsonObjectCollection)obj;
                string message = GetJsonString(col, "message");
                if (message == "key validation success")
                {
                    MessageBox.Show(message);
                    return true;
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show("key validation failed!");
            }
            return false;
        }

        public void DecryptFile(string file, string password)
        {

            byte[] bytesToBeDecrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            File.WriteAllBytes(file, bytesDecrypted);
            string extension = System.IO.Path.GetExtension(file);
            string result = file.Substring(0, file.Length - extension.Length);
            System.IO.File.Move(file, result);

        }

        private void pw_button_clicked(object sender, EventArgs e)
        {
            if (decrypt_pw_textBox.Text == "") {
                MessageBox.Show("Enter password");
                return;
            }
            string decrypt_key = decrypt_pw_textBox.Text;
            string encrypted_key = RSA_encrypt(decrypt_key);

            if (requestToServer(user_id, encrypted_key)) {
                decryptAllFiles();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
