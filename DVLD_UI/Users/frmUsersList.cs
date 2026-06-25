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
        private static DataTable _dtAllUsers = clsUser.GetAllUsers();

        private DataTable _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "UserName", "Password", "IsActive");
        public frmUsersList()
        {
            InitializeComponent();
        }

        private void _RefreshUsersList()
        {
            _dtAllUsers = clsUser.GetAllUsers();
            _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "UserName", "Password", "IsActive");

            dgvUsersList.DataSource = _dtUsers;
            _UpdateRecordsCount();
        }

        private void frmUsersList_Load(object sender, EventArgs e)
        {
            dgvUsersList.DataSource = _dtUsers;
            cmbFilterBy.SelectedIndex = 0;

            _SetupDataGridViewColumns();
            _UpdateRecordsCount();
        }

        private void _SetupDataGridViewColumns()
        {
            if (dgvUsersList.Rows.Count == 0) return;

            string[] headers = { "User ID", "PersonID", "UserName", "Password", "IsActive" };
            int[] widths = { 110, 120, 120, 140, 120 };

            for (int i = 0; i < dgvUsersList.Columns.Count; i++)
            {
                if (i < headers.Length)
                {
                    dgvUsersList.Columns[i].HeaderText = headers[i];
                    dgvUsersList.Columns[i].Width = widths[i];
                }
            }
        }

        private void _UpdateRecordsCount()
        {
            lblrecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void btnAddNewUsers_Click(object sender, EventArgs e)
        {
            using (Form frm = new frmAddNewUser())
            {
                frm.ShowDialog();
            }

            _RefreshUsersList();
        }

        private void txtboxFilterField_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cmbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtboxFilterField.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                _UpdateRecordsCount();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                //in this case we deal with numbers not string.
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtboxFilterField.Text.Trim());
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtboxFilterField.Text.Trim());

            _UpdateRecordsCount();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.CurrentRow == null) return;
            int UserID = (int)dgvUsersList.CurrentRow.Cells[0].Value;
            using (Form frmUser = new frmShowUserDetails(UserID))
            {
                frmUser.ShowDialog();
            }

            _RefreshUsersList();
        }
        
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form frm = new frmAddNewUser())
            {
                frm.ShowDialog();
            }

            _RefreshUsersList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.CurrentRow == null) return;
            int UserID = (int)dgvUsersList.CurrentRow.Cells[0].Value;

            using (Form frm = new frmUpdateUser(UserID))
            {
                frm.ShowDialog();

                _RefreshUsersList();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.CurrentRow == null) return;
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvUsersList.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsUser.DeleteUser((int)dgvUsersList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.CurrentRow == null) return;
            int UserID = (int)dgvUsersList.CurrentRow.Cells[0].Value;

            using (Form frm = new frmChangePassword(UserID))
            {
                frm.ShowDialog();

                _RefreshUsersList();
            }
        }
    }
}
