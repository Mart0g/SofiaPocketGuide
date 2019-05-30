namespace SPG.DataAccess.Unit
{
    public interface IUnitOfWork
    {
        //IBaseRepository<T> Repository<T>() where T : class;
        void Commit();
        void Rollback();
    }
}
