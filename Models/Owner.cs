using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KurthProject2Vet.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        //Pets	it	the	navigation	property
        public IEnumerable<Pet> Pets { get; set; }

        internal static void Add(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
