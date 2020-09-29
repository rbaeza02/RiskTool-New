﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.MainModule.Entities.Resources {
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
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Domain.MainModule.Entities.Resources.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to No se encontró en SISE.
        /// </summary>
        internal static string exception_AseguradoNotFound {
            get {
                return ResourceManager.GetString("exception_AseguradoNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cliente INHABILITADO por lista OFAC - Por favor contacte al Compliance Officer para más información..
        /// </summary>
        internal static string exception_AseguradoOFAC {
            get {
                return ResourceManager.GetString("exception_AseguradoOFAC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El valor &quot;{1}&quot; es incorrecto en la posición {2}..
        /// </summary>
        internal static string exception_BadVector {
            get {
                return ResourceManager.GetString("exception_BadVector", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El sublímite de &quot;Bienes Bajo Tierra&quot; no puede ser mayor al Total..
        /// </summary>
        internal static string exception_CotizacionBienesBajoTierra {
            get {
                return ResourceManager.GetString("exception_CotizacionBienesBajoTierra", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El sublímite de &quot;Daños Por Causas Externas&quot; no puede ser mayor al Total..
        /// </summary>
        internal static string exception_CotizacionCausaExt {
            get {
                return ResourceManager.GetString("exception_CotizacionCausaExt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se puede cotizar con fechas posteriores a {1} días.
        /// </summary>
        internal static string exception_CotizacionFuturo {
            get {
                return ResourceManager.GetString("exception_CotizacionFuturo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El sublímite de &quot;Gastos Extraordinarios&quot; no puede ser mayor al Total..
        /// </summary>
        internal static string exception_CotizacionGastosExtra {
            get {
                return ResourceManager.GetString("exception_CotizacionGastosExtra", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El sublímite de &quot;Huelga, Paros. Disturbios, Motines, Alborotos Populares, Sabotaje o Actos de Personas mal Intencionadas&quot; no puede ser mayor al Total..
        /// </summary>
        internal static string exception_CotizacionHuelga {
            get {
                return ResourceManager.GetString("exception_CotizacionHuelga", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se pueden hacer cambios porque la cotización ya fue emitida.
        /// </summary>
        internal static string exception_CotizacionInactiva {
            get {
                return ResourceManager.GetString("exception_CotizacionInactiva", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se puede cotizar con fechas anteriores a {1} días.
        /// </summary>
        internal static string exception_CotizacionRetroactividad {
            get {
                return ResourceManager.GetString("exception_CotizacionRetroactividad", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Esta cotización ya fue procesada en SISE.
        /// </summary>
        internal static string exception_CotizacionSISE {
            get {
                return ResourceManager.GetString("exception_CotizacionSISE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El sublímite de &quot;Terrorismo&quot; no puede ser mayor al Total..
        /// </summary>
        internal static string exception_CotizacionTerrorismo {
            get {
                return ResourceManager.GetString("exception_CotizacionTerrorismo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El máximo de beneficiarios es 3.
        /// </summary>
        internal static string exception_MaxBenef {
            get {
                return ResourceManager.GetString("exception_MaxBenef", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No coinciden los tamaños.
        /// </summary>
        internal static string exception_NotMatch {
            get {
                return ResourceManager.GetString("exception_NotMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se encontró en SISE.
        /// </summary>
        internal static string exception_PersonaNotFound {
            get {
                return ResourceManager.GetString("exception_PersonaNotFound", resourceCulture);
            }
        }
    }
}
