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

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetAllRead()
        {
            return _messageDal.List(m => m.RecevierMail == "admin@gail.com").Where(m => m.isRead == false).ToList();
        }

        public Message GetById(int Id)
        {
            return _messageDal.Get(m => m.MessageID == Id);
        }

        public List<Message> GetMessageSendBox(string sender)
        {
            return _messageDal.List(m => m.SenderMail == sender);
        }

        public List<Message> GetMessageSendBox()
        {
            return _messageDal.List(m => m.SenderMail == "admin@gmail.com");
        }

        public List<Message> GetMessagesInbox()
        {
            return _messageDal.List(m => m.RecevierMail == "admin@gmail.com");
        }

        public List<Message> GetMessagesInbox(string receiver)
        {
            return _messageDal.List(m => m.RecevierMail == receiver);
        }

        public void Insert(Message message)
        {
            _messageDal.Insert(message);
        }

        public List<Message> IsDraft()
        {
            return _messageDal.List(m => m.isDraft == true);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
