using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace assd
{
    public class regform
    {
      
            public int Id { get; set; }
            public int StudentId { get; set; }
            [ForeignKey("StudentId")]
            public student Student { get; set; }

            public DateTime Date { get; set; }

            public ICollection<regformitem> Items { get; set; }

        }
    public class RegFormDTO
    {
        public int StudentID { get; set; }

        public List<int> SubjectsIds { get; set; }
    }
}

