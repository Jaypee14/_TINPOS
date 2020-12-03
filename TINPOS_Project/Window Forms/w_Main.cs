using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TINPOS_Project.Class;
using TINPOS_Project.Window_Forms;
using TINPOS_Project.Window_Forms.Admin;
using TINPOS_Project.Class.DbFunction;
using TINPOS_Project.Class.ProjectClass;
using TINPOS_Project.Class.DBTables.DbColumns;

namespace TINPOS_Project
{
    public partial class w_Main : Form
    {
        //INITIALIZE CLASSES
        zInitialize_Columns init = new zInitialize_Columns();
        Tinposparm tp = new Tinposparm();

        //Shared shr = new Shared();
        //Tinposparm tp = new Tinposparm();
        //DBQTable a02 = new A02();
        //S02 s02 = new S02();

        //INITIALIZE FORMS
       
        


        public w_Main()
        {
            InitializeComponent();

            //tp.Initialization();

            //SET PARENT FORM


            //      shr.Initialize_TX();

            tp.User_Transaction_Access("ML", "Menu Level", "delete_S02_MenuLevel", 1);
            tp.User_Transaction_Access("ML", "Menu Level", "update_S02_MenuLevel", 1);
            //tp.User_Transaction_Access("ML", "Menu Level", "enquire_S02_MenuLevel", 1);
            tp.User_Transaction_Access("ML", "Menu Level", "print_S02_MenuLevel", 1);

            //A02 a02 = new A02();
            //MessageBox.Show(a02.Table.Column.Typeof(a02.FirstName));

         //   MessageBox.Show(a02.LastName);
            

        }

        private void ts_bt_Customers_Click(object sender, EventArgs e)
        {
            CustomerRecord frm_customerRecord = new CustomerRecord();
            frm_customerRecord.MdiParent = this;
            frm_customerRecord.Show();
        }

        private void securityMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM_SecurityMaintenance frm_SM = new SM_SecurityMaintenance();
            frm_SM.MdiParent = this;
            frm_SM.Show();
        }

       



    }
}
