using BookRecord.DAL.Models;

namespace BookRecord.BLL.Repository.Implements;

public class AutorRepository : GenericRepository<Autor>, IAutorRepository
{
    private readonly BookRecordContext context;

    public AutorRepository(BookRecordContext context): base(context)
    {
        this.context = context;
    }

}
