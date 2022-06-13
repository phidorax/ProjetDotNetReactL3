using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using RazorTP.Common.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xunit;

namespace RazorTP.WebAPI.Tests
{
    public class UserControllerTest
    {
        public HttpClient client { get; }
        public TestServer server { get; }

        private readonly JsonSerializerOptions serializationOptions;

        public UserControllerTest()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var builder = new WebHostBuilder()
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .UseEnvironment("Testing");
            var server = new TestServer(builder);

            client = server.CreateClient();

            serializationOptions = new JsonSerializerOptions();
            serializationOptions.PropertyNameCaseInsensitive = true;
        }

        [Fact]
        public async void ShouldGet200_GetAll()
        {
            var response = await client.GetAsync("/users/all");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var body = await response.Content.ReadAsStringAsync();
            var userList = JsonSerializer.Deserialize<IEnumerable<User>>(body, serializationOptions);

            userList.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData(1, "A", true)]
        [InlineData(2, "B", true)]
        [InlineData(-1, "", false)] // Deconseillé car complexité ajoutée
        public async void ShouldGet200_GetById(int id, string name, bool shouldBeOk)
        {
            var response = await client.GetAsync($"/users/{id}");

            if (!shouldBeOk)
            {
                response.StatusCode.Should().Be(HttpStatusCode.NoContent);
                return;
            }

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var body = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<User>(body, serializationOptions);

            user.Id.Should().Be(id);
            user.Name.Should().Be(name);
        }

        [Fact]
        public async void ShouldGet200_GetAverageAge()
        {
            var response = await client.GetAsync("/users/averageAge");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var body = await response.Content.ReadAsStringAsync();
            body.Should().StartWith("32.33");
        }

        [Fact]
        public async void ShouldPost200_CreateUser()
        {
            User user = new User
            {
                Id = 42,
                Name = "Dehos",
                Age = 52
            };
            var jsonUser = JsonSerializer.Serialize(user);
            var response = await client.PostAsync("/users/addUser", new StringContent(jsonUser, UnicodeEncoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void ShouldPost400_CreateUser()
        {
            var response = await client.PostAsync("/users/addUser", new StringContent("null", UnicodeEncoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void ShouldPost400_CreateUser_2()
        {
            User user = new User
            {
                Id = 42,
                Name = "    ",
                Age = 52
            };
            var jsonUser = JsonSerializer.Serialize(user);
            var response = await client.PostAsync("/users/addUser", new StringContent(jsonUser, UnicodeEncoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}