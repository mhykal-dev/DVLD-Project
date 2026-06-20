using System;
using System.Data;
using COUNTRIES_Business;
using PEOPLE_DataAccess;

namespace PEOPLE_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }

        }
        public DateTime DateOfBirth { set; get; }
        public short Gendor {  set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }
        public clsCountry CountryInfo;//
        private string _ImagePath { set; get; }
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public clsPerson()
        {
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gendor = 0;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = 0;
            ImagePath = "";

            Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            short Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, 
                this.LastName, this.DateOfBirth, this.Gendor, this.Address,
                this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPersonData.updatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.DateOfBirth, this.Gendor, this.Address,
                this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

        }
        
        public static clsPerson Find(int ID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            short Gendor = 0;

            bool IsFound = clsPersonData.GetPersonInFoByID(ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                          ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);

            if (IsFound)
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                          DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;
        }

        public static clsPerson FindByNationalNo(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1, NationalityCountryID = -1;
            short Gendor = 0;

            bool IsFound = clsPersonData.GetPersonInFoByNationalNo
                                (
                                    ref PersonID, NationalNo, ref FirstName, ref SecondName,
                                    ref ThirdName, ref LastName, ref DateOfBirth,
                                    ref Gendor, ref Address, ref Phone, ref Email,
                                    ref NationalityCountryID, ref ImagePath
                                );

            if (IsFound)

                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName,
                          NationalNo, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }




            return false;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();

        }

        //did't use it.
        public static DataTable GetPeopleByFilter(string KeyWord, string Value)
        {
            return clsPersonData.GetPeopleByFilter(KeyWord, Value);

        }

        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static bool isPersonExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }

        public static int GetPersonIDByFilter(string KeyWord, string Value)
        {
            return clsPersonData.GetPersonIDByFilter(KeyWord, Value);
        }

        public static string GetPersonNameByID(int PersonID)
        {
            return clsPersonData.GetPersonNameByID(PersonID);
        }

        public static int GetPersonIDByNationalNo(string NationalNo)
        {
            return clsPersonData.GetPersonIDByNationalNo(NationalNo);
        }

        public static string GetPersonNationalNoByID(int PersonID)
        {
            return clsPersonData.GetPersonNationalNoByID(PersonID);
        }

        public static int GetPersonGendorByID(int PersonID)
        {
            return clsPersonData.GetPersonGendorByID(PersonID);
        }

        public static DateTime GetPersonDateOfBirthByID(int PersonID)
        {
            return clsPersonData.GetPersonDateOfBirthByID(PersonID);
        }
        //did't use it.
    }
}
