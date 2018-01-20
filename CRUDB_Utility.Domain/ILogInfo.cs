using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDB_Utility.Domain
{
    public interface ILogInfo
    {

        Nullable<System.DateTime> PD_INS_Date { get; set; }
        Nullable<System.DateTime> PD_UPD_Date { get; set; }
        string PD_INS_By { get; set; }
        string PD_UPD_By { get; set; }

    }
}
