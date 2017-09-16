using System.Collections.Generic;
using System.Linq;
using Giusti.FCamara.Model.Results;
using Giusti.FCamara.Business.Library;
using Giusti.FCamara.Data;
using Giusti.FCamara.Model;
using System;
using Giusti.FCamara.Model.Dominio;
using System.Web.Security;

namespace Giusti.FCamara.Business
{
    public class UsuarioBusiness : BusinessBase
    {
        public Usuario RetornaUsuario_Email(string email)
        {
            LimpaValidacao();
            Usuario RetornoAcao = null;
            if (IsValid())
            {
                using (UsuarioData data = new UsuarioData())
                {
                    RetornoAcao = data.RetornaUsuario_Email(email);
                }
            }

            return RetornoAcao;
        }

        public UsuarioLogado EfetuaLoginSistema(string email, string senha, string ip, string nomeMaquina)
        {
            LimpaValidacao();
            if (string.IsNullOrEmpty(email))
                IncluiErroBusiness("Usuario_Email");

            if (string.IsNullOrEmpty(senha))
                IncluiErroBusiness("Usuario_Senha");

            UsuarioLogado retorno = null;
            if (IsValid())
            {
                UsuarioBusiness bizUsuario = new UsuarioBusiness();
                Usuario itemBase = bizUsuario.RetornaUsuario_Email(email);

                if (itemBase == null)
                    IncluiErroBusiness("Usuario_EmailInvalido");

                if (IsValid() && !PasswordHash.ValidatePassword(senha, itemBase.Senha))
                    IncluiErroBusiness("Usuario_SenhaInvalida");

                if (IsValid())
                {
                    retorno = new UsuarioLogado();
                    retorno.Id = itemBase.Id.Value;
                    retorno.DataHoraAcesso = DateTime.Now;
                    retorno.Email = itemBase.Email;
                    retorno.Nome = itemBase.Nome;
                    retorno.WorkstationId = nomeMaquina;

                    PerfilUsuarioBusiness bizPerfilUsuario = new PerfilUsuarioBusiness();
                    IList<string> listFuncionalidade = bizPerfilUsuario.RetornaFuncionalidades_UsuarioId((int)itemBase.Id);

                    retorno.Token = GeraToken(email, string.Join(",", listFuncionalidade));
                }

            }
            return retorno;
        }

        private string GeraToken(string email, string funcionalidades)
        {
            try
            {
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, email, DateTime.Now, DateTime.Now.AddMinutes(1), false, funcionalidades);

                string ticketCriptografado = FormsAuthentication.Encrypt(authTicket);
                return ticketCriptografado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
