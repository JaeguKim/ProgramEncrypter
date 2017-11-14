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

namespace program_encrpyter
{
    public partial class timer : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private double second_info;
        private string password;
        private string[] decrypt_file_names;

        public timer(int total_sec, string[] encrypt_file_names, string key)
        {
            InitializeComponent();
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

        // This is the method to run when the timer is raised.
        private void TimerEventProcessor(Object myObject,EventArgs myEventArgs)
        {
            second_info -= 1;
            setTimerLabel();
            if (second_info == 0)
            {
                for (int i = 0; i < decrypt_file_names.Length; i++)
                {
                    DecryptFile(decrypt_file_names[i], password);
                }
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
    }
}
