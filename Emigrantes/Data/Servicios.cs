//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Emigrantes.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Servicios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servicios()
        {
            this.emigrantesServicios = new HashSet<emigrantesServicios>();
        }
    
        public int dI { get; set; }
        public string Servicio { get; set; }
        public Nullable<int> Maximo_Emigrantes { get; set; }
        public Nullable<System.DateTime> Fecha_Inicio { get; set; }
        public Nullable<System.DateTime> Fecha_fin { get; set; }
        public Nullable<double> Estado_Servicio { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdEntidad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emigrantesServicios> emigrantesServicios { get; set; }
        public virtual Entidad Entidad { get; set; }
    }
}
