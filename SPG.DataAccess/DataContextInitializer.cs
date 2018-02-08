using SPG.DataAccess.Entities;
using SPG.DataViewModels.DataSetModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess
{
    public class DataContextInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        public override void InitializeDatabase(DataContext context)
        {
            base.InitializeDatabase(context);
            SeedVenueTag(context);
            SeedVenueUser(context);
        }
        public void SeedVenueTag(DataContext context)
        {
            string path = @"C:\Users\dido_\Documents\GitHub\SofiaPocketGuide\SPG.DataAccess\DataSets\tag-venue-dataset.txt";
            if (!context.Tag.Any() && !context.Venue.Any())
            {
                var results = from str in File.ReadAllLines(path)
                              where !String.IsNullOrEmpty(str)
                              let data = str.Split(new string[] { ".." }, StringSplitOptions.RemoveEmptyEntries)
                              where data.Length == 2 && !String.IsNullOrEmpty(data[0]) && !String.IsNullOrEmpty(data[1])
                              select new TagVenueDSM
                              {
                                  VenueId = int.Parse(data[0]),
                                  Tags = data[1]
                              };
                foreach (TagVenueDSM item in results)
                {
                    VenueEntity venue = new VenueEntity { VenueCode = item.VenueId };
                    context.Venue.Add(venue);
                    context.SaveChanges();
                    string[] tags = item.Tags.Split(',');
                    foreach (var tagItem in tags)
                    {
                        var inBase = context.Tag.Where(t => t.Value == tagItem).FirstOrDefault();
                        if (inBase == null)
                        {
                            TagEntity tag = new TagEntity { Value = tagItem };
                            tag.Venues = new List<VenueEntity>();
                            tag.Venues.Add(venue);
                            context.Tag.Add(tag);
                        }
                        else
                        {
                            inBase.Venues.Add(venue);
                        }
                        context.SaveChanges();
                    }
                }
            }
        }
        public void SeedVenueUser(DataContext context)
        {
            string path = @"C:\Users\dido_\Documents\GitHub\SofiaPocketGuide\SPG.DataAccess\DataSets\user-venue-dataset.txt";
            if (!context.User.Any())
            {
                var results = from str in File.ReadAllLines(path)
                              where !String.IsNullOrEmpty(str)
                              let data = str.Split(new string[] { ".." }, StringSplitOptions.RemoveEmptyEntries)
                              where data.Length == 2 && !String.IsNullOrEmpty(data[0]) && !String.IsNullOrEmpty(data[1])
                              select new UserVenueDSM
                              {
                                  UserId = int.Parse(data[0]),
                                  VenueId = int.Parse(data[1])
                              };
                foreach (UserVenueDSM item in results)
                {
                    UserEntity user = context.User.Where(u => u.UserId == item.UserId).FirstOrDefault();
                    VenueEntity venue = context.Venue.Where(v => v.VenueCode == item.VenueId).FirstOrDefault();
                    if (user == null && venue == null)
                    {
                        user = new UserEntity() { UserId = item.UserId, Venues = new List<VenueEntity>() };
                        venue = new VenueEntity() { VenueCode = item.VenueId };
                        user.Venues.Add(venue);
                        context.User.Add(user);
                        context.Venue.Add(venue);
                        context.SaveChanges();
                    }
                    else if (user != null && venue == null)
                    {
                        venue = new VenueEntity() { VenueCode = item.VenueId };
                        if (venue.Users == null)
                            venue.Users = new List<UserEntity>();
                        venue.Users.Add(user);
                        context.Venue.Add(venue);
                        context.SaveChanges();
                    }
                    else if (user == null && venue != null)
                    {
                        user = new UserEntity() { UserId = item.UserId, Venues = new List<VenueEntity>() };
                        if (user.Venues == null)
                            user.Venues = new List<VenueEntity>();
                        user.Venues.Add(venue);
                        context.User.Add(user);
                        context.SaveChanges();
                    }
                    else
                    {
                        if (user.Venues == null)
                            user.Venues = new List<VenueEntity>();
                        user.Venues.Add(venue);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
