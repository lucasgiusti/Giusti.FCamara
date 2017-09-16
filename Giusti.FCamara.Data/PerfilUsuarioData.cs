using System.Collections.Generic;
using System.Linq;
using System.Data;
using Giusti.FCamara.Model;
using Giusti.FCamara.Data.Library;

namespace Giusti.FCamara.Data
{
    public class PerfilUsuarioData : DataBase
    {
        public List<string> RetornaFuncionalidades_UsuarioId(int usuarioId)
        {
            List<int?> listFuncionalidades =
            Context.PerfilUsuarios.Where(d => d.UsuarioId == usuarioId)
                .Join(Context.Perfis,
                pu => pu.PerfilId,
                p => p.Id,
                (pu, p) => p).SelectMany(p => p.PerfilFuncionalidades).Select(p => p.FuncionalidadeId).Distinct().ToList();

            List<string> listFuncionalidadesStr = new List<string>();
            foreach (int? funcionalidadeId in listFuncionalidades)
                listFuncionalidadesStr.Add(funcionalidadeId.ToString());
            return listFuncionalidadesStr;
        }
    }
}
