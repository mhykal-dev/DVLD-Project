using System;
using System.Windows.Forms;

namespace DVLD_UI.International_License_Applications
{
    public partial class frmInternationalLicenseDetails : Form
    {
        private int _InternationalLicenseID;

        public frmInternationalLicenseDetails(int InternationalLicenseID)
        {
            InitializeComponent();

            _InternationalLicenseID = InternationalLicenseID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInternationalLicenseDetails_Load(object sender, EventArgs e)
        {
            ctrInternationalLicenseDetails1.LoadInfo(_InternationalLicenseID);
        }
    }
}
