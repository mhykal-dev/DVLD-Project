using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COUNTRIES_DataAccess;

namespace COUNTRIES_Business
{
    public class clsCountries
    {      

        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetAllCountries();
        }

    }
}
