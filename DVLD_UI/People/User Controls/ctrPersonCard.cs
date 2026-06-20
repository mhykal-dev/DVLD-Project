using COUNTRIES_Business;
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

namespace DVLD_UI.People.User_Controls
{
    public partial class ctrPersonCard : UserControl
    {
        public int PersonID { get; set; }

        public string NationalNo { get; set; }

        public bool EnableNext = false;

        public ctrPersonCard()
        {
            InitializeComponent();
        }

        private void _UpdateCountries()
        {
            cmboxCountries.DataSource = clsCountry.GetAllCountries();
            cmboxCountries.DisplayMember = "CountryName";

            cmboxCountries.ValueMember = "CountryID";
        }

        public void ViewPersonInFo()
        {
            _UpdateCountries();

            clsPerson Person = clsPerson.Find(PersonID);

            if (Person != null)
            {
                lblPersonID.Text = Person.PersonID.ToString();
                lblFullName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
                lblNationalNo.Text = Person.NationalNo;
                lblDateOfBirth.Text = Person.DateOfBirth.ToString();
                lblEmail.Text = Person.Email;
                lblPhone.Text = Person.Phone;
                if (Person.Gendor == 0)
                {
                    lblGendor.Text = "Male";
                }
                else
                {
                    lblGendor.Text = "Female";
                }
                txtboxAddress.Text = Person.Address;
                cmboxCountries.SelectedValue = Person.NationalityCountryID;
                NationalNo = Person.NationalNo;
            }
            else
            {
                MessageBox.Show("Wrong PersonID! = " + Person.PersonID.ToString());
            }

        }

        public void ViewPersonInFoByNationalNo()
        {
            _UpdateCountries();

            clsPerson Person = clsPerson.FindByNationalNo(NationalNo);

            if (Person != null)
            {
                lblPersonID.Text = Person.PersonID.ToString();
                lblFullName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
                lblNationalNo.Text = Person.NationalNo;
                lblDateOfBirth.Text = Person.DateOfBirth.ToString();
                lblEmail.Text = Person.Email;
                lblPhone.Text = Person.Phone;
                if (Person.Gendor == 0)
                {
                    lblGendor.Text = "Male";
                }
                else
                {
                    lblGendor.Text = "Female";
                }
                txtboxAddress.Text = Person.Address;
                cmboxCountries.SelectedValue = Person.NationalityCountryID;
                NationalNo = Person.NationalNo;
            }
            else
            {
                MessageBox.Show("Wrong PersonID! = " + Person.PersonID.ToString());
            }

        }

        public void Reset()
        {
            _UpdateCountries();

            lblPersonID.Text = "[???]";
            lblFullName.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            lblEmail.Text = "[???]";
            lblPhone.Text = "[???]";
            lblGendor.Text = "[???]";
            lblGendor.Text = "[???]";
            txtboxAddress.Text = "[???]";
            cmboxCountries.SelectedValue = 0;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                PersonID = clsPerson.GetPersonIDByFilter(cmbFilterBy.SelectedItem.ToString(), txtboxFilterField.Text);

                if (PersonID != -1)
                {
                    ViewPersonInFo();
                }

                else
                {
                    MessageBox.Show("person Not Found!");

                    Reset();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void DisableSeaech()
        {
            groupBox1.Enabled = false;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);
            frm.ShowDialog();

            frm.Dispose();
        }
    }
}
