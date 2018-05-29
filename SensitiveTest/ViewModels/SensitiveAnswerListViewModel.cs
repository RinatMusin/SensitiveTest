using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.ViewModels
{
    /// <summary>
    /// Список ответов экстрасенсов.
    /// </summary>
    public class SensitiveAnswerListViewModel
    {
        /// <summary>
        /// Список ответов экстрасенса.
        /// </summary>
        public List<SensitiveAnswerViewModel> Items = new List<SensitiveAnswerViewModel>();

        /// <summary>
        /// Идентификатор теста.
        /// </summary>
        public string QueryHash { get; set; }
    }
}