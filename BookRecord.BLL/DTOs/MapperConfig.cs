using AutoMapper;
using BookRecord.DAL.Models;

namespace BookRecord.BLL.DTOs;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Libro, LibroDTO>().ReverseMap();
        CreateMap<Autor, AutorDTO>().ReverseMap();
    }
}
