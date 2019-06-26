using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORM_HomeWork.Domain
{
    [Table("SendingStatus", Schema = "dbo")]
    public class SendingStatus
    {
        [Required]
        [Column("PostalItemId")]
        public PostalItem PostalItem { get; set; }

        [Required]
        public DateTimeOffset UpdateStatusDateTime { get; set; }

        [Required]
        [Column("StatusId")]
        public Status Status { get; set; }

        [Required]
        [Column("SendingContractorId")]
        public Contractor SendingContractor { get; set; }

        [Required]
        [Column("SendingAdressId")]
        public Address SendingAdress { get; set; }

        [Required]
        [Column("ReceiverContractorId")]
        public Contractor ReceivingContractor { get; set; }

        [Required]
        [Column("ReceicingAdressId")]
        public Address ReceivingAdress { get; set; }
    }
}
