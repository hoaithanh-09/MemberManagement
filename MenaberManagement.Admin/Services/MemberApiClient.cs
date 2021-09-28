using ManaberManagement.Utilities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.MemberViewModels;
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
    public class MemberApiClient : BaseApiClient, IMemberApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public MemberApiClient(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration)
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<string>> Create(MemberCreatRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

           

            requestContent.Add(new StringContent(request.GroupId.ToString()), "GroupId");
            requestContent.Add(new StringContent(request.FamilyId.ToString()), "FamilyId");
            requestContent.Add(new StringContent(request.JoinDate.ToString()), "JoinDate");
            requestContent.Add(new StringContent(request.Birth.ToString()), "JoinDate");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Idcard) ? "" : request.Idcard.ToString()), "Idcard");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Notes) ? "" : request.Notes.ToString()), "Notes");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Gender) ? "" : request.Gender.ToString()), "Gender");
            requestContent.Add(new StringContent(request.ContactId.ToString()), "ContactId");
            requestContent.Add(new StringContent(request.RoleId.ToString()), "RoleId");
            requestContent.Add(new StringContent(request.IdAddress.ToString()), "IdAddress");


            //var json = JsonConvert.SerializeObject(request);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/Members/Create-Member", requestContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return  new ApiSuccessResult<string>(result);
            return new ApiErrorResult<string>(result);
        }

        public async Task<bool> Delete(int id)
        {
            return await Delete($"api/Families/" + id);
        }

        public async Task<MemberVM> GetById(int id)
        {
            var data = await GetAsync<MemberVM>(
              $"/api/Members/{id}");

            return data;
        }

        public async Task<PagedResult<MemberVM>> GetFamilyPaging(MemberPaingRequest request)
        {
            var data = await GetAsync<PagedResult<MemberVM>>(
              $"/api/Members/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.KeyWord}");
            return data;
        }

        public async Task<bool> Update(int id, MemberEditRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("JWT");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/Members/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
