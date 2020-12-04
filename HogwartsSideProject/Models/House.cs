using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsSideProject
{
    public class House
    {
        //Properties
        public Program Hogwarts { get; set; }
        public string HouseName { get; set; }
        public string Founder { get; set; }
        public string HouseColors { get; set; }
        public string HouseAnimal { get; }
        public string HouseQualities { get; set; }


        public string WelcomeMessage
        {
            get
            {
                if (HouseName == "Gryffindor")
                {
                    return $"\tWelcome to Gryffindor House, where bravery and chivalry are valued." +
                        $"\r\n\tYou belong here because you have a lion's heart; you'll put your life on the line for anything," +
                        $"\r\n\twhether it be for a friend, an ally, or for the thrill of it." +
                        $"\r\n\tVery little stops you from having fun, but you have good morals and when it comes down to it," +
                        $"\r\n\tyou choose good over evil.";
                }
                if (HouseName == "Hufflepuff")
                {
                    return $"\tWelcome to Hufflepuff House, where loyalty, friendship, and justice is valued." +
                        $"\r\n\tWhile Hufflepuff might be the butt of most jokes, this House is certainly not one to overlook." +
                        $"\r\n\tHufflepuffs are very similar to Gryffindors, except they know where the line is and hardly every cross it." +
                        $"\r\n\tYou are here because you're a true friend and would do anything to help the ones you care about," +
                        $"\r\n\twhether it be a good listener or someone who always has a plate of cookies to cheer others up." +
                        $"\r\n\tYou're hardworking and want to see justice prevail in the world.";
                }
                if (HouseName == "Ravenclaw")
                {
                    return $"\tWelcome to Ravenclaw House, where your mind is your most valuable asset." +
                        $"\r\n\tRavenclaws prize learning and knowledge above all other qualities and are true believers that knowledge is power." +
                        $"\r\n\tIf you're here, then you have a strong will to learn new things and want to spread your knowledge as much as you can." +
                        $"\r\n\tYou help your fellows with problem-solving and enjoy doing it.";
                }
                else if (HouseName == "Slytherin")
                {
                    return $"\tWelcome to Slytherin House, where you will be pushed to achieve your full potential." +
                        $"\r\n\tWhile Slytherin has a bad reputation for producing Dark witches and wizards," +
                        $"\r\n\tnot all Slytherins are rotten apples. You are here simply because you have high expectations" +
                        $"\r\n\tand won't stop at anything to achieve your goals. Sure, you might step on a few fingers to get there, " +
                        $"\r\n\tbut that's a price you're willing to pay. If you make friends here, " +
                        $"\r\n\tit is because they are stepping stones, one way or another.";
                }
                return "";
            }

        }

        //Constructor

        public House (string houseName, string founder, string houseColors, string houseAnimal, string houseQualities)
        {
            HouseName = houseName;
            Founder = founder;
            HouseColors = houseColors;
            HouseAnimal = houseAnimal;
            HouseQualities = houseQualities;

        }
    }
}
