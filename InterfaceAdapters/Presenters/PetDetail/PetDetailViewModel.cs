using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAdapters.Presenters.PetDetail
{
    public class PetDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string FullData { get; set; }
        public int Age { get; set; }
        public double RecommendedWeight { get; set; }

    }
}
