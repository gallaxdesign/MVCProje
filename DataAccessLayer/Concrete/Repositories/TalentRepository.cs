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

    public class TalentRepository : ITalentDal
    {

        Context c = new Context();
        DbSet<Talent>_object;
        public void Delete(Talent p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public Talent Get(Expression<Func<Talent, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Talent p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Talent> List()
        {
            return _object.ToList();
        }

        public List<Talent> List(Expression<Func<Talent, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Talent p)
        {
            c.SaveChanges();
        }
    }
}
