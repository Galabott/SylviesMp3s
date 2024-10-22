﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylviesMp3s.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get => $"{LastName}, {FirstName}"; }

        public override string ToString() => FullName;        
    }
}
