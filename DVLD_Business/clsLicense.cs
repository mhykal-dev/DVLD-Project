using Licenses_DataAccess;
using PEOPLE_Business;
using PEOPLE_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenses_Business
{
    public class clsLicense
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int LicenseClass { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }
        public float PaidFees { set; get; }
        public int IsActive { set; get; }
        public int IssueReason { set; get; }
        public int CreatedByUserID { set; get; }

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClass = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = -1;
            IsActive =  0;
            IssueReason = -1;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID,
            int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes,
            float PaidFees, int IsActive, int IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.LicenseID = clsLicensesData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate,
                this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive,
                this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsLicensesData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate,
                this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive,
                this.IssueReason, this.CreatedByUserID);

        }

        public static clsLicense FindByLicenseID(int ID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClass = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = -1;
            int IsActive = -1;
            int IssueReason = -1;
            int CreatedByUserID = -1;

            if (clsLicensesData.GetLicenseInFoByID(ID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate,
                          ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicense(ID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                          Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            else
                return null;
        }

        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int LicenseID = -1, DriverID = -1, LicenseClass = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = -1;
            int IsActive = -1;
            int IssueReason = -1;
            int CreatedByUserID = -1;

            if (clsLicensesData.GetLicenseInFoByApplicationID(ref LicenseID, ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate,
                          ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                          Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }




            return false;
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicensesData.GetAllLicense();

        }

        public static DataTable GetAllLicensesForThisDriver(int DriverID)
        {
            return clsLicensesData.GetAllLicensesForThisDriver(DriverID);

        }
    }
}
