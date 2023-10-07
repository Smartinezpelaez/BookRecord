namespace BookRecord.BLL.Repository
{
    public interface IGenericRepositor <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);

        IEnumerable<TEntity> GetAll();
    }
}
