using Detained_Business;
using DVLD_UI.Global_Classes;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Detained_Licenses
{
    public partial class frmDetainedLicenses : Form
    {

        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;

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
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Please, recheck the input information once again");
                return;
            }

            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _DetainID = ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtboxFineFees.Text), clsGlobal.currentUser.UserID);
            if (_DetainID == -1)
            {
                MessageBox.Show("Failed to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDetainedID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetain.Enabled = false;
            ctrLocalDrivingLicenseInFOWithFilter1.FilterEnabled = false;
            txtboxFineFees.Enabled = false;
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
                btnDetain.Enabled = false;
                return;
            }

            //ToDo: make sure the license is not detained already.
            if (ctrLocalDrivingLicenseInFOWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

            txtboxFineFees.Focus();
            btnDetain.Enabled = true;
        }

        private void frmDetainedLicenses_Activated(object sender, EventArgs e)
        {
            ctrLocalDrivingLicenseInFOWithFilter1.Focus();
        }

        private void txtboxFineFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxFineFees, "Fees cannot be empty");
                return;
            }

            if (!clsValidation.IsNumber(txtboxFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxFineFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtboxFineFees, null);
            }
        }
    }
}
