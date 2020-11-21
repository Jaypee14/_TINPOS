using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TINPOS_Project.Class.POSDatabase;
using System.Data;


namespace TINPOS_Project.Class
{
  
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    [Serializable]
    public class MappingAttribute : Attribute
    {
        public string ColumnName = null;
    }

    class c_Shared
    {
        //Classes
    //    c_TX_Database txdb = new c_TX_Database();
    //    c_Database    db = new c_Database();
        S01 S01 = new S01();

        public string line_DELIM = ",";
        public string mess_DELIM = ";";
        public string txdat_File = @"C:\TINPOS\DAT\Common.dat";


  

        public string errMsg;
        public void ErrorMessage(String errorCode, String errorMessage)
        {
            MessageBox.Show(errorCode + "- " + errorMessage /*+ 
                            "\n\n Please Contact Administrator"*/, 
                            "TINPOS Administrator", 
                            MessageBoxButtons.OK);

        }

        public T MapToClass<T>(SqlDataReader reader) where T : class
        {
            T returnedObject = Activator.CreateInstance<T>();
            PropertyInfo[] modelProperties = returnedObject.GetType().GetProperties();
            for (int i = 0; i < modelProperties.Length; i++)
            {
                MappingAttribute[] attributes = modelProperties[i].GetCustomAttributes<MappingAttribute>(true).ToArray();

                if (attributes.Length > 0 && attributes[0].ColumnName != null)
                    modelProperties[i].SetValue(returnedObject, Convert.ChangeType(reader[attributes[0].ColumnName], modelProperties[i].PropertyType), null);
            }
            return returnedObject;
        }

        public void Initialize_TX()
        {
            //S01 S01 = new S01();
            //S03 S03 = new S03();
            ////Initialize all TX from Common.Dat
            //S01.Columns_C = TX_Get("TXS01");
            //S03.Columns_C = TX_Get("TXS03");

        }

        public string[] TX_Get(string txName){ //Get TX from DAT file.
            
            int txLineNumber = 0;
            string txColNum = "";
            foreach (var szLineNumber in File.ReadLines(txdat_File)
                          .Select((text, index) => new { text, lineNumber = index+ 1 })
                          .Where(x => x.text.Contains(txName)))
            {
                int charLineNum = szLineNumber.text.IndexOf("_");
                try
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

            String[] txTable = new String[szColNum]; 
            int ix = 0;
            foreach (var szLineValues in File.ReadLines(txdat_File)
                          .Select((text, index) => new { text, lineNumber = index + 1 })
                          .Where(x => x.lineNumber > txLineNumber))
            {
                txTable[ix] = szLineValues.text.Replace(line_DELIM, string.Empty);
                if (szLineValues.text.Contains(mess_DELIM))
                {
                    goto NextSentence;
                }
                ix++;
            }

        NextSentence:
        txTable[ix] = txTable[ix].ToString().Replace(mess_DELIM, string.Empty);
        return txTable;

        ErrorMessage:
        ErrorMessage("TX_Get", "TxFile does not exist: " + txName);
        return null;

        }


        public void txFunction(String[] Values)
        {
            /* Search the function
             *           If found, check if user has access.
             *                  Disable/Error Message if user has no access.
             *           
             *           If not found,
             *                  Add the function to S01
             *                  Add the function to S02, enabled by default.
             */
            int STAGE = 0;
            c_Database db = new c_Database();
            S01 s01 = new S01();
            s01.Initialization();
            _START:
            DataTable S01_table = db.Get_All(S01.TableName);
            var Table = from row in S01_table.AsEnumerable()
                        where row.Field<string>(s01.Columns_C[s01.Transaction_C]) == Values[S01.Transaction_C - 2]
                        select row;
            foreach (var result in Table)
            {
                S01.ID = result.Field<int>(s01.Columns_C[s01.ID_C]);
                if (STAGE == 0) 
                   goto _S03_USERACCESS;
                
                if (STAGE == 1)
                {
                    /* Add Values to S02 ------- S02.AddValues */
                    goto _S03_USERACCESS;
                }
            }
  
            S01.AddValues(Values);
            STAGE++;
            goto _START;
            //Add function to All S02
            // Goto _S01_TRANS


            _S03_USERACCESS:
            //Check if user has access.
         //   MessageBox.Show(S01.ID.ToString());

           

            return;

        }


        public string toTitleCase(string text)
        {
            if (text == string.Empty)
                return string.Empty;
            int count = text.Length;
            string TitleCase = text.Substring(0, 1).ToUpper();
            for (int i = 1; i < count; i++)
            {
                if (text.Substring(i, 1) == " ") 
                {
                    TitleCase = TitleCase + text.Substring(i, 1);
                    TitleCase = TitleCase + text.Substring(i + 1, 1).ToUpper();
                    i++;
                }
                else
                    TitleCase = TitleCase + text.Substring(i, 1).ToLower();

            }
            return TitleCase;
        }

        /*Function to create screen name,
         *Assign the screen name to a specific form
         *Use the S00_Screen in GO TO window
         *S00_Description will be the Name of the form e.g. CustomerRecord(.cs) --.cs excluded.
         * 
         */

        public void CreateDir(string path, string fileName)
        {
            string TINPOS = @"C:\TINPOS";
            string DebugSource = Directory.GetCurrentDirectory();
            string directory = Path.GetDirectoryName(DebugSource);
            string oneUp = Path.GetDirectoryName(directory);
            string CommonSource = oneUp + "\\" + "Class" + "\\" + fileName;

            if (!Directory.Exists(TINPOS))
                Directory.CreateDirectory(TINPOS);

            //if exist
            if (!Directory.Exists(TINPOS + "\\" + path))
                Directory.CreateDirectory(TINPOS + "\\" + path);

            string targetPath = TINPOS + "\\" + path + "\\" + fileName;

            if (!File.Exists(TINPOS + "\\" + path + "\\" + fileName))
                File.Copy(CommonSource, targetPath);

        }

    }
}
