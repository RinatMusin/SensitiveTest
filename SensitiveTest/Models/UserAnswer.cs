using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.Models
{
    public class UserAnswer
    {
        /// <summary>
        /// Значение ответа.
        /// </summary>
        public int Value;
        
        /// <summary>
        /// Результат - угадал, нет
        /// </summary>
        public bool Result;

        /// <summary>
        /// Описание результата.
        /// </summary>
        public string Description;

        /// <summary>
        /// Идентификатор теста.
        /// </summary>
        public string QueryHash;

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public string UserHash;
    }
}