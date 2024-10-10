/*
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RWA.Services
{
    public class Fast2SmsService
    {
        private readonly string _apiKey = "z8oK2GQVyYFqjbwmJDBxaEpPA3gTuIfecdO16h0MilZCU9XLRvD0H1P5mEFYOdIS38WXfGrgVwzxpCiL";

        public async Task SendSmsAsync(string phoneNumber, string otp)
        {
            using var httpClient = new HttpClient();

            // Corrected JSON body for OTP route
            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                route = "otp",
                variables_values = otp,  // Send OTP value here
                numbers = phoneNumber     // Phone number in international format
            }), Encoding.UTF8, "application/json");

            httpClient.DefaultRequestHeaders.Add("authorization", _apiKey);

            // Sending the OTP
            var response = await httpClient.PostAsync("https://www.fast2sms.com/dev/bulkV2", content);

            // Logging the response for debugging
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);  // Check response from Fast2SMS

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to send OTP: {responseString}");
            }
        }
    }
}
*/
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RWA.Services
{
    public class Fast2SmsService
    {
        private readonly string _apiKey = "z8oK2GQVyYFqjbwmJDBxaEpPA3gTuIfecdO16h0MilZCU9XLRvD0H1P5mEFYOdIS38WXfGrgVwzxpCiL";

        public async Task SendSmsAsync(string phoneNumber, int otp)
        {
            using var httpClient = new HttpClient();

            // Corrected JSON body with only numeric otp value
            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                route = "otp",
                variables_values = otp.ToString(),   // Send OTP as string to comply with Fast2SMS
                numbers = phoneNumber                  // Phone number in international format
            }), Encoding.UTF8, "application/json");

            httpClient.DefaultRequestHeaders.Add("authorization", _apiKey);

            // Sending the OTP
            var response = await httpClient.PostAsync("https://www.fast2sms.com/dev/bulkV2", content);

            // Logging the response for debugging
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);  // Check response from Fast2SMS

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to send OTP: {responseString}");
            }
        }
    }
}

