using Detained_Business;
using DVLD_UI.Global_Classes;
using Licenses_Business;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Detained_Licenses
{
    public partial class frmDetainedLicenses : Form
    {

        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;

        clsDetainedLicense DetainedLicense = new clsDetainedLicense();

        public frmDetainedLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            _DetainID = ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text), clsGlobal.CurrentUser.UserID);
            if (_DetainID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblDetainedID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetain.Enabled = false;
            ctrLocalDrivingLicenseInFOWithFilter1.FilterEnabled = false;
            tctboxFineFees.Enabled = false;
            linklblShowDetainedLicenseInFo.Enabled = true;
        }

        private void frmDetainedLicenses_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUserID.Text = clsGlobal.currentUser.UserName;
        }

        private void ctrLocalDrivingLicenseInFOWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            linklblShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)

            {
                return;
            }

            //ToDo: make sure the license is not detained already.
            if (ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tctboxFineFees.Focus();
            btnDetain.Enabled = true;
        }

        private void frmDetainedLicenses_Activated(object sender, EventArgs e)
        {
            ctrLocalDrivingLicenseInFOWithFilter1.Focus();
        }

        private void tctboxFineFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tctboxFineFees.Text.Trim()))
            {
                errorProvider1.SetError(tctboxFineFees, "Fees cannot be empty");
            }

            else
            {
                errorProvider1.SetError(tctboxFineFees, null);
            }

            if (!clsValidation.IsNumber(tctboxFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tctboxFineFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(tctboxFineFees, null);
            }
        }
    }
}
