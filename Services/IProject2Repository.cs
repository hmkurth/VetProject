using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace KurthProject2Vet.Models
{
    public interface IProject2Repository

    {
        void AddOwner(Owner owner);
        void AddPet(Pet pet);
        List<Owner> GetAllOwnersAsync();
        List<Pet> GetAllPets();
        List<Pet> GetAllPetServices();
        // MySqlConnection GetConnection();
    }
}