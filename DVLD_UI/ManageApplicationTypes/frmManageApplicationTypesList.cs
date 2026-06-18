using ApplicationTypes_Business;
using DVLD_UI.People;
using PEOPLE_Business;
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
    public partial class frmManageApplicationTypesList : Form
    {
        public frmManageApplicationTypesList()
        {
            InitializeComponent();

            dgvTypesList.DataSource = clsApplicationTypes.GetAllApplicationTypes();

        }

        private void _RefreshPeopleList()
        {
            dgvTypesList.DataSource = clsApplicationTypes.GetAllApplicationTypes();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTypesList.SelectedRows.Count > 0)
            {
                int ApplicationID = Convert.ToInt32(dgvTypesList.SelectedRows[0].Cells[0].Value);

                frmEditApplicationType frm = new frmEditApplicationType(ApplicationID);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

