using OnlineShop.Model.Models;
using OnlineShop.Service;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShop.Web.infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;

        public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                response = function.Invoke();
            }
            catch(DbEntityValidationException ex)
            {
                foreach(var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \" {eve.Entry.Entity.GetType().Name} \" in state \" {eve.Entry.State} \" has the following validation errors.");
                    foreach(var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"-Property: \" {ve.PropertyName} \", Error: \" {ve.ErrorMessage} \"");
                    }
                }
            }
            catch (DbUpdateException DbEx)
            {
                LogError(DbEx);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, DbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error error = new Error();
                error.Message = ex.Message;
                error.StackTrace = ex.StackTrace;
                error.CreateDate = DateTime.Now;

                _errorService.Create(error);
                _errorService.Save();
            }
            catch
            {

            }
        }
    }
}
