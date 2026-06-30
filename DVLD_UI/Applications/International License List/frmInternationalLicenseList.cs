using Drivers_Business;
using DVLD_UI.International_License_Applications;
using DVLD_UI.Licenses;
using InternationalLicenses_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_UI.International_License_Lists
{
    public partial class frmInternationalLicenseList : Form
    {
        private DataTable _dtInternationalLicenseApplications;

        public frmInternationalLicenseList()
        {
            InitializeComponent();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value;
            using (Form frm = new frmInternationalLicenseDetails(InternationalLicenseID))
            {
                frm.ShowDialog();
            }
        }

        private void btnAddNewLicense_Click(object sender, EventArgs e)
        {
            using (Form frm = new frmInternational_Licenses_Applications())
            {
                frm.ShowDialog();
            }

        }

        private void frmInternationalLicenseList_Load(object sender, EventArgs e)
        {
            _dtInternationalLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses();
            cbFilterBy.SelectedIndex = 0;
            
            dgvInternationalLicenses.DataSource = _dtInternationalLicenseApplications;
            lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 160;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 150;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 130;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 130;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 180;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 180;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 120;

            }
        }

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            using(Form frm = new frmInternational_Licenses_Applications())
            {
                frm.ShowDialog();
            }
            frmInternationalLicenseList_Load(null, null);
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;

            using(Form frm = new frmShowLicensesHistory(PersonID))
            {
                frm.ShowDialog();
            }
        }
    }
}
