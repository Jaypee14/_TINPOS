using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class
{

    public class S01_SCRN_TRANS
    {

        [Mapping(ColumnName = "S01_ID")]
        public int S01_ID { get; set; }

        [Mapping(ColumnName = "S01_GUID")]
        public Guid S01_GUID { get; set; }

        [Mapping(ColumnName = "S01_Transaction")]
        public string S01_Transaction { get; set; }

        [Mapping(ColumnName = "S01_Description")]
        public string S01_Description { get; set; }

        [Mapping(ColumnName = "S01_ScreenName")]
        public string S01_ScreenName { get; set; }
    }
 
}
