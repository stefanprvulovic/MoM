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

        [Column("Br. sprata")]
        public int sprat { get; set; }

     
        public virtual List<Slucaj> Slucajevi { get; set; }
        
      
        public virtual List<Radnik> Radnici { get; set; }

        [JsonIgnore]
        public virtual Ministarstvo Ministarstvo { get; set; }
    }
}