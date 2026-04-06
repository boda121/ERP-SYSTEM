using ERP.Core.DTOs;
using ERP.Core.Models;

namespace ERP.Core.Interfaces
{
    public interface IService_Layer<T,dto> where T : class
    {
         Task<ApiResponse<T, IEnumerable<dto>>> getall();
         Task<ApiResponse<T, dto>> GetById(int id);
         Task<ApiResponse<T,dto>> add(dto entity);
         Task<ApiResponse<T, dto>> Update(int id , dto entity);
         Task<ApiResponse<T, dto>> Delete(int id);
         Task<ApiResponse<T, dto>> Recovry(int id);
        
    }
}