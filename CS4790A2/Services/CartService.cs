using CS4790A3.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790A3.Services
{
    public class CartService
    {
        
        public static int itemCount(Cart crt)
        {
            return crt.getSites().Count();
        }

        public static void saveCart(Cart crt, HttpContext session)
        {
            session.Session.SetString("usersCart", JsonConvert.SerializeObject(crt));
        }

        public static Cart getCart(HttpContext session)
        {
            return JsonConvert.DeserializeObject<Cart>(session.Session.GetString("usersCart"));
        }
    }
}
