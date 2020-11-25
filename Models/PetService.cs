using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KurthProject2Vet.Models
{
    public class PetService
    {
        //. (PetId,	ServiceId)	toget  are	the	composite	primary	key
        [Required]
        //PetId	is	also	a	foreign	key	relating	to	the	Pet	model
        public int PetId { get; set; }
        [Required]
        //ServiceId	is	a	foreign	key	relating	to	the	Service	model
        public int ServiceId { get; set; }
        [Required]
        public DateTime DateRendered { get; set; }
        [Required]
        //. Pet	is	the	navigation	property	to	access	the	Pet	object	from	the	
        //PetService object
        public Pet Pet { get; set; }
        [Required]
        //Service	is	the	navigation	property	to	access	the	Service	object	from	
        //the PetService  object
        public Service Service  { get; set; }
    }
}
