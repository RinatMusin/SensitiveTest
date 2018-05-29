using SensitiveTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.ViewModels
{
    public class UserAnswerListViewModel
    {
        /// <summary>
        /// Список ответов пользователя.
        /// </summary>
        public List<UserAnswerViewModel> Items = new List<UserAnswerViewModel>();
    }
}