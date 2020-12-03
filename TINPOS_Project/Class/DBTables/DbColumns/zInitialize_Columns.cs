using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TINPOS_Project.Class.ProjectClass;

namespace TINPOS_Project.Class.DBTables.DbColumns
{
    class zInitialize_Columns
    {
        string[,] _Table;

        public zInitialize_Columns()
        {
            //Read from File
            ReadTXFile(a02.TxName);
            a02.txTable = _Table;
            a02.Initialize();

            ReadTXFile(s00.TxName);
            s00.txTable = _Table;
            s00.Initialize();

            ReadTXFile(s01.TxName);
            s01.txTable = _Table;
            s01.Initialize();

            ReadTXFile(s02.TxName);
            s02.txTable = _Table;
            s02.Initialize();

            ReadTXFile(s03.TxName);
            s03.txTable = _Table;
            s03.Initialize();

            ReadTXFile(t01.TxName);
            t01.txTable = _Table;
            t01.Initialize();

            //******************************
            


        }
        public void ReadTXFile(string TableName)
        {
            TXTable txTable = new TXTable(TableName);
            _Table = txTable.TableArray;
        }
    }
}
