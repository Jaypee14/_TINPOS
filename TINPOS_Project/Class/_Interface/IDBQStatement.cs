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
        bool INSERT_INTO(String TableName, String[,] ColumnName, String[] Values);
        bool Update_Table(string TableName, string[,] Columns, string[] Values, string Condition);
        bool SelectAll(String TableName);
        bool SelectAll_By(string TableName, string[,] columns, string[] values);

    }
}
