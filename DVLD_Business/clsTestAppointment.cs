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
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }

        public int TestTypeID { get; set; }

        public int LocalDrivingLicenseApplicationID { get; set; }

        public DateTime AppointmentDate { get; set; }

        public float PaidFees { get; set; }

        public int CreatedByUserID { get; set; }

        public bool IsLocked { get; set; }

        public int RetakeTestApplications { get; set; }

        public clsTestAppointment()
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

        private clsTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
                 DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplications)
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
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                                                                                   this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplications);

            return (this.TestAppointmentID > -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointmentIsLocked(this.TestAppointmentID, this.IsLocked);
        }

        public static clsTestAppointment FindByTestAppointmentID(int TestAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            float PaidFees = -1;
            bool IsLocked = false;
            int RetakeTestApplications = -1;

            if (clsTestAppointmentData.GetTestAppointmentByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate, 
                                                                  ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplications))
            {
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplications);
            }

            else
            {
                return null;
            }
        }

        public static clsTestAppointment GetTestAppointmentsByLDLApplicationANDTestTypeID(int TestAppointmentID, int TestTypeID)
        {
            int LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            float PaidFees = -1;
            bool IsLocked = false;
            int RetakeTestApplications = -1;

            if (clsTestAppointmentData.GetTestAppointmentByLDLApplicationANDTestTypeID(TestAppointmentID, TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate,
                                                                  ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplications))
            {
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplications);
            }

            else
            {
                return null;
            }
        }

        public static DataTable GetAllTestsAppointmentsForThisLDLApplicationANDTestType(int LocalDrivingLicenseApplicationID, int TestType)
        {
            return clsTestAppointmentData.GetAllTestsAppointmentsForThisLDLApplicationANDTestType(LocalDrivingLicenseApplicationID, TestType);
        }

        public static DataTable GetAllTestsAppointmentsForThisLDLApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsTestAppointmentData.GetAllTestsAppointmentsForThisLDLApplication(LocalDrivingLicenseApplicationID);
        }

        public static clsTestAppointment GetTheLastestTestAppointmentForThisLDLApplicationANDTestTypeID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            int TestAppointmentID = -1, CreatedByUserID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            float PaidFees = -1;
            bool IsLocked = false;
            int RetakeTestApplications = -1;

            if (clsTestAppointmentData.GetTheLastestTestAppointmentForThisLDLApplicationANDTestTypeID(ref TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, 
                                        ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplications))
            {
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
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
