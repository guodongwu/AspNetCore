using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LearnCore.Core.Entities
{
    public class User:Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
