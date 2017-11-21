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
    public partial class startForm : Form
    {
        public startForm()
        {
            InitializeComponent();
        }

        private void join_btn(object sender, EventArgs e)
        {
            this.Hide();
            joinForm joinForm = new joinForm();
            joinForm.ShowDialog();
            this.Show();
        }

        private void login_btn(object sender, EventArgs e)
        {
            this.Hide();
            loginForm loginForm = new loginForm();
            loginForm.ShowDialog();
            this.Show();
        }
    }
}
