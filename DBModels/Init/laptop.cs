namespace DBModels.Init
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class laptop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public laptop()
        {
            loans = new HashSet<loan>();
        }

        [StringLength(10)]
        public string id { get; set; }

        public int? brand_id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string img { get; set; }

        public virtual brand brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<loan> loans { get; set; }

        public virtual spec spec { get; set; }
    }
}
