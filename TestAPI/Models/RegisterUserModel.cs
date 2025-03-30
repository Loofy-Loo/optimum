using Newtonsoft.Json;

namespace TestAPI.Models
{
    namespace TestAPI.User.Models
    {
       
        public class UserDataModel 
        {
            public UserModel user { get; set; }
            public bool emailIsConfirmed { get; set; }
        }

        public class  UserModel
        {
            public string name { get; set; }
            public string email { get; set; }
            public string role { get; set; }
            public string language { get; set; }
            public string[] boxes { get; set; }
        }

        public class UserRequestModel
        {
            [JsonProperty(PropertyName = "token", NullValueHandling = NullValueHandling.Ignore)]
            public string? token { get; set; }
            
            [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)] 
            public string? name { get; set; }

            
            [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)] 
            public string? email { get; set; }

            
            [JsonProperty(PropertyName = "password", NullValueHandling = NullValueHandling.Ignore)] 
            public string? password { get; set; }

            
            [JsonProperty(PropertyName = "language", NullValueHandling = NullValueHandling.Ignore)] 
            public string? language { get; set; }

        }


        public class UserResultModel
        {
            [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)] 
            public string code { get; set; }

            
            [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)] 
            public string message { get; set; }

            
            [JsonProperty(PropertyName = "token", NullValueHandling = NullValueHandling.Ignore)] 
            public string token { get; set; }

           
            [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)] 
            public UserDataModel data { get; set; }

        }
    }
}
