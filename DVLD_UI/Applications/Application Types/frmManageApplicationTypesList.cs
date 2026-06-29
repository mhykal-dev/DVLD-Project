using ApplicationTypes_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_UI.ManageApplicationTypes
{
    public partial class frmManageApplicationTypesList : Form
    {
        private DataTable _dtAllApplicationTypes;

        public frmManageApplicationTypesList()
        {
            InitializeComponent();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTypesList.SelectedRows.Count > 0)
            {
                int ApplicationID = (int)dgvTypesList.SelectedRows[0].Cells[0].Value;

                using (frmEditApplicationType frm = new frmEditApplicationType(ApplicationID))
                {
                    frm.ShowDialog();
                }

                frmManageApplicationTypesList_Load(null, null);
            }

            else
            {
                MessageBox.Show("Please Select A Row first!");
                frmManageApplicationTypesList_Load(null, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageApplicationTypesList_Load(object sender, EventArgs e)
        {

            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvTypesList.DataSource = _dtAllApplicationTypes;
            lblRecords.Text = dgvTypesList.Rows.Count.ToString();

            dgvTypesList.Columns[0].HeaderText = "ID";
            dgvTypesList.Columns[0].Width = 110;

            dgvTypesList.Columns[1].HeaderText = "Title";
            dgvTypesList.Columns[1].Width = 400;

            dgvTypesList.Columns[2].HeaderText = "Fees";
            dgvTypesList.Columns[2].Width = 100;
        }
    }
}

