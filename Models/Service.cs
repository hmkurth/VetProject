using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KurthProject2Vet.Models
{
    public class Service
    {
        [Required]
        //navigation property
        public IEnumerable<PetService> PetServices { get; set; }

        [Required]
        public int ServiceId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int AverageLengthOfService { get; set; }



    }

}
