using SPG.Domain.Models.Entities;
using System.Data.Entity;

namespace SPG.DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext (): base("name=SPG.DataAccess2")
        {

        }

        public DataContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<MessageEntity> Message { get; set; }
        public DbSet<WordEntity> Word { get; set; }
        public DbSet<VenueEntity> Venue { get; set; }
        public DbSet<NeedEntity> Need { get; set; }
        public DbSet<TagEntity> Tag { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<PrefixEntity> Prefix { get; set; }
        public DbSet<SuffixEntity> Suffix { get; set; }

        protected override void OnModelCreating ( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<MessageEntity>().ToTable("Message");
            modelBuilder.Entity<WordEntity>().ToTable("Word");
            modelBuilder.Entity<VenueEntity>().ToTable("Venue");
            modelBuilder.Entity<NeedEntity>().ToTable("Need");
            modelBuilder.Entity<TagEntity>().ToTable("Tag");
            modelBuilder.Entity<UserEntity>().ToTable("User");
            modelBuilder.Entity<PrefixEntity>().ToTable("Prefix");
            modelBuilder.Entity<SuffixEntity>().ToTable("Suffix");
        }
    }
}
