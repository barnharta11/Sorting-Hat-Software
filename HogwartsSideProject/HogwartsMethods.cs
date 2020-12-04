using HogwartsSideProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HogwartsSideProject
{
    public class HogwartsMethods
    {
        //Properties 

        private Dictionary<string, House> houseDictionary = new Dictionary<string, House>();
        private string filePath;
        private string filePath2;
        public HogwartsMethods(List<House> houseList, string filePath, string filePath2)
        {
            this.filePath = filePath;
            this.filePath2 = filePath2;
            foreach (House house in houseList)
            {
                houseDictionary[house.HouseName] = house;
            }

        }
        public IEnumerable<House> DisplayItems()
        {
            return houseDictionary.Values;
        }

        //TODO4 Check method logic. Also why is sorting house null when declared.
        public House SortingHat()
        {
            int griffCounter = 0;
            int huffCounter = 0;
            int slyCounter = 0;
            int ravCounter = 0;
            string gryffindor = "Gryffindor";
            string slytherin = "Slytherin";
            string hufflepuff = "Hufflepuff";
            string ravenclaw = "Ravenclaw";

            using (StreamReader streamReader = new StreamReader(filePath2))
            {
                while (!streamReader.EndOfStream)
                {
                    string eachLine = streamReader.ReadLine();
                    if (eachLine.Contains("Question 1"))
                    {
                        string[] quizLine = eachLine.Split("|");
                        Console.WriteLine($"\t{quizLine[0]}\n\t{quizLine[1]}\n\t{quizLine[2]}\n\t{quizLine[3]}\n\t{quizLine[4]}");
                        string userAnswer = Console.ReadLine(); //collect input
                        
                        if (userAnswer.Contains('A') || userAnswer.Contains('a'))
                        {
                            ravCounter++;
                        }
                        if (userAnswer.Contains('B') || userAnswer.Contains('b'))
                        {
                            griffCounter++;
                        }
                        if (userAnswer.Contains('C') || userAnswer.Contains('c'))
                        {
                            huffCounter++;
                        }
                        if (userAnswer.Contains('D') || userAnswer.Contains('d'))
                        {
                            slyCounter++;
                        }

                    }
                    if (eachLine.Contains("Question 2"))
                    {
                        string[] quizLine = eachLine.Split("|");
                        Console.WriteLine($"\t{quizLine[0]}\n\t{quizLine[1]}\n\t{quizLine[2]}\n\t{quizLine[3]}\n\t{quizLine[4]}");
                        string userAnswer = Console.ReadLine(); //collect input
                         if (userAnswer.Contains('A') || userAnswer.Contains('a'))
                            {
                                huffCounter++;
                            }
                            if (userAnswer.Contains('B') || userAnswer.Contains('b'))
                            {
                                ravCounter++;
                            }
                            if (userAnswer.Contains('C') || userAnswer.Contains('c'))
                            {
                                slyCounter++;
                            }
                            if (userAnswer.Contains('D') || userAnswer.Contains('d'))
                            {
                                griffCounter++;
                            }
                        
                    }
                    if (eachLine.Contains("Question 3"))
                    {
                        string[] quizLine = eachLine.Split("|");
                        Console.WriteLine($"\t{quizLine[0]}\n\t{quizLine[1]}\n\t{quizLine[2]}\n\t{quizLine[3]}\n\t{quizLine[4]}");
                        string userAnswer = Console.ReadLine(); //collect input
                         if (userAnswer.Contains('A') || userAnswer.Contains('a'))
                            {
                                slyCounter++;
                            }
                            if (userAnswer.Contains('B') || userAnswer.Contains('b'))
                            {
                                huffCounter++;
                            }
                            if (userAnswer.Contains('C') || userAnswer.Contains('c'))
                            {
                                griffCounter++;
                            }
                            if (userAnswer.Contains('D') || userAnswer.Contains('d'))
                            {
                                ravCounter++;
                            }
                        
                    }
                    if (eachLine.Contains("Question 4"))
                    {
                        string[] quizLine = eachLine.Split("|");
                        Console.WriteLine($"\t{quizLine[0]}\n\t{quizLine[1]}\n\t{quizLine[2]}\n\t{quizLine[3]}\n\t{quizLine[4]}");
                        string userAnswer = Console.ReadLine(); //collect input
                        
                            if (userAnswer.Contains('A') || userAnswer.Contains('a'))
                            {
                                griffCounter++;
                            }
                            if (userAnswer.Contains('B') || userAnswer.Contains('b'))
                            {
                                slyCounter++;
                            }
                            if (userAnswer.Contains('C') || userAnswer.Contains('c'))
                            {
                                ravCounter++;
                            }
                            if (userAnswer.Contains('D') || userAnswer.Contains('d'))
                            {
                                huffCounter++;
                            }
                        

                    }
                    if (eachLine.Contains("Question 5"))
                    {
                        string[] quizLine = eachLine.Split("|");
                        Console.WriteLine($"\t{quizLine[0]}\n\t{quizLine[1]}\n\t{quizLine[2]}\n\t{quizLine[3]}\n\t{quizLine[4]}");
                        string userAnswer = Console.ReadLine(); //collect input
                        
                            if (userAnswer.Contains('A') || userAnswer.Contains('a'))
                            {
                                ravCounter++;
                            }
                            if (userAnswer.Contains('B') || userAnswer.Contains('b'))
                            {
                                huffCounter++;
                            }
                            if (userAnswer.Contains('C') || userAnswer.Contains('c'))
                            {
                                slyCounter++;
                            }
                            if (userAnswer.Contains('D') || userAnswer.Contains('d'))
                            {
                                griffCounter++;
                            }
                        break;
                    }
                   
                }
                if (griffCounter >= 3)
                {
                    
                    House sortedHouse = houseDictionary[gryffindor];
                     return sortedHouse;
                }
                else if (slyCounter >= 3)
                {
                    House sortedHouse = houseDictionary[slytherin];
                    return sortedHouse;
                }
                else if (huffCounter >= 3)
                {
                    House sortedHouse = houseDictionary[hufflepuff];
                    return sortedHouse;
                }
                else if (ravCounter >= 3)
                {
                    House sortedHouse = houseDictionary[ravenclaw];
                    return sortedHouse;
                }
                else
                {
                    while (!streamReader.EndOfStream)
                    {
                        string eachLine = streamReader.ReadLine();
                        if (ravCounter == 2 && slyCounter == 2)
                        {
                            if (eachLine.Contains("SR*"))
                            {
                                Console.WriteLine($"\tHmmm I need one more question just to make sure...");
                                Console.WriteLine();
                                string[] quizLine = eachLine.Split("|");
                                Console.WriteLine($"\t{quizLine[0]}\n\t{quizLine[2]}\n\t{quizLine[3]}");
                                string userAnswer = Console.ReadLine(); //collect input

                                if (userAnswer.Contains('A') || userAnswer.Contains('a'))
                                {
                                    House sortedHouse = houseDictionary["Slytherin"];
                                    return sortedHouse;
                                }
                                if (userAnswer.Contains('B') || userAnswer.Contains('b'))
                                {
                                    House sortedHouse = houseDictionary["Ravenclaw"];
                                    return sortedHouse;
                                }
                            }
                        }
                        else if (ravCounter == 2 && griffCounter == 2)
                        {
                            if (eachLine.Contains("RG*"))
                            {
                                Console.WriteLine($"\tHmmm I need one more question just to make sure...");
                                Console.WriteLine();
                                string[] quizLine = eachLine.Split("|");
                                Console.WriteLine($"\t{quizLine[0]}\n\t{quizLine[2]}\n\t{quizLine[3]}");
                                string userAnswer = Console.ReadLine(); //collect input

                                if (userAnswer.Contains('A') || userAnswer.Contains('a'))
                                {
                                    House sortedHouse = houseDictionary["Gryffindor"];
                                    return sortedHouse;
                                }
                                if (userAnswer.Contains('B') || userAnswer.Contains('b'))
                                {
                                    House sortedHouse = houseDictionary["Ravenclaw"];
                                    return sortedHouse;
                                }
                            }
                        }
                        else if (griffCounter == 2 && slyCounter == 2)
                        {
                            

                            if (eachLine.Contains("SG*"))
                            {
                                Console.WriteLine($"\tHmmm I need one more question just to make sure...");
                                Console.WriteLine();
                                string[] quizLine = eachLine.Split("|");
                                Console.WriteLine($"\t{quizLine[0]}\n\t{quizLine[2]}\n\t{quizLine[3]}");
                                string userAnswer = Console.ReadLine(); //collect input

                                if (userAnswer.Contains('A') || userAnswer.Contains('a'))
                                {
                                    House sortedHouse = houseDictionary["Gryffindor"];
                                    return sortedHouse;
                                }
                                if (userAnswer.Contains('B') || userAnswer.Contains('b'))
                                {
                                    House sortedHouse = houseDictionary["Slytherin"];
                                    return sortedHouse;
                                }
                            }
                        }
                        else if (huffCounter == 2 && slyCounter == 2)
                        {
                            

                            if (eachLine.Contains("SH*"))
                            {
                                Console.WriteLine($"\tHmmm I need one more question just to make sure...");
                                Console.WriteLine();
                                string[] quizLine = eachLine.Split("|");
                                Console.WriteLine($"\t{quizLine[0]}\n\t{quizLine[2]}\n\t{quizLine[3]}");
                                string userAnswer = Console.ReadLine(); //collect input

                                if (userAnswer.Contains('A') || userAnswer.Contains('a'))
                                {
                                    House sortedHouse = houseDictionary["Hufflepuff"];
                                    return sortedHouse;
                                }
                                if (userAnswer.Contains('B') || userAnswer.Contains('b'))
                                {
                                    House sortedHouse = houseDictionary["Slytherin"];
                                    return sortedHouse;
                                }
                            }
                        }
                        else if (huffCounter == 2 && griffCounter == 2)
                        {
                            

                            if (eachLine.Contains("GH*"))
                            {
                                Console.WriteLine($"\tHmmm I need one more question just to make sure...");
                                Console.WriteLine();
                                string[] quizLine = eachLine.Split("|");
                                Console.WriteLine($"\t{quizLine[0]}\n\t{quizLine[2]}\n\t{quizLine[3]}");
                                string userAnswer = Console.ReadLine(); //collect input

                                if (userAnswer.Contains('A') || userAnswer.Contains('a'))
                                {
                                    House sortedHouse = houseDictionary["Hufflepuff"];
                                    return sortedHouse;
                                }
                                if (userAnswer.Contains('B') || userAnswer.Contains('b'))
                                {
                                    House sortedHouse = houseDictionary["Gryffindor"];
                                    return sortedHouse;
                                }
                            }
                        }
                        else if (ravCounter == 2 && huffCounter == 2)
                        {
                            

                            if (eachLine.Contains("HR*"))
                            {
                                Console.WriteLine($"\tHmmm I need one more question just to make sure...");
                                Console.WriteLine();
                                string[] quizLine = eachLine.Split("|");
                                Console.WriteLine($"\t{quizLine[0]}\n\t{quizLine[2]}\n\t{quizLine[3]}");
                                string userAnswer = Console.ReadLine(); //collect input

                                if (userAnswer.Contains('A') || userAnswer.Contains('a'))
                                {
                                    House sortedHouse = houseDictionary["Hufflepuff"];
                                    return sortedHouse;
                                }
                                if (userAnswer.Contains('B') || userAnswer.Contains('b'))
                                {
                                    House sortedHouse = houseDictionary["Ravenclaw"];
                                    return sortedHouse;
                                }
                            }
                        }
                        
                    }
                }

            }
            return null;
        }

        //API METHODS
        public void PrintCharactersList(List<Characters> characters)
        {
           
            foreach (Characters character in characters)
            {
                if (character.Ancestry == "" && character.Patronus == "" && character.House == "")
                {
                    Console.WriteLine($"Name: {character.Name}\n\tHogwarts House: unknown\n\tAncestry: unknown\n\tPatronus: unknown\n\tHogwarts Student: {character.HogwartsStudent}\n\tHogwarts Staff: {character.HogwartsStaff}");
                    Console.WriteLine();
                }
                else if (character.Ancestry == "" && character.Patronus == "")
                {
                    Console.WriteLine($"Name: {character.Name}\n\tHogwarts House: {character.House}\n\tAncestry: unknown\n\tPatronus: unknown\n\tHogwarts Student: {character.HogwartsStudent}\n\tHogwarts Staff: {character.HogwartsStaff}");
                    Console.WriteLine();
                }
                else if (character.House == "" && character.Patronus == "")
                {
                    Console.WriteLine($"Name: {character.Name}\n\tHogwarts House: unknown\n\tAncestry: {character.Ancestry}\n\tPatronus: unknown\n\tHogwarts Student: {character.HogwartsStudent}\n\tHogwarts Staff: {character.HogwartsStaff}");
                    Console.WriteLine();
                }
                else if (character.Patronus == "")
                {
                    Console.WriteLine($"Name: {character.Name}\n\tHogwarts House: {character.House}\n\tAncestry: {character.Ancestry}\n\tPatronus: unknown\n\tHogwarts Student: {character.HogwartsStudent}\n\tHogwarts Staff: {character.HogwartsStaff}");
                    Console.WriteLine();
                }
                else if (character.Ancestry == "")
                {
                    Console.WriteLine($"Name: {character.Name}\n\tHogwarts House: {character.House}\n\tAncestry: unknown\n\tPatronus: {character.Patronus}\n\tHogwarts Student: {character.HogwartsStudent}\n\tHogwarts Staff: {character.HogwartsStaff}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Name: {character.Name}\n\tHogwarts House: {character.House}\n\tAncestry: {character.Ancestry}\n\tPatronus: {character.Patronus}\n\tHogwarts Student: {character.HogwartsStudent}\n\tHogwarts Staff: {character.HogwartsStaff}");
                    Console.WriteLine();
                }
                
            }
        }

        //SQL METHODS
        public string GetString(string message)
        {
            string userInput = String.Empty;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (String.IsNullOrEmpty(userInput));

            return userInput;
        }

    }
}
