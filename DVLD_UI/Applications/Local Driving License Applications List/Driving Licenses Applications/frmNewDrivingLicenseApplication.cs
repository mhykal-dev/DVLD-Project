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

namespace DVLD_UI.Applications.Local_Driving_License_Applications_List.Driving_Licenses_Applications.Driving_Licenses_Applications
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

            cmbClasses.DataSource = clsLicenseClass.GelAllLicenseClasses();
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
            //if (cmbClasses.SelectedItem is DataRowView row)
            //{
            //    string className = row["ClassName"].ToString();

            //    //int AppID = clsLocalDrivingLicenseApplication.IsPersonHaveThisLicenseApplication(ctrPersonCard1.NationalNo, className);

            //    //if (AppID != -1)
            //    //{
            //    //    clsLocalDrivingLicenseApplication ThisApplication = clsLocalDrivingLicenseApplication.FindByID(AppID);

            //    //    if(ThisApplication != null)
            //    //    {
            //    //        string Status = clsLocalDrivingLicenseApplication.GetApplicationLastStatus(AppID);

            //    //        switch(Status)
            //    //        {
            //    //            case "New":
            //    //                MessageBox.Show($"You Already Have an Applications For This License With ID = {AppID}");
            //    //                return;

            //    //            case "Completed":
            //    //                MessageBox.Show($"You Already Have an Applications For This License With ID = {AppID}");
            //    //                return;

            //    //            case "Cancelled":
            //    //                break;
            //    //        }
            //    //    }
            //    //}

                //else
                //{

                //    clsApplication NewApplication = new clsApplication();

                //    NewApplication.ApplicantPersonID = ctrPersonCard1.PersonID;
                //    NewApplication.ApplicationDate   = Convert.ToDateTime(lblApplicationDate.Text);
                //    NewApplication.ApplicationTypeID = 1;
                //    NewApplication.ApplicationStatus = 1;
                //    NewApplication.LastStatusDate    = Convert.ToDateTime(lblApplicationDate.Text);
                //    //NewApplication.PaidFees          = (int)lblFees.Text);
                //    NewApplication.CreatedByUserID   = 1;//This Will Remain HardCoded Until I Add The Global User.

                //    if(NewApplication.Save())
                //    {
                //        clsLocalDrivingLicenseApplication NewLocalDrivingApplication = new clsLocalDrivingLicenseApplication();
                //        NewLocalDrivingApplication.ApplicationID = NewApplication.ApplicationID;
                //        NewLocalDrivingApplication.LicenseClassID = (int)cmbClasses.SelectedValue);

                //        if(NewLocalDrivingApplication.Save())
                //        {
                //            MessageBox.Show("Added!");
                //            lblID.Text = NewApplication.ApplicationID.ToString();
                //        }
                //    }

                //    else
                //    {
                //        MessageBox.Show("Another Error😭😭😭😭😭😭😭😭😭😭😭😭");
                //    }
                //}
        }
    }
}

//MessageBox.Show($"This Person Is Already Have An Active Application With ID = {AppID}");
//return;
