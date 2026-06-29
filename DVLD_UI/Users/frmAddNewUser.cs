using System;
using System.Windows.Forms;
using USERS_Business;

namespace DVLD_UI.Users
{
    public partial class frmAddNewUser : Form
    {
        bool _AllowChange = false;
        clsUser _NewUser = new clsUser();

        public frmAddNewUser()
        {

            InitializeComponent();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrNewPersonCardWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Please select a person first!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsUser.IsUserExistForPersonID(ctrNewPersonCardWithFilter1.PersonID))
            {
                MessageBox.Show("This Person Is Already A User! Please choose another person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _AllowChange = false;
            }

            else
            {
                _AllowChange = true;
                tabControl1.SelectedTab = tabPage2;
                _AllowChange = false;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_AllowChange)
            {
                e.Cancel = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool HasError = false;

            if (string.IsNullOrEmpty(txtboxUserName.Text.Trim()))
            {
                errorProvider1.SetError(txtboxUserName, "UserName Cannot be empty!");
                HasError = true;
            }

            else if (clsUser.IsUserExistByUserName(txtboxUserName.Text.Trim()))
            {
                errorProvider1.SetError(txtboxUserName, "UserName Is Already Taken!");
                HasError = true;
            }

            if (string.IsNullOrWhiteSpace(txtboxPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtboxPassword, "Password Cannot be empty!");
                HasError = true;
            }

            if (txtboxPassword.Text.Trim() != txtboxConfirmPassword.Text.Trim())
            {
                errorProvider1.SetError(txtboxConfirmPassword, "Password Confirmation does not match!");
                HasError = true;
            }

            if (HasError)
            {
                MessageBox.Show("Please fix the highlighted errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _NewUser.PersonID = ctrNewPersonCardWithFilter1.PersonID;
            _NewUser.UserName = txtboxUserName.Text.Trim();
            _NewUser.Password = txtboxPassword.Text.Trim();
            _NewUser.IsActive = chkIsActive.Checked;

            if (_NewUser.Save())
            {
                MessageBox.Show("User Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            else
            {
                MessageBox.Show("An error occurred while saving the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAllowPassword_CheckedChanged(object sender, EventArgs e)
        {
            char passwordCahr = chkAllowPassword.Checked ? '\0' : '*';
            txtboxPassword.PasswordChar = passwordCahr;
            txtboxConfirmPassword.PasswordChar = passwordCahr;
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            _NewUser.IsActive = chkIsActive.Checked;
        }
    }
}
