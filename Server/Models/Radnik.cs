using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Radnik")]
    public class Radnik
    {
        [Key]
        public int id { get; set; }

        [MaxLength(25)]
        [Column("Ime")]
        public string ime { get; set; }

        [MaxLength(50)]
        [Column("Prezime")]
        public string prezime { get; set; }
        
        [MaxLength(1)]
        [Column("Pol")]
        public string pol { get; set; }

        [Column("Br. legitimacije")] // 0154321
        [Required]
        public int brLegitimacije { get; set; }

        [Column("Godina rođenja")]
        public int godRodj { get; set; }

        [JsonIgnore]
        public virtual List<Slucaj> Slucajevi { get; set; }

        [JsonIgnore]
        public virtual Odsek Odsek { get; set; }
   
    }
}