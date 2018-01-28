using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;
using RiverLink.Models;
using System.ComponentModel.DataAnnotations.Schema;

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
        EastEndNB,
        None
    }

    public enum TransactionStatuses
    {
        Paid,
        Unpaid
    }

    public enum TransactionTypes
    {
        Payment,
        Toll,
        Discount,
        Fee,
        None
    }

    [DelimitedRecord("|")]
    public class Transaction
    {
        [Key]
        [Required]
        public int Transaction_Id { get; set; }

        [Required]
        [FieldConverter(ConverterKind.Date, "yyyy-MM-dd")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TransactionDate { get; set; }

        [Required]
        [FieldConverter(ConverterKind.Date, "yyyy-MM-dd")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? PostedDate { get; set; }

        [Required]
        [FieldHidden]
        public TransactionStatuses TransactionStatus { get; set; }

        [Required]
        [FieldHidden]
        public Plazas Plaza { get; set; }

        [Required]
        [FieldHidden]
        public virtual Vehicle Vehicle { get; set; }

        public virtual int Journal_Id { get; set; }

        [FieldConverter(typeof(RelatedJournalConverter))]
        public virtual List<int> RelatedJournal_Id { get; set; }

        [Required]  
        [FieldHidden]
        public virtual Transponder Transponder { get; set; }

        public TransactionTypes TransactionType { get; set; }

        [Required]
        public virtual Double Amount { get; set; }

        [MaxLength(20)]
        public virtual string TransactionDescription { get; set;}

        public virtual int Lane { get; set; }

        [MaxLength(20)]
        public virtual string PlateNumber { get; set; }

        //[ForeignKey("VehicleClass")]
        //public Int16 VehicleClass_Id { get; set; }
    }
}
