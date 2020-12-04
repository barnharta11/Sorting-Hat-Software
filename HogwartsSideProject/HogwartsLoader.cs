using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HogwartsSideProject
{
    public class HogwartsLoader
    {
        //Properties
        public List<House> HouseList { get; set; }
		
		public HogwartsLoader(string filePath)
		{
			HouseList = new List<House>();
			
			using (StreamReader reader = new StreamReader(filePath))
			{
				while (!reader.EndOfStream)
				{
                    string eachLine = reader.ReadLine();
					if (eachLine.Contains("House_"))
                    {
						string[] parameter = eachLine.Split("|");
						House house = new House(parameter[0].Substring(6), parameter[1], parameter[2], parameter[3], parameter[4]);
						HouseList.Add(house);

					}
					
				}

			}

		}
	}
}

			

			

		
	
