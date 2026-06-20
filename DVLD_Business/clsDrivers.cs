using Drivers_DataAccess;
using Drivers_Business;
using Drivers_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PEOPLE_Business;

namespace Drivers_Business
{
    public class clsDrivers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DriverID { set; get; }
        public int PersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { set; get; }

        public clsDrivers()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsDrivers(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            Mode = enMode.Update;
        }

        private bool _AddNewDriver()
        {
            //call DataAccess Layer 

            this.DriverID = clsDriversData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            //call DataAccess Layer 

            return clsDriversData.updateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);

        }

        public static clsDrivers FindByDriverID(int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriversData.GetDriverInFoByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))

                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        public static clsDrivers FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriversData.GetDriverInFoByPersonID(ref DriverID, PersonID, ref CreatedByUserID, ref CreatedDate))

                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateDriver();

            }




            return false;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDrivers();

        }

        public static DataTable GetDriversByFilter(string KeyWord, string Value)
        {
            return clsDriversData.GetDriversByFilter(KeyWord, Value);

        }

        public static bool DeleteDriver(int DriverID)
        {
            return clsDriversData.DeleteDriver(DriverID);
        }

        public static bool isPersonExist(int DriverID)
        {
            return clsDriversData.IsDriverExist(DriverID);
        }

        public static int GetDriverIDByFilter(string KeyWord, string Value)
        {
            return clsDriversData.GetDriverIDByFilter(KeyWord, Value);
        }

        public static string GetDriverNameByPersonID(int PersonID)
        {
            return clsPerson.GetPersonNameByID(PersonID);
        }

        public static int GetDriverPersonIDoByDriverID(int DriverID)
        {
            return clsDriversData.GetDriverPersonIDoByDriverID(DriverID);
        }

    }
}
