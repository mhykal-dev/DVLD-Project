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
    public partial class frmUsersList : Form
    {
        public frmUsersList()
        {
            InitializeComponent();
        }

        private void _RefreshPeopleList()
        {
            dgvUsersList.DataSource = clsUsers.GetAllUsers();
        }

        private void frmUsersList_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
        }

        private void btnAddNewUsers_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.ShowDialog();

            frm.Dispose();
            _RefreshPeopleList();
        }

        private void txtboxFilterField_TextChanged(object sender, EventArgs e)
        {
            dgvUsersList.DataSource = clsUsers.GetUsersByFilter(cmbFilterBy.SelectedItem.ToString(), txtboxFilterField.Text);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.SelectedRows.Count > 0)
            {
                int UserID = Convert.ToInt32(dgvUsersList.SelectedRows[0].Cells[0].Value);

                frmShowUserDetails frmUser = new frmShowUserDetails(UserID);
                frmUser.ShowDialog();

                frmUser.Dispose();
                _RefreshPeopleList();
            }

            else
            {
                MessageBox.Show("Please Select A Row first!");
            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.ShowDialog();

            frm.Dispose();
            _RefreshPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.SelectedRows.Count > 0)
            {
                int UserID = Convert.ToInt32(dgvUsersList.SelectedRows[0].Cells[0].Value);

                frmUpdateUser frmUser = new frmUpdateUser(UserID);
                frmUser.ShowDialog();

                frmUser.Dispose();
                _RefreshPeopleList();
            }

            else
            {
                MessageBox.Show("Please Select A Row first!");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.SelectedRows.Count > 0)
            {
                int UserID = Convert.ToInt32(dgvUsersList.SelectedRows[0].Cells[0].Value);

                if(clsUsers.DeleteUser(UserID))
                {
                    MessageBox.Show("User Deleted Successfuly!");
                    _RefreshPeopleList();
                }

                else
                {
                    MessageBox.Show("Can't Delete This User Because He Has Linked To This System!!!");
                    _RefreshPeopleList();
                }
            }

            else
            {
                MessageBox.Show("Please Select A Row first!");
                _RefreshPeopleList();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.SelectedRows.Count > 0)
            {
                int UserID = Convert.ToInt32(dgvUsersList.SelectedRows[0].Cells[0].Value);

                frmChangePassword frm = new frmChangePassword(UserID);
                frm.ShowDialog();

                frm.Dispose();
                _RefreshPeopleList();
            }

            else
            {
                MessageBox.Show("Please Select A Row first!");
            }
        }
    }
}
