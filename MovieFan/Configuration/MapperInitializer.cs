using AutoMapper;
using MovieFan.Data;
using MovieFan.Model;

namespace MovieFan.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Message, MessageDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<GenericResponse, GenericResponseDTO>().ReverseMap();
        }
    }
}
