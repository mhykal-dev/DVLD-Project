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
        clsUser _User = new clsUser();
        public ctrUpdateUser()
        {
            InitializeComponent();
        }

        public void ShowDetails(int _UserID)
        {
            _User = clsUser.Find(_UserID);

            ShowLoginInFo(_User);           
        }

        public void ShowLoginInFo(clsUser User)
        {
            if (User != null)
            {
                lblID.Text = User.UserID.ToString();
                txtboxUserName.Text = User.UserName;

                chkIsActive.Checked = User.IsActive;
            }

            else
            {
                MessageBox.Show("Wrong UserID!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool HasError = false;

            if (string.IsNullOrWhiteSpace(txtboxUserName.Text.Trim()))
            {
                errorProvider1.SetError(txtboxUserName, "UserName Cannot be empty!");
                HasError = true;
            }

            else if (txtboxUserName.Text.Trim() != _User.UserName && clsUser.IsUserExistByUserName(txtboxUserName.Text.Trim()))
            {
                errorProvider1.SetError(txtboxUserName, "UserName Is Already Used!");
                HasError = true;
            }

            if (HasError)
            {
                MessageBox.Show("Please fix the highlighted errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _User.UserName = txtboxUserName.Text;

            _User.IsActive = chkIsActive.Checked;

            if (_User.Save())
            {
                MessageBox.Show("User Updated Successfuly!");
            }

            else
            {
                MessageBox.Show("New Error😭😭😭😭😭😭😭!");
            }
        }

        private void lklblChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using(Form frm = new frmChangePassword(_User.UserID))
            {
                frm.ShowDialog();
            }
        }
    }
}
