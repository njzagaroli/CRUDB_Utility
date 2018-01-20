namespace CRUDB_Utility.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("WHSE.DataRuleValidation")]
    public partial class DataRuleValidation
    {
        public int DataRuleValidationID { get; set; }

        public int? DataRuleID { get; set; }

        public int? ProductValidationID { get; set; }

        public string ValidationNotes { get; set; }

        public bool? IsNULL { get; set; }

        public bool? IsRegExpression { get; set; }

        [StringLength(256)]
        public string RegularExpression { get; set; }

        public bool? IsCode { get; set; }

        [StringLength(128)]
        public string ValidationObject { get; set; }

        public DateTime? PD_INS_Date { get; set; }

        [StringLength(128)]
        public string PD_INS_By { get; set; }

        public DateTime? PD_UPD_Date { get; set; }

        [StringLength(128)]
        public string PD_UPD_By { get; set; }

        public virtual DataRule DataRule { get; set; }

        public virtual ProductValidation ProductValidation { get; set; }
    }
}
