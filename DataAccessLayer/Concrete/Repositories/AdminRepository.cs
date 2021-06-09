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

    public class AdminRepository : IAdminDal
    {

        Context c = new Context();
        DbSet<Admin>_object;
        public void Delete(Admin p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public Admin Get(Expression<Func<Admin, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Admin GetbyAdminUsername(Expression<Func<Admin, bool>> filter)
        {
            return _object.FirstOrDefault(filter);
        }

        public void Insert(Admin p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Admin> List()
        {
            return _object.ToList();
        }

        

        public List<Admin> List(Expression<Func<Admin, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Admin p)
        {
            c.SaveChanges();
        }
    }
}
