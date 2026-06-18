using TestTypes_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTypes_Business;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_UI.Manage_Test_Types
{
    public partial class frmEditTestTypes : Form
    {
        private int _TestTypeID;
        public frmEditTestTypes(int TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;

            _ShowDetails();
        }

        private void _ShowDetails()
        {
            clsTestTypes TestType = clsTestTypes.Find(_TestTypeID);

            if (TestType != null)
            {
                lblID.Text = TestType.TestTypeID.ToString();
                txtboxTitle.Text = TestType.TestTypeTitle;
                txtboxDescription.Text = TestType.TestTypeDescription;
                txtboxFees.Text = TestType.TestTypeFees.ToString();
            }

            else
            {
                MessageBox.Show("This Type Is Not Found");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTestTypes TestType = clsTestTypes.Find(_TestTypeID);

            if (TestType != null)
            {
                TestType.TestTypeTitle = txtboxTitle.Text;
                TestType.TestTypeDescription = txtboxDescription.Text;
                TestType.TestTypeFees = Convert.ToInt32(txtboxFees.Text);

                if (TestType.Save())
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
