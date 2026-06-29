using System.Windows.Forms;
using USERS_Business;

namespace DVLD_UI.Users.User_Controls
{
    public partial class ctrUserCard : UserControl
    {
        clsUser _User = new clsUser();

        public ctrUserCard()
        {
            InitializeComponent();
        }

        public void ShowDetails(int UserID)
        {

            _User = clsUser.Find(UserID);

            if (_User == null)
            {
                MessageBox.Show("User not found with ID: " + UserID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrNewPersonCard1.LoadPersonInfo(_User.PersonID);

            ShowLogInFo();
        }

        public void ShowLogInFo()
        {
            if (_User != null)
            {
                lblUserID.Text = _User.UserID.ToString();
                lblUserName.Text = _User.UserName.ToString();

                lblIsActive.Text = _User.IsActive ? "Yes" : "No";
            }
        }
    }

}
