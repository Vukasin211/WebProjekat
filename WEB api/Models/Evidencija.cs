using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEB_api.Models
{
    [Table("Evidencija")]
    public class Evidencija
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("ImeDrzave")]
        [MaxLength(255)]
        public string ImeDrzave { get; set; }
        public virtual List<Vozacka> ListaVozackih { get; set; }
             
    }
}