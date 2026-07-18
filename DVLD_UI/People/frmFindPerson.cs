using System;
using System.Windows.Forms;

namespace DVLD_UI.People
{
    public partial class frmFindPerson : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void frmFindPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ctrNewPersonCardWithFilter2.PersonID != -1)
            {
                DataBack?.Invoke(this, ctrNewPersonCardWithFilter2.PersonID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
