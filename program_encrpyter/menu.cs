using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program_encrpyter
{
    public partial class menu : Form
    {
        private string user_id;
        private string token_str;
        public menu(string id, string token)
        {
            InitializeComponent();
            user_id = id;
            token_str = token;
        }

        private void file_encrypt_btn(object sender, EventArgs e)
        {
            this.Hide();
            setting_screen setting_screen = new setting_screen(token_str);
            setting_screen.ShowDialog();
            this.Show();
        }

        private void key_check_btn(object sender, EventArgs e)
        {
            this.Hide();
            key_check_screen setting_screen = new key_check_screen(user_id,token_str);
            setting_screen.ShowDialog();
            this.Show();
        }

        private void exit_btn_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menu_closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
