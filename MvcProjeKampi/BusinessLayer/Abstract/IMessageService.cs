﻿using EntittyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        int MessageCount();
        List<Message> GetListInbox(string p);
        List<Message> GetInbox(string aranacak);
        List<Message> GetListSendbox(string p);
        void MessageAdd(Message message);
        Message GetByID(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
