//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Emigrantes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Necesidades
    {
        public int id { get; set; }
        public int IdPersona { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdPrioridad { get; set; }
        public Nullable<int> IdEmigranteNecesidad { get; set; }
        public Nullable<int> IdTipoServicio { get; set; }
    
        public virtual Emigrante Emigrante { get; set; }
        public virtual migrantesNecesidad migrantesNecesidad { get; set; }
        public virtual prioridadNecesidad prioridadNecesidad { get; set; }
        public virtual tipoSolicitud tipoSolicitud { get; set; }
    }
}
