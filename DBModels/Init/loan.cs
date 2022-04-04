namespace DBModels.Init
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("loan")]
    public partial class loan
    {
        public int id { get; set; }

        [StringLength(10)]
        public string student_id { get; set; }

        [StringLength(10)]
        public string laptop_id { get; set; }

        public DateTime? loaned_date { get; set; }

        public DateTime? returned_date { get; set; }

        [StringLength(20)]
        public string admin_name { get; set; }

        public virtual admin admin { get; set; }

        public virtual laptop laptop { get; set; }

        public virtual student student { get; set; }
    }
}
