using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.DBTables.DbColumns
{
    static class zColumn
    {
        public static string[] AllNames { get; set; }
        //     public string[] columns { get; set; }
        public static string[] AllTypes { get; set; }
        public static string[,] szTable { get; set; }
        public static void Initialize()
        {
            int colCount = szTable.GetLength(0);
            string[] Columns = new string[colCount];
            string[] Type = new string[colCount];
            for (int ix = 0; ix < colCount; ix++)
            {
                Columns[ix] = szTable[ix, 0];
                Type[ix] = szTable[ix, 1];
            }
            AllNames = Columns;
            AllTypes = Type;
        }

        public static string Name(int columnindex)
        {
            return AllNames[columnindex];
        }

        public static string Type(int columnindex)
        {
            return AllTypes[columnindex];
        }

        public static string Typeof(string ColumnName)
        {
            int ix = 0;
            do
            {
                if (szTable[ix, 0] == ColumnName)
                    return szTable[ix, 1];
                ix++;

            } while (ix != szTable.GetLength(0));

            return string.Empty;
        }
    }
}
