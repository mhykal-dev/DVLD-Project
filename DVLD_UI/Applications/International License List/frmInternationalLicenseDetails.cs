using System;
using System.Windows.Forms;

namespace DVLD_UI.International_License_Applications
{
    public partial class frmInternationalLicenseDetails : Form
    {
        public frmInternationalLicenseDetails(int IntLicense, int LicenseID, int DriverID)
        {
            InitializeComponent();

            ctrInternationalLicenseDetails1.LicenseID = LicenseID;

            ctrInternationalLicenseDetails1.DriverID = DriverID;

            ctrInternationalLicenseDetails1.IntLicenseID = IntLicense;

            ctrInternationalLicenseDetails1.ShowDetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
