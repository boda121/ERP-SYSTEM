using AutoMapper;
using ERP.Core.Interfaces;
using ERP.Core.Models;
using ERP.Core.Interfaces;
using System.Diagnostics;

namespace ERP.Services.Services.Implementations
{
    public class Service_Layer<T> : IService_Layer<T> where T : class
    {
        private readonly IUnitOfWork _Context;
        private readonly IMapper _mapper;
        private readonly AuditLog _auditLog;
        private readonly SoftDeleteLog _softDelete;
        private readonly ErrorLog _LogErro;


        public Service_Layer(IUnitOfWork cotext,IMapper mapper, AuditLog auditLog, SoftDeleteLog softDelete,ErrorLog errorLog)
        {
            _Context = cotext;
            _mapper = mapper;
            _auditLog = auditLog;
            _softDelete = softDelete;
            _LogErro = errorLog;
        }

        public async Task<T> add(T entity)
        {
            try
            {
                if (entity != null)
                {
                    _Context.Repository<T>().Add(entity);
                    _Context.Commit();
                    var propertyInfo = entity.GetType().GetProperty("Id");
                    int? res = (int?)propertyInfo?.GetValue(entity);
                    _auditLog.Action = $"Add {typeof(T).Name}";
                    _auditLog.TableName = $"{typeof(T).Name}";
                    _auditLog.RowId = res;
                    _auditLog.UserId = "18b2bed5-f7cd-437f-afe7-95ccef0fdde1";
                    _Context.Repository<AuditLog>().Add(_auditLog);
                   await _Context.Commit();
                    var en = _mapper.Map<T>(entity);
                    return en;
                }
            }
            catch (Exception EX)
            {

                _LogErro.Message = EX.Message;
                _Context.Repository<ErrorLog>().Add(_LogErro);
               await _Context.Commit();
            }
                return null;
        }

        public async Task<string> Delete(int id)
        {
            var entity = await _Context.Repository<T>().GetByIdAsync(id);
            if (entity == null)
                return ("Not Found Any Item For This Id");
            var prop = entity.GetType().GetProperty("IsDeleted");
            var UserId = entity.GetType().GetProperty("UserId");
            if (prop == null)
                return ("Error!! Not Found Fild Deleted ");

            bool? isDeleted = (bool?)prop.GetValue(entity);
            string? iduser = (string?)UserId?.GetValue(entity) ;
            if (isDeleted != true)
            {
                prop.SetValue(entity, true);
                _softDelete.TableName = $"{typeof(T).Name} Deleted";
                _softDelete.RowId = id;
                if (iduser != null)
                {
                    _softDelete.UserId = iduser;
                }
                else
                {
                    _softDelete.UserId = "18b2bed5-f7cd-437f-afe7-95ccef0fdde1";
                }
                _Context.Repository<SoftDeleteLog>().Add(_softDelete);
                await _Context.Commit();
                return ($"{typeof(T).Name} Deleted");

            }
            else
            {
                return ("This item Already Deleted");
            }
        }

        public async Task<IEnumerable<T>> getall()
        {
            var data =await _Context.Repository<T>().GetAllAsync();
            var IsDeleted = data.GetType().GetProperty("IsDeleted");
            if(IsDeleted !=null)
            {

                bool res= (bool)IsDeleted.GetValue(data);
                
            }
            return data;
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _Context.Repository<T>().GetByIdAsync(id);
            if (entity != null)
            {
                return entity;
            }
            return null;

        }

        public async Task<string> Recovry(int id)
        {
            var entity = await _Context.Repository<T>().GetByIdAsync(id);
            if (entity == null)
                return ("Not Found Any Item For This Id");
            var prop = entity.GetType().GetProperty("IsDeleted");
            var UserId = entity.GetType().GetProperty("UserId");
            if (prop == null)
                return ("Error!! Not Found Fild Deleted ");

            bool? isDeleted = (bool?)prop.GetValue(entity);
            string? iduser = (string?)UserId?.GetValue(entity);
            if (isDeleted != false)
            {
                prop.SetValue(entity, false);
                _softDelete.TableName = $"{typeof(T).Name} Recovryd";
                _softDelete.RowId = id;
                _softDelete.UserId = "18b2bed5-f7cd-437f-afe7-95ccef0fdde1";
                if (iduser != null)
                {
                    _softDelete.UserId = iduser;
                }
                else
                {
                    _softDelete.UserId = "18b2bed5-f7cd-437f-afe7-95ccef0fdde1";
                }
                _Context.Repository<SoftDeleteLog>().Add(_softDelete);
               await _Context.Commit();
                return ($"{typeof(T).Name} Recovryd");

            }
            else
            {
                return ("This item Already Recovryd");
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            var entitys =await _Context.Repository<T>().GetByIdAsync(id);
            if (entitys != null)
            {
              _Context.Repository<T>().Update(entitys);
             _auditLog.Action = $"Edit {typeof(T).Name}";
             _auditLog.TableName = $"{typeof(T).Name}";
             _auditLog.UserId = "18b2bed5-f7cd-437f-afe7-95ccef0fdde1";
             _Context.Repository<AuditLog>().Add(_auditLog);
            await _Context.Commit();
            return entity;
            }
            return null;
        }
    } 
}
