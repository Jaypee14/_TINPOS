using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TINPOS_Project.Class.DBTables.DbColumns;

namespace TINPOS_Project.Class.DbFunction
{
    //Derived Class (Child)
    class S02 : DBQTable
    {
   
        //Constructor
        public S02() 
        {
            TableName = s02.TableName;
            Initialization(s02.txTable);
        }

       


    }
}
