using SPG.DataAccess.Entities;
using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public MessageRepository(DataContext context)
        {
            this.Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(MessageEntity entity)
        {
            Context.Message.Add(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public MessageEntity Get(int id)
        {
            return Context.Message.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<MessageEntity> GetAll()
        {
            return Context.Message;
        }

        public void Remove(MessageEntity entiity)
        {
            Context.Message.Remove(entiity);
        }

        public void Update(MessageEntity entity)
        {
            MessageEntity message = Get(entity.Id);
            message.Message = entity.Message;
            Context.SaveChanges();           
        }
    }
}
