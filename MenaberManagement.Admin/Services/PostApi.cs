using ManaberManagement.Utilities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.CommonSV;
using MemberManagement.ViewModels.PostViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace MenaberManagement.Admin.Services
{
    public class PostApi : BaseApiClient, IPostApi
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public PostApi(IHttpClientFactory httpClientFactory,
                    IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration,
                     IStorageService storageService
                     )
             : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _storageService = storageService;
        }
        public async Task<ApiResult<string>> Create(PostCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);


            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ThumbnailImage != null)
            {
                byte[] data;
                string filename;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                    filename = await this.SaveFile(request.ThumbnailImage);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ThumbnailImage", filename);
            }



            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Title) ? "" : request.Title.ToString()), "Title");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Content) ? "" : request.Content.ToString()), "Content");
            requestContent.Add(new StringContent(request.CreatedDate.ToString()), "CreateDate");
            requestContent.Add(new StringContent(request.ModifiedDate.ToString()), "ModifiedDate");

            requestContent.Add(new StringContent(request.AuthorId.ToString()), "AuthorId");

            var response = await client.PostAsync($"/api/Posts", requestContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return new ApiSuccessResult<string>(result);
            return new ApiErrorResult<string>(result);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<bool> Delete(int id)
        {
            return await Delete($"api/Posts?id=" + id);
        }

        public async Task<List<PostVM>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("JWT");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/Topics/GetALl");
            var body = await response.Content.ReadAsStringAsync();
            var post = JsonConvert.DeserializeObject<List<PostVM>>(body);
            return post;
        }

        public async  Task<PostVM> GetById(int id)
        {
            var data = await GetAsync<PostVM>(
             $"/api/Posts?id={id}");

            return data;
        }

        public async Task<PagedResult<PostVM>> GetPostPaging(GetPostPagingRequest request)
        {
            var data = await GetAsync<PagedResult<PostVM>>(
             $"/api/Posts/pagingPost?pageIndex=" +
               $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
            return data;
        }

        public async Task<bool> Update(int id, PostEditRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("JWT");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/Posts/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
