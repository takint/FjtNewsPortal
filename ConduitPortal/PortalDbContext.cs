using ConduitPortal.Models;
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
        public PortalDbContext()
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<ArticleModel> Articles { get; set; }
        public virtual DbSet<ArticleTagModel> ArticleTags { get; set; }
        public virtual DbSet<CommentModel> Comments { get; set; }
        public virtual DbSet<PersonModel> Authors { get; set; }
        public virtual DbSet<TagModel> Tags { get; set; }
    }
}
