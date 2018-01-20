namespace CRUDB_Utility.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("WHSE.DataObject")]
    public partial class DataObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DataObject()
        {
            DataStructures = new HashSet<DataStructure>();
        }

        public int DataObjectID { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string PhysicalName { get; set; }

        public string Description { get; set; }

        public DateTime? PD_INS_Date { get; set; }

        [StringLength(128)]
        public string PD_INS_By { get; set; }

        public DateTime? PD_UPD_Date { get; set; }

        [StringLength(128)]
        public string PD_UPD_By { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataStructure> DataStructures { get; set; }
    }
}
