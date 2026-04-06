using AutoMapper;
using ERP.Core.DTOs;
using ERP.Core.Interfaces;
using ERP.Core.Interfaces;
using ERP.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Security.Claims;

namespace ERP.Services.Services.Implementations
{
    public class Service_Layer<T, dto> : IService_Layer<T, dto> where T : class
    {
        private readonly IUnitOfWork _Context;
        private readonly IMapper _mapper;
        private readonly AuditLog _auditLog;
        private readonly SoftDeleteLog _softDelete;
        private readonly ErrorLog _LogErro;
        private readonly string idUser;
        IHttpContextAccessor httpContext = new HttpContextAccessor();


        public Service_Layer(IUnitOfWork cotext, IMapper mapper, AuditLog auditLog, SoftDeleteLog softDelete, ErrorLog errorLog)
        {
            _Context = cotext;
            _mapper = mapper;
            _auditLog = auditLog;
            _softDelete = softDelete;
            _LogErro = errorLog;
            idUser = httpContext.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public async Task<ApiResponse<T, dto>> add(dto ENDTO)
        {
            try
            {
                if (ENDTO != null)
                {
                    var entity = _mapper.Map<T>(ENDTO);
                    _Context.Repository<T>().Add(entity);
                    await _Context.Commit();
                    var propertyInfo = entity.GetType().GetProperty("Id");
                    int? result = (int?)propertyInfo?.GetValue(entity);
                    _auditLog.Action = $"Add {typeof(T).Name}";
                    _auditLog.TableName = $"{typeof(T).Name}";
                    _auditLog.RowId = result;
                    _auditLog.UserId = idUser;
                    _Context.Repository<AuditLog>().Add(_auditLog);
                    await _Context.Commit();
                    return new ApiResponse<T, dto>(ENDTO, "Success");
                }
                return new ApiResponse<T, dto>("Your data Is IS Empety", 400);

            }
            catch (Exception EX)
            {

                _LogErro.Message = EX.Message;
                _Context.Repository<ErrorLog>().Add(_LogErro);
                await _Context.Commit();
                return new ApiResponse<T, dto>(EX.Message, 400);
            }
        }

        public async Task<ApiResponse<T, dto>> Delete(int id)
        {
            try
            {

                var entity = await _Context.Repository<T>().GetByIdAsync(id);
                if (entity == null)
                {
                    return new ApiResponse<T, dto>("Not Found Any Item For This ID", 404);
                }
                else
                {

                    var prop = entity.GetType().GetProperty("IsDeleted");
                    var UserId = entity.GetType().GetProperty("UserId");
                    if (prop == null)
                        return new ApiResponse<T, dto>("Error!! Not Found Fild Deleted ", 404);

                    bool? isDeleted = (bool?)prop.GetValue(entity);
                    string? iduser = (string?)UserId?.GetValue(entity);
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
                            _softDelete.UserId = "61fb6e59-ab7d-4935-9cb2-f7c9c57a4d99";
                        }
                        _Context.Repository<SoftDeleteLog>().Add(_softDelete);
                        await _Context.Commit();
                        return new ApiResponse<T, dto>("Item Is Deleted ", 200);
                    }
                    else
                    {
                        return new ApiResponse<T, dto>("This item Already Deleted", 204);
                    }
                }
            }
            catch (Exception Ex)
            {
                return new ApiResponse<T, dto>(Ex.Message, 404);
            }

        }

        public async Task<ApiResponse<T, IEnumerable<dto>>> getall()
        {
            try
            {

                var data = await _Context.Repository<T>().GetAllAsync();
                if (data != null)
                {
                    var prop = typeof(T).GetProperty("IsDeleted");

                    if (prop != null)
                    {
                        data = data.Where(x =>
                        {
                            var value = prop.GetValue(x);
                            return value is bool isDeleted && !isDeleted;
                        }).ToList();
                    }
                    var res = _mapper.Map<List<dto>>(data);
                    return new ApiResponse<T, IEnumerable<dto>>(res, "Success");
                }
                return new ApiResponse<T, IEnumerable<dto>>("Not Found Any Items", 404);
            }
            catch (Exception Ex)
            {
                return new ApiResponse<T, IEnumerable<dto>>(Ex.Message, 400);

            }

        }



        public async Task<ApiResponse<T, dto>> GetById(int id)
        {
            var entity = await _Context.Repository<T>().GetByIdAsync(id);
            var dtos = _mapper.Map<dto>(entity);
            if (entity == null)
            {
                return new ApiResponse<T, dto>("Not Found Any Item For This Id ", 404);
            }
            return new ApiResponse<T, dto>(dtos, "Success");

        }

        public async Task<ApiResponse<T, dto>> Recovry(int id)
        {

            try
            {

                var entity = await _Context.Repository<T>().GetByIdAsync(id);
                if (entity == null)
                {
                    return new ApiResponse<T, dto>("Not Found Any Item For This ID", 404);
                }
                else
                {

                    var prop = entity.GetType().GetProperty("IsDeleted");
                    var UserId = entity.GetType().GetProperty("UserId");
                    if (prop == null)
                        return new ApiResponse<T, dto>("Error!! Not Found Fild Deleted ", 404);

                    bool? isDeleted = (bool?)prop.GetValue(entity);
                    string? iduser = (string?)UserId?.GetValue(entity);
                    if (isDeleted == true)
                    {
                        prop.SetValue(entity, false);
                        _softDelete.TableName = $"{typeof(T).Name} Recovryd";
                        _softDelete.RowId = id;
                        if (iduser != null)
                        {
                            _softDelete.UserId = iduser;
                        }
                        else
                        {
                            _softDelete.UserId = "61fb6e59-ab7d-4935-9cb2-f7c9c57a4d99";
                        }
                        _Context.Repository<SoftDeleteLog>().Add(_softDelete);
                        await _Context.Commit();
                        return new ApiResponse<T, dto>("Item Is Recovryd ", 200);
                    }
                    else
                    {
                        return new ApiResponse<T, dto>("This item Already Recovryd", 204);
                    }
                }
            }
            catch (Exception Ex)
            {
                return new ApiResponse<T, dto>(Ex.Message, 400);
            }
        }

        public async Task<ApiResponse<T, dto>> Update(int id, dto entity)
        {
            try
            {
                var existingEntity = await _Context.Repository<T>().GetByIdAsync(id);

                if (existingEntity != null)
                {
                    _mapper.Map(entity, existingEntity);
                    _Context.Repository<T>().Update(existingEntity);
                    _auditLog.Action = $"Edit {typeof(T).Name}";
                    _auditLog.TableName = $"{typeof(T).Name}";
                    _auditLog.UserId = idUser;
                    _auditLog.RowId = id;

                    _Context.Repository<AuditLog>().Add(_auditLog);

                    await _Context.Commit();

                    return new ApiResponse<T, dto>(entity, "Success");
                }

                return new ApiResponse<T, dto>("Not Found Any Item For This ID", 404);
            }
            catch (Exception Ex)
            {
                return new ApiResponse<T, dto>(Ex.Message, 400);

            }
        }
    }
    }
