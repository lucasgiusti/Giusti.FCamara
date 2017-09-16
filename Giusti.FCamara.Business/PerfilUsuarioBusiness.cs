using System.Collections.Generic;
using System.Linq;
using Giusti.FCamara.Model.Results;
using Giusti.FCamara.Business.Library;
using Giusti.FCamara.Data;
using Giusti.FCamara.Model;

namespace Giusti.FCamara.Business
{
    public class PerfilUsuarioBusiness : BusinessBase
    {
        public IList<string> RetornaFuncionalidades_UsuarioId(int usuarioId)
        {
            IList<string> RetornoAcao = new List<string>();
            using (PerfilUsuarioData data = new PerfilUsuarioData())
            {
                RetornoAcao = data.RetornaFuncionalidades_UsuarioId(usuarioId);
            }
            return RetornoAcao;
        }
    }
}
