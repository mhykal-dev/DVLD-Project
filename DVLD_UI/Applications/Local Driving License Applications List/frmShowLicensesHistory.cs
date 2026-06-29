using Drivers_Business;
using InternationalLicenses_Business;
using Licenses_Business;
using System.Windows.Forms;

namespace DVLD_UI.Local_Driving_License_Applications_List
{
    public partial class frmShowLicensesHistory : Form
    {
        clsDriver Driver = new clsDriver();

        public frmShowLicensesHistory(int PersonID)
        {
            InitializeComponent();

            ctrPersonCard1.PersonID = PersonID;

            ctrPersonCard1.ViewPersonInFo();

            ctrPersonCard1.DisableSeaech();

            Driver = clsDriver.FindByPersonID(PersonID);

            if (Driver == null)
            {
                MessageBox.Show("This Person Is Not A Registered Driver");
                return;
            }

            else
            {
                _RefreshLocalLicensesList();

                _RefreshInternationalLicensesList();
            }
        }

        private void _RefreshLocalLicensesList()
        {
            //dgvLocalLicensesHistory.DataSource = clsLicense.GetActiveLicenseIDByPersonID(Driver.DriverID);
        }

        private void _RefreshInternationalLicensesList()
        {
            //dgvInternationalLicensesHistory.DataSource = clsInternationalLicense.GetAllLicensesForThisDriver(Driver.DriverID);
        }


    }
}
