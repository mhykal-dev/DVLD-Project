using COUNTRIES_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PEOPLE_Business;

namespace DVLD_UI.People.User_Controls
{
    public partial class PersonCardWithFilters : UserControl
    {
        public int PersonID { get; set; }

        clsPerson Person = new clsPerson();

        public PersonCardWithFilters()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form ParentForm = this.FindForm();

            if(ParentForm != null)
            {
                ParentForm.Close();
            }
        }

        private void _updateCountries()
        {
            cmboxCountries.DataSource = clsCountry.GetAllCountries();
            cmboxCountries.DisplayMember = "CountryName";

            cmboxCountries.ValueMember = "CountryID";
        }

        public void ViewCard()
        {
            _updateCountries();

            int ID = PersonID;

            clsPerson LocalPerson = clsPerson.Find(ID);

            if(LocalPerson != null)
            {
                Person = LocalPerson;
                txtboxNationalNo.Text = Person.NationalNo;
                txtboxFirstName.Text = Person.FirstName;
                txtboxSecondName.Text = Person.SecondName;
                txtboxThirdName.Text = Person.ThirdName;
                txtboxLastName.Text = Person.LastName;

                if(Person.Gendor == 0)
                {
                    rdbtnMale.Checked = true;
                }
                else
                {
                    rdbtnFemale.Checked = true;
                }

                txtboxEmail.Text = Person.Email;
                dateTimePicker1.Value = Person.DateOfBirth;
                txtboxPhone.Text = Person.Phone;
                txtboxAddress.Text = Person.Address;
                cmboxCountries.SelectedValue = Person.NationalityCountryID;
                Person.ImagePath = "";
            }
        }

        private void _UpdatePersonInFo()
        {
            Person.NationalNo = txtboxNationalNo.Text;
            Person.FirstName = txtboxFirstName.Text;
            Person.SecondName = txtboxSecondName.Text;
            Person.ThirdName = txtboxThirdName.Text;
            Person.LastName = txtboxLastName.Text;
            
            if(rdbtnMale.Checked == true)
            {
                Person.Gendor = 0;
            }

            else
            {
                Person.Gendor = 1;
            }

            Person.Email = txtboxEmail.Text;
            Person.DateOfBirth = dateTimePicker1.Value;
            Person.Phone = txtboxPhone.Text;
            Person.NationalityCountryID = Convert.ToInt32(cmboxCountries.SelectedValue);
            Person.Address = txtboxAddress.Text;
            Person.ImagePath = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _UpdatePersonInFo();

            if(Person.Save())
            {
                MessageBox.Show("Person Updated/Added");
                
            }

            else
            {
                MessageBox.Show("Another Error 😭😭😭😭😭😭😭😭");
            }
        }
    }
}

//cmboxCountries.DataSource = clsCountry.GetAllCountries();
//cmboxCountries.DisplayMember = "CountryName";

//cmboxCountries.ValueMember = "CountryID";
