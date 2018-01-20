namespace CRUDB_Utility.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("WHSE.CRUNameValue")]
    public partial class CRUNameValue
    {
        public int CRUNameValueID { get; set; }

        [StringLength(512)]
        public string Name { get; set; }

        public int? Ordinal { get; set; }

        [StringLength(512)]
        public string NKey { get; set; }

        [StringLength(512)]
        public string RecVal { get; set; }

        public DateTime? INS_Date { get; set; }

        [StringLength(128)]
        public string INS_By { get; set; }

        public DateTime? UPD_Date { get; set; }

        [StringLength(128)]
        public string UPD_By { get; set; }
    }
}
