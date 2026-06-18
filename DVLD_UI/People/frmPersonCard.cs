using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PEOPLE_Business;

namespace DVLD_UI.People
{
    public partial class frmPersonCard : Form
    {
        private int _PersonID { get; set; }

        public frmPersonCard(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            ctrPersonCard1.PersonID = _PersonID;

            ctrPersonCard1.ViewPersonInFo();

        }
    }
}
