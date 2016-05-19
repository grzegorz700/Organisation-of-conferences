namespace WpfEF6MainPOApp.Model.RawModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("po2.konferencja")]
    /// <summary>
    /// Klasa Konferencja reprezentuje dane 1-nej edycji konferecnji(system wielokonferencyjny).
    /// </summary>
    public partial class Konferencja
    {
        /// <summary>
        /// Podstawowy konstruktor klasy. Bez parametrowy - inicjalizacja parametrów przez podanie ich odwo³añ do w³asnoœci (property) np.. Konferencja(){ID = 1}
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Konferencja()
        {
            referat = new HashSet<Referat>();
        }

        public int ID { get; set; }

        [Column(TypeName = "timestamp")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DeadlineZglaszaniaArtykulu { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime DeadlineInformacjiOAkcetpacji { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime DeadlineOstatecznyArtykulu { get; set; }

        public double? CenaNetto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Referat> referat { get; set; }
    }
}
