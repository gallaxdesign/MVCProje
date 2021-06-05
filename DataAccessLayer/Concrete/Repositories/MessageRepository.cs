using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{

    public class MessageRepository : IMessageDal
    {

        Context c = new Context();
        DbSet<Message>_object;
        public void Delete(Message p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public Message Get(Expression<Func<Message, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Message p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Message> List()
        {
            return _object.ToList();
        }

        public List<Message> List(Expression<Func<Message, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Message p)
        {
            c.SaveChanges();
        }
    }
}
