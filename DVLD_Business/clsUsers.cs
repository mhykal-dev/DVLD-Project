using PEOPLE_DataAccess;
using System;
using System.Data;
using USERS_DataAccess;

namespace USERS_Business
{
    public class clsUsers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public int PersonID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public int IsActive { set; get; }
     
        public clsUsers()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = 0;

            Mode = enMode.AddNew;
        }

        private clsUsers(int UserID, int PersonID, string UserName,
            string Password, int IsActive)
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

            this.UserID = clsUsersData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return clsUsersData.updateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);

        }

        public static clsUsers Find(int ID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            int IsActive = 0;

            if (clsUsersData.GetUserInFoByID(ID, ref PersonID, ref UserName, ref Password, ref IsActive))

                return new clsUsers(ID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsUsers FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "";
            string Password = "";
            int IsActive = 0;

            if (clsUsersData.GetUserInFoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive))

                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
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

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();

        }

        public static DataTable GetUsersByFilter(string KeyWord, string Value)
        {
            return clsUsersData.GetUsersByFilter(KeyWord, Value);

        }

        public static bool DeleteUser(int ID)
        {
            return clsUsersData.DeleteUser(ID);
        }

        public static bool isUserExist(int ID)
        {
            return clsUsersData.IsUserExist(ID);
        }

        public static bool isUserExistByPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistByPersonID(PersonID);
        }

        public static bool IsUserExistByUserName(string UserName)
        {
            return clsUsersData.IsUserExistByUserName(UserName);
        }

        public static string GetUserNameByUserID(int UserID)
        {
            return clsUsersData.GetUserNameByUserID(UserID);
        }
    }
}
