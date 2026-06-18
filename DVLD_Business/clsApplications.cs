using Applications_DataAccess;
using PEOPLE_Business;
using PEOPLE_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications_Business
{
    public class clsApplications
    {
        //(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate,
        //ref int ApplicationTypeID, ref int ApplicationStatus, ref DateTime LastStatusDate, ref int PaidFees, ref int CreatedByUserID)

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ApplicationID { get; set; }

        public int ApplicantPersonID { get; set; }

        public DateTime ApplicationDate { get; set; }

        public int ApplicationTypeID { get; set; }

        public int ApplicationStatus { get; set; }

        public DateTime LastStatusDate { get; set; }

        public int PaidFees { get; set; }

        public int CreatedByUserID { get; set; }

        public clsApplications()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.MinValue;
            ApplicationTypeID = -1;
            ApplicationStatus = -1;
            LastStatusDate = DateTime.MinValue;
            PaidFees = -1;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsApplications(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus, 
                                DateTime LastStatusDate, int PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.Update;
        }

        private bool _AddNewApplication()
        {
            //call DataAccess Layer 

            this.ApplicationID = clsApplicationsData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, 
                this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsApplicationsData.updateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID,
                this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

        }

        public static clsApplications Find(int ApplicationID)
        {
            int ApplicantPersonID = -1, ApplicationTypeID = -1, ApplicantStatus = -1, PaidFees = -1, CreatedByUserID = -1, ApplicationStatus = -1;
            DateTime ApplicationDate = DateTime.MinValue, LastStatusDate = DateTime.MinValue;

            if (clsApplicationsData.GetApplicationInFoByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus,
                                                           ref LastStatusDate, ref PaidFees, ref CreatedByUserID))

                return new clsApplications(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                                                ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }
            return false;
        }

        public static DataTable GetAlApplication()
        {
            return clsApplicationsData.GetAllApplications();
        }

        public static bool isApplicationExist(int ApplicationID)
        {
            return clsApplicationsData.IsApplicationExist(ApplicationID);
        }
    }
}