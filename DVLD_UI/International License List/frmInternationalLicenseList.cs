using DVLD_UI.International_License_Applications;
using DVLD_UI.Tests.Vision_Test;
using InternationalLicenses_Business;
using LDLApplications_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            dgvInternationalLicensesList.DataSource = clsInternationalLicenses.GetAllInternationalLicenses();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicensesList.SelectedRows.Count > 0)
            {
                int InternationalLicenseID = Convert.ToInt32(dgvInternationalLicensesList.SelectedRows[0].Cells[0].Value);

                clsInternationalLicenses InternationalLicense = clsInternationalLicenses.FindByInternationalLicenseID(InternationalLicenseID);

                int LicenseID = InternationalLicense.IssuedUsingLocalLicenseID;

                int DriverID = InternationalLicense.DriverID;

                frmInternationalLicenseDetails frm = new frmInternationalLicenseDetails(InternationalLicenseID, LicenseID, DriverID);
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
