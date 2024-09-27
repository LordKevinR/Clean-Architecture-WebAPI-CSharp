using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAdapters.Presenters
{
    public class PetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string FullData { get; set; }
    }
}
