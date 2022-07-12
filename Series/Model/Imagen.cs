using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Series.Model
{
    public class Imagen
    {
        [Key] // Comunmente lo hace autoincremental pero por siacaso podemos decir que esto es generado por la base de datos
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImagenId { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(200)]
        [Required]
        public string FileName { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(200)]
        [Required]
        public String Path { get; set; }


        public DateTime FechaSubida { get; set; }


        public bool Temporal { get; set; }

        public List<Serie> Series { get; set; }
    }
}
