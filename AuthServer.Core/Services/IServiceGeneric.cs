using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<Response<IEnumerable<TDto>>> GetByIdAsync(int id);
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<IEnumerable<TDto>>> WhereAsync(Expression<Func<TEntity, bool>> predication);
        Task<Response<TDto>> AddAsync(TDto tdto);
        Task<Response<NoDataDto>> Remove(TDto tdto);
        Task<Response<NoDataDto>> UpdateAsync(TDto tdto);
    }
}