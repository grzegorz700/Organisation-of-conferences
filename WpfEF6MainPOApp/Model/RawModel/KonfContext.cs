namespace WpfEF6MainPOApp.Model.RawModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    /// <summary>
    /// Klasa odpowiedzialna do dostêp do bazy dancyh w jeden spójny sposób
    /// </summary>
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class KonfContext : DbContext
    {
        /// <summary>
        /// Konstruktor klasy odpowiedzialny za utworzenie obiektu z dostêpem do bazy dancyh
        /// </summary>
        public KonfContext()
            : base("name=KonfContext1")
        {
        }
        /// <summary>
        /// Zbiór wszystkich Artyku³ów pobranych z bazy danych
        /// </summary>
        public virtual DbSet<Artykul> Artykuly { get; set; }
        /// <summary>
        /// Zbiór wszystkich Konferencji pobranych z bazy danych
        /// </summary>
        public virtual DbSet<Konferencja> Konferencje { get; set; }
        /// <summary>
        /// Zbiór wszystkich Prelegentów pobranych z bazy danych
        /// </summary>
        public virtual DbSet<Prelegent> Prelegenci { get; set; }
        /// <summary>
        /// Zbiór wszystkich Referatów pobranych z bazy danych
        /// </summary>
        public virtual DbSet<Referat> Referaty { get; set; }
        /// <summary>
        /// Zbiór wszystkich Sal pobranych z bazy danych
        /// </summary>
        public virtual DbSet<Sala> Sale { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Diagnostics.Debug.WriteLine("@MY@@@@    OnModelCreating @My@");
            
            //My
            modelBuilder.Entity<Artykul>().HasKey(e => e.ID);
            
            modelBuilder.Entity<Artykul>()
                .Property(e => e.NazwaPliku)
                .IsUnicode(false);

            modelBuilder.Entity<Artykul>()
                .HasMany(e => e.referat)
                .WithOptional(e => e.artykul2)
                .HasForeignKey(e => e.Artykul2ID);

            modelBuilder.Entity<Artykul>()
                .HasMany(e => e.referat1)
                .WithOptional(e => e.artykul1)
                .HasForeignKey(e => e.Artykul1ID);

            modelBuilder.Entity<Konferencja>()
                .HasMany(e => e.referat)
                .WithRequired(e => e.konferencja)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prelegent>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<Prelegent>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<Prelegent>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Prelegent>()
                .Property(e => e.Haslo)
                .IsUnicode(false);

            modelBuilder.Entity<Prelegent>()
                .Property(e => e.TytulNaukowy)
                .IsUnicode(false);

            modelBuilder.Entity<Prelegent>()
                .Property(e => e.OsrodekBadawczy)
                .IsUnicode(false);

            modelBuilder.Entity<Referat>()
                .Property(e => e.Tytul)
                .IsUnicode(false);

            modelBuilder.Entity<Referat>()
                .Property(e => e.Abstrakt)
                .IsUnicode(false);

            modelBuilder.Entity<Referat>()
                .HasMany(e => e.prelegent)
                .WithMany(e => e.referat)
                .Map(m => m.ToTable("prelegentreferat").MapLeftKey("ReferatID").MapRightKey("OsobaID"));
                //.Map(m => m.ToTable("prelegentreferat", "po2").MapLeftKey("ReferatID").MapRightKey("OsobaID"));

            modelBuilder.Entity<Sala>()
                .Property(e => e.Nazwa)
                .IsUnicode(false);
        }
    }
}
