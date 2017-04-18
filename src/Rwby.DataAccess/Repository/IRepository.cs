namespace Rwby.DataAccess
{
    public interface IRepository
    {
        void Delete<TItem>(TItem item, bool saveImmediately = true) where TItem : class;
        TItem Insert<TItem>(TItem item, bool saveImmediately = true) where TItem : class;
        void Save();
        TItem Update<TItem>(TItem item, bool saveImmediately = true) where TItem : class;
    }
}