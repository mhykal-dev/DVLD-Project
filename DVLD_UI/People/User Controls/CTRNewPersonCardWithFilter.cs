using PEOPLE_Business;
using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace DVLD_UI.People.User_Controls
{
    public partial class CTRNewPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelectedev;
        
        protected virtual void OnPersonSelected(int PersonID)
        {
            Action <int> Handler = OnPersonSelectedev;

            if( Handler != null )
            {
                Handler(PersonID);
            }
        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public CTRNewPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get { return ctrNewPersonCard1.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctrNewPersonCard1.SelectedPersonInfo; }
        }

        public void LoadPersonInFo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();
        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    if(int.TryParse(txtFilterValue.Text.Trim(), out int PersonID))
                    {
                        ctrNewPersonCard1.LoadPersonInfo(PersonID);
                        OnPersonSelected(PersonID);
                    }

                    break;

                case "National No.":
                    ctrNewPersonCard1.LoadPersonInfo(txtFilterValue.Text);

                    break;

                default:
                    break;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FindNow();
        }

        private void ctrNewPersonCard1_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This Field Is required!");
                return;
            }

            if(cbFilterBy.Text == "Person ID" && !int.TryParse(txtFilterValue.Text.Trim(), out int PersonID))
            {
                e.Cancel= true;
                errorProvider1.SetError(txtFilterValue, "Person ID Must be a Number");
                return;
            }

            errorProvider1.SetError(txtFilterValue, null);
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            using (frmAddUpdatePerson frm1 = new frmAddUpdatePerson())
            {
                frm1.DataBack += DataBackEvent; // Subscribe to the event
                frm1.ShowDialog();
            }
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrNewPersonCard1.LoadPersonInfo(PersonID);
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}