using DVLD_UI.Tests.Tests;
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
using TestAppointments_Business;
using Tests_Business;
using TestTypes_Business;

namespace DVLD_UI.Tests.Vision_Test
{
    public partial class frmTestAppointments : Form
    {
        private int _LDLAppID { get; set; }

        private int _TestTypeID { get; set; }

        private string _NationalNo { get; set; }

        private string _ClassTypeName { get; set; }

        private string _FullName { get; set; }

        public frmTestAppointments(int LDLApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _LDLAppID = LDLApplicationID;

            _RefreshPeopleList();

            ctrApplicationsBasicInFo1.LDLApplicationID = LDLApplicationID;

            ctrApplicationsBasicInFo1.ShowDetails();
        }

        private void _RefreshPeopleList()
        {
            dgvTestAppointments.DataSource = clsTestAppointment.GetAllTestsAppointmentsForThisLDLApplicationANDTestType(_LDLAppID, _TestTypeID);
        }

        private void _DecideHeader(int TestTypeID)
        {
            if (TestTypeID == 1)
            {
                lblHeader.Text = "Vision Test";
            }

            else if (TestTypeID == 2)
            {
                lblHeader.Text = "Written Test";
            }

            else
            {
                lblHeader.Text = "Street Test";
            }
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            clsTestAppointment IsThereApreviousTest = clsTestAppointment.GetTheLastestTestAppointmentForThisLDLApplicationANDTestTypeID(_LDLAppID, _TestTypeID);

            if(IsThereApreviousTest != null)
            {
                if(IsThereApreviousTest.IsLocked)
                {
                    clsTest PreviousTest = clsTest.Ge(IsThereApreviousTest.TestAppointmentID);

                    if(PreviousTest.TestResult == 0)
                    {
                        //New Application, With The New TestAppointment.

                        frmScheduleTests frmSheduleTest = new frmScheduleTests(_LDLAppID, _TestTypeID, _ClassTypeName, _FullName, _NationalNo, true);
                        frmSheduleTest.ShowDialog();

                        frmSheduleTest.Dispose();
                        _RefreshPeopleList();

                    }

                    else
                    {
                        MessageBox.Show($"This Person Has Already Passed The Test!, With a TestAppointmentID {IsThereApreviousTest.TestAppointmentID}");
                        return;
                    }
                }

                else
                {
                    MessageBox.Show($"This Person Has Already Have An Open Appointment For The Same Test!, With a TestAppointmentID {IsThereApreviousTest.TestAppointmentID}");
                    return;
                }
            }

            else
            {

                //New Test Appointment Only.(int LDLAppID, int TestTypeID, string ClassTypeName, string FullName, string NationalNo, bool Retaken)

                frmScheduleTests frmSheduleTest = new frmScheduleTests(_LDLAppID, _TestTypeID, _ClassTypeName, _FullName, _NationalNo, false);
                frmSheduleTest.ShowDialog();

                frmSheduleTest.Dispose();
                _RefreshPeopleList();
            }
        }
    }
}