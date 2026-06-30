using Applications_Business;
using ApplicationTypes_Business;
using Drivers_Business;
using DVLD_UI.Global_Classes;
using DVLD_UI.Local_Driving_License_Applications_List;
using LicenseClasses_Business;
using Licenses_Business;
using PEOPLE_Business;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Renew_Driving_License
{
    public partial class frmRenewLicense : Form
    {
        private int _NewLicenseID = -1;

        public frmRenewLicense()
        {
            InitializeComponent();
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsLicense NewLicense =
                ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.RenewLicense(txtboxNotes.Text.Trim(),
                clsGlobal.currentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblRenewedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            ctrLocalDrivingLicenseInFOWithFilter1.FilterEnabled = false;
            linklblShowNewLicenseInFo.Enabled = true;

        }

        private void linklblShowNewLicenseInFo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Form frm = new frmShowLocalLicenseDetails(_NewLicenseID))
            {
                frm.ShowDialog();
            }
        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //using (Form frm = new frmShowLicensesHistory(ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID))
            //{
            //    frm.ShowDialog();
            //}
        }

        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            ctrLocalDrivingLicenseInFOWithFilter1.txtLicenseIDFocus();

            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;

            lblExpirationDate.Text = "???";
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblCreatedByUserName.Text = clsGlobal.currentUser.UserName;
        }

        private void ctrLocalDrivingLicenseInFOWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLiceseID.Text = SelectedLicenseID.ToString();

            linklblShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }
            
            int DefaultValidityLength = ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.LicenseClassIfo.DefaultValidityLength;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLength));
            lblLicenseFees.Text = ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.LicenseClassIfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txtboxNotes.Text = ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.Notes;


            //check the license is not Expired.
            if (!ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + clsFormat.DateToShort(ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.ExpirationDate)
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            //check the license is not Active.
            if (!ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
            btnRenew.Enabled = true;
        }

        private void frmRenewLicense_Activated(object sender, EventArgs e)
        {
            ctrLocalDrivingLicenseInFOWithFilter1.Focus();
        }
    }
}