using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.Models
{
    /// <summary>
    /// Экстрасенс.
    /// </summary>
    public class Sensitive
    {
        /// <summary>
        /// Имя экстрасенса.
        /// </summary>
        public string Name;

        /// <summary>
        /// Достоверность.
        /// </summary>
        public int Reliability;

        /// <summary>
        /// Фотография эктрасенса.
        /// </summary>
        public string Photo;

        /// <summary>
        /// Количество правильных ответов.
        /// </summary>
        public int SuccessCount;

        /// <summary>
        /// Количество ошибочных ответов.
        /// </summary>
        public int ErrorCount;

        public int AnswerCount { get { return AnswerItems.Count; } }

        public List<SensitiveAnswer> AnswerItems = new List<SensitiveAnswer>();
        internal void AddAnswer(SensitiveAnswer answer)
        {
            AnswerItems.Add(answer);
            //TODO сохранить
        }
    }
}