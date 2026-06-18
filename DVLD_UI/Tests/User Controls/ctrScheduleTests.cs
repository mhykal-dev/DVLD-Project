using Applications_Business;
using DVLD_UI.Users;
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
using TestAppointments_Business;
using Tests_Business;
using TestTypes_Business;

namespace DVLD_UI.Tests.User_Controls
{
    public partial class ctrScheduleTests : UserControl
    {

        public int LDLAppID { get; set; }

        public int TestTypeID { get; set; }

        public string ClassTypeName { get; set; }

        public string FullName { get; set; }

        public string NationalNo { get; set; }

        public bool Retaken { get; set; }

        clsApplications applications = new clsApplications();

        clsTestAppointments testAppointment = new clsTestAppointments();

        clsTests Test = new clsTests();

        public ctrScheduleTests()
        {          
            InitializeComponent();

            //CheckIfTheTestIsRetaken();

            //DecideHeader();

            //ShowDetails();
           
        }

        public void CheckIfTheTestIsRetaken()
        {
            if(Retaken)
            {
                //(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate,
                //ref int ApplicationTypeID, ref int ApplicationStatus, ref DateTime LastStatusDate, ref int PaidFees, ref int CreatedByUserID)
                
                gbRetakeTest.Enabled = true;

                applications.ApplicantPersonID = clsPeople.GetPersonIDByNationalNo(NationalNo);
                applications.ApplicationDate = dateTimePicker1.Value;
                applications.ApplicationTypeID = 7;
                applications.ApplicationStatus = 1;
                applications.LastStatusDate = dateTimePicker1.Value;
                applications.PaidFees = 15;
                applications.CreatedByUserID = 1;


                lblretakeAppFees.Text = applications.PaidFees.ToString();

            }
        }

        public void DecideHeader()
        {
            string Retake = "";

            if (Retaken)
                Retake = " Retake";


            switch (TestTypeID)
            {
                case 1:
                    {
                        lblHeader.Text = "Schedule" + Retake + " VisionTest";
                        break;
                    }

                case 2:
                    {
                        lblHeader.Text = "Schedule" + Retake + " WrittenTest";
                        break;
                    }

                case 3:
                    {
                        lblHeader.Text = "Schedule" + Retake + " StreetTest";
                        break;
                    }
            }
        }

        public void ShowDetails()
        {
            lblDLAppID.Text = LDLAppID.ToString();
            lblDrivingClassName.Text = ClassTypeName;
            lblFullName.Text = FullName;
            //lblTrial                                 Leve It Empty For Now!.
            lblFees.Text = clsTestTypes.GetTestPriceByID(TestTypeID).ToString();

            int fees1 = Convert.ToInt32(lblFees.Text);
            int fees2 = Convert.ToInt32(applications.PaidFees);
            int fees3 = fees1 + fees2;

            lblTotalFees.Text = fees3.ToString();



            testAppointment.TestTypeID = TestTypeID;
            testAppointment.LocalDrivingLicenseApplicationID = LDLAppID;
            testAppointment.AppointmentDate = dateTimePicker1.Value;
            testAppointment.PaidFees = fees3;
            testAppointment.CreatedByUserID = 1;
            testAppointment.IsLocked = false;
            testAppointment.RetakeTestApplications = applications.ApplicationID;

            Test.TestAppointmentID = testAppointment.TestAppointmentID;
            Test.TestResult = 0;
            Test.CreatedByUserID = 1;
            Test.Notes = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Retaken)
            {
                if(!applications.Save())
                {
                    MessageBox.Show("Error While Saving The Application");
                    return;
                }
            }

            else if(!testAppointment.Save())
            {
                MessageBox.Show("Error While Saving The TestAppointment");
            }

            else if(!Test.Save())
            {
                MessageBox.Show("Error While Saving The Test");
            }

            else
            {
                MessageBox.Show("Data Added!");
            }
        }
    }
}
