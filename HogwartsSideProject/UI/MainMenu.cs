using Figgle;
using HogwartsSideProject.DAL;
using HogwartsSideProject.Models;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsSideProject
{
    public class MainMenu : ConsoleMenu

    {
        private ICharactersDAO charactersDAO;
        private HogwartsMethods hogwarts;
        private IStudentDAO studentDAO;
        public MainMenu(HogwartsMethods hogwarts, ICharactersDAO charactersDAO, IStudentDAO studentDAO)
        {
            this.hogwarts = hogwarts;
            this.charactersDAO = charactersDAO;
            this.studentDAO = studentDAO;
            AddOption("1. Get Sorted", GetSorted);
            AddOption("2. About Hogwarts", SubMenu);
            AddOption("3. Add New Student", AddStudent);
            AddOption("4. Look Up Classmates", LookUpClass);
            AddOption("Exit", Exit);

            Configure(cfg =>
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                cfg.Title = FiggleFonts.Ogre.Render("Hogwarts");
                cfg.ItemForegroundColor = ConsoleColor.Gray;
                cfg.SelectedItemForegroundColor = ConsoleColor.Blue;

            });

        }

        private MenuOptionResult AddStudent()
        {
            string studentFName = hogwarts.GetString("Provide first name for the new student:");
            string studentLName = hogwarts.GetString("Provide last name for the new student:");
            string gender = hogwarts.GetString("Provide gender (M, F, O):");
            int hogwartsHouse = GetInteger("Provide the Hogwarts' House ID for the new student ((1) Gryffindor, (2) Slytherin, (3) Ravenclaw, or (4) Hufflepuff):", null, new int[] {1,2,3,4 } );
            int teClass = GetInteger("Provide the Tech Elevator Class for the new student ((1) .NET, (2) Java, or (3) Other):", null, new int[] { 1, 2, 3});
            Student newStudent = new Student
            {
                FirstName = studentFName,
                LastName = studentLName,
                Gender = gender,
                HogwartsHouseID = hogwartsHouse,
                TEClassID = teClass

            };

            int id = studentDAO.CreateStudent(newStudent);

            if (id > 0)
            {
                Console.WriteLine("*** SUCCESS ***");
            }
            else
            {
                Console.WriteLine("*** DID NOT CREATE ***");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }
        private MenuOptionResult LookUpClass()
        {
            IList<Student> students = studentDAO.GetStudents();

            if (students.Count > 0)
            {
                foreach (Student student in students)
                {
                    Console.WriteLine(student.StudentId.ToString().PadRight(5) + student.FirstName.PadRight(12) + student.LastName.PadRight(13) + student.Gender.PadRight(5) + student.HogwartsHouse.PadRight(15) + student.TEClass.PadRight(10));
                }
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }
        private MenuOptionResult SubMenu()
        {
            SubMenu subMenu = new SubMenu(hogwarts, charactersDAO);
            subMenu.Show();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }
        private MenuOptionResult GetSorted()
        {
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine();
            Console.WriteLine($"\tOh, you may not think I'm pretty\r\n\tBut don't judge on what you see,\r\n\tI'll eat myself if you can find\r\n\tA smarter hat than me.");
            Console.WriteLine();
            Console.WriteLine($"\tYou can keep your bowlers black,\r\n\tYour top hats sleek and tall,\r\n\tFor I'm the Hogwarts Sorting Hat\r\n\tAnd I can cap them all.");
            Console.WriteLine();
            Console.WriteLine($"\tThere's nothing hidden in your head\r\n\tThe Sorting Hat can't see,\r\n\tSo try me on and I will tell you\r\n\tWhere you ought to be...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Is the hat on snug? Answer the following questions honestly to determine your house...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            House sortedHouse = hogwarts.SortingHat();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\tI've never yet been wrong,\r\n\tI'll have alook inside your mind\r\n\tAnd tell where you belong!");
            Console.ReadLine();
            if (sortedHouse.HouseName == "Gryffindor")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t***{sortedHouse.HouseName}***");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine($"{sortedHouse.WelcomeMessage}");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ReadLine();
                Console.WriteLine($"\tNow that you're sorted, add yourself as a New Student on the Main Menu.");

            }
            
            if (sortedHouse.HouseName == "Slytherin")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t***{sortedHouse.HouseName}***");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine($"{sortedHouse.WelcomeMessage}");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ReadLine();
                Console.WriteLine($"\tNow that you're sorted, add yourself as a New Student on the Main Menu.");
            }
            if (sortedHouse.HouseName == "Ravenclaw")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\t***{sortedHouse.HouseName}***");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine($"{sortedHouse.WelcomeMessage}");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.ReadLine();
                Console.WriteLine($"\tNow that you're sorted, add yourself as a New Student on the Main Menu.");
            }
            else if (sortedHouse.HouseName == "Hufflepuff")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\t***{sortedHouse.HouseName}***");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine($"{sortedHouse.WelcomeMessage}");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ReadLine();
                Console.WriteLine($"\tNow that you're sorted, add yourself as a New Student on the Main Menu.");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}

