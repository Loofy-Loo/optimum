using System.Net.Http;
using System.Text;
using TestAPI.Objects;
using TestAPI.Models;
using Newtonsoft.Json;
using TestAPI.Models.TestAPI.User.Models;


namespace TestAPI.Services
{
    public class UserService
    {
        private readonly OpenSenseMapApiService OpenSenseMapApiService;

        public UserService(OpenSenseMapApiService OpenSenseMapApiService)
        {
            this.OpenSenseMapApiService = OpenSenseMapApiService;
        }

        public async Task<UserResultModel> RegisterUser(UserRequestModel Model)
        {
            return await OpenSenseMapApiService.RegisterUser(Model);
        }

        public async Task<UserResultModel> Login(UserRequestModel Model)
        {
            return await OpenSenseMapApiService.Login(Model);
        }

        public async Task<UserResultModel> Logout(UserRequestModel Model)
        {
            return await OpenSenseMapApiService.Logout(Model);
        }
    }
}
