﻿using System;
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
        public IEnumerable<int> Get()
        {
            return new int[] { 10,20 };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}