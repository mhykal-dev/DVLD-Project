using DVLD_UI.People.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USERS_Business;

namespace DVLD_UI.Users.User_Controls
{
    public partial class ctrUserCard : UserControl
    {
        public int UserID { get; set; }

        public ctrUserCard()
        {
            InitializeComponent();
        }

        public void ShowDetails()
        {

            clsUsers User = clsUsers.Find(UserID);

            ctrPersonCard1.PersonID = User.PersonID;

            ctrPersonCard1.ViewPersonInFo();

            ShowLogInFo(User);
        }

        public void ShowLogInFo(clsUsers User)
        {         
            if (User != null)
            {
                lblUserID.Text = User.UserID.ToString();
                lblUserName.Text = User.UserName.ToString();

                if (User.IsActive == 1)
                    lblIsActive.Text = "YES";

                else
                    lblIsActive.Text = "No";
            }
        }
    }

}
