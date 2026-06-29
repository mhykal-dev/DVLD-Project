using System;
using System.Windows.Forms;
using USERS_Business;

namespace DVLD_UI.Users.User_Controls
{
    public partial class ctrChangeUserPassword : UserControl
    {
        clsUser _User = new clsUser();

        public ctrChangeUserPassword()
        {
            InitializeComponent();

        }

        public void ShowDetails(int UserID)
        {
            _User = clsUser.Find(UserID);

            if (_User == null)
            {
                MessageBox.Show("Wrong UserID!");
            }

            else
            {
                lblID.Text = _User.UserID.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool HasError = false;

            if (string.IsNullOrWhiteSpace(txtboxOldPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtboxOldPassword, "OldPassword Cannot be empty!");
                HasError = true;
            }

            else if (_User.Password.Trim() != txtboxOldPassword.Text.Trim())
            {
                errorProvider1.SetError(txtboxOldPassword, "OldPassword Not Matched!");
                HasError = true;
            }

            if (!string.IsNullOrWhiteSpace(txtboxNewPassword.Text) && txtboxNewPassword.Text.Trim() == txtboxOldPassword.Text.Trim())
            {
                errorProvider1.SetError(txtboxNewPassword, "New Password Cann't be OldPassword Matched!");
                HasError = true;
            }

            if (txtboxNewPassword.Text != txtboxConfirmNewPassword.Text)
            {
                errorProvider1.SetError(txtboxConfirmNewPassword, "Password Confirmation does not match!");
                HasError = true;
            }

            if (HasError)
            {
                MessageBox.Show("Please fix the highlighted errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _User.Password = txtboxNewPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show("Password changed Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtboxOldPassword.Clear();
                txtboxNewPassword.Clear();
                txtboxConfirmNewPassword.Clear();
            }

            else
            {
                MessageBox.Show("An error occurred while Changing the user's Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkAllowPassword_CheckedChanged(object sender, EventArgs e)
        {
            char passwordCahr = chkAllowPassword.Checked ? '\0' : '*';
            txtboxOldPassword.PasswordChar = passwordCahr;
            txtboxNewPassword.PasswordChar = passwordCahr;
            txtboxConfirmNewPassword.PasswordChar = passwordCahr;
        }

        private void ctrChangeUserPassword_Load(object sender, EventArgs e)
        {

        }

        private void txtboxOldPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtboxOldPassword, "");
        }
    }
}
