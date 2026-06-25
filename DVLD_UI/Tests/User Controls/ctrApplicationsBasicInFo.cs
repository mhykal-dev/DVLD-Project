using Applications_Business;
using ApplicationTypes_Business;
using DVLD_UI.People;
using DVLD_UI.Users;
using LDLApplications_Business;
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

namespace DVLD_UI.Tests.User_Controls
{
    public partial class ctrApplicationsBasicInFo : UserControl
    {
        public int LDLApplicationID { get; set; }

        public string NationalNo { get; set; }

        public ctrApplicationsBasicInFo()
        {
            InitializeComponent();
        }

        public void ShowDetails()
        {
            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLApplicationID);

            //if(LDLApp != null)
            //{
            //    string AppliedForLicense = "";
            //    int PassedTests = -1;

            //    if (clsLocalDrivingLicenseApplication.GetLDLApplicationsFromView(LDLApplicationID, ref PassedTests, ref AppliedForLicense))
            //    {
            //        lblLDLAppID.Text = LDLApplicationID.ToString();
            //        lblClassName.Text = AppliedForLicense;
            //        lblPassedTests.Text = PassedTests.ToString();
            //    }

            //    clsApplication Application = clsApplication.Find(LDLApp.ApplicationID);

            //    if (Application != null)
            //    {
            //        lblID.Text = Application.ApplicationID.ToString();
            //        lblStatus.Text = Application.ApplicationStatus.ToString();
            //        lblFees.Text = Application.PaidFees.ToString();

            //        clsApplicationType ApplicationType = clsApplicationType.Find(Application.ApplicationTypeID);

            //        if (ApplicationType != null)
            //        {
            //            lblType.Text = ApplicationType.ApplicationTypeTitle;
            //        }

            //        lblApplicant.Text = clsPerson.GetPersonNameByID(Application.ApplicationID);
            //        lblDate.Text = Application.ApplicationDate.ToString();
            //        lblStatusDate.Text = Application.ApplicationStatus.ToString();//it's worng Untill i Find A Fix. 
            //        lblApplicant.Text = NationalNo;

            //        //lblCreatedBy.Text = clsUser.GetUserNameByUserID(Application.CreatedByUserID);
            //    }
            //}
        }

        private void linklblPersonInFo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsPerson PersonInFo = clsPerson.Find(NationalNo);

            if(PersonInFo != null)
            {
                frmShowPersonInFo frm = new frmShowPersonInFo(PersonInFo.PersonID);
                frm.ShowDialog();

                frm.Dispose();
            }
        }
    }
}
