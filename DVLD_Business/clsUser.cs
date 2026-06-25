using PEOPLE_DataAccess;
using System;
using System.Data;
using USERS_DataAccess;
using PEOPLE_Business;

namespace USERS_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public int PersonID { set; get; }

        private clsPerson _Person = null;
        public clsPerson Person
        {
            get
            {
                if (_Person == null && this.PersonID != -1)
                {
                    _Person = clsPerson.Find(PersonID);
                }
                return _Person;
            }
        }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }
     
        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, int PersonID, string UserName,
            string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);

        }

        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInFoByID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive);

            return IsFound ? new clsUser(UserID, PersonID, UserName, Password, IsActive) : null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInFoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive);

            return IsFound ? new clsUser(UserID, PersonID, UserName, Password, IsActive) : null;
        }

        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInFoByUserNameAndPassword(ref UserID, ref PersonID, UserName, Password, ref IsActive);

            return IsFound ? new clsUser(UserID, PersonID, UserName, Password, IsActive) : null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }
            return false;
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            return clsUserData.ChangePassword(UserID, NewPassword);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        // تحديث التسميات لتصبح PascalCase القياسية
        public static bool IsUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }

        public static bool IsUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        public static bool IsUserExistByUserName(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }
    }
}
