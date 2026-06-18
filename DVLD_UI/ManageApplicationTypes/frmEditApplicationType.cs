using ApplicationTypes_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.ManageApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private int _ApplicationID;
        public frmEditApplicationType(int ApplicationID)
        {
            InitializeComponent();

            _ApplicationID = ApplicationID;

            _ShowDetails();
        }

        private void _ShowDetails()
        {
            clsApplicationTypes applicationType = clsApplicationTypes.Find(_ApplicationID);

            if(applicationType != null)
            {
                lblID.Text = applicationType.ApplicationTypeID.ToString();
                txtboxTitle.Text = applicationType.ApplicationTypeTitle;
                txtboxFees.Text = applicationType.ApplicationFees.ToString();
            }

            else
            {
                MessageBox.Show("This Type Is Not Found");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsApplicationTypes applicationType = clsApplicationTypes.Find(_ApplicationID);

            if (applicationType != null)
            {
                applicationType.ApplicationTypeTitle = txtboxTitle.Text;
                applicationType.ApplicationFees = Convert.ToInt32(txtboxFees.Text);

                if(applicationType.Save())
                {
                    MessageBox.Show("Saved!");
                }
                else
                {
                    MessageBox.Show("Not Saved!");
                }
            }
        }

        private void bntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
