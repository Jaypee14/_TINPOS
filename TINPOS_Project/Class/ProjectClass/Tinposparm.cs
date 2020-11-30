using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TINPOS_Project.Class.DbFunction;
using TINPOS_Project.Class.ProjectClass;

namespace TINPOS_Project.Class.ProjectClass
{
    //Parent
    class Tinposparm
    {
        S00 s00 = new S00();
        S01 s01 = new S01();
        S02 s02 = new S02();
        S03 s03 = new S03();
        T01 t01 = new T01();
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
            //s00.Initialization();
            //s01.Initialization();
            //s02.Initialization();
            //s03.Initialization();
            //t01.Initialization();

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
            string[] s00Col = { s00.Screen,
                             s00.Description };
            string[] s00Val = { ScreenName,
                                Description };
            bool s00Found = s00.Get_All_By(s00Col, s00Val);
            if (s00Found)
                s00_ID = Convert.ToInt32(s00.ValueOf(s00.ID));
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
            if (stage > 1)
            {
                shr.errMsg = "Application Error.";
                goto Exit;
            }
          
            int s01_ID = 0;
            string[] s01Col = { s01.Transaction,
                             s01.S00_ID };
            string[] s01Val = { transactionName,
                                screenID.ToString() };
            bool s01Found = s01.Get_All_By(s01Col, s01Val);
            if (s01Found)
                s01_ID = Convert.ToInt32(s01.ValueOf(s01.ID));
            else
            {
                s01.AddValues(s01Col, s01Val);
                s01_ID = Transaction(transactionName, screenID, 1);
            }

            if (stage == 1)
            {
                //Add transaction to All Menu Levels.
                if (!s02.GetAll()) //no S02 found
                {
                    shr.errMsg = "No Menu Level found";
                    goto Exit;
                } 
                DataTable s02Data = s02.DataResult;
                if (s02Data.Rows.Count > 0)
                {
                    int szS02Count = s02Data.Rows.Count;
                    for(int ix = 0; ix < szS02Count; ix++){
                        DataRow row = s02Data.Rows[ix];
                        int szS02_ID = Convert.ToInt32(row[s02.ID]);
                        string[] t01col = { t01.S02_ID,
                                         t01.S01_ID,
                                         t01.ACCESS
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

        public bool User_Transaction_Access(string screen, string description, string transaction, int userID)
        {
            //Get the Menu Level for this userID.
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
            string[] t01col = {t01.S02_ID,
                               t01.S01_ID};
            string[] t01val = {MenuID.ToString(),
                              TransactionID.ToString()};
            bool t01Found = t01.Get_All_By(t01col, t01val);
            if (t01Found)
            {
                if (Convert.ToInt32(t01.ValueOf(t01.ACCESS)) == 1)
                    MenuAccess = true;
            }
            
            //Check if user has extra access to this transaction.
            //If user has no Extra Access, use the Menu Level
            bool UserAccess = false;
            bool hasExtraAccess = false;
            string[] s03col = {s03.A02_ID,
                               s03.S01_ID};
            string[] s03val = {userID.ToString(),
                              TransactionID.ToString()};
            bool s03Found = s03.Get_All_By(s03col, s03val);
            if (s03Found)
            {
                hasExtraAccess = true;
                if (Convert.ToInt32(s03.ValueOf(s03.ACCESS)) == 1)
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
