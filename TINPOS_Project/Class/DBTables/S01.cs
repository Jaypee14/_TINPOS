using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TINPOS_Project.Class.ProjectClass;


namespace TINPOS_Project.Class.DbFunction
{
    //Derived Class (Child)
    class S01 : DBQTable
    {
        public override DataTable DataResult      { get; set; }
        public string tableName       { get { return "S01_SCRN_TRANS"; } }
        public string txName          { get { return "TXS01"; } }
        //Column Index
        private int ID_i                 { get { return 0; } }
        private int GUID_i               { get { return 1; } }
        private int Description_i        { get { return 3; } }
    

        public string ID                 { get; set; }
        public string GUID               { get; set; }
        public string Transaction        { get; set; }
        public string Description        { get; set; }
        public string S00_ID             { get; set; }

   
        //Constructor
        public S01() 
        {
            //Default Columns.
            ID_C = ID_i;
            GUID_C = GUID_i;

            TableName = tableName;
            TxName = txName;
            Initialization();

            ID          = Table.Column.Name(0);
            GUID        = Table.Column.Name(1);
            Transaction = Table.Column.Name(2);
            Description = Table.Column.Name(3);
            S00_ID      = Table.Column.Name(4);

        }

        public override void AddValues(string[] columnName, String[] Values)
        {
            DBQStatement db = new DBQStatement();
            Shared shr = new Shared();


            int valCount = Values.GetLength(0);
            if (valCount <= 0)
            {
                shr.errMsg = "No Values to Add.";
                goto ErrorMsg;
            }

            string[,] defaultColumns = {
                                      {TXTable[ID_C,0],TXTable[ID_C,1]}, //TableID
                                      {TXTable[GUID_C,0],TXTable[GUID_C,1]}, //GUID
                                      {TXTable[Description_i,0], TXTable[Description_i,1]} //Transaction Description
                                    };
            string[,] columnsToAdd = addColumnType(columnName);

            int defColCount = defaultColumns.GetLength(0);
            int colCount = defColCount + columnsToAdd.GetLength(0);
            string[,] columns = new string[colCount, 2];
            for (int i = 0; i < colCount; i++)
            {
                if (i < defColCount)
                {
                    columns[i, 0] = defaultColumns[i, 0];
                    columns[i, 1] = defaultColumns[i, 1];
                    continue;
                }
                columns[i, 0] = columnsToAdd[i - defColCount, 0];
                columns[i, 1] = columnsToAdd[i - defColCount, 1];
            }

            String[] newValues = new String[valCount + 1]; //Set default value for Transaction Description.
            for (int ix = 0; ix < valCount + 1; ix++)
            {
                if (ix == 0)
                    newValues[ix] = shr.toTitleCase(Values[ix].Replace('_', ' '));
                else
                    newValues[ix] = Values[ix - 1];
            }
            db.INSERT_INTO(TableName, columns, newValues);
            return;
        ErrorMsg:
            shr.ErrorMessage("S01_AddValues()", shr.errMsg);
        }

     
    }
}
