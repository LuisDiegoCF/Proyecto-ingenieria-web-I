using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Series.Model
{
    public class Usuario
    {
        [Key] // Comunmente lo hace autoincremental pero por siacaso podemos decir que esto es generado por la base de datos
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string NombreCompleto { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Password { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string TipoUsuario { get; set; }

        public List<Lista> ListaFavoritos { get; set; }
    }
}
