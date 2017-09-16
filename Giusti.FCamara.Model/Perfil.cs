using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Resources;
using System.Reflection;
using Giusti.FCamara.Model.Resource;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Giusti.FCamara.Model
{
    [HasSelfValidation()]
    public partial class Perfil
    {
        public Perfil()
        {
            PerfilFuncionalidades = new List<PerfilFuncionalidade>();
        }
        public int? Id { get; set; }

        public string Nome { get; set; }
        public IList<PerfilFuncionalidade> PerfilFuncionalidades { get; set; }
    }
}
