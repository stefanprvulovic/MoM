using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Slučaj")]
    public class Slucaj 
    {
        [Key]  
        public int id { get; set; }
        
        [Column("Kodno ime")]
        public string kodnoIme { get; set; }

        [Range(0,1)]
        [Column("Status")]
        public int status { get; set; } // 0-rešen, 1-u procesu rešavanja

        [Column("Nivo poverljivosti")]
        public string nivoPov { get; set; } // poverljivo, ograničen pristup, javno

        [MaxLength(150)]
        [Column("Kratak opis")]
        public string opis { get; set; }
        
        public virtual Radnik Radnik { get; set; }

        [JsonIgnore]
        public virtual Odsek Odsek { get; set; }

      
    }
}