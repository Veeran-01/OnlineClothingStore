using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class LoginViewModel
    {
        [Required (ErrorMessage ="You must enter a Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must enter a Password")]
        [StringLength(50, MinimumLength =6)]
        public string Password { get; set; }
    }
}