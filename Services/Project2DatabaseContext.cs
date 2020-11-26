using KurthProject2Vet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurthProject2Vet.Database


{
    public class Project2DatabaseContext : IProject2DatabaseContext
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
                owner.Pets = new Pet();
                owner.PhoneNumber = dataReader.GetInt32("PhoneNumber");

                owners.Add(owner);
            }
            dataReader.Close();
            connection.Close();
            return owners;
        }

    }
}
