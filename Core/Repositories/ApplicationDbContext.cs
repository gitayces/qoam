﻿namespace QOAM.Core.Repositories
{
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;

    using QOAM.Core.Migrations;

    public class ApplicationDbContext : DbContext
    {
        static ApplicationDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApplicationDbContextMigrationsConfiguration>());
        }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Journal> Journals { get; set; }
        public DbSet<BaseJournalPrice> JournalsPrices { get; set; }
        public DbSet<BaseScoreCard> BaseScoreCards { get; set; }
        public DbSet<ValuationScoreCard> ValuationScoreCards { get; set; }
        public DbSet<ScoreCardVersion> ScoreCardVersions { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<InstitutionJournal> InstitutionJournals { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ValuationJournalPrice> ValuationJournalPrices { get; set; }

        public ObjectContext ObjectContext
        {
            get
            {
                return ((IObjectContextAdapter)this).ObjectContext;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<BaseScoreCardScore>();
            modelBuilder.ComplexType<ValuationScoreCardScore>();

            modelBuilder.Entity<Journal>()
                .HasOptional(t => t.BaseJournalPrice)
                .WithMany(t => t.Journals)
                .HasForeignKey(d => d.BaseJournalPriceId);

            modelBuilder.Entity<Journal>()
                .HasOptional(t => t.JournalScore)
                .WithMany(t => t.Journals)
                .HasForeignKey(d => d.JournalScoreId);
        }
    }
}