
using System.Text;
using Newtonsoft.Json;
using TestAPI.Models.TestAPI.User.Models;
using TestAPI.Models.TestAPI.SenseBox.Models;
using System.Net.Http.Headers;


namespace TestAPI.Services
{
    public class OpenSenseMapApiService
    {
        private readonly HttpClient HttpClient;
        private readonly AppConfigService AppConfigService;

        public OpenSenseMapApiService(HttpClient HttpClient, AppConfigService AppConfigService)
        {
            this.HttpClient = HttpClient;
            this.AppConfigService = AppConfigService;
        }

        public async Task<UserResultModel> RegisterUser(UserRequestModel Model)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "users/register");

            string jsonStr = JsonConvert.SerializeObject(new UserRequestModel
            {
                name = Model.name,
                email = Model.email,
                password = Model.password,
                language = Model.language != null ? Model.language : "en_US"
            });

            request.Content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var response = await HttpClient.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UserResultModel>(result);
            return data;
        }

        public async Task<UserResultModel> Login(UserRequestModel Model)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "users/sign-in");

            string jsonStr = JsonConvert.SerializeObject(new UserRequestModel
            {
                email = Model.email,
                password = Model.password,
            });

            request.Content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var response = await HttpClient.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UserResultModel>(result);
            return data;
        }

        public async Task<UserResultModel> Logout(UserRequestModel Model)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "users/sign-out");
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Model.token);
            var response = await HttpClient.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UserResultModel>(result);
            return data;
        }

        public async Task<SenseBoxResultModel> NewSenseBox(SenseBoxRequestModel Model)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "boxes");
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Model.token);

            string jsonStr = JsonConvert.SerializeObject(new SenseBoxRequestModel
            {
                email = Model.email,
                name = Model.name,
                exposure = Model.exposure,
                model = Model.model,
                location = new Location { lat = Model.location.lat, lng = Model.location.lng, height = Model.location.height.HasValue ? Model.location.height.Value : null }
            });

            request.Content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var response = await HttpClient.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<SenseBoxResultModel>(result);
            return data;
        }

        public async Task<List<SenseBoxDataModel>> GetSenseBox(string SenseBoxId, string Format)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "boxes");
            request.Headers.Add("senseBoxId", SenseBoxId);
            if(Format != null || Format != "")
                request.Headers.Add("format", Format);

            var response = await HttpClient.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<SenseBoxDataModel>>(result);
            return data;
        }
    }
}
