using FileHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiverLink.Models
{
    public class BankTransaction
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Transaction_Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "yyyyMMddHHmmss")]
        public DateTime TransactionDate { get; set; }

        [Required]
        public virtual double Amount { get; set; }

        public string Comment { get; set; }
    }
}
