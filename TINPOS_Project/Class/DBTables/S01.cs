using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TINPOS_Project.Class.ProjectClass;
using TINPOS_Project.Class.DBTables.DbColumns;

namespace TINPOS_Project.Class.DbFunction
{
    //Derived Class (Child)
    class S01 : DBQTable
    {
        //Column Index
        private int ID_i                 { get { return 0; } }
        private int GUID_i               { get { return 1; } }
        private int Description_i        { get { return 3; } }
   
        //Constructor
        public S01() 
        {
            TableName = s01.TableName;
            Initialization(s01.txTable);
        }

        public override string[,] addDefaultColumns()
        {
            string[,] defaultColumns = {
                                      {_TXTable[ID_i,0],_TXTable[ID_i,1]}, //TableID
                                      {_TXTable[GUID_i,0],_TXTable[GUID_i,1]}, //GUID
                                      {_TXTable[Description_i,0], _TXTable[Description_i,1]} //Transaction Description
                                    };
            return defaultColumns;
        }
        public override string[] addDefaultValues()
        {
            Shared shr = new Shared();
            int valCount = Values.GetLength(0);
            string[] newValues = new String[valCount + 1]; //Set default value for Transaction Description.
            for (int ix = 0; ix < valCount + 1; ix++)
            {
                if (ix == 0)
                    newValues[ix] = shr.toTitleCase(Values[ix].Replace('_', ' '));
                else
                    newValues[ix] = Values[ix - 1];
            }
            return newValues;
        }
     
    }
}
