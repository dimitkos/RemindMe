namespace Application.Services.Infrastructure
{
    public interface IDomainRetrievalRepository<TKey, TOut>
        where TOut : class
        where TKey : notnull
    {
        Task<TOut?> TryGet(TKey id);
        Task<Dictionary<TKey, TOut>> TryGetMany(TKey[] ids);
    }
}
