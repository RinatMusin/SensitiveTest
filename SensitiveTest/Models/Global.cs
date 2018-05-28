using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.Models
{
    public class Global
    {
        public const string SESSION_KEY = "Global";

        /// <summary>
        /// Список экстрасенсев.
        /// </summary>
        public List<Sensitive> Sensitives;
        
        public static Global GetGlobal()
        {
            if (HttpContext.Current.Items[SESSION_KEY] == null)
            {
                var instance = new Global();
                HttpContext.Current.Items[SESSION_KEY] = instance;
            }

            return (Global)HttpContext.Current.Items[SESSION_KEY];
        }


    }
}