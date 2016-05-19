namespace WpfEF6MainPOApp.Model.RawModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.IO;

    //[Table("po2.artykul")]
    /// <summary>
    /// Klasa reprezentujaca Artyku�. Przechowuje dane wys�anym pliku na artyku� wraz z potrzebnymi informacjami.
    /// </summary>
    public partial class Artykul
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        private Artykul()
        {
            referat = new HashSet<Referat>();
            referat1 = new HashSet<Referat>();
        }

        /// <summary>
        /// Konstruktor Artykulu dla referatu.
        /// </summary>
        /// <param name="id">identyfikator Artyku�u</param>
        /// <param name="plik">bajtowa wersja pliku</param>
        /// <param name="nazwaPliku">Nazwa pliku</param>
        /// <param name="dataWyslania">Data wys�ania pliku</param>
        public Artykul(int id, byte[] plik, string nazwaPliku,  DateTime dataWyslania)  : this()
        {
            ID = id;
            Plik = plik;
            if(plik == null || plik.Length == 0 || plik.Length > 16*1024*1024 ||
                nazwaPliku == null || nazwaPliku.Length > 255 ||
                dataWyslania == null)
                {
                throw new ArgumentNullException();
            }
            NazwaPliku = nazwaPliku;
            DataWyslania = dataWyslania;
        }

        [Key]
        public int ID { get; set; }

        [Column(TypeName = "mediumblob")]
        [Required]
        public byte[] Plik { get; set; }

        [Required]
        [StringLength(255)]
        public string NazwaPliku { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] //Wczesniej Indentity
        public DateTime DataWyslania { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Referat> referat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Referat> referat1 { get; set; }

        /// <summary>
        ///     Sprawdza czy wybrany plik spe�nia kryteria wys�ania go jako pliku Artyku�u.
        /// </summary>
        /// <param name="FullPath">
        /// Pe�na �cie�ka dost�pu do pliku
        /// </param>
        /// <returns>
        ///     werdykt czy plik spe�nia warunki pliku Artyku�u. True - spe�nia, false - niespe�nia.
        /// </returns>
        public static bool FileValidate(string FullPath)
        {
            FileInfo file = new FileInfo(FullPath);
            if(!file.Exists)
                return false;
            if (file.Name.Length > 255)
            {
                return false;
            }
            if (!ValidExtensions.Contains(file.Extension.ToLower()))
                return false;
            if(file.Length == 0 || file.Length >= 16*1024*1024){
                return false;
            }
            return true;
        }

        private static List<string> ValidExtensions = new List<string>(){
        ".txt",
        ".doc" ,
        ".docx",
        ".pdf" ,
        ".dvi" 
        };
    }
}
