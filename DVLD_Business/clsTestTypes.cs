using TestTypes_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTypes_Business
{
    public class clsTestTypes
    {
        public int TestTypeID { get; set; }

        public string TestTypeTitle { get; set; }

        public string TestTypeDescription { get; set; }

        public int TestTypeFees { get; set; }

        public clsTestTypes()
        {
            TestTypeID = -1;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = 0;
        }

        private clsTestTypes(int TestTypeID, string TestTypeTitle, string TestTypeDescription, int TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }

        public static clsTestTypes Find(int TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            int TestTypeFees = 0;

            if (clsTestTypesData.GetTestTypeByID(TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
            {
                return new clsTestTypes(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }

            else
            {
                return null;
            }
        }

        private bool _UpdateTestType()
        {
            //call DataAccess Layer 

            return clsTestTypesData.UpdateTestType(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestType();
        }

        public static int GetTestPriceByID(int TestTypeID)
        {
            return clsTestTypesData.GetTestTypeFees(TestTypeID);
        }

        public bool Save()
        {
            if (_UpdateTestType())
            {
                return true;
            }

            return false;
        }
    }

}
