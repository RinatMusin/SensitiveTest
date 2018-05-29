using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.ViewModels
{
    public class AnswerResultViewModel
    {
        /// <summary>
        /// Сообщение ошибке.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public string UserHash { get; set; }
    }
}