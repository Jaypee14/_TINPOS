using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TINPOS_Project.Class;

namespace TINPOS_Project.Windows_Forms_Headers.Admin
{
    class SM_SecurityMaintenance_h : Form
    {
        public bool add_S02_MenuLevel { get; set; }
        public SM_SecurityMaintenance_h()
        {
            c_Tinposparm parm = new c_Tinposparm();

            add_S02_MenuLevel = parm.User_Transaction_Access("ML", "Menu Level", "add_S02_Product", 1);

        }
    }
}
