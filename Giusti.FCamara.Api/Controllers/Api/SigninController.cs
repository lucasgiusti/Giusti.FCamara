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

namespace Giusti.FCamara.Web.Controllers
{
    /// <summary>
    /// Signin
    /// </summary>
    public class SigninController : ApiBase
    {
        UsuarioBusiness biz = new UsuarioBusiness();

        public UsuarioLogado Post([FromBody]Usuario usuario)
        {
            UsuarioLogado usuarioLogado = new UsuarioLogado();
            try
            {
                string ipMaquina = string.Empty;
                string nomeMaquina = string.Empty;
                string email = null;
                string senha = null;

                if (usuario != null)
                {
                    if (!string.IsNullOrEmpty(usuario.Email))
                        email = usuario.Email;
                    if (!string.IsNullOrEmpty(usuario.Senha))
                        senha = usuario.Senha;
                }

                nomeMaquina = Dns.GetHostName();
                ipMaquina = "127.0.0.1";

                usuarioLogado = biz.EfetuaLoginSistema(email, senha, ipMaquina, nomeMaquina);

                if (!biz.IsValid())
                    throw new InvalidDataException();
            }
            catch (InvalidDataException)
            {
                GeraErro(HttpStatusCode.InternalServerError, biz.serviceResult);
            }
            catch (UnauthorizedAccessException)
            {
                GeraErro(HttpStatusCode.Forbidden, biz.serviceResult);
            }
            catch (Exception ex)
            {
                GeraErro(HttpStatusCode.BadRequest, ex);
            }

            return usuarioLogado;
        }
    }
}