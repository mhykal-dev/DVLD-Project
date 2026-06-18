using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_UI.People.User_Controls;
using PEOPLE_Business;

namespace DVLD_UI.People
{
    public partial class frmAddUpdatePerson : Form
    {
        private int _PersonID = -1;
        public frmAddUpdatePerson(int ID)
        {
            InitializeComponent();

            _PersonID = ID;

            if(ID == -1 || ID == 0)
            {
                lblAdd_UpdatePersonHeader.Text = "AddNewPerson";
                lblPersonID.Text = "N/A";
            }

            else
            {
                lblAdd_UpdatePersonHeader.Text = "UpdatePerson";
                lblPersonID.Text = ID.ToString();
            }

            personCardWithFilters1.PersonID = _PersonID;

            personCardWithFilters1.ViewCard();
        }  
    }
}
