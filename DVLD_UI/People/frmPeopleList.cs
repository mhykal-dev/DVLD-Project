using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PEOPLE_Business;

namespace DVLD_UI.People
{
    public partial class frmPeopleList : Form
    {
        public frmPeopleList()
        {
            InitializeComponent();
        }

        private void _RefreshPeopleList()
        {
            dgvPeopleList.DataSource = clsPerson.GetAllPeople();
        }

        private void frmPeopleList_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvPeopleList.SelectedRows.Count > 0)
            {
                int PersonID = Convert.ToInt32(dgvPeopleList.SelectedRows[0].Cells[0].Value);

                frmShowPersonInFo frmPerson = new frmShowPersonInFo(PersonID);
                frmPerson.ShowDialog();

                frmPerson.Dispose();
                _RefreshPeopleList();
            }

            else
            {
                MessageBox.Show("Please Select A Row first!");
            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeopleList.SelectedRows.Count > 0)
            {
                int PersonID = Convert.ToInt32(dgvPeopleList.SelectedRows[0].Cells[0].Value);

                if(clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person Deleted Successfuly!");
                    _RefreshPeopleList();
                }
            }

            else
            {
                MessageBox.Show("Please Select A Row first!");
                _RefreshPeopleList();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeopleList.SelectedRows.Count > 0)
            {
                int PersonID = Convert.ToInt32(dgvPeopleList.SelectedRows[0].Cells[0].Value);

                frmAddUpdatePerson frm = new frmAddUpdatePerson(PersonID);
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

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I Don't Have The Email!");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I Don't Have The Number!");
        }

        private void txtboxFilterField_TextChanged(object sender, EventArgs e)
        {
            dgvPeopleList.DataSource = clsPerson.GetPeopleByFilter(cmbFilterBy.SelectedItem.ToString(), txtboxFilterField.Text.ToString());
        }
    }
}