﻿using MySql.Data.MySqlClient;
using System;

namespace UltimateCalendarClassLibrary
{
    class GetUserFromDB : DBQuery
    {
        private User user;

        private string passwordInput;
        private string emailInput;

        public GetUserFromDB(string connectionString):base(connectionString)
        {
        }

        public User GetUser(string password, string email)
        {
            user = new User();
            passwordInput = password;
            emailInput = email;
            Execute();
            return user;
        }

        public override void ExecuteCommand()
        {
            command.CommandText = "SELECT * FROM users WHERE Email = @Email AND Password = @Password LIMIT 1;";
            command.Parameters.AddWithValue("@Email", emailInput);
            command.Parameters.AddWithValue("@Password", passwordInput);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    user.UserID = (int)reader["ID"];
                    user.Name = (string)reader["FirstName"];
                    user.Surname = (string)reader["LastName"];
                    user.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    user.Password = (string)reader["Password"];
                    user.Email = (string)reader["Email"];
                }
            }
        }
    }
}
