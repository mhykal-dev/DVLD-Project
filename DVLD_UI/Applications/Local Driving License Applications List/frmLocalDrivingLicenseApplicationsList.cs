using DVLD_UI.Applications.Local_Driving_License_Applications_List.Driving_Licenses_Applications.Driving_Licenses_Applications;
using DVLD_UI.People;
using DVLD_UI.Tests.Vision_Test;
using LDLApplications_Business;
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
using TestAppointments_Business;
using Tests_Business;

namespace DVLD_UI.Local_Driving_License_Applications_List
{
    public partial class frmLocalDrivingLicenseApplicationsList : Form
    {
        public frmLocalDrivingLicenseApplicationsList()
        {
            InitializeComponent();

            _RefreshPeopleList();

            dgvLDLApplicationsList.SelectionChanged += dgvLDLApplicationsList_SelectionChanged;

            visionTestToolStripMenuItem.Enabled  = false;

            writtinTestToolStripMenuItem.Enabled = false;

            driveTestToolStripMenuItem.Enabled   = false;

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
        }

        private void btnAddNewLicense_Click(object sender, EventArgs e)
        {
            using (Form frm = new frmNewDrivingLicenseApplication())
            {
                frm.ShowDialog();
            }

            _RefreshPeopleList();
        }

        private void _RefreshPeopleList()
        {
            dgvLDLApplicationsList.DataSource = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

            visionTestToolStripMenuItem.Enabled = false;

            writtinTestToolStripMenuItem.Enabled = false;

            driveTestToolStripMenuItem.Enabled = false;

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
        }

        private void txtboxFilterField_TextChanged(object sender, EventArgs e)
        {
            //dgvLDLApplicationsList.DataSource = clsLocalDrivingLicenseApplication.GetAllLDLApplicationsByFilter(cmbFilterBy.SelectedItem.ToString(), txtboxFilterField.Text.ToString());
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLDLApplicationsList.SelectedRows.Count > 0)
            {
                //(int LDLAppID, int TestTypeID, string ClassTypeName, string FullName, string NationalNo, bool Retaken)

                int LDLApplicationID = (int)dgvLDLApplicationsList.SelectedRows[0].Cells[0].Value;

                string NationalNo = dgvLDLApplicationsList.SelectedRows[0].Cells[2].Value as string;

                string ClassTypeName = dgvLDLApplicationsList.SelectedRows[0].Cells[1].Value as string;

                string FullName = dgvLDLApplicationsList.SelectedRows[0].Cells[3].Value as string;

                frmTestAppointments frm = new frmTestAppointments(LDLApplicationID, 1, NationalNo, ClassTypeName, FullName);
                frm.ShowDialog();

                frm.Dispose();
                _RefreshPeopleList();
            }

            else
            {
                MessageBox.Show("Please Select A Row first!");
            }
        }

        private void dgvLDLApplicationsList_SelectionChanged(object sender, EventArgs e)
        {
            visionTestToolStripMenuItem.Enabled = false;

            writtinTestToolStripMenuItem.Enabled = false;

            driveTestToolStripMenuItem.Enabled = false;

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;

            if (dgvLDLApplicationsList.DataSource == null || dgvLDLApplicationsList.Rows.Count == 0)
                return;

            if (!dgvLDLApplicationsList.Focused)
                return;

            if(dgvLDLApplicationsList.SelectedRows.Count > 0)
            {
                int PassedTests = (int)dgvLDLApplicationsList.SelectedRows[0].Cells[5].Value;

                switch (PassedTests)
                {
                    case 0:
                        {
                            visionTestToolStripMenuItem.Enabled = true;
                            writtinTestToolStripMenuItem.Enabled = false;
                            driveTestToolStripMenuItem.Enabled = false;
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                            break;
                        }

                    case 1:
                        {
                            visionTestToolStripMenuItem.Enabled = false;
                            writtinTestToolStripMenuItem.Enabled = true;
                            driveTestToolStripMenuItem.Enabled = false;
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                            break;
                        }

                    case 2:
                        {
                            visionTestToolStripMenuItem.Enabled = false;
                            writtinTestToolStripMenuItem.Enabled = false;
                            driveTestToolStripMenuItem.Enabled = true;
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                            break;
                        }

                    case 3:
                        {
                            visionTestToolStripMenuItem.Enabled = false;
                            writtinTestToolStripMenuItem.Enabled = false;
                            driveTestToolStripMenuItem.Enabled = false;
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                            break;
                        }
                }

            }

            else
            {
                visionTestToolStripMenuItem.Enabled = false;

                writtinTestToolStripMenuItem.Enabled = false;

                driveTestToolStripMenuItem.Enabled = false;

                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }
        }

        private void writtinTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLDLApplicationsList.SelectedRows.Count > 0)
            {
                int LDLApplicationID = (int)dgvLDLApplicationsList.SelectedRows[0].Cells[0].Value;

                string NationalNo = dgvLDLApplicationsList.SelectedRows[0].Cells[2].Value as string;

                string ClassTypeName = dgvLDLApplicationsList.SelectedRows[0].Cells[1].Value as string;

                string FullName = dgvLDLApplicationsList.SelectedRows[0].Cells[3].Value as string;

                frmTestAppointments frm = new frmTestAppointments(LDLApplicationID, 1, NationalNo, ClassTypeName, FullName);
                frm.ShowDialog();

                frm.Dispose();
                _RefreshPeopleList();
            }

            else
            {
                MessageBox.Show("Please Select A Row first!");
            }
        }

        private void driveTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLDLApplicationsList.SelectedRows.Count > 0)
            {
                int LDLApplicationID = (int)dgvLDLApplicationsList.SelectedRows[0].Cells[0].Value;

                string NationalNo = dgvLDLApplicationsList.SelectedRows[0].Cells[2].Value as string;

                string ClassTypeName = dgvLDLApplicationsList.SelectedRows[0].Cells[1].Value as string;

                string FullName = dgvLDLApplicationsList.SelectedRows[0].Cells[3].Value as string;

                frmTestAppointments frm = new frmTestAppointments(LDLApplicationID, 1, NationalNo, ClassTypeName, FullName);
                frm.ShowDialog();

                frm.Dispose();
                _RefreshPeopleList();
            }

            else
            {
                MessageBox.Show("Please Select A Row first!");
            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}