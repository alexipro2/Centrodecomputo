using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EIN.DTOS
{
    public class GrupoSetDTO
    {
        [Required] public int IdGeneracion { get; set; }

        [Required, StringLength(12)] public string Nombre { get; set; } = string.Empty;
    }

    public class GrupoGetDTO
    {
        [Key] public int Id { get; set; }

        [Required] public int IdGeneracion { get; set; }

        public string NombreGeneracion { get; set; }

        [Required, StringLength(12)] public string Nombre { get; set; } = string.Empty;


    }
}
