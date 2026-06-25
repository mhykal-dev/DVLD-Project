using Drivers_Business;
using LicenseClasses_Business;
using Licenses_Business;
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

namespace DVLD_UI.Local_Driving_License_Applications_List.User_Controls
{
    public partial class ctrLocalDrivingLicenseInFO : UserControl
    {
        public int LicenseID { get; set; }

        clsLicense License = new clsLicense();

        clsDriver Driver = new clsDriver();

        public ctrLocalDrivingLicenseInFO()
        {
            InitializeComponent();
        }

        public void GetDriverPersonalDetails(ref string FullName, ref string NationalNo, ref string Gendor, ref string IsActive, ref string ISDetained, ref DateTime DateOfBirth)
        {
            Driver = clsDriver.FindByDriverID(License.DriverID);

            FullName = clsDriver.GetDriverNameByPersonID(Driver.PersonID);

            NationalNo = clsPerson.GetPersonNationalNoByID(Driver.PersonID);


            if (clsPerson.GetPersonGendorByID(Driver.PersonID) == 0)
                Gendor = "Male";

            else
                Gendor = "Female";



            if (License.IsActive == 1)
                IsActive = "Yes";

            else
                IsActive = "No";



            ISDetained = "No";//Only For Now!!!, I didn't made The Detained Classess Yet!, So Only For No, Teasting I mean, The Anwer Well Be No.
            DateOfBirth = clsPerson.GetPersonDateOfBirthByID(Driver.PersonID);

        }

        public void ShowDetail()
        {
            License = clsLicense.FindByLicenseID(LicenseID);

            if( License != null )
            {
                string FullName = "", NationalNo = "", Gendor = "", IsActive = "", ISDetained = "";
                DateTime DateOfBirth = DateTime.Now;

                GetDriverPersonalDetails(ref FullName, ref NationalNo, ref Gendor, ref IsActive, ref ISDetained, ref DateOfBirth);

                lblClassTypeName.Text = clsLicenseClass.GetClassName(LicenseID);
                lblFullName.Text = FullName;
                lblLicenseID.Text = License.LicenseID.ToString();
                lblNationalNo.Text = NationalNo;
                lblGendor.Text = Gendor;
                lblDate.Text = License.IssueDate.ToString();
                lblReason.Text = License.IssueReason.ToString();
                lblNotes.Text = License.Notes;
                lblIsActive.Text = IsActive;
                lblDateOfBirth.Text = DateOfBirth.ToString();
                lblDriverID.Text = License.DriverID.ToString();
                lblExpireDate.Text = License.ExpirationDate.ToString();
                lblISDetained.Text = ISDetained;
            }
        }
    }
}
