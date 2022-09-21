using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace assd
{
    public class regformitem
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
       
        public subject Subject { get; set; }
        public int RegFormId { get; set; }
        public regform RegForm { get; set; }
    }
}

