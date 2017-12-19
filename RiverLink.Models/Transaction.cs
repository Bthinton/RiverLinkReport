using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverLink.Models
{
    public enum Plazas
    {
        //NB/SB for direction of travel
        Lincoln,
        Kennedy,
        EastEndSB,
        EastEndNB
    }

    public enum TransactionStatuses
    {
        Paid,
        Unpaid
    }



    public class Transaction
    {
        [Key]
        [Required]
        public Int32 Transaction_Id { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TransactionDate { get; set; }
        [Required]
        [StringLength(20)]
        public TransactionStatuses TransactionStatus { get; set; }
        [Required]
        [StringLength(32)]
        public Plazas Plaza { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        [MaxLength(20)]
        public virtual Journal Journal { get; set; }
        [MaxLength(20)]
        public virtual Transponder Transponder { get; set; }
    }
}
