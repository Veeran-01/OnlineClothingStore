using OnlineShoppingStore.Abstract;
using OnlineShoppingStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Concrete
{
        public class FormsAuthenticationProvider : IAuthentication
    {
        private readonly OnlineShoppingStoreDBEntities3 context = new OnlineShoppingStoreDBEntities3();
        public bool Authenticate(string username, string password)
        {
            var result = context.Users.FirstOrDefault(u =>u.Username == username &&
                u.Password == password);

            if (result == null)
                return false;
            return true;


        }

        public bool Logout()
        {
            return true;
        }
    }
}