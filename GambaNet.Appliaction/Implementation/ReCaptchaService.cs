using System.Net.Http;
using System.Threading.Tasks;
using GambaNet_Web.Application.Abstraction;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GambaNet_Web.Application.Implementation
{
    public class ReCaptchaService : IReCaptchaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _secretKey;

        public ReCaptchaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _secretKey = configuration["6Le_UbUqAAAAAAlIy2GWIbAkjOZdjsiKp6wAokm3"];
        }

        public async Task<bool> VerifyCaptchaAsync(string token)
        {
            var response = await _httpClient.PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={_secretKey}&response={token}", null);
            var jsonString = await response.Content.ReadAsStringAsync();
            var reCaptchaResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(jsonString);
            return reCaptchaResponse.Success;
        }
    }

    public class ReCaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("challenge_ts")]
        public string ChallengeTimestamp { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("error-codes")]
        public string[] ErrorCodes { get; set; }
    }
}
