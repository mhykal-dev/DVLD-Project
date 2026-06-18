using LicenseClasses_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseClasses_Business
{
    public class clsLicenseClasses
    {
        public static DataTable GelAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }

        public static DataTable GelAllLicenseClassesFrocmb()
        {
            return clsLicenseClassesData.GetAllLicenseClassesForcmb();
        }

        public static int GetClassFees(int ClassID)
        {
            return clsLicenseClassesData.GetClassFees(ClassID);
        }

        public static string GetClassName(int LicenseClassID)
        {
            return clsLicenseClassesData.GetClassTypeName(LicenseClassID);
        }

    }
}
