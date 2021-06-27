using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {

        //List<Message> GetReadList();
        
        //List<Message> GetListInbox();
        //List<Message> GetListSendbox();
        //List<Message> GetListDraft();
        //List<Message> GetListTrash();

        List<Message> GetMessageListInbox(string p);
        List<Message> GetMessageListSentbox(string p);

        void MessageAdd(Message message);
        Message GetByID(int id);

        List<Message> GetUnreadList();

        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
