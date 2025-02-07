using AutoMapper;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyAuthService.Core.Repositories;
using UdemyAuthService.Core.Services;
using UdemyAuthService.Core.UnitOfWork;

namespace UdemyAuthService.Service.Services
{
    public class ServiceGeneric<T, Dto> : IGenericService<T, Dto> where T : class where Dto : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceGeneric(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<T>> AddAsync(Dto dto)
        {
            var entity = ObjectMapper.Mapper.Map<T>(dto);
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return Response<T>.Success(entity, 200);
        }

        public async Task<Response<IEnumerable<Dto>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var dtos = ObjectMapper.Mapper.Map<IEnumerable<Dto>>(entities);
            return Response<IEnumerable<Dto>>.Success(dtos, 200);
        }

        public async Task<Response<Dto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var dto = ObjectMapper.Mapper.Map<Dto>(entity);
            return Response<Dto>.Success(dto, 200);
        }

        public async Task<Response<NoDataDto>> RemoveAsync(int id)
        {
            var isExistEntity = await _repository.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail($"{id} is not found.", 404, true);
            }

            _repository.Remove(isExistEntity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }

        public async Task<Response<NoDataDto>> UpdateAsync(Dto dto, int id)
        {
            var isExistEntity = await _repository.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail($"{id} is not found.", 404, true);
            }

            _repository.Update(ObjectMapper.Mapper.Map<T>(dto));
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<IEnumerable<Dto>>> Where(Expression<Func<T, bool>> expression)
        {
            var entities = _repository.Where(expression);

            var dtos = ObjectMapper.Mapper.Map<IEnumerable<Dto>>(await entities.ToListAsync());

            return Response<IEnumerable<Dto>>.Success(dtos, 200);
        }
    }
}
