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
        public int TypeID { get; set; }

        public string Title { get; set; }

        public int Fees { get; set; }

        public clsApplicationType()
        {
            TypeID = -1;
            Title = "";
            Fees = 0;
        }

        private clsApplicationType(int TypeID, string Title, int Fees)
        {
            this.TypeID = TypeID;
            this.Title = Title;
            this.Fees = Fees;
        }

        public static clsApplicationType Find(int TypeID)
        {
            string Title = "";
            int Fees = 0;

            if(clsApplicationsTypeData.GetApplicatinTypeByID(TypeID, ref Title, ref Fees))
            {
                return new clsApplicationType(TypeID, Title, Fees);
            }

            else
            {
                return null;
            }
        }

        private bool _UpdateApplicationType()
        {
            //call DataAccess Layer 

            return clsApplicationsTypeData.UpdateApplicationType(this.TypeID, this.Title, this.Fees);

        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationsTypeData.GetAllApplicatinsType();
        }

        public static int GetApplicatinTypePrice(int TypeID)
        {
            return clsApplicationsTypeData.GetApplicatinTypePrice(TypeID);
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
