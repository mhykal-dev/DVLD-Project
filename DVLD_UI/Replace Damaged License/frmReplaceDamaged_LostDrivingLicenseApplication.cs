using Applications_Business;
using ApplicationTypes_Business;
using Drivers_Business;
using DVLD_UI.Local_Driving_License_Applications_List;
using LicenseClasses_Business;
using Licenses_Business;
using PEOPLE_Business;
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

namespace DVLD_UI.frmReplaceDamaged_LostDrivingLicenseApplication
{
    public partial class frmReplaceLicense : Form
    {
        clsLicenses oldlicense = new clsLicenses();

        clsLicenses NewLicense = new clsLicenses();

        clsApplications application = new clsApplications();

        clsPeople Person = new clsPeople();

        clsDrivers Driver = new clsDrivers();

        public frmReplaceLicense()
        {
            InitializeComponent();

            ctrDrivingLicenseWithFilters1.DataBack += _ShowApplicationDetails;
        }

        private void _ShowApplicationDetails(object sender, int LicenseID, DateTime ExpirationDate, int DriverID, int IsActive)
        {
            oldlicense = clsLicenses.FindByLicenseID(LicenseID);

            Driver = clsDrivers.FindByDriverID(DriverID);

            Person = clsPeople.Find(Driver.PersonID);

            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();

            if (rdbtnDamaged.Checked)
            {
                lblApplicationFees.Text = clsApplicationTypes.GetApplicatinTypePrice(4).ToString();
            }

            else
            {
                lblApplicationFees.Text = clsApplicationTypes.GetApplicatinTypePrice(3).ToString();
            }
            
            int LicFees = clsLicenseClasses.GetClassFees(oldlicense.LicenseClass);
            int APPFees = Convert.ToInt32(lblApplicationFees.Text);
            int Total   = APPFees + LicFees;

            lblLicenseFees.Text = LicFees.ToString();
            lblTotalFees.Text = Total.ToString();

            lblOldLiceseID.Text = LicenseID.ToString();
            lblExpirationDate.Text = ExpirationDate.ToString();
            lblCreatedByUserName.Text = clsUsers.GetUserNameByUserID(1);
        }

        private void _LoadApplication()
        {
            application.ApplicantPersonID = Person.PersonID;
            application.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);

            if (rdbtnDamaged.Checked)
            {
                application.ApplicationTypeID = 4;
            }

            else
            {
                application.ApplicationTypeID = 3;
            }
           
            application.ApplicationStatus = 1;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = clsApplicationTypes.GetApplicatinTypePrice(2);
            application.CreatedByUserID = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {

            if(oldlicense.IsActive == 0)
            {
                MessageBox.Show("This License Is No Longer Active And Can't be Used!");
                return;
            }

            else
            {
                _LoadApplication();

                if (!application.Save())
                {
                    MessageBox.Show("Application didn't Save!");
                    return;
                }

                lblApplicationID.Text = application.ApplicationID.ToString();

                oldlicense.IsActive = 0;

                if (!oldlicense.Save())
                {
                    MessageBox.Show("OldLicense didn't Save!");
                    return;
                }

                NewLicense.ApplicationID = application.ApplicationID;
                NewLicense.DriverID = oldlicense.DriverID;
                NewLicense.LicenseClass = oldlicense.LicenseClass;
                NewLicense.IssueDate = DateTime.Now;
                NewLicense.ExpirationDate = DateTime.Now.AddYears(10);
                NewLicense.Notes = txtboxNotes.Text;
                NewLicense.PaidFees = Convert.ToInt32(lblTotalFees.Text);

                if (rdbtnDamaged.Checked)
                {
                    NewLicense.IssueReason = 3;
                }

                else
                {
                    NewLicense.IssueReason = 4;
                }

                NewLicense.IsActive = 1;
                NewLicense.CreatedByUserID = 1;

                if(!NewLicense.Save())
                {
                    MessageBox.Show("NewLicense didn't Save!");
                    return;
                }

                lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();

                MessageBox.Show("License Replaced!");
                linklblShowNewLicenseInFo.Enabled = true;
            }             
        }

        private void linklblShowNewLicenseInFo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLocalLicenseDetails frm = new frmShowLocalLicenseDetails(NewLicense.LicenseID);
            frm.ShowDialog();

            frm.Dispose();
        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicensesHistory frm = new frmShowLicensesHistory(Person.PersonID);
            frm.ShowDialog();

            frm.Dispose();
        }

        private void rdbtnDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnDamaged.Checked)
            {
                lblApplicationFees.Text = clsApplicationTypes.GetApplicatinTypePrice(4).ToString();
            }

            else
            {
                lblApplicationFees.Text = clsApplicationTypes.GetApplicatinTypePrice(3).ToString();
            }

            if (rdbtnDamaged.Checked)
            {
                application.ApplicationTypeID = 4;
            }

            else
            {
                application.ApplicationTypeID = 3;
            }

            if (rdbtnDamaged.Checked)
            {
                NewLicense.IssueReason = 3;
            }

            else
            {
                NewLicense.IssueReason = 4;
            }
        }

        private void rdbtnLost_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnDamaged.Checked)
            {
                lblApplicationFees.Text = clsApplicationTypes.GetApplicatinTypePrice(4).ToString();
            }

            else
            {
                lblApplicationFees.Text = clsApplicationTypes.GetApplicatinTypePrice(3).ToString();
            }

            if (rdbtnDamaged.Checked)
            {
                application.ApplicationTypeID = 4;
            }

            else
            {
                application.ApplicationTypeID = 3;
            }

            if (rdbtnDamaged.Checked)
            {
                NewLicense.IssueReason = 3;
            }

            else
            {
                NewLicense.IssueReason = 4;
            }
        }
    }
}