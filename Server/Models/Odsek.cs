using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Odsek")]
    public class Odsek
    {
        [Key]
        public int id { get; set; }

        [MaxLength(50)]
        [Column("Ime")]
        public string ime { get; set; }

        [Range(1,7)]
        [Column("Br. sprata")] // Ministarstvo ima 7 spratova
        public int sprat { get; set; }

        [JsonIgnore]
        public virtual List<Slucaj> Slucajevi { get; set; }
        
        [JsonIgnore]
        public virtual List<Radnik> Radnici { get; set; }
    }
}