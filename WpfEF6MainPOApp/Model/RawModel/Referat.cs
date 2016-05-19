namespace WpfEF6MainPOApp.Model.RawModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public enum StatusReferatu
    {
        Zloszony = 1,
        Zaakceptowany = 2,
        DoPoprawy = 3,
        NieZaakceptowany = 4
    }

    //[Table("po2.referat")]
    public partial class Referat
    {
        /// <summary>
        /// Podstawowy konstruktor klasy. Bez parametrowy - inicjalizacja parametrów przez podanie ich odwo³añ do w³asnoœci (property) np.. Referat(){ID = 1}
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Referat()
        {
            prelegent = new HashSet<Prelegent>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Tytul { get; set; }

        [Required]
        [StringLength(2048)]
        public string Abstrakt { get; set; }

        /// <summary>
        ///     Data rozpoczecia wystapienia(referatu)
        /// </summary>
        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DataRozpoczecia { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime DataZakonczenia { get; set; }

        public StatusReferatu CzyZaakceptowany { get; set; }

        public double? CenaNetto { get; set; }

        public int KonferencjaID { get; set; }

        public int? Artykul1ID { get; set; }

        public int? Artykul2ID { get; set; }

        public int? SalaID { get; set; }

        public virtual Artykul artykul1 { get; set; }
        
        public virtual Artykul artykul2 { get; set; }

        public virtual Konferencja konferencja { get; set; }

        public virtual Sala sala { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prelegent> prelegent { get; set; }


    }
}
