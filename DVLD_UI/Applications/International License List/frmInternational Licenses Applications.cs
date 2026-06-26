using Applications_Business;
using ApplicationTypes_Business;
using Drivers_Business;
using InternationalLicenses_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USERS_Business;

namespace DVLD_UI.International_License_Applications
{

    public partial class frmInternational_Licenses_Applications : Form
    {
        clsApplication application = new clsApplication();

        clsInternationalLicense InternationalLicenses = new clsInternationalLicense();

        public int _DriverID { get; set; }

        public int _LicenseID { get; set; }

        public int _IsActive { get; set; }

        public frmInternational_Licenses_Applications()
        {
            InitializeComponent();

            ctrDrivingLicenseWithFilters1.DataBack += _LoadApplication;
        }

        private void _LoadApplication(object sender, int LicenseID, DateTime ExpirationDate, int DriverID, int IsActive)
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = clsApplicationType.GetApplicatinTypePrice(6).ToString();
            lblLocalLiceseID.Text = LicenseID.ToString();
            _DriverID = DriverID;
            _LicenseID = LicenseID;
            _IsActive = IsActive;
            lblExpirationDate.Text = ExpirationDate.ToString();
            //lblCreatedByUserName.Text = clsUser(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _SaveApplicationInFo()
        {
            //(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate,
            //ref int ApplicationTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)

            application.ApplicantPersonID = clsDriver.GetDriverPersonIDoByDriverID(_DriverID);
            application.ApplicationDate = Convert.ToDateTime(lblIssueDate.Text);
            application.ApplicationTypeID = 6;
            application.ApplicationStatus = (clsApplication.enApplicationStatus)1;
            application.LastStatusDate = Convert.ToDateTime(lblApplicationDate.Text);
            application.PaidFees = Convert.ToInt32(lblApplicationFees.Text);
            application.CreatedByUserID = 1;
        }

        private void _SaveInternationalLicenseInFo()
        {
            InternationalLicenses.ApplicationID = application.ApplicationID;
            InternationalLicenses.DriverID = _DriverID;
            InternationalLicenses.IssuedUsingLocalLicenseID = _LicenseID;
            InternationalLicenses.IssueDate = Convert.ToDateTime(lblIssueDate.Text);
            InternationalLicenses.ExpirationDate = Convert.ToDateTime(lblExpirationDate.Text);
            InternationalLicenses.IsActive = _IsActive;
            InternationalLicenses.CreatedByUserID = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _SaveApplicationInFo();

            if (!application.Save())
            {
                MessageBox.Show("Application Didn't Save!");
                return;
            }

            lblApplicationID.Text = application.ApplicationID.ToString();

            _SaveInternationalLicenseInFo();

            if (_LicenseID == clsInternationalLicense.IsThereInternationalLicenseForThisLocalLicense(_LicenseID))
            {
                MessageBox.Show($"This Driver Have Already An InternationalLicense With ID {clsInternationalLicense.FindByDriverID(_DriverID)}");
                return;
            }

            if (!InternationalLicenses.Save())
            {
                MessageBox.Show("InternationalLicense Didn't Save!");
                return;
            }

            lblILicenseID.Text = InternationalLicenses.InternationalLicenseID.ToString();

            MessageBox.Show($"InternationalLicense Have Been Issued With ID = {InternationalLicenses.InternationalLicenseID}");
            linklblShowLicenseInFo.Enabled = true;
        }

        private void linklblShowLicenseInFo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int IntLicense = Convert.ToInt32(lblILicenseID.Text);
            frmInternationalLicenseDetails frm = new frmInternationalLicenseDetails(IntLicense, _LicenseID, _DriverID);
            frm.ShowDialog();

            frm.Dispose();
        }
    }
}