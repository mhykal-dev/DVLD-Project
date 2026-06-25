
using DVLD_UI.Applications.Local_Driving_License_Applications_List.Driving_Licenses_Applications.Driving_Licenses_Applications;
using DVLD_UI.frmReplaceDamaged_LostDrivingLicenseApplication;
using DVLD_UI.International_License_Applications;
using DVLD_UI.International_License_Lists;
using DVLD_UI.Local_Driving_License_Applications_List;
using DVLD_UI.Login;
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
        frmLogin _frmLogin;

        public Form1(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPeopleList frm = new frmPeopleList())
            {
                frm.ShowDialog();
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmUsersList frm = new frmUsersList())
            {
                frm.ShowDialog();
            }
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ManageApplicationTypes.frmManageApplicationTypesList frm = new frmManageApplicationTypesList())
            {
                frm.ShowDialog();
            }
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Manage_Test_Types.frmManageTestTypes frm = new Manage_Test_Types.frmManageTestTypes())
            {
                frm.ShowDialog();
            }
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form frm = new frmNewDrivingLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmLocalDrivingLicenseApplicationsList frm = new frmLocalDrivingLicenseApplicationsList())
            {
                frm.ShowDialog();
            }
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmInternational_Licenses_Applications frm = new frmInternational_Licenses_Applications())
            {
                frm.ShowDialog();
            }
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmInternationalLicenseList frm = new frmInternationalLicenseList())
            {
                frm.ShowDialog();
            }
        }

        private void rENewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Renew_Driving_License.frmRenewLicense frm = new Renew_Driving_License.frmRenewLicense())
            {
                frm.ShowDialog();
            }
        }

        private void replaceDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmReplaceLicense frm = new frmReplaceLicense())
            {
                frm.ShowDialog();
            }
        }
    }
}
