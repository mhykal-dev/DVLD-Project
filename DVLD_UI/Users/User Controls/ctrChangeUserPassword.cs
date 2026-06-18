using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USERS_Business;

namespace DVLD_UI.Users.User_Controls
{
    public partial class ctrChangeUserPassword : UserControl
    {
        public int UserID { get; set; }
        public ctrChangeUserPassword()
        {
            InitializeComponent();
        }

        public void ShowDetails()
        {
            clsUsers user = clsUsers.Find(UserID);

            if(user == null)
            {
                MessageBox.Show("Wrong UserID!");
            }

            else
            {
                lblID.Text = user.UserID.ToString();
            }
        }

        private void txtboxNewPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtboxNewPassword.Text != txtboxConfirmNewPassword.Text)
                btnSave.Enabled = false;

            else
                btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsUsers User = clsUsers.Find(UserID);

            if (User.Password != txtboxOldPassword.Text)
            {
                MessageBox.Show("Wrong Old Password!");
                return;
            }

            User.Password = txtboxNewPassword.Text;

            if (User.Save())
                MessageBox.Show("password Changed!");

            else
                MessageBox.Show("New Error 😭😭😭😭😭😭");
        }

        private void txtboxConfirmNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtboxNewPassword.Text != txtboxConfirmNewPassword.Text)
                btnSave.Enabled = false;

            else
                btnSave.Enabled = true;
        }

        private void chkAllowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowPassword.Checked)
            {
                txtboxOldPassword.PasswordChar = '\0';
                txtboxNewPassword.PasswordChar = '\0';
                txtboxConfirmNewPassword.PasswordChar = '\0';
            }
            else
            {
                txtboxOldPassword.PasswordChar = '*';
                txtboxNewPassword.PasswordChar = '*';
                txtboxConfirmNewPassword.PasswordChar = '*';
            }
        }
    }
}
