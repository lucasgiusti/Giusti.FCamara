﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Giusti.FCamara.Business.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Mensagem {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Mensagem() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Giusti.FCamara.Business.Resource.Mensagem", typeof(Mensagem).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O usuário {0} não tem permissão de acesso a funcionalidade {1}.
        /// </summary>
        internal static string Usuario_AcessoNegado {
            get {
                return ResourceManager.GetString("Usuario_AcessoNegado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo email é obrigatório.
        /// </summary>
        internal static string Usuario_Email {
            get {
                return ResourceManager.GetString("Usuario_Email", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email inválido.
        /// </summary>
        internal static string Usuario_EmailInvalido {
            get {
                return ResourceManager.GetString("Usuario_EmailInvalido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Login expirado, faça a autenticação novamente.
        /// </summary>
        internal static string Usuario_LoginExpirado {
            get {
                return ResourceManager.GetString("Usuario_LoginExpirado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Necessário autenticação.
        /// </summary>
        internal static string Usuario_NecessarioAutenticacao {
            get {
                return ResourceManager.GetString("Usuario_NecessarioAutenticacao", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo senha é obrigatório.
        /// </summary>
        internal static string Usuario_Senha {
            get {
                return ResourceManager.GetString("Usuario_Senha", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Senha inválida.
        /// </summary>
        internal static string Usuario_SenhaInvalida {
            get {
                return ResourceManager.GetString("Usuario_SenhaInvalida", resourceCulture);
            }
        }
    }
}
