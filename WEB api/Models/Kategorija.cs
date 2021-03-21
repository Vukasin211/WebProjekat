using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WEB_api.Models
{
    public class Kategorija
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        
        [Column("Kategorije")]
        [MaxLength(255)]
        public string Kategorije { get; set; }

        [JsonIgnore]
        public Vozacka vozac { get; set; }
        
    }
}