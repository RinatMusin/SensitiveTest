using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.ViewModels
{
    /// <summary>
    /// Ответ экстрасенса.
    /// </summary>
    public class SensitiveAnswerViewModel
    {
        /// <summary>
        /// Угаданное значение.
        /// </summary>
        public int Value;      

        /// <summary>
        /// Имя экстрасенса.
        /// </summary>
        public string Name;

        /// <summary>
        /// Фотография эктрасенса.
        /// </summary>
        public string Photo;     
    }
}