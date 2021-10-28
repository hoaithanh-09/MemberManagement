using ManaberManagement.Utilities;
using MemberManagement.ViewModels.AuthorViewModels;
using MemberManagement.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace MenaberManagement.Client.Services
{
    public class AuthorApi : BaseApiClient, IAuthorApi
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public AuthorApi(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

     

        public async Task<List<AuthorVM>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("JWT");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/Authors/GetAll");
            var body = await response.Content.ReadAsStringAsync();
            var author = JsonConvert.DeserializeObject<List<AuthorVM>>(body);
            return author;
        }

        public async Task<AuthorVM> GetById(int id)
        {
            var data = await GetAsync<AuthorVM>(
              $"/api/Authors/GetByIdAuthor/{id}");

            return data;
        }
      
    }
}
