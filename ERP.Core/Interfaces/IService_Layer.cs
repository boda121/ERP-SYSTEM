namespace ERP.Core.Interfaces
{
    public interface IService_Layer<T> where T : class
    {
         Task<IEnumerable<T>> getall();
         Task<T> GetById(int id);
         Task<T> add(T entity);
         Task<T> Update(int id , T entity);
         Task<string> Delete(int id);
         Task<string> Recovry(int id);
        
    }
}