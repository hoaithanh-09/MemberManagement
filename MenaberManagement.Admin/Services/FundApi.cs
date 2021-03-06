using ManaberManagement.Utilities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.FundGroupVIewModels;
using MemberManagement.ViewModels.FundMemberViewModels;
using MemberManagement.ViewModels.FundViewModels;
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
    public class FundApi : BaseApiClient, IFundApi
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public FundApi(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public Task<bool> AddAction(int fundId, FundGroupCreateRequest request)
        {
            throw new NotImplementedException();
        }

   
        public async Task<bool> AddMember(int fundId, FundMemberCreateRequest request)
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
            var response = await client.PostAsync($"/api/Funds/Creat-listmember", httpContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Create(FundCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            //var requestContent = new MultipartFormDataContent();

            //requestContent.Add(new StringContent(request.CreatedDate.ToString()), "CreatedDate");
            //requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            //requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Description) ? "" : request.Description.ToString()), "CreatedDate");

            //requestContent.Add(new StringContent(request.TotalFund.ToString()), "TotalFund");

            var json = JsonConvert.SerializeObject(request);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/Funds", httpContent);
            //var json = JsonConvert.SerializeObject(request);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync($"/api/Funds", json);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            return await Delete($"api/Funds/" + id);
        }

        public async Task<FundVM> GetById(int id)
        {
            var data = await GetAsync<FundVM>(
             $"/api/Funds/{id}");

            return data;
        }

        public async Task<PagedResult<FundVM>> GetFundPaging(GetFundPagingRequest request)
        {
            var data = await GetAsync<PagedResult<FundVM>>(
             $"/api/Funds/paging?pageIndex=" +
               $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
            return data;
        }

        public async Task<PagedResult<ListAction>> ListAction(int fundId, GetFundPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ListAction>>(
             $"/api/Funds/ListAction?fundId={fundId}&PageIndex=" +
               $"{request.PageIndex}&PageSize={request.PageSize}&keyword={request.Keyword}");
            return data;
        }

        public async Task<PagedResult<ListMember>> ListMembers(int fundId, GetFundPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ListMember>>(
             $"/api/Funds/ListMember?fundId={fundId}&PageIndex=" +
               $"{request.PageIndex}&PageSize={request.PageSize}&keyword={request.Keyword}");
            return data;
        }


        public async Task<bool> Update(int id, FundEditRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("JWT");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/Funds/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
