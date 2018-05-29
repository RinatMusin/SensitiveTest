using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.ViewModels
{
    /// <summary>
    /// Данные по истории ответов экстасенсов.
    /// </summary>
    public class SensitiveViewModel
    {
        /// <summary>
        /// Ответы экстрасенса.
        /// </summary>
        public List<Models.SensitiveAnswer> Answers { get; set; }

        /// <summary>
        /// Идентификатор экстрасенса.
        /// </summary>
        public string Hash { get; set; }
    }
}