using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.ProjectClass
{
    class TXTable
    {
        public string[,] TableArray { get; set; }
        public Column Column;
     
        public TXTable(string TableName)
        {
            Files file = new Files();
            //If in case there we use multiple .Dat file, loop this.
            if (TX_Get(TableName, file.txdat_File))
                Column = new Column(TableArray);
            else
                throw new FileNotFoundException();
        }

        private bool TX_Get(string txName, string txFileName) //Read the .Dat file from drive C:
        { //Get TX from DAT file.
            int txLineNumber = 0; //Number of Columns. 
            string txColNum = "";
            string mess_DELIM = ";";
            foreach (var szLineNumber in File.ReadLines(txFileName)
                          .Select((text, index) => new { text, lineNumber = index + 1 })
                          .Where(x => x.text.Contains(txName)))
            {
                int charLineNum = szLineNumber.text.IndexOf("_");
                try //Check if number of columns is greater than 1
                {
                    if (szLineNumber.text[charLineNum + 2].ToString() != "")
                        txColNum = szLineNumber.text[charLineNum + 1].ToString() +
                                   szLineNumber.text[charLineNum + 2].ToString();
                    else
                        txColNum = szLineNumber.text[charLineNum + 1].ToString();
                }
                catch
                {
                    txColNum = szLineNumber.text[charLineNum + 1].ToString();
                }
                txLineNumber = szLineNumber.lineNumber;
            }
            if (txLineNumber <= 0)
                goto ErrorMessage;

            int szColNum = Int32.Parse(txColNum);
            if (szColNum <= 0)
                goto ErrorMessage;

            TableArray = new String[szColNum, 2];
            int ix = 0;
            foreach (var szLineValues in File.ReadLines(txFileName)
                          .Select((text, index) => new { text, lineNumber = index + 1 })
                          .Where(x => x.lineNumber > txLineNumber))
            {
                string[] line = szLineValues.text.Split(',');
                TableArray[ix, 0] = line[0];
                TableArray[ix, 1] = line[1];
                if (szLineValues.text.Contains(mess_DELIM))
                {
                    goto NextSentence;
                }
                ix++;
            }
        NextSentence:
            TableArray[ix, 1] = TableArray[ix, 1].ToString().Replace(mess_DELIM, string.Empty);
            return true;

        ErrorMessage:
            //ErrorMessage("TX_Get", "TxFile does not exist: " + txName);
            return false;
        }

    }

    class Column 
    {
        public string[] AllNames { get; set; }
        //     public string[] columns { get; set; }
        public string[] AllTypes { get; set; }
        private string[,] szTable { get; set; }
        public Column(string[,] Table)
        {
            szTable = Table;
            int colCount = Table.GetLength(0);
            string[] Columns = new string[colCount];
            string[] Type = new string[colCount];
            for (int ix = 0; ix < colCount; ix++)
            {
                Columns[ix] = Table[ix, 0];
                Type[ix] = Table[ix, 1];
            }
            AllNames = Columns;
            AllTypes = Type;
        }

        public string Name(int columnindex)
        {
            return AllNames[columnindex];
        }

        public string Type(int columnindex)
        {
            return AllTypes[columnindex];
        }

        public string Typeof(string ColumnName)
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
        

