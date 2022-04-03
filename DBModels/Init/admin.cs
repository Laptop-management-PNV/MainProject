namespace DBModels.Init
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public admin()
        {
            loans = new HashSet<loan>();
        }

        [Key]
        [StringLength(20)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }

        [StringLength(10)]
        public string permission { get; set; }

        public bool active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<loan> loans { get; set; }
    }
}
