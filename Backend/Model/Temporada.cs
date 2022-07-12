using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Series.Model
{
    public class Temporada
    {
        [Key] // Comunmente lo hace autoincremental pero por siacaso podemos decir que esto es generado por la base de datos
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TemporadaId { get; set; }


        // Llave foranea ===============================
        [JsonIgnore]
        public Serie Serie { get; set; }
        public int SerieId { get; set; }
        // =============================================


        [Column(TypeName = "varchar")]
        [StringLength(200)]
        [Required]
        public string NombreTemporada { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Orden { get; set; }

        public List<Episodio> Episodios { get; set; }
    }
}
