using ApplicationTypes_DataAccess;
using PEOPLE_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApplicationTypes_Business
{
    public class clsApplicationTypes
    {
        public int ApplicationTypeID { get; set; }

        public string ApplicationTypeTitle { get; set; }

        public int ApplicationFees { get; set; }

        public clsApplicationTypes()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = "";
            ApplicationFees = 0;
        }

        private clsApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle, int ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
        }

        public static clsApplicationTypes Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            int ApplicationFees = 0;

            if(clsApplicationsTypesData.GetApplicatinTypeByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
            {
                return new clsApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            }

            else
            {
                return null;
            }
        }

        private bool _UpdateApplicationType()
        {
            //call DataAccess Layer 

            return clsApplicationsTypesData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);

        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationsTypesData.GetAllApplicatinsType();
        }

        public static int GetApplicatinTypePrice(int ApplicationTypeID)
        {
            return clsApplicationsTypesData.GetApplicatinTypePrice(ApplicationTypeID);
        }

        public bool Save()
        {
            if(_UpdateApplicationType())
            {
                return true;
            }

            return false;
        }
    }
}
