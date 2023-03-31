using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AuthServer.Core.Repositories;
using AuthServer.Core.Services;
using AuthServer.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;

namespace AuthServer.Service.Services
{
    public class GenericService<TEntity, TDto> : IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<Response<IEnumerable<TDto>>> GetByIdAsync(int id)
        {
            var products = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await _genericRepository.GetByIdAsync(id));
            return Response<IEnumerable<TDto>>.Success(products, 200);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var products = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await _genericRepository.GetAllAsync());
            return Response<IEnumerable<TDto>>.Success(products, 200);
        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predication)
        {
            var predicateProducts = _genericRepository.Where(predication);
            return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await predicateProducts.ToListAsync()), 200);
        }

        public async Task<Response<TDto>> AddAsync(TDto tdto)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(tdto);
            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);
            return Response<TDto>.Success(newDto, 200);
        }

        public async Task<Response<NoDataDto>> Remove(int id)
        {
            var findData = await _genericRepository.GetByIdAsync(id);
            if (findData == null)
            {
                return Response<NoDataDto>.Fail("Id not found", 404, true);
            }
            _genericRepository.Remove(findData);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }

        public async Task<Response<NoDataDto>> UpdateAsync(TDto tdto,int id)
        {
            var updateFindData = _genericRepository.GetByIdAsync(id);
            if (updateFindData==null)
            {
                return Response<NoDataDto>.Fail("Id not found", 404, true);
            }
            _genericRepository.UpdateAsync(ObjectMapper.Mapper.Map<TEntity>(tdto));
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }
    }
}