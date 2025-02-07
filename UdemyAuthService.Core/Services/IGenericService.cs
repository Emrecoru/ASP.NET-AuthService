using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UdemyAuthService.Core.Services
{
    public interface IGenericService<T, Dto> where T : class where Dto : class
    {
        Task<Response<Dto>> GetByIdAsync(int id);

        Task<Response<IEnumerable<Dto>>> GetAllAsync();

        Task<Response<IEnumerable<Dto>>> Where(Expression<Func<T, bool>> expression);

        Task<Response<T>> AddAsync(Dto dto);

        Task<Response<NoDataDto>> RemoveAsync(int id);

        Task<Response<NoDataDto>> UpdateAsync(Dto dto, int id);
    }
}
