using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;

namespace Giusti.FCamara.Model
{
    [HasSelfValidation()]
    public class Livro
    {
        public Livro()
        {
            
        }

        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
    }
}
