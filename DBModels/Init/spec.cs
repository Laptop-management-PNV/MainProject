namespace DBModels.Init
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class spec
    {
        [Key]
        [StringLength(10)]
        public string laptop_id { get; set; }

        [StringLength(30)]
        public string memory { get; set; }

        [StringLength(10)]
        public string hard_drive { get; set; }

        [StringLength(50)]
        public string graphic_card { get; set; }

        [StringLength(11)]
        public string resolution { get; set; }

        public virtual laptop laptop { get; set; }
    }
}
