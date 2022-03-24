using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Ministarstvo")]
    public class Ministarstvo
    {
        [Key]
        public int id { get; set; }

        [MaxLength(50)]
        [Column("Ime")]
        public string ime { get; set; }

        [Column("Broj spratova")]
        public int sprat { get; set; }

        public virtual List<Odsek> Odseci { get; set; }
    }
}