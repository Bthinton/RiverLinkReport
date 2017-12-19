using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RiverLink.Models
{
    public enum Classifications
    {
        Class1,
        Class2,
        Class3
    }

    public enum PriceTypes
    {
        Transponder,
        RegisteredPlate,
        UnregisteredPlate
    }

    public class VehicleClass
    {
        [Key]
        [Required]
        [MaxLength(20)]
        public Int16 VehicleClass_Id { get; set; }
        [StringLength(32)]
        public string VehicleDescription { get; set; }
        [Required]
        [StringLength(32)]
        public string ClassificationDescription { get; set; }
        [Required]
        [MaxLength(20)]
        public double Price { get; set; }
        [MaxLength(32)]
        public PriceTypes PriceType { get; set; }
        [Required]
        [StringLength(20)]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        [Required]
        [StringLength(20)]
        public Classifications Classification { get; set; }
    }
}
