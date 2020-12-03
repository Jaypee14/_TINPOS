using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using TINPOS_Project.Class._Interface;


namespace TINPOS_Project.Class.ProjectClass
{
  
    class Shared: IShared
    {

        public string errMsg { get; set; }

        public void ErrorMessage(String errorCode, String errorMessage)
        {
            MessageBox.Show(errorCode + "- " + errorMessage /*+ 
                            "\n\n Please Contact Administrator"*/,
                            "TINPOS Administrator",
                            MessageBoxButtons.OK);
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

        //public void txFunction(String[] Values)
        //{
        //    /* Search the function
        //     *           If found, check if user has access.
        //     *                  Disable/Error Message if user has no access.
        //     *           
        //     *           If not found,
        //     *                  Add the function to S01
        //     *                  Add the function to S02, enabled by default.
        //     */
        //    int STAGE = 0;
        //    c_Database db = new c_Database();
        //    S01 s01 = new S01();
        //    s01.Initialization();
        //    _START:
        //    DataTable S01_table = db.Get_All(S01.TableName);
        //    var Table = from row in S01_table.AsEnumerable()
        //                where row.Field<string>(s01.Columns_C[s01.Transaction_C]) == Values[S01.Transaction_C - 2]
        //                select row;
        //    foreach (var result in Table)
        //    {
        //        S01.ID = result.Field<int>(s01.Columns_C[s01.ID_C]);
        //        if (STAGE == 0) 
        //           goto _S03_USERACCESS;
                
        //        if (STAGE == 1)
        //        {
        //            /* Add Values to S02 ------- S02.AddValues */
        //            goto _S03_USERACCESS;
        //        }
        //    }
  
        //   // S01.AddValues(Values);
        //    STAGE++;
        //    goto _START;
        //    //Add function to All S02
        //    // Goto _S01_TRANS


        //    _S03_USERACCESS:
        //    //Check if user has access.
        // //   MessageBox.Show(S01.ID.ToString());

           

        //    return;

        //}




        /*Function to create screen name,
         *Assign the screen name to a specific form
         *Use the S00_Screen in GO TO window
         *S00_Description will be the Name of the form e.g. CustomerRecord(.cs) --.cs excluded.
         * 
         */



    }
}
