using System.Net.Http;
using System.Text;
using TestAPI.Objects;
using TestAPI.Models;
using Newtonsoft.Json;
using TestAPI.Models.TestAPI.User.Models;
using TestAPI.Models.TestAPI.SenseBox.Models;
using System.Globalization;


namespace TestAPI.Services
{
    public class SenseBoxService
    {
        private readonly OpenSenseMapApiService OpenSenseMapApiService;

        public SenseBoxService(OpenSenseMapApiService OpenSenseMapApiService)
        {
            this.OpenSenseMapApiService = OpenSenseMapApiService;
        }

        public async Task<SenseBoxResultModel> NewSenseBox(SenseBoxRequestModel Model)
        {
            return await OpenSenseMapApiService.NewSenseBox(Model);
        }

        public async Task<List<SenseBoxDataModel>> GetSenseBox(string SenseBoxId, string Format)
        {
            return await OpenSenseMapApiService.GetSenseBox(SenseBoxId, Format);
        }
    }
}
