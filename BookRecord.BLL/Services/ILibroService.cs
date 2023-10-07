using BookRecord.DAL.Models;

namespace BookRecord.BLL.Services;

public interface ILibroService
{
    Task<Libro> InsertLibroAsync(Libro libro);
}
