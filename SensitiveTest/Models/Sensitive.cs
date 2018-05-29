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
        /// Количество ответов экстрасенса
        /// </summary>
        public int AnswerCount { get { return AnswerItems.Count; } }

        /// <summary>
        /// Список ответов.
        /// </summary>
        public List<SensitiveAnswer> AnswerItems = new List<SensitiveAnswer>();

        /// <summary>
        /// Добавить ответ
        /// </summary>
        /// <param name="answer"></param>
        internal void AddAnswer(SensitiveAnswer answer)
        {
            AnswerItems.Add(answer);
        }

        /// <summary>
        /// Идентификатор экстрасенса.
        /// </summary>
        public string Hash { get; set; }
    }
}