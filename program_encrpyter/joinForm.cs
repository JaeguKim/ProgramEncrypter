using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace program_encrpyter
{
    using System.Net.Json;

    public partial class joinForm : Form
    {
        public joinForm()
        {
            InitializeComponent();
            initializeTextBox();
        }

        private void initializeTextBox()
        {
            // Set to no text.
            pwTextBox.Text = "";
            // The password character is an asterisk.
            pwTextBox.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            pwTextBox.MaxLength = 14;
        }

        private void join_btn_click(object sender, EventArgs e)
        {
            if (id_textBox.Text == "")
            {
                MessageBox.Show("Enter id!");
                return;
            }
            else if (pwTextBox.Text == "")
            {
                MessageBox.Show("Enter pw!");
                return;
            }

            string id_str = id_textBox.Text;
            string pw_str = pwTextBox.Text;
            string encrypted_pw = RSA_encrypt(pw_str);

            requestToServer(id_str, encrypted_pw);
  
            
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

        public void requestToServer(string id, string encrypted_pw)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:3000/api/auth/register");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"username\":\"" + id + "\"," +
                              "\"password\":\"" + encrypted_pw + "\"}";

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
                if (message == "registered successfully")
                {
                    MessageBox.Show(message);
                    this.DialogResult = DialogResult.OK;
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show("register failed!");
                return;
            }
        }
    }
}
