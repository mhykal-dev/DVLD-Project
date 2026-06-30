using Detained_Business;
using Licenses_Business;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Detained_Licenses
{
    public partial class frmDetainedLicenses : Form
    {

        clsLicense License = new clsLicense();

        clsDetainedLicense DetainedLicense = new clsDetainedLicense();

        public frmDetainedLicenses()
        {
            InitializeComponent();

            //ctrDrivingLicenseWithFilters1.DataBack += _ShowDetails;
        }

        private void _ShowDetails(object sender, int LicenseID, DateTime ExpirationDate, int DriverID, int IsActive)
        {
            License = clsLicense.Find(LicenseID);

            if (License.IsActive == false)
            {

                MessageBox.Show("Can't Detain a non-Active License!");

                btnDetain.Enabled = false;
                return;

            }

            if (clsDetainedLicense.IsLicenseDetained(LicenseID))
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
            DetainedLicense.IsReleased = false;
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
