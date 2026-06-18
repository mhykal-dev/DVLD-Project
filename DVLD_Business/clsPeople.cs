using System;
using System.Data;
using PEOPLE_DataAccess;

namespace PEOPLE_Business
{
    public class clsPeople
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public int Gendor {  set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }
        public string ImagePath { set; get; }

        public clsPeople()
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

        private clsPeople(int PersonID, string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
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

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = clsPeopleData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, 
                this.LastName, this.DateOfBirth, this.Gendor, this.Address,
                this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPeopleData.updatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.DateOfBirth, this.Gendor, this.Address,
                this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

        }
        
        public static clsPeople Find(int ID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            int Gendor = 0;
            string Address = "", Phone = "", Email = "";
            int NationalityCountryID = 0;
            string ImagePath = "";

            if (clsPeopleData.GetPersonInFoByID(ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                          ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))

                return new clsPeople(ID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                          DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static clsPeople FindByNationalNo(string NationalNo)
        {
            int ID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            int Gendor = 0;
            string Address = "", Phone = "", Email = "";
            int NationalityCountryID = 0;
            string ImagePath = "";

            if (clsPeopleData.GetPersonInFoByNationalNo(ref ID, NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                          ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))

                return new clsPeople(ID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                          DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
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
            return clsPeopleData.GetAllPeople();

        }

        public static DataTable GetPeopleByFilter(string KeyWord, string Value)
        {
            return clsPeopleData.GetPeopleByFilter(KeyWord, Value);

        }

        public static bool DeletePerson(int ID)
        {
            return clsPeopleData.DeletePerson(ID);
        }

        public static bool isPersonExist(int ID)
        {
            return clsPeopleData.IsPersonExist(ID);
        }

        public static int GetPersonIDByFilter(string KeyWord, string Value)
        {
            return clsPeopleData.GetPersonIDByFilter(KeyWord, Value);
        }

        public static string GetPersonNameByID(int PersonID)
        {
            return clsPeopleData.GetPersonNameByID(PersonID);
        }

        public static int GetPersonIDByNationalNo(string NationalNo)
        {
            return clsPeopleData.GetPersonIDByNationalNo(NationalNo);
        }

        public static string GetPersonNationalNoByID(int PersonID)
        {
            return clsPeopleData.GetPersonNationalNoByID(PersonID);
        }

        public static int GetPersonGendorByID(int PersonID)
        {
            return clsPeopleData.GetPersonGendorByID(PersonID);
        }

        public static DateTime GetPersonDateOfBirthByID(int PersonID)
        {
            return clsPeopleData.GetPersonDateOfBirthByID(PersonID);
        }

    }
}
