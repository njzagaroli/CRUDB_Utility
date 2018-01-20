namespace CRUDB_Utility.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("WHSE.CRUConstant")]
    public partial class CRUConstant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConstantID { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        public bool? IsSerializable { get; set; }

        public bool? IsXML { get; set; }

        public DateTime? INS_Date { get; set; }

        [StringLength(128)]
        public string INS_By { get; set; }

        public DateTime? UPD_Date { get; set; }

        [StringLength(128)]
        public string UPD_By { get; set; }
    }
}
