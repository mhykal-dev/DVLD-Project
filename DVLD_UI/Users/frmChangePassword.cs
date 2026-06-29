using System.Windows.Forms;

namespace DVLD_UI.Users
{
    public partial class frmChangePassword : Form
    {
        public int UserID { get; set; }
        public frmChangePassword(int userID)
        {
            InitializeComponent();

            UserID = userID;

            ctrChangeUserPassword1.ShowDetails(UserID);
        }
    }
}
