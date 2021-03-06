﻿using SPG.Domain.Interfaces.Repositories;
using SPG.Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SPG.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(UserEntity entity)
        {
            Context.User.Add(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public UserEntity Get(int id)
        {
            return Context.User.Where(u => u.UserId == id).FirstOrDefault();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return Context.User;
        }

        public void Remove(UserEntity entity)
        {
            Context.User.Remove(entity);
        }

        public void Update(UserEntity entity)
        {
            UserEntity user = Get(entity.Id);
            user.UserName = entity.UserName;
            Context.SaveChanges();
        }
    }
}
