using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Домашнее_задание__7.Class
{
    public class UserService
    {
        private RestClient _client;
        private RestClientOptions _options;
        public UserService()
        {
            _options = new RestClientOptions("https://jsonplaceholder.typicode.com");
            _client = new RestClient(_options);
        }

        public async Task<List<User>> GetUsers()
        {
            var response = await _client.GetJsonAsync<List<User>>("users");

            return response;
        }
    }
}
