using ManaberManagement.Utilities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.FamilyViewModels;
using MemberManagerment.ViewModels.FamilyViewModels;
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
    public class FamilyApiClient : BaseApiClient, IFamilyApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public FamilyApiClient(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> Create(FamilyCreatRequest request)
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
            var response = await client.PostAsync($"/api/Families/Creat-Family", httpContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            return await Delete($"api/Families/" + id);
        }

        public async Task<List<FamilyVM>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("JWT");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/Families/GetAll");
            var body = await response.Content.ReadAsStringAsync();
            var families = new List<FamilyVM>();
            if (!string.IsNullOrEmpty(body))
            {
                families = JsonConvert.DeserializeObject<List<FamilyVM>>(body);
            }
            return families;

          
        }

        public async Task<FamilyVM> GetById(int id)
        {
            var data = await GetAsync<FamilyVM>(
              $"/api/Families/{id}");

            return data;
        }
        
        public async Task<PagedResult<FamilyVM>> GetFamilyPaging(GetFamilyPagingRequest request)
        {
            var data = await GetAsync<PagedResult<FamilyVM>>(
              $"/api/Families/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
           // PagedResult<FamilyVM> query = new PagedResult<FamilyVM>();
           // query.PageIndex = data.PageIndex;
           // query.PageSize = data.PageSize;
           // query.PageCount = data.PageCount;

           // foreach ( var familyVm in data.Items)
           //{
           //     if(familyVm.Id !=0 && familyVm.IdMember != 0)
           //     {
           //         query.Items.Add(familyVm);
           //     }
           //} 

            return data;
        }

        public async Task<bool> Update(int id, FamilyEditRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("JWT");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/families/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
