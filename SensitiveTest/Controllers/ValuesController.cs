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
                Random random = new Random();

                // Определить идентификатор запроса данных, для дальнейшей проверки. Используется Hash.
                string queryHash = HashService.GetHashValue(sensitiveService.GetRandomSensitiveIndex().ToString());
                vm.QueryHash = queryHash;
                foreach (var s in sensitives)
                {
                    var answer = new Models.SensitiveAnswer
                        {
                            Value = random.Next(10, 99),
                            QueryHash = queryHash
                        };
                    s.AddAnswer(answer);

                    vm.Items.Add(new SensitiveAnswerViewModel
                    {
                        Name = s.Name,
                        Photo = s.Photo,
                        Value = answer.Value,
                    });
                }
            }
            return vm;
        }

        /// <summary>
        /// Ввод данных пользователя.
        /// </summary>
        /// <param name="value"></param>
        public AnswerResultViewModel Post([FromBody]ValueResultFormModel form)
        {
            var vm = new AnswerResultViewModel();

            UserService userService = new UserService();

            var cookie = Request.Headers.GetCookies("UserHash").FirstOrDefault();
            string userHash = cookie != null ? cookie["UserHash"].Value : HashService.GetHashValue(userService.GetUserID().ToString());

            // Попытка преобразовать в число.
            int res = 0;
            Int32.TryParse(form.Value, out res);

            // Проверка на диапазон от 10 до 99.
            if (res >= 10 && res <= 99)
            {
                var userAnswer = new Models.UserAnswer
                {
                    Value = res,
                    UserHash = userHash
                };

                SensitiveService sensitiveService = new SensitiveService();

                // Идет проверка по экстрасенсам.
                var sensitives = sensitiveService.GetSensitives();
                foreach (var s in sensitives)
                {
                    var answer = s.AnswerItems.Where(a => a.QueryHash == form.QueryHash).FirstOrDefault();
                    if (answer != null)
                    {
                        if (answer.Value == res)
                        {
                            answer.Result = true;
                            s.Reliability++;
                            userAnswer.Result = true;
                            if (!string.IsNullOrEmpty(userAnswer.Description))
                                userAnswer.Description += ", ";
                            userAnswer.Description += s.Name;
                        }
                        else
                            s.Reliability--;
                    }
                }
                userService.AddUserAnswer(userAnswer);
            }
            else
            {
                vm.ErrorMessage = "Введите правильное число!";
            }
            vm.UserHash = userHash;

            return vm;
        }
    }
}