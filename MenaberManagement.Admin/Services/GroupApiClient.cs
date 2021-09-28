using ManaberManagement.Utilities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.GroupViewModels;
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

namespace MenaberManagement.Admin.Services
{
    public class GroupApiClient : BaseApiClient, IGroupApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public GroupApiClient(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> Create(GroupCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/Groups/Create", httpContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            return await Delete($"api/Groups/" + id);
        }

        public async Task<PagedResult<GroupVM>> GetAll(GetGroupPagingRequest request)
        {
            var data = await GetAsync<PagedResult<GroupVM>>(
              $"/api/Groups/GetAll");
            return data;
        }

        public async Task<GroupVM> GetById(int id)
        {
            var data = await GetAsync<GroupVM>(
              $"/api/Groups/{id}");

            return data;
        }

        public async Task<PagedResult<GroupVM>> GetFamilyPaging(GetGroupPagingRequest request)
        {
            var data = await GetAsync<PagedResult<GroupVM>>(
              $"/api/Groups/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.KeyWord}");
            return data;
        }

        public async Task<bool> Update(int id, GroupEditRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("JWT");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/Groups/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

    }
}
