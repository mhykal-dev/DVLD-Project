using ApplicationTypes_Business;
using DVLD_UI.ManageApplicationTypes;
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

namespace DVLD_UI.Manage_Test_Types
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();

            dgvTypesList.DataSource = clsTestTypes.GetAllTestTypes();
        }

        private void _RefreshPeopleList()
        {
            dgvTypesList.DataSource = clsTestTypes.GetAllTestTypes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTypesList.SelectedRows.Count > 0)
            {
                int TestTypeID = Convert.ToInt32(dgvTypesList.SelectedRows[0].Cells[0].Value);

                frmEditTestTypes frm = new frmEditTestTypes(TestTypeID);
                frm.ShowDialog();

                frm.Dispose();
                _RefreshPeopleList();
            }

            else
            {
                MessageBox.Show("Please Select A Row first!");
                _RefreshPeopleList();
            }
        }
    }
}
