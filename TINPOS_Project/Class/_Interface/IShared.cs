using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class._Interface
{
    interface IShared
    {
        string toTitleCase(string text);
        void ErrorMessage(String errorCode, String errorMessage);
    }
}
