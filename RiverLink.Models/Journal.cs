using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverLink.Models
{


    public class Journal
    {
        [Key]
        [Required]
        public Int32 Journal_Id { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PostedDate { get; set; }
        [Required]
        [MaxLength(20)]
        public double Amount { get; set; }
        [MaxLength(20)]
        public virtual Transaction Transaction { get; set; }
        //Might need to be in transaction model
        [StringLength(10)]
        public TransactionTypes TransactionType { get; set; }
        //not sure if i should create JournalDescription shows CC used to pay the transaction
    }
}
