using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests_DataAccess;

namespace Tests_Business
{
    public class clsTests
    {
        public int TestID { get; set; }

        public int TestAppointmentID { get; set; }

        public int TestResult {  get; set; }

        public string Notes { get; set; }

        public int CreatedByUserID { get; set; }

        public clsTests()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = -1;
            Notes = "";
            CreatedByUserID = -1;
        }

        private clsTests(int TestID, int TestAppointmentID, int TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
        }

        public static clsTests GetTestByTestID(int TestID)
        {
            int TestAppointmentID = -1, TestResult = -1;
            string Notes = "";
            int CreatedByUserID = -1;

            if (clsTestsData.GetTestByTestID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTests(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }

            else
            {
                return null;
            }
        }

        public static clsTests GetTestByTestAppointmentID(int TestAppointmentID)
        {
            int TestID = -1, TestResult = -1;
            string Notes = "";
            int CreatedByUserID = -1;

            if (clsTestsData.GetTestByAppointmentID(ref TestID, TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTests(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }

            else
            {
                return null;
            }
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestsData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

            return (this.TestID != -1);
        }

        public static DataTable GetAllTests()
        {
            return clsTestsData.GetAllTests();
        }

        public bool Save()
        {
            return (_AddNewTest());
        }

    }
}