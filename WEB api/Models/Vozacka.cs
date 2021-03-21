using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WEB_api.Models
{
    [Table("Vozacka")]
    public class Vozacka
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        
        [Column("ImeVozaca")]
        [MaxLength(255)]
        public string ImeVozaca { get; set; }

        [Column("PrezimeVozaca")]
        [MaxLength(255)]
        public string PrezimeVozaca { get; set; }

        [Column("BrojDozvole")]
        [MaxLength(255)]
        public string BrojDozvole { get; set; }

        [Column("Grad")]
        [MaxLength(255)]
        public string Grad { get; set; }

        [Column("JMBG")]
        [MaxLength(255)]
        public string JMBG { get; set; }
        
        [Column("Kategorija")]
        public virtual List<Kategorija> Kategorije { get; set; }
        
        [JsonIgnore]
        public Evidencija evidencija { get; set; }
        
    }
}