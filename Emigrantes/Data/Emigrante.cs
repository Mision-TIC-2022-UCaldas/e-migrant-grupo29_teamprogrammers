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
    using System.ComponentModel.DataAnnotations;


    public partial class Emigrante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Emigrante()
        {
            this.Emergencias = new HashSet<Emergencias>();
            this.emigrantesServicios = new HashSet<emigrantesServicios>();
            this.Grupos = new HashSet<Grupos>();
            this.GruposMigrantes = new HashSet<GruposMigrantes>();
            this.Necesidades = new HashSet<Necesidades>();
        }

        
        public int id { get; set; }

        public string TipoIdentificacion { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string PaisOrigen { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public Nullable<System.DateTime> Fecha_Nacimiento { get; set; }
        
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public Nullable<int> IdEstadoLaboral { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emergencias> Emergencias { get; set; }
        public virtual situacionLaboral situacionLaboral { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emigrantesServicios> emigrantesServicios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grupos> Grupos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GruposMigrantes> GruposMigrantes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Necesidades> Necesidades { get; set; }
    }
}
