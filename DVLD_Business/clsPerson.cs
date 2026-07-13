using System;
using System.Data;
using System.Linq;
using COUNTRIES_Business;
using PEOPLE_DataAccess;

namespace PEOPLE_Business
{
    public class clsPerson
    {
        public enum enGender { Male = 0, Female = 1 };
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        private int _PersonID;
        public int PersonID
        {
            get
            {
                return _PersonID;
            }

            set
            {
                if (Mode == enMode.Update && _PersonID != value)
                    throw new InvalidOperationException("PersonID cannot be changed once a person is created.");
                _PersonID = value;
            }
        }
        private string _NationalNo;
        public string NationalNo
        {
            get
            {
                return _NationalNo;
            }

            set
            {
                if (Mode == enMode.Update && _NationalNo != value)
                    throw new InvalidOperationException("NationalNo cannot be changed once a person is created.");
                _NationalNo = value;
            }
        }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string FullName
        {
            get { return string.Join(" ", new[] { FirstName, SecondName, ThirdName, LastName }.Where(S => !string.IsNullOrWhiteSpace(S)) ); }

        }
        public DateTime DateOfBirth { set; get; }
        public enGender Gender {  set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }

        private clsCountry _CountryInfo = null;
        private bool _CountryInfoLoaded = false;
        public clsCountry CountryInfo
        {
            get
            {
                if(!_CountryInfoLoaded && NationalityCountryID != -1)
                {
                    _CountryInfo = clsCountry.Find(NationalityCountryID);
                    _CountryInfoLoaded = true;
                }

                return _CountryInfo;
            }
        }
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
            Gender = 0;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";

            Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            enGender Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
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

            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, 
                this.LastName, this.DateOfBirth, (short)this.Gender, this.Address,
                this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPersonData.UpdatePerson(this.PersonID, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.DateOfBirth, (short)this.Gender, this.Address,
                this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

        }
        
        public static clsPerson Find(int ID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            short Gender = 0;

            bool IsFound = clsPersonData.GetPersonInFoByID(ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                          ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);

            if (IsFound)
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                          DateOfBirth, (enGender)Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1, NationalityCountryID = -1;
            short Gender = 0;

            bool IsFound = clsPersonData.GetPersonInFoByNationalNo
                                (
                                    ref PersonID, NationalNo, ref FirstName, ref SecondName,
                                    ref ThirdName, ref LastName, ref DateOfBirth,
                                    ref Gender, ref Address, ref Phone, ref Email,
                                    ref NationalityCountryID, ref ImagePath
                                );

            if (IsFound)

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                          DateOfBirth, (enGender)Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
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

        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static bool isPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }

        public static string GetPersonNameByID(int PersonID)
        {
            return clsPersonData.GetPersonNameByID(PersonID);
        }
    }
}
