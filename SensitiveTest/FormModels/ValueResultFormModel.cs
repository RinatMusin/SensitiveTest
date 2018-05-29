using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.FormModels
{
    public class ValueResultFormModel
    {
        /// <summary>
        /// Введенное значение пользователем.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Идентификатор теста.
        /// </summary>
        public string QueryHash { get; set; }
    }
}