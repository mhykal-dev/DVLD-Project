using Detained_Business;
using Licenses_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Detained_Licenses
{
    public partial class frmDetainedLicenses : Form
    {

        clsLicenses License = new clsLicenses();

        clsDetainedLicenses DetainedLicense = new clsDetainedLicenses();

        public frmDetainedLicenses()
        {
            InitializeComponent();

            ctrDrivingLicenseWithFilters1.DataBack += _ShowDetails;
        }

        private void _ShowDetails(object sender, int LicenseID, DateTime ExpirationDate, int DriverID, int IsActive)
        {
            License = clsLicenses.FindByLicenseID(LicenseID);

            if (License.IsActive == 0)
            {

                MessageBox.Show("Can't Detain a non-Active License!");

                btnDetain.Enabled = false;
                return;

            }

            if (clsDetainedLicenses.IsLicenseDetained(LicenseID))
            {

                MessageBox.Show("Can't Detain An Already Detained License!");

                btnDetain.Enabled = false;
                return;

            }

            btnDetain.Enabled = true;
            lblLicenseID.Text = LicenseID.ToString();
            lblDetainDate.Text = DateTime.Now.ToString();
            lblCreatedByUserID.Text = Convert.ToString(1);
        }

        private void _LoadDetainedLicense()
        {
            DetainedLicense.LicenseID = License.LicenseID;
            DetainedLicense.DetainDate = DateTime.Now;
            DetainedLicense.FineFees = Convert.ToInt32(tctboxFineFees.Text);
            DetainedLicense.CreatedByUserID = 1;
            DetainedLicense.IsReleased = 0;
            DetainedLicense.ReleasedByUserID = -1;
            DetainedLicense.ReleaseApplicationID = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            _LoadDetainedLicense();
        }
    }
}
