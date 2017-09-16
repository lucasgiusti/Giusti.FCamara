using System.Collections.Generic;
using System.Linq;
using System.Data;
using Giusti.FCamara.Model;
using Giusti.FCamara.Data.Library;

namespace Giusti.FCamara.Data
{
    public class LivroData : DataBase
    {
        public IList<Livro> RetornaLivros()
        {
            IQueryable<Livro> query = Context.Livros;

            return query.ToList();
        }
    }
}
