using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORM_HomeWork.Domain
{
    [Table("Status", Schema = "dbo")]
    public class Status
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "VARCHAR(20)")]
        public string Name { get; set; }
    }
}
