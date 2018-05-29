using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensitiveTest.ViewModels
{
    public class SensitiveViewModel
    {
        public List<Models.SensitiveAnswer> Answers { get; set; }

        public string Hash { get; set; }
    }
}