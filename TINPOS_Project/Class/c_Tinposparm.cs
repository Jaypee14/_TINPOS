using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TINPOS_Project.Class.POSDatabase;

namespace TINPOS_Project.Class
{
    class c_Tinposparm
    {
        S00 s00 = new S00();
        S01 s01 = new S01();
        S02 s02 = new S02();
        S03 s03 = new S03();
        T01 t01 = new T01();


        public bool add_A01_Customer {get; set;}
        public bool enquire_A01_Customer { get; set; }
        public bool update_A01_Customer { get; set; }
        public bool delete_A01_Customer { get; set; }
        public bool add_A03_Product { get; set; }
        public bool enquire_A03_Product { get; set; }
        public bool update_A03_Product { get; set; }
        public bool delete_A03_Product { get; set; }
        public bool add_S02_MenuLevel { get; set; }


        public void Initialization()
        {
            s00.Initialization();
            s01.Initialization();
            s02.Initialization();
            s03.Initialization();
            t01.Initialization();

            add_A01_Customer        =               User_Transaction_Access("CR", "CustomerRecord", "add_A01_Customer", 1);
            enquire_A01_Customer    =               User_Transaction_Access("CR", "CustomerRecord", "enquire_A01_Customer", 1);
            update_A01_Customer     =               User_Transaction_Access("CR", "CustomerRecord", "update_A01_Customer", 1);
            delete_A01_Customer     =               User_Transaction_Access("CR", "CustomerRecord", "delete_A01_Customer", 1);
            add_A03_Product         =               User_Transaction_Access("PR", "Products", "add_A03_Product", 1);
            enquire_A03_Product     =               User_Transaction_Access("PR", "Products", "enquire_A03_Product", 1);
            update_A03_Product      =               User_Transaction_Access("PR", "Products", "update_A03_Product", 1);
            delete_A03_Product      =               User_Transaction_Access("PR", "Products", "delete_A03_Product", 1);
            add_S02_MenuLevel       =               User_Transaction_Access("ML", "Menu Level", "add_S02_Product", 1);

        }


        //Method to check if there is an access to screen.
        //Method to check if there is access to a specific transaction.
        private int Screen(string ScreenName, string Description, int stage = 0)
        {
            c_Shared shr = new c_Shared();

            if (stage > 1)
            {
                shr.errMsg = "Application Error.";
                goto Exit;
            }

            int s00_ID = 0;
            int[] s00Col = { s00.Screen_C,
                             s00.Description_C };
            string[] s00Val = { ScreenName,
                                Description };
            DataTable s00Data = s00.get_All_By(s00Col, s00Val);
            if (s00Data.Rows.Count > 0)
            {
                DataRow row = s00Data.Rows[0];
                s00_ID = Convert.ToInt32(row[s00.Columns_C[s00.ID_C]]);
            }
            else
            {
                s00.AddValues(s00Col, s00Val);
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
            c_Shared shr = new c_Shared();
            c_Database db = new c_Database();

            if (stage > 1)
            {
                shr.errMsg = "Application Error.";
                goto Exit;
            }
          
            int s01_ID = 0;
            int[] s01Col = { s01.Transaction_C,
                             s01.S00_ID_C };
            string[] s01Val = { transactionName,
                                screenID.ToString() };
            DataTable s01Data = s01.get_All_By(s01Col, s01Val);
            if (s01Data.Rows.Count > 0)
            {
                DataRow row = s01Data.Rows[0];
                s01_ID = Convert.ToInt32(row[s01.ID_C]);
            }
            else
            {
                s01.AddValues(s01Col, s01Val);
                s01_ID = Transaction(transactionName, screenID, 1);
            }

            if (stage == 1)
            {
                //Add transaction to All Menu Levels.
                DataTable s02Data = db.Get_All(s02.TableName);
                if (s02Data.Rows.Count > 0)
                {
                    int szS02Count = s02Data.Rows.Count;
                    for(int ix = 0; ix < szS02Count; ix++){
                        DataRow row = s02Data.Rows[ix];
                        int szS02_ID = Convert.ToInt32(row[s02.Columns_C[s02.ID_C]]);
                        int[] t01col = { t01.S02_ID_C,
                                         t01.S01_ID_C,
                                         t01.ACCESS_C,
                                       };
                        string[] t01val = { szS02_ID.ToString(),
                                            s01_ID.ToString(),
                                            "0"
                                          };
                        t01.AddValues(t01col, t01val);
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

        private bool User_Transaction_Access(string screen, string description, string transaction, int userID)
        {
            //Get the Menu Level for this userID.
            c_Shared shr = new c_Shared();

            int MenuID = s03.get_MenuLevel(userID);
            if (MenuID == 0)
            {
                shr.errMsg = "No Menu Level Linked.";
                goto Exit;
            }

            //Check if screen exist
            int screenID      = Screen(screen, description);

            //Check if Transaction exist
            int TransactionID = Transaction(transaction, screenID);

            //Check if user's Menu Level has access to this screen.
            bool MenuAccess = false;
            int[] t01col = {t01.S02_ID_C,
                            t01.S01_ID_C};
            string[] t01val = {MenuID.ToString(),
                              TransactionID.ToString()};
            DataTable t01Data = t01.get_All_By(t01col, t01val);
            if (t01Data.Rows.Count > 0)
            {
                DataRow row = t01Data.Rows[0];
                if (Convert.ToInt32(row[t01.Columns_C[t01.ACCESS_C]]) == 1)
                    MenuAccess = true;
            }
            
            //Check if user has extra access to this transaction.
            bool UserAccess = false;
            int[] s03col = {s03.A02_ID_C,
                            s03.S01_ID_C};
            string[] s03val = {userID.ToString(),
                              TransactionID.ToString()};
            DataTable s03Data = s03.get_All_By(s03col, s03val);
            if (s03Data.Rows.Count > 0)
            {
                DataRow row = s03Data.Rows[0];
                if (Convert.ToInt32(row[s03.Columns_C[s03.ACCESS_C]]) == 1)
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
                if (MenuAccess)
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
