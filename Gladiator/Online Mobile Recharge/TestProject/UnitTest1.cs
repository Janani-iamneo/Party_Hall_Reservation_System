using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using dotnetapp.Models;

[TestFixture]
public class SpringappApplicationTests
{
    private HttpClient _httpClient;
    private string _generatedToken;

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://8080-fcebdccccdbcfacbdcbaeadbebabcdebdca.premiumproject.examly.io"); 
    }

    [Test, Order(1)]
    public async Task Backend_TestRegisterUser()
    {
        string uniqueId = Guid.NewGuid().ToString();

        // Generate a unique userName based on a timestamp
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";

        var registrationRequest = new
        {
            Username = uniqueUsername,
            Password = "abc@123A",
            Email = uniqueEmail,
            MobileNumber = "1234567890",
            Role = "customer" // or "admin" based on your requirements
        };

        string requestBody = JsonConvert.SerializeObject(registrationRequest);
        HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

        Console.WriteLine(response.StatusCode);
        string responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseString);

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    // [Test, Order(2)]
    // public async Task Backend_TestRegisterAdmin()
    // {
    //     string uniqueId = Guid.NewGuid().ToString();
    //     string uniqueUsername = $"abcd_{uniqueId}";
    //     string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    //     await RegisterAndLoginAsync(uniqueUsername, "abc@123A", "admin", "/api/auth/register", "/api/auth/login");
    // }

    // [Test, Order(3)]
    // public async Task Backend_TestLoginAdmin()
    // {
    //     string uniqueId = Guid.NewGuid().ToString();
    //     string uniqueUsername = $"abcd_{uniqueId}";

    //     await RegisterAndLoginAsync(uniqueUsername, $"abcdA{uniqueId}@123", "admin", "/api/auth/register", "/api/auth/login");
    // }

    // private async Task RegisterAndLoginAsync(string username, string password, string role, string registerPath, string loginPath)
    // {
    //     // Register the user with the correct role
    //     var registrationRequest = new
    //     {
    //         UserName = username,
    //         Password = password,
    //         Role = role
    //     };

    //     string registrationRequestBody = JsonConvert.SerializeObject(registrationRequest);
    //     HttpResponseMessage registrationResponse = await _httpClient.PostAsync(registerPath, new StringContent(registrationRequestBody, Encoding.UTF8, "application/json"));

    //     // Check if registration failed with BadRequest
    //     if (registrationResponse.StatusCode == HttpStatusCode.BadRequest)
    //     {
    //         // Log response details for debugging
    //         string registrationResponseContent = await registrationResponse.Content.ReadAsStringAsync();
    //         Console.WriteLine($"Registration failed. Response: {registrationResponseContent}");
    //         // Adjust the Assert to expect BadRequest
    //         Assert.AreEqual(HttpStatusCode.BadRequest, registrationResponse.StatusCode);
    //         return;
    //     }

    //     // Check the response content for success indicators
    //     string loginResponseContent = await registrationResponse.Content.ReadAsStringAsync();
    //     if (loginResponseContent.Contains("success indicator")) // Modify this condition based on your actual response content
    //     {
    //         Console.WriteLine($"Registration successful. Response: {loginResponseContent}");
    //     }
    //     else
    //     {
    //         Console.WriteLine($"Unexpected registration response. Response: {loginResponseContent}");
    //         Assert.Fail("Unexpected registration response.");
    //     }
    // }

    [Test, Order(4)]
public async Task AddOnController_AddAddon_ValidData_Success()
{
    // Check if the authentication token is available
    if (string.IsNullOrEmpty(_generatedToken))
    {
        // Handle the case where the token is not available
        Assert.Fail("Authentication token not available");
        return;
    }

    // Set up the HttpClient with the base address and authorization header
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("https://8080-fcebdccccdbcfacbdcbaeadbebabcdebdca.premiumproject.examly.io");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _generatedToken);

        var addon = new Addon
        {
            AddonName = "TestAddon",
            AddonPrice = 10.99,
            AddonDetails = "Test details",
            AddonValidity = "30"
        };

        // Serialize the addon object to JSON and send a POST request
        string requestBody = JsonConvert.SerializeObject(addon);
        HttpResponseMessage response = await client.PostAsync("/api/addAddon", new StringContent(requestBody, Encoding.UTF8, "application/json"));

        Console.WriteLine(response.StatusCode);
        string responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseString);

        // Check if the request was successful (status code 200 OK) and the response message
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.AreEqual("Addon added successfully", responseString);
    }
}

}