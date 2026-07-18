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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInternationalLicenseDetails_Load(object sender, EventArgs e)
        {
            try
            {
                ctrInternationalLicenseDetails1.LoadInfo(_InternationalLicenseID);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error : " +  ex.Message);
                this.BeginInvoke(new Action(() => this.Close()));
            }
        }
    }
}
