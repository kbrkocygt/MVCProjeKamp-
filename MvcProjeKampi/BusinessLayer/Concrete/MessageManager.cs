using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntittyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
       
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID==id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.RecevierMail == p); //alıcısı admin olanlar 
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p); //gönderen kişi admin olanlar
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public int MessageCount()
        {
          return  _messageDal.List().Count();
        }
        public int GetCountUnreadMessage(string p)
        {
            return _messageDal.List(x => !x.isRead && x.RecevierMail == p).Count;
        }
        public int GetCountUnreadSenderMessage(string p)
        {
            return _messageDal.List(x => !x.isRead && x.SenderMail == p).Count;
        }
        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetInbox(string aranacak)
        {
            return _messageDal.List(x => x.MessageContent.Contains(aranacak));
        }
    }
}
