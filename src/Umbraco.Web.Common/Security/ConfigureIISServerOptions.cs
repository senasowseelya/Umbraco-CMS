using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Configuration.Models;

namespace Umbraco.Cms.Web.Common.Security
{
    public class ConfigureIISServerOptions : IConfigureOptions<IISServerOptions>
    {
        private readonly IOptions<RuntimeSettings> _runtimeSettings;

        public ConfigureIISServerOptions(IOptions<RuntimeSettings> runtimeSettings) => _runtimeSettings = runtimeSettings;
        public void Configure(IISServerOptions options)
        {
            // convert from KB to bytes
            options.MaxRequestBodySize = _runtimeSettings.Value.MaxRequestLength.HasValue ? _runtimeSettings.Value.MaxRequestLength.Value * 1024 : uint.MaxValue; // ~4GB is the max supported value for IIS and IIS express.
        }
    }
}
