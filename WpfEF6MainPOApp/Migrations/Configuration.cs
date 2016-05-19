namespace WpfEF6MainPOApp.Migrations
{
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.Migrations.Sql;
    using System.Linq;

    /// <summary>
    /// Klasa odpowiedzialna za poprawn¹ obs³ugê bazy danych MySQl.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<WpfEF6MainPOApp.Model.RawModel.KonfContext>
    {
        /// <summary>
        /// Konsturkot odpowiedzialny za skonfigurowanie bazydanych w odpowieni dla MySQl sposób.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
            CodeGenerator = new MySql.Data.Entity.MySqlMigrationCodeGenerator();
            System.Diagnostics.Debug.WriteLine("@MY@@@@    Configuration @My@");
        }

        protected override void Seed(WpfEF6MainPOApp.Model.RawModel.KonfContext context)
        {
            System.Diagnostics.Debug.WriteLine("@MY@@@@    Configuration-Seed @My@");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
       

    }
    /*
    public class MyOwnMySqlMigrationSqlGenerator : MySqlMigrationSqlGenerator
    {
        protected override MigrationStatement Generate(AddForeignKeyOperation addForeignKeyOperation)
        {
            System.Diagnostics.Debug.WriteLine("@MY@@@@    MyOwnMySqlMigrationSqlGenerator-Generate @My@");
            addForeignKeyOperation.PrincipalTable = addForeignKeyOperation.PrincipalTable.Replace("po2.", "");
            addForeignKeyOperation.DependentTable = addForeignKeyOperation.DependentTable.Replace("po2.", "");
            MigrationStatement ms = base.Generate(addForeignKeyOperation);
            return ms;
        }
    }
     */ 
}
