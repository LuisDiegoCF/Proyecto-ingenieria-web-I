using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Series.Model
{
    public class Serie
    {
        [Key] // Comunmente lo hace autoincremental pero por siacaso podemos decir que esto es generado por la base de datos
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerieId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(200)]
        [Required]
        public string NombreSerie { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        [Required]
        public string Descripcion { get; set; }


        // Llave foranea ===============================
        [JsonIgnore]
        public Imagen Imagen { get; set; }
        public int ImagenId { get; set; }
        // =============================================


        public List<Temporada> Temporadas { get; set; }
        public List<Lista> ListaFavoritos { get; set; }

        public Serie()
        {
            ListaFavoritos = new List<Lista>();
        }
    }
}
