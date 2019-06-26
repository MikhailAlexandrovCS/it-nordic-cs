using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORM_HomeWork.Domain
{
    [Table("Adress", Schema = "dbo")]
    public class Address
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column("CityId")]
        [ForeignKey("FK_Address_CityId")]
        public City City { get; set; }

        [Required]
        [Column("Address", TypeName = "VARCHAR(50)")]
        public string Adress { get; set; }
    }
}
