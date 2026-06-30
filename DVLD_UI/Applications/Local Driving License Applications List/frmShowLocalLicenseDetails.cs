using System.Windows.Forms;

namespace DVLD_UI.Local_Driving_License_Applications_List
{
    public partial class frmShowLocalLicenseDetails : Form
    {
        private int _LicenseID;
        public frmShowLocalLicenseDetails(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmShowLocalLicenseDetails_Load(object sender, System.EventArgs e)
        {
            ctrLocalDrivingLicenseInFO1.LoadInfo(_LicenseID);
        }
    }
}
