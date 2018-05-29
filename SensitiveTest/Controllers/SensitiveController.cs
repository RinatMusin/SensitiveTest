using SensitiveTest.Services;
using SensitiveTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SensitiveTest.Controllers
{
    public class SensitiveController : ApiController
    {
        SensitiveService sensitiveService = new SensitiveService();

        /// <summary>
        /// Получить список экстрасенсов.
        /// </summary>
        /// <returns></returns>
        public SensitiveListViewModel Get()
        {
            var vm = new SensitiveListViewModel();
            vm.Items = sensitiveService.GetSensitives();
            return vm;
        }

        /// <summary>
        /// Данные по экстрасенсу - история догадок.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SensitiveViewModel Get(string id)
        {
            var vm = new SensitiveViewModel
            {
                Hash = id
            };

            var sensitive = sensitiveService.GetSensitive(id);
            if (sensitive != null)
                vm.Answers = sensitive.AnswerItems;

            return vm;
        }

        /// <summary>
        /// Идентификатор экстрасенса.
        /// </summary>
        public string Hash { get; set; }
    }
}
