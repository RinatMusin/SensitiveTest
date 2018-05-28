using SensitiveTest.FormModels;
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

    public class ValuesController : ApiController
    {
        /// <summary>
        /// Получить варианты ответа экстрасенсов.
        /// </summary>
        /// <returns></returns>
        public SensitiveAnswerListViewModel Get()
        {
            var vm = new SensitiveAnswerListViewModel();
            SensitiveService sensitiveService = new SensitiveService();

            // Получить список случайных экстрасенсов.
            var sensitives = sensitiveService.GetRandomSensitives();

            // Задать ответы экстрасенсов.
            if (sensitives != null)
            {
                // Определить идентификатор запроса данных, для дальнейшей проверки. Используется Hash.
                string queryHash = HashService.GetHashValue(sensitiveService.GetRandomSensitiveIndex().ToString());
                vm.QueryHash = queryHash;
                foreach (var s in sensitives)
                {
                    var answer = new Models.SensitiveAnswer
                        {
                            Value = 34,
                            QueryHash = queryHash
                        };
                    s.AddAnswer(answer);
                    vm.Items.Add(new SensitiveAnswerViewModel
                    {
                        Name = s.Name,
                        Photo = s.Photo,
                        Value = answer.Value,
                        //    QueryHash = queryHash
                    });
                }
            }
            return vm;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Ввод данных пользователя.
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]ValueResultFormModel form)
        {
            // Попытка преобразовать в число.
            int res = 0;
            Int32.TryParse(form.Value, out res);

            // Проверка на диапазон от 10 до 99.
            if (res >= 10 && res <= 99)
            {
                SensitiveService sensitiveService = new SensitiveService();

                // Идет проверка по экстрасенсам.
                var sensitives = sensitiveService.GetSensitives();//.Where(s => s.AnswerItems.Where(a => a.QueryHash == form.QueryHash).ToList().Count > 0).ToList();
                foreach (var s in sensitives)
                {
                    var answer = s.AnswerItems.Where(a => a.QueryHash == form.QueryHash).FirstOrDefault();
                    if (answer != null)
                    {
                        if (answer.Value == res)
                        {
                            answer.Result = true;
                            s.Reliability++;
                        }
                        else
                            s.Reliability--;


                    }
                }
            }
        }



    }
}