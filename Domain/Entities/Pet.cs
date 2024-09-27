using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int Age { get; set; }
    }
}
