using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Series.Model
{
    public class Episodio
    {
        [Key] // Comunmente lo hace autoincremental pero por siacaso podemos decir que esto es generado por la base de datos
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EpisodioId { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(200)]
        [Required]
        public string Titulo { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        [Required]
        public string Descripcion { get; set; }


        public int YoutubeVideoId { get; set; }

        // Llave foranea ===============================
        [JsonIgnore]
        public Temporada Temporada { get; set; }
        public int TemporadaId { get; set; }
        // =============================================
        
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Orden { get; set; }
    }
}
