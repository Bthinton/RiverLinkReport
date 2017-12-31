﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace RiverLink.Models
{
    public enum Plazas
    {
        //NB/SB for direction of travel
        LincolnSB,
        LincolnNB,
        KennedySB,
        KennedyNB,
        EastEndSB,
        EastEndNB
    }

    public enum TransactionStatuses
    {
        Paid,
        Unpaid
    }

    public enum TransactionTypes
    {
        Payment,
        Toll
    }

    [DelimitedRecord("|")]
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

        [Required]
        [MaxLength(20)]
        public virtual Vehicle Vehicle { get; set; }

        [MaxLength(20)]
        public virtual Journal Journal { get; set; }

        [Required]
        [MaxLength(20)]
        public virtual Transponder Transponder { get; set; }

        [MaxLength(20)]
        public TransactionTypes TransactionType { get; set; }

        [Required]
        [MaxLength(20)]
        public virtual Double Amount { get; set; }

        [MaxLength(20)]
        public virtual string TransactionDescription { get; set;}

        [MaxLength(20)]
        public virtual int Lane { get; set; }

        [MaxLength(20)]
        public virtual string PlateNumber { get; set; }
    }
}
