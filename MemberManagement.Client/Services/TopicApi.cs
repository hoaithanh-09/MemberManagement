using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.TopicViewModels;
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
    public class TopicApi : BaseApiClient, ITopicApi
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public TopicApi(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<TopicVM>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("JWT");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/Topics/GetALl");
            var body = await response.Content.ReadAsStringAsync();
            var topic = JsonConvert.DeserializeObject<List<TopicVM>>(body);
            return topic;
        }
       
        public async Task<TopicVM> GetById(int id)
        {
            var data = await GetAsync<TopicVM>(
             $"/api/Topics/{id}");

            return data;
        }

       
    }
}
