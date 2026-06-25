
using InternationalLicense_DataAccess;
using Licenses_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalLicenses_Business
{
    public class clsInternationalLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int InternationalLicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public int IsActive { set; get; }
        public int CreatedByUserID { set; get; }

        public clsInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = 0;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID,
            int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, int IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.InternationalLicenseID = clsInternationalLicenseData.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate,
                this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsInternationalLicenseData.UpdateInternationalLicense(this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate,
                this.ExpirationDate, this.IsActive, this.CreatedByUserID);

        }

        public static clsInternationalLicense FindByInternationalLicenseID(int ID)
        {
            int ApplicationID = -1, DriverID = -1, IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            int IsActive = -1;
            int CreatedByUserID = -1;

            if (clsInternationalLicenseData.GetInternationalLicenseInFoByID(ID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))

                return new clsInternationalLicense(ID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            else
                return null;
        }

        public static clsInternationalLicense FindByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1, ApplicationID = -1, IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            int IsActive = -1;
            int CreatedByUserID = -1;

            if (clsInternationalLicenseData.GetInternationalLicenseInFoByDriverID(ref InternationalLicenseID, ref ApplicationID, DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))

                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            else
                return null;
        }

        public static clsInternationalLicense FindByApplicationID(int ApplicationID)
        {
            int InternationalLicenseID = -1, DriverID = -1, IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = -1;
            int IsActive = -1;
            string IssueReason = "";
            int CreatedByUserID = -1;

            if (clsInternationalLicenseData.GetInternationalLicenseInFoByApplicationID(ref InternationalLicenseID, ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))

                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
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

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicense();

        }

        public static int IsThereInternationalLicenseForThisLocalLicense(int LicenseID)
        {
            return clsInternationalLicenseData.IsThereInternationalLicenseForThisLocalLicense(LicenseID);

        }

        public static DataTable GetAllLicensesForThisDriver(int DriverID)
        {
            return clsInternationalLicenseData.GetAllLicensesForThisDriver(DriverID);

        }

    }
}
