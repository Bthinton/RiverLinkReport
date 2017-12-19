using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverLink.Models
{
    public enum TransponderTypes
    {
        EZPass, 
        Sticker
    }

    public enum TransponderStatuses
    {
        Valid,
        Invalid
    }

    public class Transponder
    {
        [Key]
        [Required]
        [MaxLength(20)]
        public int Transponder_Id { get; set; }
        [Required]
        [Display(Name = "Transponder Type")]
        [StringLength(20)]
        public TransponderTypes TransponderType { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
