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
using TINPOS_Project.Class.POSDatabase;
using TINPOS_Project.Window_Forms.Admin;

namespace TINPOS_Project
{
    public partial class w_Main : Form
    {
        //INITIALIZE CLASSES
      
        c_Shared shr = new c_Shared();
        

        //INITIALIZE FORMS
       
        


        public w_Main()
        {
            InitializeComponent();

            //SET PARENT FORM
            
          
      //      shr.Initialize_TX();

     
            String[] add_Product = {"add_A03_Product", "Add Products", "PR"};
            shr.txFunction(add_Product);
            

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
