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
            clsLocalDrivingLicenseApplications LDLApp = clsLocalDrivingLicenseApplications.FindByID(LDLApplicationID);

            if(LDLApp != null)
            {
                string AppliedForLicense = "";
                int PassedTests = -1;

                if (clsLocalDrivingLicenseApplications.GetLDLApplicationsFromView(LDLApplicationID, ref PassedTests, ref AppliedForLicense))
                {
                    lblLDLAppID.Text = LDLApplicationID.ToString();
                    lblClassName.Text = AppliedForLicense;
                    lblPassedTests.Text = PassedTests.ToString();
                }

                clsApplications Application = clsApplications.Find(LDLApp.ApplicationID);

                if (Application != null)
                {
                    lblID.Text = Application.ApplicationID.ToString();
                    lblStatus.Text = Application.ApplicationStatus.ToString();
                    lblFees.Text = Application.PaidFees.ToString();

                    clsApplicationTypes ApplicationType = clsApplicationTypes.Find(Application.ApplicationTypeID);

                    if (ApplicationType != null)
                    {
                        lblType.Text = ApplicationType.ApplicationTypeTitle;
                    }

                    lblApplicant.Text = clsPeople.GetPersonNameByID(Application.ApplicationID);
                    lblDate.Text = Application.ApplicationDate.ToString();
                    lblStatusDate.Text = Application.ApplicationStatus.ToString();//it's worng Untill i Find A Fix. 
                    lblApplicant.Text = NationalNo;

                    lblCreatedBy.Text = clsUsers.GetUserNameByUserID(Application.CreatedByUserID);
                }
            }
        }

        private void linklblPersonInFo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsPeople PersonInFo = clsPeople.FindByNationalNo(NationalNo);

            if(PersonInFo != null)
            {
                frmPersonCard frm = new frmPersonCard(PersonInFo.PersonID);
                frm.ShowDialog();

                frm.Dispose();
            }
        }
    }
}
