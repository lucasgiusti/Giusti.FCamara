using System.Collections.Generic;
using System.Linq;
using System.Data;
using Giusti.FCamara.Model;
using Giusti.FCamara.Data.Library;

namespace Giusti.FCamara.Data
{
    public class UsuarioData : DataBase
    {
        public Usuario RetornaUsuario_Email(string email)
        {
            IQueryable<Usuario> query = Context.Usuarios.Include("Perfis");

            if (!string.IsNullOrEmpty(email))
                query = query.Where(d => d.Email == email);
            return query.FirstOrDefault();
        }
    }
}
