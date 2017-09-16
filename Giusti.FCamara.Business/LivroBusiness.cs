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
    public class LivroBusiness : BusinessBase
    {
        public IList<Livro> RetornaLivros()
        {
            LimpaValidacao();
            IList<Livro> RetornoAcao = new List<Livro>();
            if (IsValid())
            {
                using (LivroData data = new LivroData())
                {
                    RetornoAcao = data.RetornaLivros();
                }
            }

            return RetornoAcao;
        }

    }
}
