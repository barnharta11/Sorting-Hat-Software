using Figgle;
using HogwartsSideProject.DAL;
using HogwartsSideProject.Models;
using MenuFramework;
using System;
using System.Collections.Generic;

namespace HogwartsSideProject
{
    public class SubMenu : ConsoleMenu
    {
        private ICharactersDAO charactersDAO;
        private HogwartsMethods hogwarts;
        public SubMenu(HogwartsMethods hogwarts, ICharactersDAO charactersDAO)
        {
            this.hogwarts = hogwarts;
            this.charactersDAO = charactersDAO;
            AddOption("1. Hogwarts, A History", GetHHistory);
            AddOption("2. List of Harry Potter Characters", HPList);
            AddOption("3. Search for Characters by House", ByHouse);

            Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.Gray;
                cfg.SelectedItemForegroundColor = ConsoleColor.Blue;

            });
        }
        private MenuOptionResult ByHouse()
        {
            Console.Write("Please enter a House name: ");
            string searchTitle = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(searchTitle))
            {

                List<Characters> characters = charactersDAO.SearchCharactersByHouse(searchTitle);

                if (searchTitle.ToLower() == "slytherin" || searchTitle == "ravenclaw" || searchTitle == "gryffindor" || searchTitle == "hufflepuff")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Characters in {searchTitle}");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    hogwarts.PrintCharactersList(characters);
                    return MenuOptionResult.WaitAfterMenuSelection;
                }
                else
                {
                    Console.WriteLine($"No characters found for House: {searchTitle}. Try typing Gryffindor, Ravenclaw, Hufflepuff, or Slytherin.");
                    return MenuOptionResult.WaitAfterMenuSelection;
                }

            }
            
            return MenuOptionResult.ExitAfterSelection;
        }
        private MenuOptionResult HPList()
        {

            List<Characters> characters = charactersDAO.GetAllCharacters();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("List of Harry Potter Characters:");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            hogwarts.PrintCharactersList(characters);
            return MenuOptionResult.WaitAfterMenuSelection;

        }
        private MenuOptionResult GetHHistory()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(FiggleFonts.Big.Render("Hogwarts A History:"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\tHogwarts School of Witchcraft and Wizardry is a British wizarding school,\n\tlocated in the Scottish Highlands. The precise location of the school\n\twill never be uncovered as it was rendered Unplottable. To Muggles,\n\tthe school appears to be an old, abandoned castle. Similarly, most wizarding\n\tschools' locations are protected in order to prevent their ways of teaching\n\tfrom being revealed, as well as protect the students and schools themselves from\n\tany harm.");
            Console.WriteLine();
            Console.WriteLine($"\tHogwarts was founded around 990 A.D. by four of the greatest wizards and\n\twitches of the age: Godric Gryffindor, Helga Hufflepuff, Rowena Ravenclaw,\n\tand Salazar Slytherin. They each represented an aspect of personality that\n\tthey wanted to bring out in new students. However, shortly after founding\n\tthe school, Slytherin had a falling out with the other founders about blood\n\tpurity, and wanted to admit only pure-blood students.");
            Console.WriteLine();
            Console.WriteLine($"\tHe felt pure-blooded students deserved to learn magic, and those of other\n\tancestry such as Muggle-borns and Half-bloods, were unworthy. The other\n\tthree founders all disagreed, especially Gryffindor. Slytherin left the\n\tschool, but not before secretly building the Chamber of Secrets. He foretold\n\tthat only his own heir would be able to open it once they arrived at the\n\tschool, and the heir would unleash a murderous basilisk living inside to\n\tpurge the school of all Muggle-born students.");
            Console.WriteLine();
            Console.WriteLine($"\tHogwarts is considered to be one of the finest magical institutions in the\n\tWizarding World, though other notable schools included Beauxbatons Academy\n\tof Magic in France, the Durmstrang Institute implied to be in northern Europe,\n\tand Ilvermorny School of Witchcraft and Wizardry in the United States.\n\tChildren with magical abilities were enrolled at birth, and acceptance was\n\tconfirmed by owl post at age eleven. However, if the child in question was a\n\tMuggle-born, a staff member from the school visited the child and his or her\n\tfamily in order to inform them of their magical heritage and the existence\n\tof the Wizarding world.");
            Console.WriteLine();
            Console.WriteLine($"\tThe school's motto is Draco Dormiens Nunquam Titillandus which means\n\t\"Never tickle a sleeping dragon\".");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(FiggleFonts.Big.Render("Hogwarts' Four Houses:"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            foreach (House house in hogwarts.DisplayItems())
            {
                if (house.HouseName == "Gryffindor")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\t{house.HouseName}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\tHouse Founder: {house.Founder}\n\tHouse Colors: {house.HouseColors}\n\tHouse Animal: {house.HouseAnimal}\n\tHouse Qualities: {house.HouseQualities}");
                    Console.WriteLine();
                }
                else if (house.HouseName == "Slytherin")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\t{house.HouseName}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\tHouse Founder: {house.Founder}\n\tHouse Colors: {house.HouseColors}\n\tHouse Animal: {house.HouseAnimal}\n\tHouse Qualities: {house.HouseQualities}");
                    Console.WriteLine();
                }
                else if (house.HouseName == "Ravenclaw")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\t{house.HouseName}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\tHouse Founder: {house.Founder}\n\tHouse Colors: {house.HouseColors}\n\tHouse Animal: {house.HouseAnimal}\n\tHouse Qualities: {house.HouseQualities}");
                    Console.WriteLine();
                }
                else if (house.HouseName == "Hufflepuff")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t{house.HouseName}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\tHouse Founder: {house.Founder}\n\tHouse Colors: {house.HouseColors}\n\tHouse Animal: {house.HouseAnimal}\n\tHouse Qualities: {house.HouseQualities}");
                    Console.WriteLine();
                }

            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}