using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Base.Response;
using WS.Data.UnitOfWork;

namespace WS.Operation.Base
{
    public class BaseService<TEntity, TRequest, TResponse> : IBaseService<TEntity, TRequest, TResponse> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual ApiResponse Delete(int Id)
        {
            try
            {
                var entity = _unitOfWork.Repository<TEntity>().GetById(Id);
                if (entity is null)
                {
                    return new ApiResponse("Record not found");
                }

                _unitOfWork.Repository<TEntity>().DeleteById(Id);
                _unitOfWork.Complete();
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public ApiResponse<List<TResponse>> GetAll()
        {
            try
            {
                var entityList = _unitOfWork.Repository<TEntity>().GetAll();
                var mapped = _mapper.Map<List<TEntity>, List<TResponse>>(entityList);
                return new ApiResponse<List<TResponse>>(mapped);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<TResponse>>(ex.Message);
            }
        }

        public ApiResponse<TResponse> GetById(int id)
        {
            try
            {
                var entity = _unitOfWork.Repository<TEntity>().GetById(id);
                if (entity is null)
                {
                    return new ApiResponse<TResponse>("Record not found");
                }

                var mapped = _mapper.Map<TEntity, TResponse>(entity);
                return new ApiResponse<TResponse>(mapped);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TResponse>(ex.Message);
            }
        }

        public ApiResponse Insert(TRequest request)
        {
            try
            {
                var entity = _mapper.Map<TRequest, TEntity>(request);
                entity.GetType().GetProperty("CreatedAt").SetValue(entity, DateTime.UtcNow);
                _unitOfWork.Repository<TEntity>().Insert(entity);
                _unitOfWork.Complete();
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public ApiResponse Update(int Id, TRequest request)
        {
            try
            {
                var entity = _mapper.Map<TRequest, TEntity>(request);

                var exist = _unitOfWork.Repository<TEntity>().GetById(Id);
                if (exist is null)
                {
                    return new ApiResponse("Record not found");
                }

                entity.GetType().GetProperty("Id").SetValue(entity, Id);
                entity.GetType().GetProperty("UpdatedAt").SetValue(entity, DateTime.UtcNow);
                _unitOfWork.Repository<TEntity>().Update(entity);
                _unitOfWork.Complete();
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }
    }
}
