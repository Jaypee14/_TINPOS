using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TINPOS_Project.Class.DbFunction;
using TINPOS_Project.Class.ProjectClass;
using TINPOS_Project.Class.DBTables.DbColumns;

namespace TINPOS_Project.Class.ProjectClass
{
    //Parent
    class Tinposparm
    {
        S00 S00 = new S00();
        S01 S01 = new S01();
        S02 S02 = new S02();
        S03 S03 = new S03();
        T01 T01 = new T01();
        Shared shr = new Shared();


        public bool add_A01_Customer {get; set;}
        public bool enquire_A01_Customer { get; set; }
        public bool update_A01_Customer { get; set; }
        public bool delete_A01_Customer { get; set; }
        public bool add_A03_Product { get; set; }
        public bool enquire_A03_Product { get; set; }
        public bool update_A03_Product { get; set; }
        public bool delete_A03_Product { get; set; }
        public bool add_S02_MenuLevel { get { return User_Transaction_Access("ML", "Menu Level", "add_S02_Product", 1); } }
    


        public void Initialization()
        {
 

            //add_A01_Customer        =               User_Transaction_Access("CR", "CustomerRecord", "add_A01_Customer", 1);
            //enquire_A01_Customer    =               User_Transaction_Access("CR", "CustomerRecord", "enquire_A01_Customer", 1);
            //update_A01_Customer     =               User_Transaction_Access("CR", "CustomerRecord", "update_A01_Customer", 1);
            //delete_A01_Customer     =               User_Transaction_Access("CR", "CustomerRecord", "delete_A01_Customer", 1);
            //add_A03_Product         =               User_Transaction_Access("PR", "Products", "add_A03_Product", 1);
            //enquire_A03_Product     =               User_Transaction_Access("PR", "Products", "enquire_A03_Product", 1);
            //update_A03_Product      =               User_Transaction_Access("PR", "Products", "update_A03_Product", 1);
            //delete_A03_Product      =               User_Transaction_Access("PR", "Products", "delete_A03_Product", 1);

        }


        //Method to check if there is an access to screen.
        //Method to check if there is access to a specific transaction.
        private int Screen(string ScreenName, string Description, int stage = 0)
        {
            if (stage > 1)
            {
                shr.errMsg = "Application Error.";
                goto Exit;
            }

            int s00_ID = 0;
            S00.ColumnName = new string[]
                           { s00.Screen,
                             s00.Description };
            S00.Values = new string []
                           { ScreenName,
                             Description };
            bool s00Found = S00.GetAll_By();
            if (s00Found)
                s00_ID = Convert.ToInt32(S00.ValueOf(s00.ID));
            else
            {
                S00.Insert();
                s00_ID = Screen(ScreenName, Description, 1);
            }
            if(s00_ID != 0)
               return s00_ID;
            shr.errMsg = "Screen ID is zero";
        Exit:
            shr.ErrorMessage("Parm/Screen: ", shr.errMsg);
            System.Environment.Exit(0);
            return 0;
        }

        private int Transaction(string transactionName, int screenID, int stage = 0)
        {
            if (stage > 1)
            {
                shr.errMsg = "Application Error.";
                goto Exit;
            }
          
            int s01_ID = 0;
            S01.ColumnName = new string []
                           { s01.Transaction,
                             s01.S00_ID };
            S01.Values = new string []
                           { transactionName,
                             screenID.ToString() };
            bool s01Found = S01.GetAll_By();
            if (s01Found)
                s01_ID = Convert.ToInt32(S01.ValueOf(s01.ID));
            else
            {
                S01.Insert();
                s01_ID = Transaction(transactionName, screenID, 1);
            }

            if (stage == 1)
            {
                //Add transaction to All Menu Levels.
                if (!S02.GetAll()) //no S02 found
                {
                    shr.errMsg = S02.DbStatus;
                    goto Exit;
                } 
                DataTable s02Data = S02.DataResult;
                if (s02Data.Rows.Count > 0)
                {
                    int szS02Count = s02Data.Rows.Count;
                    for(int ix = 0; ix < szS02Count; ix++){
                        DataRow row = s02Data.Rows[ix];
                        int szS02_ID = Convert.ToInt32(row[s02.ID]);
                        T01.ColumnName = new string[]
                                       { t01.S02_ID,
                                         t01.S01_ID,
                                         t01.ACCESS
                                       };
                        T01.Values = new string []
                                       { szS02_ID.ToString(),
                                            s01_ID.ToString(),
                                            "0"
                                       };
                        T01.Insert();
                    }
                }
            }
            if (s01_ID != 0)
               return s01_ID;
            shr.errMsg = "Transaction ID is zero";
        Exit:
            shr.ErrorMessage("Parm/Transaction: ", shr.errMsg);
            System.Environment.Exit(0);
            return 0;
            
        }

        public bool User_Transaction_Access(string screen, string description, string transaction, int userID)
        {
            //Get the Menu Level for this userID.
            int MenuID = S03.get_MenuLevel(userID);
            if (MenuID == 0)
            {
                shr.errMsg = "No Menu Level Linked. -" + Environment.NewLine + S03.DbStatus;
                goto Exit;
            }

            //Check if screen exist
            int screenID      = Screen(screen, description);

            //Check if Transaction exist
            int TransactionID = Transaction(transaction, screenID);

            //Check if user's Menu Level has access to this screen.
            bool MenuAccess = false;
            T01.ColumnName = new string[]
                              {t01.S02_ID,
                               t01.S01_ID};
            T01.Values = new string []
                              {MenuID.ToString(),
                              TransactionID.ToString()};
            bool t01Found = T01.GetAll_By();
            if (t01Found)
            {
                if (Convert.ToInt32(T01.ValueOf(t01.ACCESS)) == 1)
                    MenuAccess = true;
            }
            
            //Check if user has extra access to this transaction.
            //If user has no Extra Access, use the Menu Level
            bool UserAccess = false;
            bool hasExtraAccess = false;
            S03.ColumnName = new string[]
                              {s03.A02_ID,
                               s03.S01_ID};
            S03.Values = new string []
                              {userID.ToString(),
                               TransactionID.ToString()};
            bool s03Found = S03.GetAll_By();
            if (s03Found)
            {
                hasExtraAccess = true;
                if (Convert.ToInt32(S03.ValueOf(s03.ACCESS)) == 1)
                    UserAccess = true;
            }



            /*
             * If UserAccess = false, MenuAccess = true
             *      return true;
             * If UserAccess = true
             *      return true;
             * If UserAccess = false, MenuAccess = false
             *     return false;
             */
            if (UserAccess)
                return true;
            else
            {
                if (!hasExtraAccess && MenuAccess)
                    return true;
                else
                    return false;
            }

        Exit:
            shr.ErrorMessage("User Screen Access: ", shr.errMsg);
            System.Environment.Exit(0);
            return false;
        }

    }
}
