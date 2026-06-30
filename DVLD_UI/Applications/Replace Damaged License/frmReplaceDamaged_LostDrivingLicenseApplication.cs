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
using static Licenses_Business.clsLicense;

namespace DVLD_UI.frmReplaceDamaged_LostDrivingLicenseApplication
{
    public partial class frmReplaceLicense : Form
    {
        private int _NewLicenseID = -1;

        public frmReplaceLicense()
        {
            InitializeComponent();
        }

        private int _GetApplicationTypeID()
        {
            //this will decide which application type to use accirding 
            // to user selection.

            if (rdbtnDamaged.Checked)

                return (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }

        private enIssueReason _GetIssueReason()
        {
            //this will decide which reason to issue a replacement for

            if (rdbtnDamaged.Checked)

                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            using (Form frm = new frmShowLicensesHistory(ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID))
            {
                frm.ShowDialog();
            }
        }

        private void rdbtnDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for Damaged License";
            this.Text = lblTitle.Text;
            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).Fees.ToString();
        }

        private void rdbtnLost_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for Lost License";
            this.Text = lblTitle.Text;
            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).Fees.ToString();
        }

        private void frmReplaceLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUserName.Text = clsGlobal.currentUser.UserName;

            rdbtnDamaged.Checked = true;
        }

        private void frmReplaceLicense_Activated(object sender, EventArgs e)
        {
            ctrLocalDrivingLicenseInFOWithFilter1.Focus();
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

            //dont allow a replacement if is Active .
            if (!ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReplacement.Enabled = false;
                return;
            }

            btnReplacement.Enabled = true;
        }

        private void btnReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicense =
               ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(),
               clsGlobal.currentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;

            lblRenewedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnReplacement.Enabled = false;
            gbReplacementFor.Enabled = false;
            ctrLocalDrivingLicenseInFOWithFilter1.FilterEnabled = false;
            linklblShowNewLicenseInFo.Enabled = true;
        }
    }
}