using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace TestAPI.Models
{
    namespace TestAPI.SenseBox.Models
    {

        public class SenseBoxRequestModel
        {
            public string token { get; set; }
            public string email {  get; set; }
            public string name { get; set; }
            
            [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)] 
            public string? description { get; set; }


            [JsonProperty(PropertyName = "grouptag", NullValueHandling = NullValueHandling.Ignore)] 
            public string? grouptag { get; set; }

            public string exposure { get; set; }

            public Location location { get; set; }


            [JsonProperty(PropertyName = "model", NullValueHandling = NullValueHandling.Ignore)] 
            public string? model { get; set; }

            [JsonProperty(PropertyName = "sensors", NullValueHandling = NullValueHandling.Ignore)]
            public List<Sensor>? sensors { get; set; }

            [JsonProperty(PropertyName = "sensorTemplates", NullValueHandling = NullValueHandling.Ignore)]
            public List<string>? sensorTemplates { get; set; }


            [JsonProperty(PropertyName = "mqtt", NullValueHandling = NullValueHandling.Ignore)]
            public MQTT? mqtt { get; set; }

            [JsonProperty(PropertyName = "ttn", NullValueHandling = NullValueHandling.Ignore)]
            public TTN? ttn { get; set; }

            [JsonProperty(PropertyName = "useAuth", NullValueHandling = NullValueHandling.Ignore)] 
            public bool? useAuth { get; set; }

            [JsonProperty(PropertyName = "sharedBox", NullValueHandling = NullValueHandling.Ignore)]
            public bool? sharedBox { get; set; }
        }

        public class  Location
        {
            public int lat {  get; set; }
            public int lng { get; set; }
            public int? height { get; set; }
        }

        public class Sensor
        {
            public string _id { get; set; }
            public string title { get; set; }
            public string unit { get; set; }
            public string sensorType { get; set; }
            public string? icon { get; set; }
            //public Measurement lastMeasurement { get; set; }
            public string lastMeasurement { get; set; }

        }

        public class Measurement
        {
            public string value  { get; set; }
            public DateTime createdAt { get; set; }
        }

        public class MQTT
        {
            public bool enabled { get; set; }
            
            [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)] 
            public string url { get; set; }
            
            [JsonProperty(PropertyName = "topic", NullValueHandling = NullValueHandling.Ignore)] 
            public string topic { get; set; }
            
            [JsonProperty(PropertyName = "messageFormat", NullValueHandling = NullValueHandling.Ignore)] 
            public string messageFormat { get; set; }
            
            [JsonProperty(PropertyName = "decodeOptions", NullValueHandling = NullValueHandling.Ignore)] 
            public string decodeOptions { get; set; }
            
            [JsonProperty(PropertyName = "connectionOptions", NullValueHandling = NullValueHandling.Ignore)] 
            public string connectionOptions { get; set; }
        }

        public class TTN
        {
            public string dev_id { get; set; }
            public string app_id { get; set; }
            public string profile { get; set; }
            public List<string>? decodeOptions { get; set; }
            public int port { get; set; }
        }

        public class SenseBoxResultModel
        {
            public string message { get; set; }
            public SenseBoxDataModel data { get; set; }
        }

        public class SenseBoxDataModel
        {
            public string _id { get; set; }
            public DateTime createdAt { get; set; }
            public string exposure { get; set; }
            public string model { get; set; }
            public string[] grouptag { get; set; }
            public string name { get; set; }
            
            public DateTime updatedAt { get; set; }
            public DateTime lastMeasurementAt { get; set; }
            public currentLocation currentLocation { get; set; }
            public List<Sensor> sensors { get; set; }
            
            public List<loc> loc { get; set; }
            public Integration integrations { get; set; }
            public string access_token { get; set; }
            public bool useAuth { get; set; }

            public string image { get; set; }
        }

        public class currentLocation
        {
            public string type { get; set; }
            public List<double> coordinates { get; set; }
            public DateTime timestamp { get; set; }
        }

        public class loc
        {
            public Geometry geometry { get; set; }
            public string type { get; set; }
        }

        public class Geometry
        {
            public string type { get; set; }
			public List<int> coordinates { get; set; }
			public DateTime timestamp { get; set; }
        }

        public class Integration 
        {
            public MQTT mqtt { get; set; }
        }
    }
}
