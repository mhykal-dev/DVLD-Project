using System;
using System.Windows.Forms;

namespace DVLD_UI.Users
{
    public partial class frmShowUserDetails : Form
    {
        private int _UserID = -1;
        public frmShowUserDetails(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

        }

        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {
            ctrUserCard1.ShowDetails(_UserID);
        }
    }
}
