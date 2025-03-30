using TestAPI.Objects;

namespace TestAPI.Services
{
    public class AppConfigService
    {
        public AppConfigSetting AppSettings { get; }

        public AppConfigService(IConfiguration config)
        {
            this.AppSettings = new AppConfigSetting();

            // This will bind our settings in the appsettings.json into the AppConfigSetting object.
            config.Bind(this.AppSettings);
        }
    }
}
