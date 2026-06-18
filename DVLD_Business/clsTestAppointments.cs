using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TestAppointments_DataAccess;

namespace TestAppointments_Business
{
    public class clsTestAppointments
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }

        public int TestTypeID { get; set; }

        public int LocalDrivingLicenseApplicationID { get; set; }

        public DateTime AppointmentDate { get; set; }

        public int PaidFees { get; set; }

        public int CreatedByUserID { get; set; }

        public bool IsLocked { get; set; }

        public int RetakeTestApplications { get; set; }

        public clsTestAppointments()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.MinValue;
            PaidFees = -1;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplications = -1;

            Mode = enMode.AddNew;
        }

        private clsTestAppointments(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
                 DateTime AppointmentDate, int PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplications)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplications = RetakeTestApplications;

            Mode = enMode.Update;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                                                                                   this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplications);

            return (this.TestAppointmentID > -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsData.UpdateTestAppointmentIsLocked(this.TestAppointmentID, this.IsLocked);
        }

        public static clsTestAppointments FindByTestAppointmentID(int TestAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            int PaidFees = -1, CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplications = -1;

            if (clsTestAppointmentsData.GetTestAppointmentByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate, 
                                                                  ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplications))
            {
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplications);
            }

            else
            {
                return null;
            }
        }

        public static clsTestAppointments GetTestAppointmentsByLDLApplicationANDTestTypeID(int TestAppointmentID, int TestTypeID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            int PaidFees = -1, CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplications = -1;

            if (clsTestAppointmentsData.GetTestAppointmentByLDLApplicationANDTestTypeID(TestAppointmentID, TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate,
                                                                  ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplications))
            {
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplications);
            }

            else
            {
                return null;
            }
        }

        public static DataTable GetAllTestsAppointmentsForThisLDLApplicationANDTestType(int LocalDrivingLicenseApplicationID, int TestType)
        {
            return clsTestAppointmentsData.GetAllTestsAppointmentsForThisLDLApplicationANDTestType(LocalDrivingLicenseApplicationID, TestType);
        }

        public static DataTable GetAllTestsAppointmentsForThisLDLApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsTestAppointmentsData.GetAllTestsAppointmentsForThisLDLApplication(LocalDrivingLicenseApplicationID);
        }

        public static clsTestAppointments GetTheLastestTestAppointmentForThisLDLApplicationANDTestTypeID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            int TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            int PaidFees = -1, CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplications = -1;

            if (clsTestAppointmentsData.GetTheLastestTestAppointmentForThisLDLApplicationANDTestTypeID(ref TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, 
                                        ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplications))
            {
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                 AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplications);
            }

            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewTestAppointment())
                        {
                            Mode = enMode.Update;
                            return true;
                        }

                        else
                        {
                            return false;
                        }
                    }

                    case enMode.Update:
                    {
                        return _UpdateTestAppointment();
                    }
            }

            return false;
        }
    }
}
