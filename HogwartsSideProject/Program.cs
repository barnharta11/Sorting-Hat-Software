using HogwartsSideProject.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing.Text;

namespace HogwartsSideProject
{
    public class Program
    {
        
        private static readonly string API_URL = "http://hp-api.herokuapp.com/api/characters";
        


        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("connection.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("HarryPotter");
            IStudentDAO studentDAO = new StudentSqlDAO(connectionString);

            string filePath = @"C:\Users\Student\Desktop\HogwartsSideProject\hogwartshouses.txt";
            string filePath2 = @"C:\Users\Student\Desktop\HogwartsSideProject\hogwarts.txt";
            HogwartsLoader hogwartsLoader = new HogwartsLoader(filePath);
            HogwartsMethods hogwarts = new HogwartsMethods(hogwartsLoader.HouseList, filePath, filePath2);
            ICharactersDAO charactersApiDAO = new CharactersApiDAO(API_URL);
            MainMenu menu = new MainMenu(hogwarts, charactersApiDAO, studentDAO);
            menu.Show();
        }
    }
}

