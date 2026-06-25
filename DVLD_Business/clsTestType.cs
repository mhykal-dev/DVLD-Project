using TestTypes_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTypes_Business
{
    public class clsTestType
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public clsTestType.enTestType TestTypeID { set; get; }

        public string TestTypeTitle { get; set; }

        public string TestTypeDescription { get; set; }

        public int TestTypeFees { get; set; }

        public clsTestType()
        {
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = 0;
        }

        private clsTestType(clsTestType.enTestType ID, string TestTypeTitle, string TestTypeDescription, int TestTypeFees)
        {
            this.TestTypeID = ID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }

        public static clsTestType Find(clsTestType.enTestType TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            int TestTypeFees = 0;

            if (clsTestTypeData.GetTestTypeByID((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
            {
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }

            else
            {
                return null;
            }
        }

        private bool _UpdateTestType()
        {
            //call DataAccess Layer 

            return clsTestTypeData.UpdateTestType((int)this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestType();
        }

        public static int GetTestPriceByID(int TestTypeID)
        {
            return clsTestTypeData.GetTestTypeFees(TestTypeID);
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
