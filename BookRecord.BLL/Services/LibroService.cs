using BookRecord.BLL.Repository;
using BookRecord.DAL.Models;

namespace BookRecord.BLL.Services;

public class LibroService: ILibroService
{
    private readonly ILibroRepository _libroRepository;
    private readonly IAutorRepository _autorRepository;
    private readonly int MaxLibrosPermitidos = 6; // Puedes ajustar este valor según tus requisitos

    public LibroService(ILibroRepository libroRepository, IAutorRepository autorRepository)
    {
        _libroRepository = libroRepository;
        _autorRepository = autorRepository;
    }

    public async Task<Libro> InsertLibroAsync(Libro libro)
    {
        // Verificar si el autor existe
        var autor = await _autorRepository.GetByIdAsync(libro.AutorId);
        if (autor == null)
        {
            throw new Exception("El autor no está registrado");
        }

        // Verificar el número de libros permitidos
        var libros = await _libroRepository.GetAllAsync();
        var librosCount = libros.Count();

        if (librosCount >= MaxLibrosPermitidos)
        {
            throw new Exception("No es posible registrar el libro, se alcanzó el máximo permitido");
        }

        // Resto de la lógica de inserción
        // ...

        return await _libroRepository.InsertAsync(libro);
    }

}
