using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KurthProject2Vet.Models
{
    public class Pet
    {   //foreign key
        [Required]
        public int OwnerId { get; set; }
        public int PetId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        // Owner	is	the	navigation	property to	access	the	Owner	object	from	the	
         // Pet object
         [Required]
        public Owner Owner { get; set; }
        [Required]
        public string Type { get; set; }
        //PetServices	is	the	navigation	property
        [Required]
        public IEnumerable<PetService> PetServices { get; set; }

    }
}
