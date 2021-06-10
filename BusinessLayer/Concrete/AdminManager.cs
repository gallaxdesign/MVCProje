using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{

    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }


        public void AdminAdd(Admin writer)
        {
            _adminDal.Insert(writer);
        }

       
        public void AdminDelete(Admin writer)
        {
            _adminDal.Delete(writer);
        }

        public void AdminUpdate(Admin writer)
        {
            _adminDal.Update(writer);
        }

        public Admin GetByID(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetAdminList()
        {
            return _adminDal.List();
        }

        public Admin GetbyAdminUsername(Admin admin)
        {
            return _adminDal.Get(x => x.AdminUsername == admin.AdminUsername && x.AdminPassword == admin.AdminPassword);
        }
    }
}
