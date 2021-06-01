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

    public class AboutRepository : IAboutDal
    {

        Context c = new Context();
        DbSet<About>_object;
        public void Delete(About p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public About Get(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(About p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<About> List()
        {
            return _object.ToList();
        }

        public List<About> List(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(About p)
        {
            c.SaveChanges();
        }
    }
}
