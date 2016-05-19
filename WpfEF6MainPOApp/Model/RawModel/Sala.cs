namespace WpfEF6MainPOApp.Model.RawModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("po2.sala")]
    public partial class Sala
    {
        /// <summary>
        /// Podstawowy konstruktor klasy. Bez parametrowy - inicjalizacja parametrów przez podanie ich odwo³añ do w³asnoœci (property) np.. Sala(){ID = 1}
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sala()
        {
            referat = new HashSet<Referat>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Nazwa { get; set; }

        public int MaxMiejsc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Referat> referat { get; set; }
    }
}
