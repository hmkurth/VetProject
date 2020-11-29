using KurthProject2Vet.Models;
using System;
using System.Collections.Generic;
//using System.Collections.Generic.IEnumerable;
using System.Linq;
using System.Threading.Tasks;

namespace KurthProject2Vet.ViewModels
{
    public class VetViewModel
    {
        public List<Owner> Owners { get; set; }
        public List<Pet> Pets { get; set; }
        public List<Service> Services { get; set; }
        public List<PetService> PetServices { get; set; }


    }
}
