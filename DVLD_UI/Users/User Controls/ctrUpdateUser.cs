using DVLD_UI.People;
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
    public partial class ctrUpdateUser : UserControl
    {
        public int UserID { get; set; }

        public int PersonID { get; set; }
        public ctrUpdateUser()
        {
            InitializeComponent();
        }

        public void ShowDetails()
        {
            clsUsers User = clsUsers.Find(UserID);

            PersonID = User.PersonID;

            ShwoLoginInFo(User);           
        }

        public void ShwoLoginInFo(clsUsers User)
        {
            if (User != null)
            {
                lblID.Text = User.UserID.ToString();
                txtboxUserName.Text = User.UserName;
                txtboxPassword.Text = User.Password;
                txtboxConfirmPassword.Text = txtboxPassword.Text;

                if (User.IsActive == 1)
                    chkIsActive.Checked = true;
                else
                    chkIsActive.Checked = false;
            }

            else
            {
                MessageBox.Show("Wrong UserID!");
            }
        }

        private void btnUpdatePersonInFo_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(PersonID);
            frm.ShowDialog();

            frm.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {         
            clsUsers User = clsUsers.Find(UserID);
            User.UserName = txtboxUserName.Text;
            User.Password = txtboxPassword.Text;

            if (chkIsActive.Checked)
                User.IsActive = 1;
            else
                User.IsActive = 0;

            if (User.Save())
            {
                MessageBox.Show("User Added Successfuly!");
            }

            else
            {
                MessageBox.Show("New Error😭😭😭😭😭😭😭!");
            }
        }

        private void txtboxPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtboxPassword.Text != txtboxConfirmPassword.Text)
            {
                btnSave.Enabled = false;
            }

            else
            {
                btnSave.Enabled = true;
            }
        }

        private void chkAllowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowPassword.Checked)
            {
                txtboxPassword.PasswordChar = '\0';
                txtboxConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtboxPassword.PasswordChar = '*';
                txtboxConfirmPassword.PasswordChar = '*';
            }
        }

        private void txtboxUserName_TextChanged(object sender, EventArgs e)
        {
            if(txtboxUserName.Text == "")
            {
                btnSave.Enabled = false;
            }

            else
            {
                btnSave.Enabled = true;
            }
        }
    }
}
