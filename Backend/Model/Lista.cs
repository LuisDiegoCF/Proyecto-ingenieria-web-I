using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Series.Model
{
    public class Lista
    {
        [Key]
        public int Id { get; set; }


        // Llave foranea ===============================
        [JsonIgnore]
        public Serie Serie { get; set; }
        public int SerieId { get; set; }
        // =============================================


        // Llave foranea ===============================
        [JsonIgnore]
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        // =============================================
    }
}
