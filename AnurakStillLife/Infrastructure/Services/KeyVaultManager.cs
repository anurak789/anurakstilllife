using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class KeyVaultManager : IKeyVaultManager
    {
        private readonly ILogger<KeyVaultManager> logger;
        private readonly IConfiguration configuration;

        public KeyVaultManager(ILogger<KeyVaultManager> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        public async Task<string> GetVaultSecret()
        {
            try
            {
                SecretClientOptions options = new SecretClientOptions()
                {
                    Retry =
                    {
                        Delay= TimeSpan.FromSeconds(2),
                        MaxDelay = TimeSpan.FromSeconds(16),
                        MaxRetries = 5,
                        Mode = RetryMode.Exponential
                     }
                };

                var secretClient = new SecretClient(new Uri(this.configuration.GetSection("KeyVaultUri").Value), new DefaultAzureCredential(), options);

                var secret = await secretClient.GetSecretAsync(this.configuration.GetSection("SecretKey").Value);
                //var secret = await secretClient.GetSecretAsync(secretName);

                //KeyVaultSecret keyValueSecret = await this.secretClient.GetSecretAsync(secret.Value);

                return secret.Value.Value;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, "An error occured while try to get secret");
            }

            return null;
        }
    }
}
