using EIN.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EIN.DTOS
{
    public class GeneracionsetDTO
    {
        [Required, StringLength(20)] public string Nombre { get; set; } = string.Empty;
    }
    public class GeneraciongetDTO
    {
        public GeneraciongetDTO() { }
        public GeneraciongetDTO(GeneracionEntity entity)

        {
            Id =entity.Id;
            Nombre = entity.Nombre;
        }
        public int Id {  get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
