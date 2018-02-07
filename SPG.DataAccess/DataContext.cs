using SPG.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext (): base("name=SPG.DataAccess")
        {

        }

        public DbSet<MessageEntity> Message { get; set; }
        public DbSet<WordEntity> Word { get; set; }
        public DbSet<VenueEntity> Venue { get; set; }
        public DbSet<NeedEntity> Need { get; set; }
        public DbSet<TagEntity> Tag { get; set; }
        public DbSet<UserEntity> User { get; set; }

        protected override void OnModelCreating ( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<MessageEntity>().ToTable("Message");
            modelBuilder.Entity<WordEntity>().ToTable("Word");
            modelBuilder.Entity<VenueEntity>().ToTable("Venue");
            modelBuilder.Entity<NeedEntity>().ToTable("Need");
            modelBuilder.Entity<TagEntity>().ToTable("Tag");
            modelBuilder.Entity<UserEntity>().ToTable("User");
        }

        
    }
}
