using DBModels.Init;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoanLaptopManagement.Models
{
    public class LaptopAndSpec
    {
        [Required]
        [StringLength(10)]
        public string id { get; set; }
        [Required]
        public int brand_id { get; set; }
        [Required]
        [StringLength(100)]
        public string name { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string img { get; set; }
        public string memory { get; set; }
        [Required]
        [StringLength(6)]
        public string hard_drive { get; set; }
        [Required]
        [StringLength(50)]
        public string graphic_card { get; set; }
        [Required]
        [StringLength(11)]
        public string resolution { get; set; }


        public laptop getLaptop()
        {
            return new laptop() { 
                id = this.id, 
                brand_id = this.brand_id, 
                name = this.name, 
                img = this.img 
            };
        }
        public spec getSpec()
        {
            return new spec() { laptop_id = id, 
                memory = this.memory, 
                graphic_card = this.graphic_card, 
                hard_drive = this.hard_drive, 
                resolution = this.resolution 
            };
        }
    }
}