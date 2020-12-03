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
    class T01 : DBQTable
    {
        //Constructor
        public T01() 
        {
            TableName = t01.TableName;
            Initialization(t01.txTable);
        }

      
    }
}
