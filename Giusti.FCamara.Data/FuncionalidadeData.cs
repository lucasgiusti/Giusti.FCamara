using System.Collections.Generic;
using System.Linq;
using System.Data;
using Giusti.FCamara.Model;
using Giusti.FCamara.Data.Library;

namespace Giusti.FCamara.Data
{
    public class FuncionalidadeData : DataBase
    {
        public IList<Funcionalidade> RetornarFuncionalidades_UtilizaMenu(int[] funcionalidadesId)
        {
            IQueryable<Funcionalidade> query = Context.Funcionalidades;
            query = query.Where(d => d.UtilizaMenu == true);

            query = query.Where(d => funcionalidadesId.Contains((int)d.Id));

            return query.ToList();
        }
    }
}
