using COUNTRIES_Business;
using Applications_Business;
using LDLApplications_Business;
using LicenseClasses_Business;
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

namespace DVLD_UI.Driving_Licenses_Applications
{
    public partial class frmNewDrivingLicenseApplication : Form
    {
        bool AllowChange = false;

        public frmNewDrivingLicenseApplication()
        {
            InitializeComponent();

            _LoadClasses();
        }

        private void _LoadClasses()
        {
            cmbClasses.DisplayMember = "ClassName";
            cmbClasses.ValueMember = "LicenseClassID";

            cmbClasses.DataSource = clsLicenseClasses.GelAllLicenseClasses();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!(clsPerson.isPersonExist(ctrPersonCard1.PersonID)))
            {
                MessageBox.Show("This Person Dosen't Exist!");
                AllowChange = false;
            }

            else
            {
                AllowChange = true;
                tabControl1.SelectedTab = tabPage2;
                AllowChange = false;
                lblApplicationDate.Text = DateTime.Now.ToString();
                lblCreatedBy.Text = "Msaqer77";
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!AllowChange)
            {
                e.Cancel = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbClasses.SelectedItem is DataRowView row)
            {
                string className = row["ClassName"].ToString();

                int AppID = clsLocalDrivingLicenseApplications.IsPersonHaveThisLicenseApplication(ctrPersonCard1.NationalNo, className);

                if (AppID != -1)
                {
                    clsLocalDrivingLicenseApplications ThisApplication = clsLocalDrivingLicenseApplications.FindByID(AppID);

                    if(ThisApplication != null)
                    {
                        string Status = clsLocalDrivingLicenseApplications.GetApplicationLastStatus(AppID);

                        switch(Status)
                        {
                            case "New":
                                MessageBox.Show($"You Already Have an Applications For This License With ID = {AppID}");
                                return;

                            case "Completed":
                                MessageBox.Show($"You Already Have an Applications For This License With ID = {AppID}");
                                return;

                            case "Cancelled":
                                break;
                        }
                    }
                }

                else
                {

                    clsApplications NewApplication = new clsApplications();

                    NewApplication.ApplicantPersonID = ctrPersonCard1.PersonID;
                    NewApplication.ApplicationDate   = Convert.ToDateTime(lblApplicationDate.Text);
                    NewApplication.ApplicationTypeID = 1;
                    NewApplication.ApplicationStatus = 1;
                    NewApplication.LastStatusDate    = Convert.ToDateTime(lblApplicationDate.Text);
                    NewApplication.PaidFees          = Convert.ToInt32(lblFees.Text);
                    NewApplication.CreatedByUserID   = 1;//This Will Remain HardCoded Until I Add The Global User.

                    if(NewApplication.Save())
                    {
                        clsLocalDrivingLicenseApplications NewLocalDrivingApplication = new clsLocalDrivingLicenseApplications();
                        NewLocalDrivingApplication.ApplicationID = NewApplication.ApplicationID;
                        NewLocalDrivingApplication.LicenseClassID = Convert.ToInt32(cmbClasses.SelectedValue);

                        if(NewLocalDrivingApplication.Save())
                        {
                            MessageBox.Show("Added!");
                            lblID.Text = NewApplication.ApplicationID.ToString();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Another Error😭😭😭😭😭😭😭😭😭😭😭😭");
                    }
                }
            }
        }
    }
}

//MessageBox.Show($"This Person Is Already Have An Active Application With ID = {AppID}");
//return;
