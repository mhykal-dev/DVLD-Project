using DVLD_UI.Global_Classes;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using TestTypes_Business;

namespace DVLD_UI.Manage_Test_Types
{
    public partial class frmEditTestTypes : Form
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private clsTestType _TestType;

        public frmEditTestTypes(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.Title = txtboxTitle.Text;
            _TestType.Description = txtboxDescription.Text;
            _TestType.Fees = Convert.ToInt32(txtboxFees.Text);

            if (_TestType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestTypeID);

            if (_TestType != null)
            {
                lblID.Text = _TestType.TestTypeID.ToString();
                txtboxTitle.Text = _TestType.Title;
                txtboxDescription.Text = _TestType.Description;
                txtboxFees.Text = _TestType.Fees.ToString();
            }

            else
            {
                MessageBox.Show("This Type Is Not Found");
                this.Close();
            }
        }

        private void txtboxTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxTitle, "Title is required");
            }

            else
            {
                errorProvider1.SetError(txtboxTitle, null);
            }
            ;
        }

        private void txtboxDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtboxDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtboxDescription, null);
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
