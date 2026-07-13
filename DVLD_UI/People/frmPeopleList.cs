using PEOPLE_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_UI.People
{
    public partial class frmPeopleList : Form
    {
        private DataTable _dtAllPeople;

        //only select the columns that you want to show in the grid.
        private DataTable _dtPeople;

        public frmPeopleList()
        {
            InitializeComponent();
        }

        private void frmPeopleList_Load(object sender, EventArgs e)
        {

            try
            {
                _dtAllPeople = clsPerson.GetAllPeople();

                //only select the columns that you want to show in the grid.
                _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                               "FirstName", "SecondName", "ThirdName", "LastName",
                                                               "GenderCaption", "DateOfBirth", "CountryName",
                                                               "Phone", "Email");

                dgvPeopleList.DataSource = _dtPeople;
                cmbFilterBy.SelectedIndex = 0; //None!.
            }

            catch(Exception ex)
            {
                MessageBox.Show("Error while loading People List: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() => this.Close())); // Close the form on load error.
                return;
            }

            _SetupDataGridViewColumns();
            _UpdateRecordsCount();
        }

        private void _SetupDataGridViewColumns()
        {
            if (dgvPeopleList.Columns.Count == 0) return;

            string[] headers = { "Person ID", "National No.", "First Name", "Second Name", "Third Name", "Last Name", "Gender", "Date Of Birth", "Nationality", "Phone", "Email" };
            int[] widths = { 110, 120, 120, 140, 120, 120, 120, 140, 120, 120, 170 };

            for (int i = 0; i < dgvPeopleList.Columns.Count; i++)
            {
                if (i < headers.Length)
                {
                    dgvPeopleList.Columns[i].HeaderText = headers[i];
                    dgvPeopleList.Columns[i].Width = widths[i];
                }
            }
        }

        private void _RefreshPeopleList()
        {
            try
            {
                _dtAllPeople = clsPerson.GetAllPeople();
                _dtPeople = _dtAllPeople.DefaultView.ToTable(false,
                    "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName",
                    "LastName", "GenderCaption", "DateOfBirth", "CountryName", "Phone", "Email");

                dgvPeopleList.DataSource = _dtPeople;
                //cmbFilterBy.SelectedIndex = 0;
                _ApplyFilter();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error while refreshing People List: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _UpdateRecordsCount();
            _SetupDataGridViewColumns();
        }

        private void _UpdateRecordsCount()
        {
            lblrecords.Text = dgvPeopleList.Rows.Count.ToString();
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtboxFilterField.Visible = (cmbFilterBy.Text != "None");

            if (txtboxFilterField.Visible)
            {
                txtboxFilterField.Clear();
                txtboxFilterField.Focus();
            }

            else
            {
                _dtPeople.DefaultView.RowFilter = "";
                _UpdateRecordsCount();
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddNewPerson();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(dgvPeopleList.CurrentRow == null)
            {
                MessageBox.Show("Please select a valid Person to show details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int PersonID = (int)dgvPeopleList.CurrentRow.Cells[0].Value;
            using (Form frmPerson = new frmShowPersonInFo(PersonID))
            {
                frmPerson.ShowDialog();
            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewPerson();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvPeopleList.CurrentRow == null)
            {
                MessageBox.Show("Please select a valid Person to show details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int PersonID = (int)dgvPeopleList.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeopleList.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvPeopleList.CurrentRow == null)
            {
                MessageBox.Show("Please select a valid Person to show details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int PersonID = (int)dgvPeopleList.CurrentRow.Cells[0].Value;
            using (Form frm = new frmAddUpdatePerson(PersonID))
            {
                frm.ShowDialog();

                _RefreshPeopleList();
            }
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not available yet.", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not available yet.", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtboxFilterField_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void _ApplyFilter()
        {
            string filterColumn;

            switch (cmbFilterBy.Text)
            {
                case "Person ID": filterColumn = "PersonID"; break;
                case "National No.": filterColumn = "NationalNo"; break;
                case "First Name": filterColumn = "FirstName"; break;
                case "Second Name": filterColumn = "SecondName"; break;
                case "Third Name": filterColumn = "ThirdName"; break;
                case "Last Name": filterColumn = "LastName"; break;
                case "Nationality": filterColumn = "CountryName"; break;
                case "Gender": filterColumn = "GenderCaption"; break;
                case "Phone": filterColumn = "Phone"; break;
                case "Email": filterColumn = "Email"; break;
                default: filterColumn = "None"; break;
            }

            if (string.IsNullOrWhiteSpace(txtboxFilterField.Text) || filterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                _UpdateRecordsCount();
                return;
            }

            string filterValue = txtboxFilterField.Text.Trim().Replace("'", "''");

            try
            {
                if (filterColumn == "PersonID")
                {
                    if (!int.TryParse(filterValue, out int personId))
                    {
                        MessageBox.Show("Please enter a valid numeric value for Person ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _UpdateRecordsCount();
                        return;
                    }
                    _dtPeople.DefaultView.RowFilter = $"{filterColumn} = {filterValue}";
                }
                else
                {
                    _dtPeople.DefaultView.RowFilter = $"{filterColumn} LIKE '{filterValue}%'";
                }
            }
            catch (Exception)
            {
                // invalid filter characters — ignore rather than crash
            }

            _UpdateRecordsCount();
        }

        private void txtboxFilterField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void AddNewPerson()
        {
            using(Form frm = new frmAddUpdatePerson())
            {
                frm.ShowDialog();
            }
            _RefreshPeopleList();
        }
    }
}