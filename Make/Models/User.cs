﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Make.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Mensagem> Mensagems { get; set; }
    }
}