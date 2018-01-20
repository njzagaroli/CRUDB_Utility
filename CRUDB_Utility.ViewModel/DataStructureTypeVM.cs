using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CRUDB_Utility.ViewModel
{
    public class DataStructureTypeVM
    {
        [Key]
        public int DataStructureTypeID { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [UIHint("tinymce_jquery_full")]
        public string Description { get; set; }

        [Display(Name = "Insert Date")]
        public DateTime? PD_INS_Date { get; set; }

        [StringLength(128)]
        [Display(Name = "Inserted By")]
        public string PD_INS_By { get; set; }

        [Display(Name = "Last Update")]
        public DateTime? PD_UPD_Date { get; set; }

        [StringLength(128)]
        [Display(Name = "Updated By")]
        public string PD_UPD_By { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataStructure> DataStructures { get; set; }
    }
}
