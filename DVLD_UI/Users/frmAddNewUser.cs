using DVLD_UI.People;
using PEOPLE_Business;
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

namespace DVLD_UI.Users
{
    public partial class frmAddNewUser : Form
    {
        bool AllowChange = false;

        clsUsers NewUser = new clsUsers();
        public frmAddNewUser()
        {
            InitializeComponent();

            btnSave.Enabled = false;
           
        }   

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            People.frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);
            frm.ShowDialog();

            frm.Dispose();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(clsUsers.isUserExistByPersonID(ctrPersonCard1.PersonID))
            {
                MessageBox.Show("This Person Is Already A User!");
                AllowChange = false;
            }

            else
            {
                AllowChange = true;
                tabControl1.SelectedTab = tabPage2;
                AllowChange = false;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(!AllowChange)
            {
                e.Cancel = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtboxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtboxConfirmPassword.Text == txtboxPassword.Text)
            {
                if(txtboxUserName.Text != null)
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(clsUsers.IsUserExistByUserName(txtboxUserName.Text))
            {
                MessageBox.Show("UserName Is Already Taken!");
            }
            else
            {
                
                NewUser.PersonID = ctrPersonCard1.PersonID;
                NewUser.UserName = txtboxUserName.Text;
                NewUser.Password = txtboxPassword.Text;

                if (chkIsActive.Checked)
                    NewUser.IsActive = 1;
                else
                    NewUser.IsActive = 0;



                if (NewUser.Save())
                {
                    MessageBox.Show("User Added Successfuly!");
                    this.Close();
                }

                else
                {
                    MessageBox.Show("New Error😭😭😭😭😭😭😭!");
                }
            }
        }

        private void chkAllowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAllowPassword.Checked)
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

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if(chkIsActive.Checked)
            {
                NewUser.IsActive = 1;
            }
            else
            {
                NewUser.IsActive = 0;
            }
        }
    }
}
