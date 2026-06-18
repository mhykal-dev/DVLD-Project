using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Tests.Tests
{
    public partial class frmScheduleTests : Form
    {
        public frmScheduleTests(int LDLAppID, int TestTypeID, string ClassTypeName, string FullName, string NationalNo, bool Retaken)
        {
            InitializeComponent();

            ctrScheduleTests1.LDLAppID = LDLAppID;

            ctrScheduleTests1.TestTypeID = TestTypeID;

            ctrScheduleTests1.ClassTypeName = ClassTypeName;

            ctrScheduleTests1.FullName = FullName;

            ctrScheduleTests1.NationalNo = NationalNo;

            ctrScheduleTests1.Retaken = Retaken;

            ctrScheduleTests1.CheckIfTheTestIsRetaken();

            ctrScheduleTests1.DecideHeader();

            ctrScheduleTests1.ShowDetails();
        }
    }
}
