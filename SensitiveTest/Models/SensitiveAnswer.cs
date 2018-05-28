using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.Models
{
    /// <summary>
    /// Ответ экстрасенса.
    /// </summary>
    public class SensitiveAnswer
    {
        /// <summary>
        /// Угаданное значение.
        /// </summary>
        public int Value;

        /// <summary>
        /// Результат угадывания: true - верно.
        /// </summary>
        public bool Result;

       
        public string QueryHash;


    }
}