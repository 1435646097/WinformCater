using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Bll;

namespace UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ManagerInfo mi = new ManagerInfo();
            mi.MName = txtName.Text;
            mi.MPwd = txtPwd.Text;
            if(new ManagerInfoBll().Login(mi))
            {
                FormMian mian = new FormMian();
                mian.Tag = mi.MType;
                mian.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("账号或密码错误");
            }
        }
    }
}
