using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KurthProject2Vet.Models
{
    public class Project2EntityFrameworkCoreDbContext : DbContext, IProject2Repository
    {
        public Project2EntityFrameworkCoreDbContext(DbContextOptions<Project2EntityFrameworkCoreDbContext> options)
            :base(options) { }

        //trying to get the _context to populate
        private Project2EntityFrameworkCoreDbContext _context;

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
             return Owners.ToList();
           
        }

        

        public List<Pet> GetAllPets()
        {
            return Pets.ToList();
        }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining the composite key in the join entity
            modelBuilder.Entity<PetService>().HasKey(petService => new {petService.PetId, petService.ServiceId});

            // Specify the foreign keys in the join entity
            modelBuilder.Entity<PetService>()
                .HasOne(p => p.Pet)
                .WithMany(ps => ps.PetServices)
                .HasForeignKey(p => p.PetId);

            modelBuilder.Entity<PetService>()
                .HasOne(e => e.Service)
                .WithMany(s => s.PetServices)
                .HasForeignKey(e => e.ServiceId);
        }

        public List<PetService> GetAllPetServices()
        {
            //return PetServices.ToList();
            return Pets.Include(p => p.PetServices)
                            .ThenInclude(ps => ps.Pet)
                            .ToList();
        }


        DbSet<Owner> Owners { get; set; }
        DbSet<Pet> Pets { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<PetService> PetServices { get; set; }
        public object Owner { get; private set; }
    }

}
