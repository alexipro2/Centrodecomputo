using EIN.Enumeradores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EIN.Entidades
{
    [Table("Alumno")]
    public class AlumnoEntity
    {
        [Key]public int Id { get; set; }
        [Required,StringLength(10)]public string NumeroDeCuenta { get; set; } = string.Empty;
        [Required, StringLength(30)] public string Nombre { get; set; } = string.Empty;
        [Required, StringLength(30)] public string ApellidoPaterno { get; set; } = string.Empty;
        [StringLength(30)] public string ApellidoMaterno { get; set; } = string.Empty;

        [StringLength(10)] public string Telefono { get; set; } = string.Empty;
        public SexoEnum Sexo {  get; set; }

        public int IdGrupo { get; set; }

        public bool EstaActivo { get; set; }
        
       [ForeignKey("IdGrupo")] public virtual GrupoEntity Grupo { get; set; }


    }
}
