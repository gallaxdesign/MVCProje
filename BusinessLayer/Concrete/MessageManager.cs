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

    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }


        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetMessageListInbox(string p)
        {
            return _messageDal.List(x=> x.ReceiverMail== p);
        }
        public List<Message> GetMessageListSentbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public List<Message> GetUnreadList()
        {
            return _messageDal.List(x => x.MessageUnread == true);
        }

        //public List<Message> GetReadList()
        //{
        //    return _messageDal.List(x => x.MessageRead == true);
        //}
    

        //public List<Message> GetListDraft()
        //{
        //    return _messageDal.List(x => x.MessageStatus == "Draft");
        //}

        //public List<Message> GetListTrash()
        //{
        //    return _messageDal.List(x => x.MessageStatus == "Trash");
        //}
    }
}
