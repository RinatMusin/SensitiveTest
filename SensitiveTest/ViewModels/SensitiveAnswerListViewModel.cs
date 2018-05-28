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
        public List<SensitiveAnswerViewModel> Items = new List<SensitiveAnswerViewModel>();

        public string QueryHash { get; set; }
    }
}