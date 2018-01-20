namespace CRUDB_Utility.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("WHSE.DataStructure")]
    public partial class DataStructure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DataStructure()
        {
            DataRules = new HashSet<DataRule>();
        }

        [Key]
        public int DataStructureID { get; set; }

        public int? DataStructureTypeID { get; set; }

        public int? DataObjectID { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string DisplayTitle { get; set; }

        public string Description { get; set; }

        public DateTime? PD_INS_Date { get; set; }

        [StringLength(128)]
        public string PD_INS_By { get; set; }

        public DateTime? PD_UPD_Date { get; set; }

        [StringLength(128)]
        public string PD_UPD_By { get; set; }

        public virtual DataObject DataObject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataRule> DataRules { get; set; }

        public virtual DataStructureType DataStructureType { get; set; }
    }
}
