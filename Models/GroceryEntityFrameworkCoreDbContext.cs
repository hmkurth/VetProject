﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryList.Database;
using Microsoft.EntityFrameworkCore;

namespace KurthGroceryList.Models
{
    public class GroceryEntityFrameworkCoreDbContext : DbContext, IGroceryRepository
    {
        public GroceryEntityFrameworkCoreDbContext(DbContextOptions<GroceryEntityFrameworkCoreDbContext> options)
            :base(options) { }
        DbSet<GroceryItem> GroceryItems { get; set; }
        DbSet<Store> Stores { get; set; }

        public void AddGroceryItem(GroceryItem groceryItem)
        {
            GroceryItems.Add(groceryItem);
            SaveChanges();
           
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

        public List<Store> GetAllStores()
        {
            return Stores.ToList();
            throw new NotImplementedException();
        }
    }
}
