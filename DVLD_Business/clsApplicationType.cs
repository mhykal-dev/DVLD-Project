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
    public class clsApplicationType
    {
        public int ApplicationTypeID { get; set; }

        public string ApplicationTypeTitle { get; set; }

        public int ApplicationFees { get; set; }

        public clsApplicationType()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = "";
            ApplicationFees = 0;
        }

        private clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, int ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            int ApplicationFees = 0;

            if(clsApplicationsTypeData.GetApplicatinTypeByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
            {
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            }

            else
            {
                return null;
            }
        }

        private bool _UpdateApplicationType()
        {
            //call DataAccess Layer 

            return clsApplicationsTypeData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);

        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationsTypeData.GetAllApplicatinsType();
        }

        public static int GetApplicatinTypePrice(int ApplicationTypeID)
        {
            return clsApplicationsTypeData.GetApplicatinTypePrice(ApplicationTypeID);
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
