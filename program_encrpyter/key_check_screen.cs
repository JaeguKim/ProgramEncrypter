using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace program_encrpyter
{
    using System.Net.Json;

    public partial class key_check_screen : Form
    {
        private string token_str;

        public key_check_screen(string id, string token)
        {
            InitializeComponent();
            token_str = token;
            if (!requestToServer(id,token_str))
            {
                this.DialogResult = DialogResult.OK;
            }
           
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

        public bool requestToServer(string id, string token)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:3000/api/getKey");
            httpWebRequest.Headers.Add("x-access-token:"+RSA_encrypt(token));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"username\":\"" + id + "\"}";

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

                try
                {
                    string message = GetJsonString(col, "message");
                    MessageBox.Show(message);
                    if (message == "username not exists")
                        return false;
                }
                catch
                {
                    string encrypted_key = GetJsonString(col, "encrypted_key");
                    key_text_label.Text = RSA_decrypt(encrypted_key);
                    return true;
                }
                
            }
            catch (WebException ex)
            {
                MessageBox.Show("get key failed!");
                return false;
            }
            return false;
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

        private string RSA_decrypt(string cipher)
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
            string execCmd = "node rsa_decrypt.js 5d2f0dd982596ef781affb1cab73a77c46985c6da2aafc252cea3f4546e80f40c0e247d7d9467750ea1321cc5aa638871b3ed96d19dcc124916b0bcb296f35e1 " + cipher;

            string completeCmd = cdCmd + " && " + execCmd;
            p.StandardInput.Write(@completeCmd + Environment.NewLine);
            p.StandardInput.Close();

            string line;
            StreamReader outputReader = p.StandardOutput;
            p.WaitForExit();
            p.Close();

            string plaintext = "";

            while ((line = outputReader.ReadLine()) != null)
            {
                if (line.Contains("decrypted:"))
                {
                    int start_idx = line.IndexOf(':') + 1;
                    int end_idx = line.Length - 1;
                    int plaintext_len = end_idx - start_idx + 1;
                    plaintext = line.Substring(start_idx, plaintext_len);
                    break;
                }

            }

            return plaintext;
        }

        private void moveToMenu_btn(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
