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

        public string Title { get; set; }

        public string Description { get; set; }

        public int Fees { get; set; }

        public clsTestType()
        {
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            Title = "";
            Description = "";
            Fees = 0;
        }

        private clsTestType(clsTestType.enTestType ID, string Title, string Description, int Fees)
        {
            this.TestTypeID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }

        public static clsTestType Find(clsTestType.enTestType TestTypeID)
        {
            string Title = "", Description = "";
            int Fees = 0;

            if (clsTestTypeData.GetTestTypeByID((int)TestTypeID, ref Title, ref Description, ref Fees))
            {
                return new clsTestType(TestTypeID, Title, Description, Fees);
            }

            else
            {
                return null;
            }
        }

        private bool _UpdateTestType()
        {
            //call DataAccess Layer 

            return clsTestTypeData.UpdateTestType((int)this.TestTypeID, this.Title, this.Description, this.Fees);

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
