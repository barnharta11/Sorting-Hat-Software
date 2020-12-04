using HogwartsSideProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsSideProject.DAL
{
    public interface ICharactersDAO
    {
        List<Characters> GetAllCharacters();
        List<Characters> SearchCharactersByHouse(string house);

        

       
    }
}
