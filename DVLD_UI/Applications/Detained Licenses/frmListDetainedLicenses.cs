using Detained_Business;
using DVLD_UI.Licenses;
using DVLD_UI.Local_Driving_License_Applications_List;
using DVLD_UI.People;
using Licenses_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_UI.Applications.Detained_Licenses
{
    public partial class frmListDetainedLicenses : Form
    {

        private DataTable _dtDetainedLicenses;

        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _UpdateRecordsCount()
        {
            lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        //I Added This Method Here Claude.
        private void _Refresh(bool ResetFilter = false)
        {
            try
            {
                if(ResetFilter)
                {
                    cbFilterBy.SelectedIndex = 0;
                }

                _dtDetainedLicenses = clsDetainedLicense.GetAllDetainedLicenses();

                dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
                _UpdateRecordsCount();

                if (dgvDetainedLicenses.Rows.Count > 0)
                {
                    dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                    dgvDetainedLicenses.Columns[0].Width = 90;

                    dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                    dgvDetainedLicenses.Columns[1].Width = 90;

                    dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                    dgvDetainedLicenses.Columns[2].Width = 160;

                    dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                    dgvDetainedLicenses.Columns[3].Width = 110;

                    dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                    dgvDetainedLicenses.Columns[4].Width = 110;

                    dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                    dgvDetainedLicenses.Columns[5].Width = 160;

                    dgvDetainedLicenses.Columns[6].HeaderText = "N.No.";
                    dgvDetainedLicenses.Columns[6].Width = 90;

                    dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                    dgvDetainedLicenses.Columns[7].Width = 330;

                    dgvDetainedLicenses.Columns[8].HeaderText = "Rlease App.ID";
                    dgvDetainedLicenses.Columns[8].Width = 150;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                MessageBox.Show("Since There IS No Data TO Display, This Form Will Be Closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            if(txtFilterValue.Text.Trim() != "" && cbFilterBy.SelectedIndex != 0)
            {
                _ApplyFilter();
            }
        }

        private void _ApplyFilter()
        {
            try
            {
                string FilterColumn = "";
                //Map Selected Filter to real Column name 
                switch (cbFilterBy.Text)
                {
                    case "Detain ID":
                        FilterColumn = "DetainID";
                        break;
                    case "Is Released":
                        FilterColumn = "IsReleased";
                        break;

                    case "National No.":
                        FilterColumn = "NationalNo";
                        break;

                    case "Full Name":
                        FilterColumn = "FullName";
                        break;

                    case "Release Application ID":
                        FilterColumn = "ReleaseApplicationID";
                        break;

                    default:
                        FilterColumn = "None";
                        break;
                }

                //Reset The Filter Incase Nothing Selected or txtfilterValue Contain Nothing.
                if (FilterColumn == "None" || txtFilterValue.Text == "")
                {
                    _dtDetainedLicenses.DefaultView.RowFilter = "";
                    _UpdateRecordsCount();
                    return;
                }

                if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                {
                    //in this case we are dealing with numbers not string.
                    string FilterValue = txtFilterValue.Text.Trim();

                    if (!int.TryParse(FilterValue, out _))
                    {
                        MessageBox.Show("Please Enter Only Numeric Values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFilterValue.Text = "";
                        return;
                    }
                    _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
                }

                else
                {
                    //I Added Replace Here Claude.
                    _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim().Replace("'", "''"));
                }

                _UpdateRecordsCount();
            }

            catch(Exception ex)
            {
                MessageBox.Show("Error While Filtering : " + ex.Message);
                return;
            }
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _Refresh(true);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsReleased";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtDetainedLicenses.DefaultView.RowFilter = "";
            else
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            _UpdateRecordsCount();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Released")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Enabled = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsReleased.Visible = false;
                cbIsReleased.Enabled = false;

                if (cbFilterBy.Text == "None")
                    txtFilterValue.Enabled = false;
                else
                    txtFilterValue.Enabled = true;
            }

            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //I Added This Guard Check Here Claude.
            if (dgvDetainedLicenses.CurrentRow == null)
            {
                MessageBox.Show("Please Select A Row First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;

            using (Form frm = new frmShowPersonInFo(PersonID))
            {
                frm.ShowDialog();
            }
            //Added This Here Claude.
            _Refresh(false);
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //I Added This Guard Check Here Claude.
            if (dgvDetainedLicenses.CurrentRow == null)
            {
                MessageBox.Show("Please Select A Row First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicensseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            using (Form frm = new frmShowLocalLicenseDetails(LicensseID))
            {
                frm.ShowDialog();
            }
            //Added This Here Claude.
            _Refresh(false);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //I Added This Guard Check Here Claude.
            if (dgvDetainedLicenses.CurrentRow == null)
            {
                MessageBox.Show("Please Select A Row First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicensseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            using (Form frm = new frmShowLicensesHistory(LicensseID))
            {
                frm.ShowDialog();
            }
            //Added This Here Claude.
            _Refresh(false);
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //I Added This Guard Check Here Claude.
            if (dgvDetainedLicenses.CurrentRow == null)
            {
                MessageBox.Show("Please Select A Row First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicensseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            using (Form frm = new frmReleaseDetainedLicense(LicensseID))
            {
                frm.ShowDialog();
            }
            //Added This Here Claude.
            _Refresh(false);
        }
    }
}
