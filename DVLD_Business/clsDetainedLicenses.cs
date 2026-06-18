using DetainedLicenses_DataAccess;
using Licenses_Business;
using Licenses_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detained_Business
{
    public class clsDetainedLicenses
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DetainID { set; get; }
        public int LicenseID { set; get; }
        public DateTime DetainDate { set; get; }
        public int FineFees { set; get; }
        public int CreatedByUserID { set; get; }
        public int IsReleased { set; get; }
        public DateTime ReleaseDate { set; get; }
        public int ReleasedByUserID { set; get; }
        public int ReleaseApplicationID { set; get; }

        public clsDetainedLicenses()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.MinValue;
            FineFees = -1;
            CreatedByUserID = -1;
            IsReleased = -1;
            ReleaseDate = DateTime.MinValue;
            ReleasedByUserID = -1;
            ReleaseApplicationID = 0;

            Mode = enMode.AddNew;
        }

        private clsDetainedLicenses(int DetainID, int LicenseID, DateTime DetainDate,
            int FineFees, int CreatedByUserID, int IsReleased, DateTime ReleaseDate,
            int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.DetainID = clsDetainedLicensesData.AddNewLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID,
                this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);

            return (this.DetainID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsDetainedLicensesData.UpdateLicense(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID,
                this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);

        }

        public static clsDetainedLicenses FindByDetainID(int DetainID)
        {
            int LicenseID = -1, FineFees = -1;
            int CreatedByUserID = -1, IsReleased = -1;
            DateTime ReleaseDate = DateTime.MinValue, DetainDate = DateTime.MinValue;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;

            if (clsDetainedLicensesData.GetDetainedLicenseInFoByDetainedID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased,
                          ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                          ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            else
                return null;
        }

        public static clsDetainedLicenses FindByLicenseID(int LicenseID)
        {
            int DetainID = -1, IsReleased = -1, FineFees = -1;
            DateTime ReleaseDate = DateTime.Now, DetainDate = DateTime.Now;
            int CreatedByUserID = -1;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;

            if (clsDetainedLicensesData.GetDetainedLicenseInFoByLicenseID(ref DetainID, LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased,
                          ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                          ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
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
            return clsDetainedLicensesData.GetAllDetainedLicenses();

        }

        public static DataTable GetAllLicensesForThisDriver(DateTime DetainDate)
        {
            return clsDetainedLicensesData.GetAllDetainedLicensesForThisDetainDate(DetainDate);

        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicensesData.IsLicenseDetained(LicenseID);

        }
    }
}