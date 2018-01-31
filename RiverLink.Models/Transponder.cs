using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FileHelpers;

namespace RiverLink.Models
{
    /// <value>
    /// Defines type of transponder
    /// </value>
    public enum TransponderTypes
    {
        EZPass, 
        Sticker
    }
    /// <value>
    /// Defines status of transponder
    /// </value>
    public enum TransponderStatuses
    {
        Valid,
        Invalid
    }
    /// <summary>
    /// Main <c>Transponder</c> class where all properties are set
    /// </summary>
    [DelimitedRecord("|")]
    public class Transponder
    {
        /// <value>
        /// Gets and sets the transponder id
        /// </value>
        [Key]
        [Required]
        public int Transponder_Id { get; set; }
        /// <value>
        /// Gets and sets the type of transponder
        /// </value>
        [Required]
        [Display(Name = "Transponder Type")]
        [FieldHidden]
        public TransponderTypes TransponderType { get; set; }
        /// <value>
        /// Gets and sets the vehicle used with the transponder
        /// </value>
        [FieldHidden]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        /// <value>
        /// Gets and sets the transaction made with the transponder
        /// </value>
        [FieldHidden]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
