using System;
using System.Data;
using System.Windows.Forms;
using TestTypes_Business;

namespace DVLD_UI.Manage_Test_Types
{
    public partial class frmManageTestTypes : Form
    {
        private DataTable _dtAllTestTypes;
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTypesList.SelectedRows.Count > 0)
            {
                clsTestType.enTestType TestTypeID = (clsTestType.enTestType)dgvTypesList.SelectedRows[0].Cells[0].Value;

                using (Form frm = new frmEditTestTypes(TestTypeID))
                {
                    frm.ShowDialog();
                    frmManageTestTypes_Load(null, null);
                }
            }

            else
            {
                MessageBox.Show("Please Select A Row first!");
                frmManageTestTypes_Load(null, null);
            }
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _dtAllTestTypes = clsTestType.GetAllTestTypes();
            dgvTypesList.DataSource = _dtAllTestTypes;
            lblRecords.Text = dgvTypesList.Rows.Count.ToString();

            dgvTypesList.Columns[0].HeaderText = "ID";
            dgvTypesList.Columns[0].Width = 120;

            dgvTypesList.Columns[1].HeaderText = "Title";
            dgvTypesList.Columns[1].Width = 200;

            dgvTypesList.Columns[2].HeaderText = "Description";
            dgvTypesList.Columns[2].Width = 400;

            dgvTypesList.Columns[3].HeaderText = "Fees";
            dgvTypesList.Columns[3].Width = 100;
        }
    }
}
