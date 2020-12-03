using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TINPOS_Project.Class._Interface
{
    interface IDBQStatement
    {
        bool dbOpen();
        void dbClose();
        bool INSERT_INTO();
        bool Update_Table();
        DataTable SelectAll(String TableName);
        DataTable SelectAll_By(string TableName, string[,] columns, string[] values);

        string TableName { get; set; }
        string[,] ColumnName { get; set; }
        string[] Values { get; set; }
        string Condition { get; set; }
        string DbStatus { get; set; } 

    }
}
