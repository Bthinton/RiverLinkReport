using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace RiverLink.Models
{
    public enum VehicleStatuses
    {
        Active,
        Inactive
    }

    [DelimitedRecord("|")]
    public class Vehicle
    {
        [Key]
        [Required]
        [StringLength(20)]
        [Display(Name = "Plate Number")]
        public string PlateNumber { get; set; }

        [StringLength(32)]
        public string Make { get; set; }

        [StringLength(32)]
        public string Model { get; set; }

        public Int16 Year { get; set; }

        [Required]
        [Display(Name = "Vehicle State")]
        [StringLength(2)]
        public string VehicleState { get; set; }

        [Display(Name = "Vehicle Status")]
        public string VehicleStatus { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Vehicle Class")]
        [FieldHidden]
        public virtual VehicleClass VehiclePriceClass { get; set; }

        [MaxLength(20)]
        [FieldHidden]
        public virtual ICollection<Transaction> Transactions { get; set; }

        [MaxLength(20)]
        [FieldHidden]
        public virtual ICollection<Transponder> Transponders { get; set; }
    }
}
