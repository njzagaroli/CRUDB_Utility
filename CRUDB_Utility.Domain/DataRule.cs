namespace CRUDB_Utility.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("WHSE.DataRule")]
    public partial class DataRule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DataRule()
        {
            DataRuleValidations = new HashSet<DataRuleValidation>();
        }

        public int DataRuleID { get; set; }

        public int? DataStructureID { get; set; }

        public int? SectionOrdinal { get; set; }

        [StringLength(128)]
        public string SectionName { get; set; }

        public int? DisplayOrdinal { get; set; }

        [StringLength(128)]
        public string ColumnName { get; set; }

        [StringLength(128)]
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public DateTime? PD_INS_Date { get; set; }

        [StringLength(128)]
        public string PD_INS_By { get; set; }

        public DateTime? PD_UPD_Date { get; set; }

        [StringLength(128)]
        public string PD_UPD_By { get; set; }

        public virtual DataStructure DataStructure { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataRuleValidation> DataRuleValidations { get; set; }
    }
}
