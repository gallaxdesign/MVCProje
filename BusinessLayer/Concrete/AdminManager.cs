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


        public void AdminAdd(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public object GetbyAdminUsername(Admin p)
        {
            return _adminDal.Get(x => x.AdminUsername == p.AdminUsername && x.AdminPassword == p.AdminPassword);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin GetByID(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetAdminList()
        {
            return _adminDal.List();
        }

        Admin IAdminService.GetbyAdminUsername(Admin admin)
        {
            return _adminDal.Get(x => x.AdminUsername == admin.AdminUsername
                                      && x.AdminPassword == admin.AdminPassword);
        }

        public Admin GetByUsername(string username)
        {
            return _adminDal.Get(x => x.AdminUsername == username);
        }
    }
}
