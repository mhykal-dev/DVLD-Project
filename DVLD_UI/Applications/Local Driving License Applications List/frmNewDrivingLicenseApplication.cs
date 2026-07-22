using Applications_Business;
using ApplicationTypes_Business;
using DVLD_UI.Global_Classes;
using LDLApplications_Business;
using LicenseClasses_Business;
using Licenses_Business;
using System;
using System.Windows.Forms;
using USERS_Business;

namespace DVLD_UI.Applications.Local_Driving_License_Applications_List.Driving_Licenses_Applications.Driving_Licenses_Applications
{
    public partial class frmNewDrivingLicenseApplication : Form
    {
        public enum enMode { AddNew = 1, Update = 2 };

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmNewDrivingLicenseApplication()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmNewDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void _LoadClasses()
        {
            cmbClasses.DisplayMember = "ClassName";
            cmbClasses.ValueMember = "LicenseClassID";

            try
            {
                cmbClasses.DataSource = clsLicenseClass.GelAllLicenseClasses();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error While Loading The License Classes! : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("This Form Will Be Closed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
        }

        private void _ResetDefualtValues()
        {
            //This Will Reset To The Default Parameters.
            _LoadClasses();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrNewPersonCardWithFilter1.FilterFocus();
                tpApplicationInFo.Enabled = false;

                cmbClasses.SelectedIndex = 2;
                lblFees.Text = clsApplicationType.GetApplicatinTypePrice((int)clsApplication.enApplicationType.NewDrivingLicense).ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = clsGlobal.currentUser.UserName;
            }

            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpApplicationInFo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void _LoadData()
        {
            ctrNewPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.BeginInvoke(new Action(() => this.Close()));

                return;
            }

            ctrNewPersonCardWithFilter1.LoadPersonInFo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            cmbClasses.SelectedValue = _LocalDrivingLicenseApplication.LicenseClassID;
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();

            try
            {
                lblCreatedBy.Text = clsUser.Find(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Can't Find The User Who Created This Application", "Error", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                MessageBox.Show("This Form Will Be Closed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInFo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpApplicationInFo"];
                return;
            }

            //incase of add new mode.
            if (ctrNewPersonCardWithFilter1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tpApplicationInFo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpApplicationInFo"];
            }

            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrNewPersonCardWithFilter1.FilterFocus();
                btnSave.Enabled = false;
                tpApplicationInFo.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClass.Find(cmbClasses.Text).LicenseClassID;


            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClasses.Focus();
                return;
            }


            //check if user already have issued license of the same driving  class.
            if (clsLicense.IsLicenseExistByPersonID(ctrNewPersonCardWithFilter1.PersonID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrNewPersonCardWithFilter1.PersonID; ;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewDrivingLicense;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.currentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;


            if (_LocalDrivingLicenseApplication.Save())
            {
                lblID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNewDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void frmNewDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrNewPersonCardWithFilter1.FilterFocus();
        }

        private void ctrNewPersonCardWithFilter1_OnPersonSelectedev(int obj)
        {
            _SelectedPersonID = obj;
        }
    }
}