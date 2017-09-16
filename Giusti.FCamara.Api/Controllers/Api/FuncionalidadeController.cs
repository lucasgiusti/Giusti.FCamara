using System;
using System.Collections.Generic;
using System.Web.Http;
using System.IO;
using Giusti.FCamara.Api.Library;
using System.Net.Http;
using System.Net;
using Giusti.FCamara.Model;
using Giusti.FCamara.Model.Dominio;
using System.Web;
using Giusti.FCamara.Business;

namespace Giusti.FCamara.Api.Controllers
{
    /// <summary>
    /// Perfil
    /// </summary>
    public class FuncionalidadeController : ApiBase
    {
        FuncionalidadeBusiness biz = new FuncionalidadeBusiness();

        /// <summary>
        /// Retora todas as funcionalidades para utilização no menu
        /// </summary>
        /// <returns></returns>
        public List<Funcionalidade> Get()
        {
            List<Funcionalidade> ResultadoBusca = new List<Funcionalidade>();
            try
            {
                //API
                string[] funcionalidadesUsuario = RetornaFuncionalidadesUsuario();

                if (funcionalidadesUsuario != null)
                {
                    int[] funcionalidadeId = Array.ConvertAll(funcionalidadesUsuario, int.Parse);
                    ResultadoBusca = new List<Funcionalidade>(biz.RetornaFuncionalidades_UtilizaMenu(funcionalidadeId));
                }

                if (!biz.IsValid())
                    throw new InvalidDataException();
            }
            catch (InvalidDataException)
            {
                GeraErro(HttpStatusCode.InternalServerError, biz.serviceResult);
            }
            catch (UnauthorizedAccessException)
            {
                GeraErro(HttpStatusCode.Unauthorized, biz.serviceResult);
            }
            catch (Exception ex)
            {
                GeraErro(HttpStatusCode.BadRequest, ex);
            }

            return ResultadoBusca;
        }

    }
}