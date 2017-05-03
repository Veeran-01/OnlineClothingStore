using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "veeran-01@hotmail.co.uk";
        public string MailFromAddress = "projectthreejustit@gmail.com";
        public bool UseSsl = true;
        public string Username = "projectthreejustit@gmail.com";
        public string Password = "Password100";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
}