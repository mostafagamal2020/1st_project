using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace assd
{
    public class student
    {
        
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
      
        public string Password { get; set; }

        public int? RegFormId { get; set; }
        [ForeignKey("RegFormId")]
        public regform? RegForm { get; set; } }
        public class StudentLogin
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class StudentRegister
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    public class uprage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

    }

