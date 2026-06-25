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
    public class clsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DriverID { set; get; }
        public int PersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { set; get; }

        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
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

            this.DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            //call DataAccess Layer 

            return clsDriverData.updateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);

        }

        public static clsDriver FindByDriverID(int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverInFoByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))

                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverInFoByPersonID(ref DriverID, PersonID, ref CreatedByUserID, ref CreatedDate))

                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
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
            return clsDriverData.GetAllDrivers();

        }

        public static DataTable GetDriversByFilter(string KeyWord, string Value)
        {
            return clsDriverData.GetDriversByFilter(KeyWord, Value);

        }

        public static bool DeleteDriver(int DriverID)
        {
            return clsDriverData.DeleteDriver(DriverID);
        }

        public static bool isPersonExist(int DriverID)
        {
            return clsDriverData.IsDriverExist(DriverID);
        }

        public static int GetDriverIDByFilter(string KeyWord, string Value)
        {
            return clsDriverData.GetDriverIDByFilter(KeyWord, Value);
        }

        public static string GetDriverNameByPersonID(int PersonID)
        {
            return clsPerson.GetPersonNameByID(PersonID);
        }

        public static int GetDriverPersonIDoByDriverID(int DriverID)
        {
            return clsDriverData.GetDriverPersonIDoByDriverID(DriverID);
        }

    }
}
