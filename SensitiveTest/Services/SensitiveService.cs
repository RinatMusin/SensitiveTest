using SensitiveTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.Services
{
    public class SensitiveService
    {
        /// <summary>
        /// Заполнение начальными данными.
        /// </summary>
        /// <returns></returns>
        private List<Sensitive> GetNewSensitives()
        {
            var res = new List<Sensitive>();
            res.Add(new Sensitive
            {
                Hash = HashService.GetHashValue("1"),
                Name = "Константин Гецати",
                Reliability = 0,
                Photo = "/images/s1.jpg"
            });
            res.Add(new Sensitive
            {
                Hash = HashService.GetHashValue("2"),
                Name = "Cвами Даши",
                Reliability = 0,
                Photo = "/images/s2.jpg"
            });
            res.Add(new Sensitive
            {
                Hash = HashService.GetHashValue("3"),
                Name = "Мерилин Керро",
                Reliability = 0,
                Photo = "/images/s3.jpg"
            });
            res.Add(new Sensitive
            {
                Hash = HashService.GetHashValue("4"),
                Name = "Надежда Шевченко",
                Reliability = 0,
                Photo = "/images/s4.jpg"
            });
            return res;
        }

        /// <summary>
        /// Получить список экстрасенсов.
        /// </summary>
        /// <returns></returns>
        internal List<Sensitive> GetSensitives()
        {
            return (List<Sensitive>)HttpContext.Current.Application["Sensitives"];
        }

        /// <summary>
        /// Инициализация списка экстрасенсов.
        /// </summary>
        internal void InitData()
        {
            HttpContext.Current.Application["Sensitives"] = GetNewSensitives();
            HttpContext.Current.Application["RandomSensitiveIndex"] = 0;
        }

        /// <summary>
        /// Получить список случайных экстрасенсов.
        /// </summary>
        /// <returns></returns>
        internal List<Sensitive> GetRandomSensitives()
        {
            var sensitives = GetSensitives();
            var r = new Random();
            //return sensitives.ElementAt(r.Next(0, sensitives.Count()));
            return sensitives.OrderBy(emp => Guid.NewGuid()).Take(2).ToList();
        }

        internal int GetRandomSensitiveIndex()
        {
            int index = (int)HttpContext.Current.Application["RandomSensitiveIndex"];
            index++;
            HttpContext.Current.Application["RandomSensitiveIndex"] = index;
            return index;
        }

        internal Sensitive GetSensitive(string hash)
        {
            return GetSensitives().Where(s => s.Hash == hash).FirstOrDefault();
        }
    }
}