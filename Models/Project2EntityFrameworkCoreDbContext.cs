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
            return Owners
                .Include(owner => owner.Pets)
                .ToList();
            throw new NotImplementedException();
        }

        public List<Pet> GetAllPets()
        {
                return Pets
            .Include(pet => pet.Owner)
                .ToList();
            throw new NotImplementedException();
        }

        public List<PetService> GetAllPetServices()
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining the composite key in the join entity
            modelBuilder.Entity<PetService>)()
                .HasKey(petService => new
                {
                    petService.PetId,
                    petService.ServiceId
                }

            // Specify the foreign keys in the join entity
            modelBuilder.Entity<PetService>()
                .HasOne(e => e.Section)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.SectionId);

            modelBuilder.Entity<PetService>()
                .HasOne(e => e.Student)
                .WithMany(student => student.Enrollments)
                .HasForeignKey(e => e.StudentId);
        }

       //ublic List<PetService> GetAllPetServices()
        {
            //Passes	the	Pet	objects	that	include	the	related	Services	to	the	
            // PetServices View
           // return Students.Include(student => student.Enrollments)
                                // .ThenInclude(e => e.Section)
                                 //.ToList();

     //     return PetService.Include(petService => petService.Pet)
     //         .ThenInclude(p => p.Names
      //   .ToList();
      //  throw new NotImplementedException();
      // }
    }
}
