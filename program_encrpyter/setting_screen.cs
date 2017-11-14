using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Security.Cryptography;

namespace program_encrpyter
{
    struct time_interval {
        public int hour, minute, second;
    }

    public partial class setting_screen : Form
    {
        time_interval time_interval;
        string[] file_names;
        string other_user_id;
        string password;

        public setting_screen()
        {
            InitializeComponent();
        }
        
        
        private void setting_screen_load(object sender, EventArgs e)
        {
            string[] hour_array = new String[25];
            for (int i = 0; i < hour_array.Length; i++) hour_array[i] = Convert.ToString(i);
            string[] minute_array = new String[60];
            for (int i = 0; i < minute_array.Length; i++) minute_array[i] = Convert.ToString(i);
            string[] second_array = minute_array;

            // 각 콤보박스에 데이타를 초기화
            hour_list.Items.AddRange(hour_array);
            minute_list.Items.AddRange(minute_array);
            second_list.Items.AddRange(second_array);

            hour_list.SelectedIndex = 0;
            minute_list.SelectedIndex = 0;
            second_list.SelectedIndex = 0;

            
        }


        bool check_duplicate_file(string f_name) {
            for (int i = 0; i < file_list.Items.Count; i++) {
                if (file_list.Items[i].ToString() == f_name)
                    return true;
            }
            return false;
        }

        private void add_btn_click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            
            if (OFD.ShowDialog() == DialogResult.OK) {
                string file = OFD.FileName;
                if (!check_duplicate_file(file))
                    file_list.Items.Add(file);
                else
                    MessageBox.Show("file is duplicated");
            }
       }

        private void delete_file(object sender, EventArgs e)
        {
            file_list.Items.Remove(file_list.SelectedItem);
        }

        private void other_user_id_changed(object sender, EventArgs e)
        {
            other_user_id = other_user_textbox.Text;
        }

        private void confirm_btn_click(object sender, MouseEventArgs e)
        {
            //set timer
            file_names = new String[file_list.Items.Count];
            for (int i=0; i < file_names.Length; i++)
            {
                file_names[i] = file_list.Items[i].ToString();
            }
            startEncrypt();
            change_file_names();
            this.Hide();
            int total_sec = time_interval.hour * 3600 + time_interval.minute * 60 + time_interval.second;
            timer t_form = new timer(total_sec,file_names,password);
            t_form.ShowDialog();
            this.Show();
            
        }

        void change_file_names() {
            for (int i = 0; i < file_names.Length; i++) {
                file_names[i] = file_names[i] + ".locked";
            }
        }
        //AES encryption algorithm
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
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

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        //creates random password for encryption
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!=&?&/";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        /*
        //Sends created password target location
        public void SendPassword(string password)
        {

            string info = computerName + "-" + userName + " " + password;
            var fullUrl = targetURL + info;
            var conent = new System.Net.WebClient().DownloadString(fullUrl);
        }
        */

        //Encrypts single file
        public void EncryptFile(string file, string password)
        {

            byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            File.WriteAllBytes(file, bytesEncrypted);
            System.IO.File.Move(file, file + ".locked");

        }

        public void startEncrypt()
        {
            password = CreatePassword(15);

            for (int i = 0; i < file_names.Length; i++) {
                EncryptFile(file_names[i], password);
            }
            
        }

        private void hour_selected(object sender, EventArgs e)
        {
                time_interval.hour = Int32.Parse(hour_list.SelectedItem.ToString());
        }

        private void minute_selected(object sender, EventArgs e)
        {
            time_interval.minute = Int32.Parse(minute_list.SelectedItem.ToString());
        }

        private void second_selected(object sender, EventArgs e)
        {
            time_interval.second = Int32.Parse(second_list.SelectedItem.ToString());
        }

        private void setting_screen_close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
