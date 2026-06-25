using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Local_Driving_License_Applications_List
{
    public partial class frmShowLocalLicenseDetails : Form
    {
        public frmShowLocalLicenseDetails(int LicenseID)
        {
            InitializeComponent();

            ctrLocalDrivingLicenseInFO1.LicenseID = LicenseID;

            ctrLocalDrivingLicenseInFO1.ShowDetail();
        }
    }
}
