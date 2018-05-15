using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FileHelpers;

namespace RiverLink.Models
{
    /// <summary>
    /// Main <c>TransponderData</c> class where all properties are set
    /// </summary>
    [DelimitedRecord("|")]
    public class TransponderData
    {
        /// <value>
        /// Gets and sets the transponder id
        /// </value>
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Transponder_Id { get; set; }

        public string TransponderNumber { get; set; }
        /// <value>
        /// Gets and sets the type of transponder
        /// </value>
        [Required]
        [Display(Name = "Transponder Type")]
        public string TransponderType { get; set; }
        /// <value>
        /// Gets and sets the vehicle used with the transponder
        /// Field</value>
        [FieldHidden]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        /// <value>
        /// Gets and sets the transaction made with the transponder
        /// </value>
        [FieldHidden]
        public virtual ICollection<Transaction> Transactions { get; set; }

        public string PlateNumber { get; set; }
    }
}
