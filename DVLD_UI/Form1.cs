using DVLD_UI.Driving_Licenses_Applications;
using DVLD_UI.frmReplaceDamaged_LostDrivingLicenseApplication;
using DVLD_UI.International_License_Applications;
using DVLD_UI.International_License_Lists;
using DVLD_UI.Local_Driving_License_Applications_List;
using DVLD_UI.ManageApplicationTypes;
using DVLD_UI.People;
using DVLD_UI.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeopleList frm = new frmPeopleList();
            frm.ShowDialog();

            frm.Dispose();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersList frm = new frmUsersList();
            frm.ShowDialog();

            frm.Dispose();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypes.frmManageApplicationTypesList frm = new frmManageApplicationTypesList();
            frm.ShowDialog();

            frm.Dispose();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Test_Types.frmManageTestTypes frm = new Manage_Test_Types.frmManageTestTypes();
            frm.ShowDialog();

            frm.Dispose();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewDrivingLicenseApplication frm = new frmNewDrivingLicenseApplication();
            frm.ShowDialog();

            frm.Dispose();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationsList frm = new frmLocalDrivingLicenseApplicationsList();
            frm.ShowDialog();

            frm.Dispose();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternational_Licenses_Applications frm = new frmInternational_Licenses_Applications();
            frm.ShowDialog();

            frm.Dispose();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseList frm = new frmInternationalLicenseList();
            frm.ShowDialog();

            frm.Dispose();
        }

        private void rENewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Renew_Driving_License.frmRenewLicense frm = new Renew_Driving_License.frmRenewLicense();
            frm.ShowDialog();

            frm.Dispose();
        }

        private void replaceDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLicense frm = new frmReplaceLicense();
            frm.ShowDialog();

            frm.Dispose();
        }
    }
}
