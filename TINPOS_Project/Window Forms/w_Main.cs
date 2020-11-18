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

namespace TINPOS_Project
{
    public partial class w_Main : Form
    {
        //INITIALIZE CLASSES
        c_Database txc_dat = new c_Database();

        //INITIALIZE FORMS
        CustomerRecord frm_customerRecord = new CustomerRecord();



        public w_Main()
        {
            InitializeComponent();

            //SET PARENT FORM
            frm_customerRecord.MdiParent = this;



            txc_dat.dbOpen();


            txc_dat.dbClose();
        }

        private void ts_bt_Customers_Click(object sender, EventArgs e)
        {
            frm_customerRecord.Show();
        }

       



    }
}
