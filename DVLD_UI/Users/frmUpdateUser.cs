using System;
using System.Windows.Forms;
using USERS_Business;

namespace DVLD_UI.Users
{
    public partial class frmUpdateUser : Form
    {
        private int _UserID { get; set; }

        clsUser _User;
        public frmUpdateUser(int userID)
        {
            InitializeComponent();

            _UserID = userID;

        }

        private void frmUpdateUser_Load(object sender, EventArgs e)
        {
            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrNewPersonCard1.LoadPersonInfo(_User.PersonID);

            ctrUpdateUser1.ShowDetails(_User.UserID);
        }

        private void btnUpdatePersonalInFo_Click(object sender, EventArgs e)
        {
            using (Form frm = new People.frmAddUpdatePerson(_User.PersonID))
            {
                frm.ShowDialog();
            }

            ctrNewPersonCard1.LoadPersonInfo(_User.PersonID);
        }
    }
}
