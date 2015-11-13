using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.xamarin.forms.Model;
using Newtonsoft.Json;

namespace demo.xamarin.forms.Service
{
    class UserService : IUserService
    {
        private readonly IHttpService _httpService;


        private const string usersUrlFormat = "https://www.randomuser.me/api/?results={0}";

        public List<User> Users { get; private set; }

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
            Users = new List<User>();
        }

        public async Task LoadUsers(uint amount)
        {
            try
            {
                var url = string.Format(usersUrlFormat, amount);
                var result = await _httpService.GetAsync<UserResult>(url);
                Users = result.Results.Select(u => u.User).ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}