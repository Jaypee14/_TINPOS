using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TINPOS_Project.Class
{
    class c_Shared
    {
        public void ErrorMessage(String errorCode, String errorMessage)
        {
            MessageBox.Show(errorCode + "- " + errorMessage + 
                            "\n\n Please Contact Administrator", 
                            "TINPOS Administrator", 
                            MessageBoxButtons.OK);

        }
    }
}
