namespace WpfEF6MainPOApp.Model.RawModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("po2.prelegent")]
    public partial class Prelegent
    {
        /// <summary>
        /// Podstawowy konstruktor klasy. Bez parametrowy - inicjalizacja parametrów przez podanie ich odwo³añ do w³asnoœci (property) np.. Prelegent(){ID = 1}
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prelegent()
        {
            referat = new HashSet<Referat>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Imie { get; set; }

        [Required]
        [StringLength(150)]
        public string Nazwisko { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Haslo { get; set; }

        [StringLength(40)]
        public string TytulNaukowy { get; set; }

        [StringLength(255)]
        public string OsrodekBadawczy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Referat> referat { get; set; }
    }
}
