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

        public void AddGroceryItem(GroceryItem groceryItem)
        {
            GroceryItems.Add(groceryItem);
            SaveChanges();
           
        }

        public void AddOwner(Owner owner)
        {
            throw new NotImplementedException();
        }

        public void AddPet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void AddStore(Store store)
        {
            Stores.Add(store);
            SaveChanges();
            
        }

        public List<GroceryItem> GetAllGroceryItems()
        {
            return GroceryItems
                .Include(groceryItem => groceryItem.Store)
                .ToList();
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

        public List<Store> GetAllStores()
        {
            return Stores.ToList();
            throw new NotImplementedException();
        }
    }
}
