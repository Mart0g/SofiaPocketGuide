using SPG.DataAccess;
using SPG.Domain.Models.DataSetModels;
using SPG.Domain.Models.Entities;
using SPG.Domain.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Word2Vec.Net;

namespace SPG.Console
{
    public class DataContextInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        public ConfigurationObject Configuration { get; set; }

        public DataContextInitializer(ConfigurationObject configuration ): base()
        {
            Configuration = configuration;
        }

        public override void InitializeDatabase(DataContext context)
        {
            base.InitializeDatabase(context);
            System.Console.WriteLine("Data base initialized!");
            SeedVenueTag(context);
            System.Console.WriteLine("Venue-Tag connection seeded in DB!");
            SeedVenueUser(context);
            System.Console.WriteLine("Venue-User connection seeded in DB!");
            SeedPrefixes(context);
            System.Console.WriteLine("Prefixes seeded in DB!");
            SeedSuffixes(context);
            System.Console.WriteLine("Suffixes seeded in DB!");
            GenerateSourceFile();
            System.Console.WriteLine("Source file for Word2Vec generated!");
            CreateWord2VecModel();
            System.Console.WriteLine("Word2Vec model created!");
        }
        public void SeedVenueTag(DataContext context)
        {
            string path = Configuration.TagVenueFile;
            if (!context.Tag.Any())
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
                    string[] tags = item.Tags.Split(',', '\t');
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
            string path = Configuration.UserVenueFile;
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
            string trainFile = Configuration.TrainFile;
            string outputFile = Configuration.OutputFile;
            string vocubFile = Configuration.VocabularyFile;

            if (!File.Exists(outputFile) && !File.Exists(vocubFile) && File.Exists(trainFile))
            {
                var word2Vec = Word2VecBuilder.Create()
                .WithTrainFile(trainFile)
                .WithOutputFile(outputFile)
                .WithSize(200)
                .WithSaveVocubFile(vocubFile)
                .Build();

                word2Vec.TrainModel();
            }
        }

        public void GenerateSourceFile()
        {

            string tagsPath = Configuration.TagVenueFile;
            string tipsPath = Configuration.TipVenueFile;
            string targetPath = Configuration.TrainFile;

            if (!File.Exists(targetPath) && File.Exists(tagsPath) && File.Exists(tipsPath))
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
                               Tip = data[2].Replace("\t", " ")
                           };
                List<string> lines = new List<string>();
                foreach (TipVenueDSM tip in tips)
                {
                    string line = tags.Where(t => t.VenueId == tip.VenueId).FirstOrDefault().Tags + "  " + tip.Tip;
                    lines.Add(line);
                }
                File.WriteAllLines(targetPath, lines.ToArray());
            }
        }

        public void SeedPrefixes(DataContext context)
        {
            string path = Configuration.PrefixFile;
            if (!context.Prefix.Any() && File.Exists(path))
            {
                var results = from str in File.ReadAllLines(path)
                              where !String.IsNullOrEmpty(str)
                              select str;

                foreach (string item in results)
                {
                    PrefixEntity prefix = new PrefixEntity { Value = item };
                    context.Prefix.Add(prefix);
                    context.SaveChanges();
                }
            }
        }

        public void SeedSuffixes(DataContext context)
        {
            string path = Configuration.SuffixFile;
            if (!context.Suffix.Any() && File.Exists(path))
            {
                var results = from str in File.ReadAllLines(path)
                              where !String.IsNullOrEmpty(str)
                              select str;

                foreach (string item in results)
                {
                    SuffixEntity suffix = new SuffixEntity { Value = item };
                    context.Suffix.Add(suffix);
                    context.SaveChanges();
                }
            }
        }
    }
}
