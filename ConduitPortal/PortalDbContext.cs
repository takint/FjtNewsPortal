using ConduitPortal.Models;
using FjtFramework.Cores;
using Microsoft.EntityFrameworkCore;

namespace ConduitPortal
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> options)
         : base(options)
        {
        }

        // This constructor is for unit testing mock
        public PortalDbContext() : base()
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<ArticleModel>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<ArticleTagModel>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<CommentModel>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<PersonModel>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<TagModel>());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Local use only
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=.\MSSQLSERVER17;Initial Catalog=NewsPortalDb;User ID=sa;Password=123;Persist Security Info=True;MultipleActiveResultSets=True");
            }
        }

        public virtual DbSet<ArticleModel> Articles { get; set; }
        public virtual DbSet<ArticleTagModel> ArticleTags { get; set; }
        public virtual DbSet<CommentModel> Comments { get; set; }
        public virtual DbSet<PersonModel> Authors { get; set; }
        public virtual DbSet<TagModel> Tags { get; set; }
    }
}
