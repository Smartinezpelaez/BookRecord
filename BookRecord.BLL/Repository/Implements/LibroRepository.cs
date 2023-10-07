using BookRecord.DAL.Models;

namespace BookRecord.BLL.Repository.Implements;

public class LibroRepository: GenericRepository<Libro>, ILibroRepository
{
    private readonly BookRecordContext context;

    public LibroRepository(BookRecordContext context): base(context)
    {
        this.context = context;
    }
}
