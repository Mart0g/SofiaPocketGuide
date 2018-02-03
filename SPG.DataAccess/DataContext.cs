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
        public DataContext (): base("name=DataContext")
        {

        }

        public DbSet<MessageEntity> Message { get; set; }
        public DbSet<WordEntity> Word { get; set; }
        public DbSet<RootEntity> Root { get; set; }
        public DbSet<PlaceEntity> Place { get; set; }
        public DbSet<LexicalCategoryEntity> LexicalCategory { get; set; }
        public DbSet<NeedCategoryEntity> NeedCategory { get; set; }
        public DbSet<PlaceCategoryEntity> PlaceCategory { get; set; }
        public DbSet<SubCategoryEntity> SubCategory { get; set; }


        protected override void OnModelCreating ( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<MessageEntity>().ToTable("Message");
            modelBuilder.Entity<WordEntity>().ToTable("Word");
            modelBuilder.Entity<PlaceEntity>().ToTable("Place");
            modelBuilder.Entity<RootEntity>().ToTable("Root");
            modelBuilder.Entity<LexicalCategoryEntity>().ToTable("LexicalCategory");
            modelBuilder.Entity<NeedCategoryEntity>().ToTable("NeedCategory");
            modelBuilder.Entity<PlaceCategoryEntity>().ToTable("PlaceCategory");
            modelBuilder.Entity<SubCategoryEntity>().ToTable("SubCategory");
        }
    }
}
