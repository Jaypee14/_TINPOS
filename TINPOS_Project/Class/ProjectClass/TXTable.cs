using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TINPOS_Project.Class.ProjectClass
{
    class TXTable
    {
        public string[,] TableArray { get; set; }
     //   public Column Column;
     
        public TXTable(string TableName)
        {
            Files file = new Files();
            //If in case there we use multiple .Dat file, loop this.
            //if (TX_Get(TableName, file.txdat_File))
            //    Column = new Column(TableArray);
            //else
            //    throw new FileNotFoundException();

            if (!TX_Get(TableName, file.txdat_File))
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

}
        

