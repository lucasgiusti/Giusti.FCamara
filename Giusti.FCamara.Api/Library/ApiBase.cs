using Giusti.FCamara.Business;
using Giusti.FCamara.Business.Library;
using Giusti.FCamara.Model;
using Giusti.FCamara.Model.Dominio;
using Giusti.FCamara.Model.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace Giusti.FCamara.Api.Library
{
    public abstract partial class ApiBase : ApiController
    {
        #region Return Ok for DELETE

        protected HttpResponseMessage RetornaMensagemOk(ServiceResult resultado)
        {
            var json = JsonConvert.SerializeObject(resultado);
            HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.OK, json);
            return response;
        }

        #endregion

        #region Return Error

        #region Return Error for PUT, POST, DELETE

        protected HttpResponseMessage RetornaMensagemErro(HttpStatusCode statusCode, ServiceResult resultado)
        {
            var json = JsonConvert.SerializeObject(resultado);
            HttpResponseMessage response = this.Request.CreateResponse(statusCode, json);
            return response;
        }

        protected HttpResponseMessage RetornaMensagemErro(HttpStatusCode statusCode, Exception ex)
        {
            ServiceResult serviceResult = new ServiceResult();
            serviceResult.Success = false;
            serviceResult.Messages.Add(new ServiceResultMessage() { Message = UtilitarioBusiness.RetornaExceptionMessages(ex) });

            var json = JsonConvert.SerializeObject(serviceResult);
            HttpResponseMessage response = this.Request.CreateResponse(statusCode, json);
            return response;
        }

        #endregion

        #region Return Error for GET

        protected void GeraErro(HttpStatusCode statusCode, Exception ex)
        {
            ServiceResult serviceResult = new ServiceResult();
            serviceResult.Success = false;
            serviceResult.Messages.Add(new ServiceResultMessage() { Message = UtilitarioBusiness.RetornaExceptionMessages(ex) });

            var json = JsonConvert.SerializeObject(serviceResult);
            HttpResponseMessage response = this.Request.CreateErrorResponse(statusCode, json);
            throw new HttpResponseException(response);
        }

        protected void GeraErro(HttpStatusCode statusCode, ServiceResult resultado)
        {
            var json = JsonConvert.SerializeObject(resultado);
            HttpResponseMessage response = this.Request.CreateErrorResponse(statusCode, json);
            throw new HttpResponseException(response);
        }

        #endregion

        #endregion

        #region Authentication

        protected void VerificaAutenticacao(string codigoFuncionalidade, string funcionalidade, BusinessBase biz)
        {
            biz.VerificaAutenticacao(RetornaToken(), codigoFuncionalidade, funcionalidade);
            if (!biz.IsValid())
                throw new UnauthorizedAccessException();
        }
        protected string RetornaToken()
        {
            string token = string.Empty;
            if (Request.Headers.Authorization != null)
                token = Request.Headers.Authorization.Parameter;

            return token;
        }
        private FormsAuthenticationTicket RetornaTokenDescriptografado(string token)
        {
            FormsAuthenticationTicket cookie = FormsAuthentication.Decrypt(token);
            return cookie;
        }
        public string RetornaEmailAutenticado()
        {
            string token = RetornaToken();
            if (string.IsNullOrEmpty(token))
                return string.Empty;

            return RetornaTokenDescriptografado(token).Name;
        }
        protected string[] RetornaFuncionalidadesUsuario()
        {
            string token = RetornaToken();
            if (string.IsNullOrEmpty(token))
                return null;

            FormsAuthenticationTicket cookie = FormsAuthentication.Decrypt(token);

            string userData = cookie.UserData;
            string[] roles = userData.Split(',');

            return roles;
        }

        #endregion

    }
}