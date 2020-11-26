using KurthProject2Vet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurthProject2Vet.Database


{
    public class Project2DatabaseContext : IProject2Repository
    {
        private string _connectionString;
        public Project2DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public MySqlConnection GetConnection()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(_connectionString);
            return mySqlConnection;
        }
        public List<Owner> GetAllOwners()
        {
            List<Owner> owners = new List<Owner>();

            MySqlConnection connection;
            MySqlCommand sqlCommand;
            MySqlDataReader dataReader;
            connection = GetConnection();
            connection.Open();

            sqlCommand = new MySqlCommand();
            sqlCommand.CommandText = "SELECT * FROM OWNER";
            sqlCommand.Connection = connection;

            dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                Owner owner = new Owner();

                owner.OwnerId = dataReader.GetInt32("OwnerId");
                owner.FirstName = dataReader.GetString("FirstName");
                owner.LastName = dataReader.GetString("LastName");
              //  owner.Pets = dataReader.GetString("Pets");
                owner.PhoneNumber = dataReader.GetInt32("PhoneNumber");

                owners.Add(owner);
            }
            dataReader.Close();
            connection.Close();
            return owners;
        }

        public void AddOwner(Owner owner)
        {

            MySqlConnection connection;
            MySqlCommand sqlCommand;

            connection = GetConnection();
            connection.Open();

            sqlCommand = new MySqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO STORE VALUES (NULL, @FirstName, @LastName, @PhoneNumber @Pets )";
            sqlCommand.Parameters.AddWithValue("@FirstName", owner.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", owner.LastName);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", owner.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@Pets", owner.Pets);
            
            sqlCommand.ExecuteNonQuery();

            connection.Close();
            throw new NotImplementedException();
        }

        public void AddPet(Pet pet)
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
