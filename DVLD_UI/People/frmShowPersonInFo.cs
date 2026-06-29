using System;
using System.Windows.Forms;

namespace DVLD_UI.People
{
    public partial class frmShowPersonInFo : Form
    {
        public frmShowPersonInFo(int PersonID)
        {
            InitializeComponent();

            ctrNewPersonCard1.LoadPersonInfo(PersonID);
        }

        public frmShowPersonInFo(string NationalNo)
        {
            InitializeComponent();

            ctrNewPersonCard1.LoadPersonInfo(NationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}