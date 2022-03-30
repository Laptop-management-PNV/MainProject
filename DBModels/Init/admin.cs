namespace DBModels.Init
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class admin
    {
        private const string ADMINNAMEBLANKED = "AdminName bị trống!";
        private const string PASWORDBLANKED = "Password bị trống!";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public admin()
        {
            loans = new HashSet<loan>();
        }

        [Key]
        [Required(ErrorMessage = ADMINNAMEBLANKED)]
        [StringLength(20, ErrorMessage = "Độ dài tối đa là 20 kí tự!")]

        public string name { get; set; }

        [Required(ErrorMessage = PASWORDBLANKED)]
        [StringLength(100, ErrorMessage = "Độ dài tối đa 100 kí tự!")]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<loan> loans { get; set; }
    }
}
