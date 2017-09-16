using System.Collections.Generic;
using System.Linq;
using Giusti.FCamara.Model.Results;
using Giusti.FCamara.Business.Library;
using Giusti.FCamara.Data;
using Giusti.FCamara.Model;

namespace Giusti.FCamara.Business
{
    public class FuncionalidadeBusiness : BusinessBase
    {
        public IList<Funcionalidade> RetornaFuncionalidades_UtilizaMenu(int[] funcionalidadesId)
        {
            LimpaValidacao();
            List<Funcionalidade> RetornoAcao = new List<Funcionalidade>();
            if (IsValid())
            {
                using (FuncionalidadeData data = new FuncionalidadeData())
                {
                    RetornoAcao = data.RetornarFuncionalidades_UtilizaMenu(funcionalidadesId).ToList();
                }
            }

            RetornoAcao.RemoveAll(a =>
                    a.FuncionalidadePai != null && a.FuncionalidadePai.UtilizaMenu

                );

            RetiraFuncionalidadesPai(RetornoAcao);

            return RetornoAcao;
        }

        public void RetiraFuncionalidadesPai(List<Funcionalidade> listFuncionalidades)
        {
            listFuncionalidades.ForEach(a =>
            {
                a.FuncionalidadePai = null;
                if (a.FuncionalidadesFilho != null)
                    RetiraFuncionalidadesPai(a.FuncionalidadesFilho.ToList());
            });
        }

    }
}
