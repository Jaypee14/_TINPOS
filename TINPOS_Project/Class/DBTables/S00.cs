using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TINPOS_Project.Class.DBTables.DbColumns;

namespace TINPOS_Project.Class.DbFunction
{
    //Derived Class (Child)
    class S00 : DBQTable
    {
        //Constructor
        public S00() 
        {
            TableName = s00.TableName;
            Initialization(s00.txTable);

        }
       


    }
}
