using Drivers_Business;
using InternationalLicenses_Business;
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

namespace DVLD_UI.International_License_Applications.User_Controls
{
    public partial class ctrInternationalLicenseDetails : UserControl
    {
        public int IntLicenseID { get; set; }

        public int LicenseID { get; set; }

        public int DriverID { get; set; }

        clsLicense License = new clsLicense();

        clsDriver Driver = new clsDriver();

        clsPerson Person = new clsPerson();

        clsInternationalLicense InternationalLicense = new clsInternationalLicense();

        public ctrInternationalLicenseDetails()
        {
            InitializeComponent();
        }

        public void ShowDetails()
        {
            License = clsLicense.FindByLicenseID(LicenseID);

            Driver = clsDriver.FindByDriverID(DriverID);

            Person = clsPerson.Find(Driver.PersonID);

            InternationalLicense = clsInternationalLicense.FindByInternationalLicenseID(IntLicenseID);

            lblFullName.Text = clsPerson.GetPersonNameByID(Person.PersonID);
            lblIntLicenseID.Text = Convert.ToString(IntLicenseID);
            lblLocalLicense.Text = Convert.ToString(LicenseID);
            lblNationalNo.Text = clsPerson.GetPersonNationalNoByID(Person.PersonID);

            if (Person.Gendor == 0)
                lblGendor.Text = "Male";
            else
                lblGendor.Text = "Female";

            lblDate.Text = InternationalLicense.IssueDate.ToString();
            lblAppID.Text = InternationalLicense.ApplicationID.ToString();

            if (InternationalLicense.IsActive == 1)
                lblIsActive.Text = "YES";

            else
                lblIsActive.Text = "NO";

            lblDateOFBirth.Text = Person.DateOfBirth.ToString();
            lblDriverID.Text = Driver.DriverID.ToString();
            lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToString();

        }
    }
}
