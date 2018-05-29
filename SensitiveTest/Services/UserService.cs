using SensitiveTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.Services
{
    public class UserService
    {
        /// <summary>
        /// Начальные данные.
        /// </summary>
        internal void InitData()
        {
            HttpContext.Current.Application["Users"] = new List<UserAnswer>();
            HttpContext.Current.Application["UserIndex"] = 0;
        }

        /// <summary>
        /// Получить список ответов пользователя.
        /// </summary>
        /// <param name="userHash"></param>
        /// <returns></returns>
        public List<UserAnswer> GetAnswers(string userHash)
        {
            var res = (List<UserAnswer>)HttpContext.Current.Application["Users"];
            return res.Where(u => u.UserHash == userHash).ToList();
        }

        /// <summary>
        /// Добавить ответ пользователя.
        /// </summary>
        /// <param name="answer"></param>
        public void AddUserAnswer(UserAnswer answer)
        {
            //List<UserAnswer> answers = GetAnswers(answer.UserHash);
            ((List<UserAnswer>)HttpContext.Current.Application["Users"]).Add(answer);
        }

        /// <summary>
        /// Получить идентификатор пользователя.
        /// </summary>
        /// <returns></returns>
        public int GetUserID()
        {
            var index = (int)HttpContext.Current.Application["UserIndex"];
            index++;
            HttpContext.Current.Application["UserIndex"] = index;
            return index;

        }

    }
}