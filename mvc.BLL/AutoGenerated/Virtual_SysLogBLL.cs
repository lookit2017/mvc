//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using mvc.Models;
using mvc.Common;
using Microsoft.Practices.Unity;
using mvc.IBLL;
using mvc.IDAL;
using mvc.BLL.Core;
using mvc.Models.Sys;
namespace mvc.BLL
{
    public class Virtual_SysLogBLL
    {
        [Dependency]
        public ISysLogRepository m_Rep { get; set; }

        public virtual List<SysLogModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<SysLog> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
                                a=>a.Id.Contains(queryStr)
                                || a.Operator.Contains(queryStr)
                                || a.Message.Contains(queryStr)
                                || a.Result.Contains(queryStr)
                                || a.Type.Contains(queryStr)
                                || a.Module.Contains(queryStr)
                                
                                );
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            pager.totalRows = queryData.Count();
            //排序
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        public virtual List<SysLogModel> CreateModelList(ref IQueryable<SysLog> queryData)
        {

            List<SysLogModel> modelList = (from r in queryData
                                              select new SysLogModel
                                              {
                                                    Id = r.Id,
                                                    Operator = r.Operator,
                                                    Message = r.Message,
                                                    Result = r.Result,
                                                    Type = r.Type,
                                                    Module = r.Module,
                                                    CreateTime = r.CreateTime,
          
                                              }).ToList();

            return modelList;
        }

        public virtual bool Create(ref ValidationErrors errors, SysLogModel model)
        {
            try
            {
                SysLog entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysLog();
                               entity.Id = model.Id;
                entity.Operator = model.Operator;
                entity.Message = model.Message;
                entity.Result = model.Result;
                entity.Type = model.Type;
                entity.Module = model.Module;
                entity.CreateTime = model.CreateTime;
  

                if (m_Rep.Create(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.InsertFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }



         public virtual bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public virtual bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
					if (m_Rep.Delete(deleteCollection) == deleteCollection.Length)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        
       

        public virtual bool Edit(ref ValidationErrors errors, SysLogModel model)
        {
            try
            {
                SysLog entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                                              entity.Id = model.Id;
                entity.Operator = model.Operator;
                entity.Message = model.Message;
                entity.Result = model.Result;
                entity.Type = model.Type;
                entity.Module = model.Module;
                entity.CreateTime = model.CreateTime;
 


                if (m_Rep.Edit(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.NoDataChange);
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

      

        public virtual SysLogModel GetById(string id)
        {
            if (IsExists(id))
            {
                SysLog entity = m_Rep.GetById(id);
                SysLogModel model = new SysLogModel();
                                              model.Id = entity.Id;
                model.Operator = entity.Operator;
                model.Message = entity.Message;
                model.Result = entity.Result;
                model.Type = entity.Type;
                model.Module = entity.Module;
                model.CreateTime = entity.CreateTime;
 
                return model;
            }
            else
            {
                return null;
            }
        }

        public virtual bool IsExists(string id)
        {
            return m_Rep.IsExist(id);
        }
          public void Dispose()
        { 
            
        }

    }
}
