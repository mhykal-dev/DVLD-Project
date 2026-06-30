using System;
using System.Windows.Forms;

namespace DVLD_UI.Licenses
{
    public partial class frmShowLicensesHistory : Form
    {
        private int _PersonID = -1;

        public frmShowLicensesHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmShowLicensesHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                ctrNewPersonCardWithFilter1.LoadPersonInFo(_PersonID);
                ctrNewPersonCardWithFilter1.FilterEnabled = false;
                ctrlDriverLicenses1.LoadByPersonID(_PersonID);
            }
            else
            {
                ctrNewPersonCardWithFilter1.Enabled = true;
                ctrNewPersonCardWithFilter1.FilterFocus();
            }
        }

        private void ctrNewPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            if (_PersonID == -1)
            {
                ctrlDriverLicenses1.Clear();
            }
            else
                ctrlDriverLicenses1.LoadByPersonID(_PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
