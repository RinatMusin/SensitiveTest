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
        /// <summary>
        /// Получить список экстрасенсов.
        /// </summary>
        /// <returns></returns>
        public SensitiveListViewModel Get()
        {
            var vm = new SensitiveListViewModel();
            SensitiveService sensitiveService = new SensitiveService();
            vm.Items = sensitiveService.GetSensitives();
            return vm;
        }
    }
}
