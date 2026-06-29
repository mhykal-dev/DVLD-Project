using ApplicationTypes_Business;
using DVLD_UI.Global_Classes;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD_UI.ManageApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private int _ApplicationID = -1;

        clsApplicationType ApplicationType;
        public frmEditApplicationType(int ApplicationID)
        {
            InitializeComponent();

            _ApplicationID = ApplicationID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (ApplicationType != null)
            {
                ApplicationType.Title = txtboxTitle.Text;
                ApplicationType.Fees = Convert.ToInt32(txtboxFees.Text);

                if (ApplicationType.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            ApplicationType = clsApplicationType.Find(_ApplicationID);

            if (ApplicationType != null)
            {
                lblID.Text = ApplicationType.TypeID.ToString();
                txtboxTitle.Text = ApplicationType.Title;
                txtboxFees.Text = ApplicationType.Fees.ToString();
            }

            else
            {
                MessageBox.Show("This Type Is Not Found");
            }
        }

        private void txtboxTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtboxTitle, null);
            }
            ;
        }

        private void txtboxFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtboxFees, null);

            }
            ;


            if (!clsValidation.IsNumber(txtboxFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtboxFees, null);
            }
            ;
        }
    }
}
