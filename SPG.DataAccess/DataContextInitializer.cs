using SPG.DataAccess.Entities;
using SPG.DataViewModels.DataSetModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word2Vec.Net;

namespace SPG.DataAccess
{
    public class DataContextInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        public override void InitializeDatabase(DataContext context)
        {
            base.InitializeDatabase(context);
            SeedVenueTag(context);
            SeedVenueUser(context);
            CreateWord2VecModel();
            GenerateSourceFile();
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
        public void CreateWord2VecModel()
        {
            string trainFile = @"C:\Users\dido_\Documents\GitHub\SofiaPocketGuide\SPG.DataAccess\Word2VecFiles\source-word-2-vec-file.txt";
            string outputFile = @"C:\Users\dido_\Documents\GitHub\SofiaPocketGuide\SPG.DataAccess\Word2VecFiles\vector.txt";
            if (!File.Exists(outputFile) && File.Exists(trainFile))
            {
                var word2Vec = Word2VecBuilder.Create()
                .WithTrainFile(trainFile)// Use text data to train the model;
                .WithOutputFile(outputFile)//Use to save the resulting word vectors / word clusters
                .WithSize(200)//Set size of word vectors; default is 100
                .Build();

                word2Vec.TrainModel();
            }
        }
        public void GenerateSourceFile()
        {

            string tagsPath = @"C:\Users\dido_\Documents\GitHub\SofiaPocketGuide\SPG.DataAccess\DataSets\tag-venue-dataset.txt";
            string tipsPath = @"C:\Users\dido_\Documents\GitHub\SofiaPocketGuide\SPG.DataAccess\DataSets\tip-venue-dataset.txt";
            string targetPath = @"C:\Users\dido_\Documents\GitHub\SofiaPocketGuide\SPG.DataAccess\Word2VecFiles\source-word-2-vec-file.txt";

            if (!File.Exists(targetPath)&& File.Exists(tagsPath)&& File.Exists(tipsPath))
            {
                var tags = from str in File.ReadAllLines(tagsPath)
                           where !String.IsNullOrEmpty(str)
                           let data = str.Split(new string[] { ".." }, StringSplitOptions.RemoveEmptyEntries)
                           where data.Length == 2 && !String.IsNullOrEmpty(data[0]) && !String.IsNullOrEmpty(data[1])
                           select new TagVenueDSM
                           {
                               VenueId = int.Parse(data[0]),
                               Tags = data[1]
                           };
                var tips = from str in File.ReadAllLines(tipsPath)
                           where !String.IsNullOrEmpty(str)
                           let data = str.Split(new string[] { ".." }, StringSplitOptions.RemoveEmptyEntries)
                           where data.Length == 3 && !String.IsNullOrEmpty(data[0]) && !String.IsNullOrEmpty(data[1]) && !String.IsNullOrEmpty(data[2])
                           select new TipVenueDSM
                           {
                               UserId = int.Parse(data[0]),
                               VenueId = int.Parse(data[1]),
                               Tip = data[2]
                           };
                List<string> lines = new List<string>();
                foreach (TipVenueDSM tip in tips)
                {
                    string line = tags.Where(t => t.VenueId == tip.VenueId).FirstOrDefault()?.Tags + "  " + tip.Tip;
                    lines.Add(line);
                }
                File.WriteAllLines(targetPath, lines.ToArray());
            }
        }
    }
}
