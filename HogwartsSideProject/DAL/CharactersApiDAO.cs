using HogwartsSideProject.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsSideProject.DAL
{
    
    public class CharactersApiDAO : ICharactersDAO
    {
        private RestClient client;
        public CharactersApiDAO(string API_URL)
        {
            client = new RestClient(API_URL);   
        }
        public List<Characters> GetAllCharacters()
        {
            RestRequest request = new RestRequest();
            IRestResponse<List<Characters>> response = client.Get<List<Characters>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.", response.ErrorException);
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
        }
        public List<Characters> SearchCharactersByHouse(string house)
        {
            RestRequest request = new RestRequest($"/house/{house}");
            IRestResponse<List<Characters>> response = client.Get<List<Characters>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.", response.ErrorException);
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
        }
      
    }
}
