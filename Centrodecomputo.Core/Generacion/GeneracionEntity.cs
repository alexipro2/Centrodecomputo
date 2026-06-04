using EIN.DTOS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EIN.Entidades
{
    [Table("Generacion")]
    public class GeneracionEntity
    {
       
        [Key] public int Id { get; set; }

        [Required,StringLength(20)]public string Nombre { get; set; } = string.Empty;

       [Required] public bool EstaActivo { get; set; }
    }
}
