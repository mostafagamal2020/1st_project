﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assd
{
    public class subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<regformitem> Items { get; set; }
    }
}
