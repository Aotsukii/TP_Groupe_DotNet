using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP_Groupe.Models;

namespace TP_Groupe.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Etagere> Etageres { get; set; }
        public DbSet<Secteur> Secteurs { get; set; }
        public DbSet<PositionMagasin> PositionsMagasin { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // création de la classe de configuration pour l'entité "Article"
            var articleEntity = modelBuilder.Entity<Article>();
            // définition du mapping
            articleEntity.HasKey(m => m.Id); // définition du champ clé
            articleEntity.Property(m => m.Libelle).HasMaxLength(256).IsRequired(); // définition de contrainte
            articleEntity.Property(m => m.SKU).HasMaxLength(256).IsRequired(); // définition de contrainte
            articleEntity.Property(m => m.DateSortie).IsRequired(); // définition de contrainte
            articleEntity.Property(m => m.PrixInitial).IsRequired(); // définition de contrainte
            articleEntity.Property(m => m.Poids).IsRequired(); // définition de contrainte
            //création des relations

            // création de la classe de configuration pour l'entité "Etagere"
            var etagereEntity = modelBuilder.Entity<Etagere>();
            // définition du mapping
            etagereEntity.HasKey(m => m.Id);
            etagereEntity.Property(m => m.PoidsMaximum).IsRequired(); // définition de contrainte
            //création des relations

            etagereEntity // Une étagère a ...
                .HasOne(m => m.Secteur) // a un secteur ...
                .WithMany(m => m.Etageres) // 
                .HasForeignKey(m => m.SecteurId); // 

            // création de la classe de configuration pour l'entité "Secteur"
            var secteurEntity = modelBuilder.Entity<Secteur>();
            // définition du mapping
            secteurEntity.HasKey(m => m.Id);
            secteurEntity.Property(m => m.Nom).HasMaxLength(256).IsRequired(); // définition de contrainte
            //création des relations

            secteurEntity // Un professeur a ...
                .HasMany<Etagere>(m => m.Etageres) // plusieurs étagères différentes ...
                .WithOne(t => t.Secteur) // qui le connaissse ...
                .HasForeignKey(t => t.SecteurId); // par son id

            // création de la classe de configuration pour l'entité "PositionMagasin"
            var posititonMagasin = modelBuilder.Entity<PositionMagasin>();
            //définition du mapping
            posititonMagasin.HasKey(m => new { m.IdArticle, m.IdEtagere }); // définition d'une clé composée

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // définition de la base de données à utiliser ainsi que de la chaine de connexion
            optionsBuilder.UseSqlite("Filename=tp_mspr.db");

            base.OnConfiguring(optionsBuilder);
        }
    }
}