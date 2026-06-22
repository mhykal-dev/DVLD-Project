using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PEOPLE_Business;

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