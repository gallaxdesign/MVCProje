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

    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }


        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }





        //GenericRepository<Category> repo = new GenericRepository<Category>();

        //public List<Category> GetAllBL()
        //{
        //    return repo.List();
        //}
        //public void CategoryAddBL(Category p)
        //{
        //    if(p.CategoryName=="" && p.CategoryName.Length>3 && p.CategoryDescription!="")
        //    {
        //        //hata mesajı
        //    }
        //    else
        //    {
        //        repo.Insert(p);
        //    }
        //}
        public List<Writer> GetWriterList()
        {
            return _writerDal.List();
        }
    }
}
