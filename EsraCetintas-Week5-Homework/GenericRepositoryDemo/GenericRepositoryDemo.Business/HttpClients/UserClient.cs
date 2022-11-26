using GenericRepositoryDemo.Business.Abstract;
using GenericRepositoryDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Business.HttpClients
{
   public class UserClient 
    {
        IUserService _userService;

        public UserClient(IUserService userService)
        {
            _userService = userService;
        }

        // This method fetches data from the API

        public async Task GetUser()
        {
            using var httpClient = new HttpClient();

            var result= httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts").Result;

            var jsonString = result.Content.ReadAsStringAsync().Result;

            var users = JsonSerializer.Deserialize<List<User>>(jsonString);

               await _userService.Add(users[0]);

        }
    }
}
