using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionNetCore.Models
{
    public static class UtilSession
    {
        /*  Você também pode armazenar objetos, basta apenas fazer uma adição de um método na classe HttpContext.Session 
         *  (ou ISession que implementa o método) e assim podemos serializar objetos em strings JSON para conseguir isso:
         * */
         
        public static void SetObject<T>(this ISession session , string key , T value)
        {
            session.SetString(key , JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session , string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }
}
