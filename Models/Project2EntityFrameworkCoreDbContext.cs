using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace KurthProject2Vet.Models
{
    public class Project2EntityFrameworkCoreDbContext : DbContext, IProject2Repository
    {
        public Project2EntityFrameworkCoreDbContext(DbContextOptions<Project2EntityFrameworkCoreDbContext> options)
            :base(options) { }
        DbSet<Owner> Owners { get; set; }
        DbSet<Pet> Pets { get; set; }

        public void AddOwner(Owner owner)
        {
            Owners.Add(owner);
            SaveChanges();
           
        }

        public void AddPet(Pet pet)
        {
            Pets.Add(pet);
            SaveChanges();
            throw new NotImplementedException();
        }



        public List<Owner> GetAllOwners()
        {
            throw new NotImplementedException();
        }

        public List<Pet> GetAllPets()
        {
            throw new NotImplementedException();
        }

        public List<PetService> GetAllPetServices()
        {
            throw new NotImplementedException();
        }
    }
}
