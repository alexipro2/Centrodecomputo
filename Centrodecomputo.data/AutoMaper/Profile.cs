using AutoMapper;
using EIN.DTOS;
using EIN.Entidades;
    namespace Centrodecomputo.data.AutoMaper
{
    public class AutoMaperProfile:Profile
    {
        public AutoMaperProfile()
        {

            CreateMap<GeneracionsetDTO, GeneracionEntity>()
                .ForMember(campo => campo.EstaActivo, asignar => asignar.MapFrom(valor => true));

            CreateMap<GeneracionEntity, GeneraciongetDTO>();

            CreateMap<GrupoSetDTO, GrupoEntity>()
               .ForMember(campo => campo.EstaActivo, asignar => asignar.MapFrom(valor => true));

            CreateMap<GrupoEntity, GrupoGetDTO>()
                .ForMember(campo => campo.NombreGeneracion, asignar => asignar.MapFrom(valor => valor.Generacion.Nombre));
        }
    }
}
