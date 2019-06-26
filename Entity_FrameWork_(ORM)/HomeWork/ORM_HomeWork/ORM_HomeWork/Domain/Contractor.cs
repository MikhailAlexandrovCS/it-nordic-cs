using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORM_HomeWork.Domain
{
    [Table("Contractor", Schema = "dbo")]
    public class Contractor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "VARCHAR(250)")]
        public string Name { get; set; }

        [Required]
        [Column("PositionId")]
        [ForeignKey("FK_Contractor_PositionId")]
        public Position Position { get; set; }
    }
}
