using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            ctrUserCard1.UserID = _UserID;

            ctrUserCard1.ShowDetails();
        }
    }
}
