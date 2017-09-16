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
    /// Livro
    /// </summary>
    public class LivroController : ApiBase
    {
        LivroBusiness biz = new LivroBusiness();

        /// <summary>
        /// Retorna todos os livros
        /// </summary>
        /// <returns></returns>
        public List<Livro> Get()
        {
            List<Livro> ResultadoBusca = new List<Livro>();
            try
            {
                VerificaAutenticacao(Constantes.FuncionalidadeLivroConsulta, Constantes.FuncionalidadeNomeLivroConsulta, biz);

                //API
                ResultadoBusca = new List<Livro>(biz.RetornaLivros());

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