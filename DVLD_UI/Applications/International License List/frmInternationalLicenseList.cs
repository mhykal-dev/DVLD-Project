using DVLD_UI.International_License_Applications;
using InternationalLicenses_Business;
using System;
using System.Windows.Forms;

namespace DVLD_UI.International_License_Lists
{
    public partial class frmInternationalLicenseList : Form
    {
        public frmInternationalLicenseList()
        {
            InitializeComponent();

            _RefreshPeopleList();
        }

        private void _RefreshPeopleList()
        {
            dgvInternationalLicensesList.DataSource = clsInternationalLicense.GetAllInternationalLicenses();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicensesList.SelectedRows.Count > 0)
            {
                int InternationalLicenseID = (int)dgvInternationalLicensesList.SelectedRows[0].Cells[0].Value;

                clsInternationalLicense InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);

                int LicenseID = InternationalLicense.IssuedUsingLocalLicenseID;

                int DriverID = InternationalLicense.DriverID;

                frmInternationalLicenseDetails frm = new frmInternationalLicenseDetails(InternationalLicenseID);
                frm.ShowDialog();

                frm.Dispose();
                _RefreshPeopleList();
            }
        }

        private void btnAddNewLicense_Click(object sender, EventArgs e)
        {
            frmInternational_Licenses_Applications frm = new frmInternational_Licenses_Applications();
            frm.ShowDialog();

            frm.Dispose();
            _RefreshPeopleList();
        }
    }
}
