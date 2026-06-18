using LDLApplications_DataAccess;
using PEOPLE_Business;
using PEOPLE_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDLApplications_Business
{
    public class clsLocalDrivingLicenseApplications
    {
        public int LocalDrivingLicenseApplicationID { get; set; }

        public int ApplicationID { get; set; }

        public int LicenseClassID { get; set; }

        public clsLocalDrivingLicenseApplications()
        {
            LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
        }

        private clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }

        private bool _AddNewApplication()
        {
            //call DataAccess Layer 

            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsData.AddNewLDLApplication(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        public static clsLocalDrivingLicenseApplications FindByID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationsData.GetDLApplicationByLDLID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))

                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplications FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationsData.GetDLApplicationByApplicationID(ref LocalDrivingLicenseApplicationID, ApplicationID, ref LicenseClassID))

                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplications FindByClassID(int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1, ApplicationID = -1;

            if (clsLocalDrivingLicenseApplicationsData.GetDLApplicationByLicenseClassID(ref LocalDrivingLicenseApplicationID, ref ApplicationID, LicenseClassID))

                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
            else
                return null;
        }

        public static int IsPersonHaveThisLicenseApplication(string NationalNo, string ClassName)
        {
            return clsLocalDrivingLicenseApplicationsData.IsPersonHaveThisLicenseApplication(NationalNo, ClassName);
        }

        public static string GetApplicationLastStatus(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsData.GetLDLApplicationLastStatus(LocalDrivingLicenseApplicationID);
        }

        public static DataTable GetAllLDLApplications()
        {
            return clsLocalDrivingLicenseApplicationsData.GetLLApplications();
        }

        public static DataTable GetAllLDLApplicationsByFilter(string KeyWord, string Value)
        {
            return clsLocalDrivingLicenseApplicationsData.GetLDLApplicationsByFilter(KeyWord, Value);
        }

        public static bool GetLDLApplicationsFromView(int LocalDrivingLicenseApplicationID, ref int PassedTestCount, ref string ClassName)
        {
            if(clsLocalDrivingLicenseApplicationsData.GetDLApplicationByLDLIDFromView(LocalDrivingLicenseApplicationID, ref PassedTestCount, ref ClassName))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool Save()
        {
            if(_AddNewApplication())
            {
                return true;
            }

            return false;
        }
    }
}