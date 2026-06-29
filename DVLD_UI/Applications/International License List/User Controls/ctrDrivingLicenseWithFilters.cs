using Licenses_Business;
using System;
using System.Windows.Forms;

namespace DVLD_UI.International_License_Applications.User_Controls
{
    public partial class ctrDrivingLicenseWithFilters : UserControl
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int LicenseID, DateTime ExpirationDate, int DriverID, int IsActive);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public ctrDrivingLicenseWithFilters()
        {
            InitializeComponent();
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            clsLicense License = clsLicense.Find(Convert.ToInt32(txtboxLicenseField.Text));

            if (License != null)
            {
                //ctrLocalDrivingLicenseInFO1.LicenseID = License.LicenseID;

                //ctrLocalDrivingLicenseInFO1.ShowDetail();

                DataBack?.Invoke(this, License.LicenseID, License.ExpirationDate, License.DriverID, Convert.ToInt32(License.IsActive));

                return;
            }

            else
            {
                MessageBox.Show("Imvaild License ID");
            }
        }
    }
}
