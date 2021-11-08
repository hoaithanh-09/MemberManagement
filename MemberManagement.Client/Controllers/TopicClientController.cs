﻿using MemberManagement.ViewModels.TopicViewModels;
using MenaberManagement.Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Client.Controllers
{
    public class TopicClientController:Controller
    {
        private readonly ITopicApi _iTopicApi;
        private readonly IConfiguration _configuration;
        private readonly IPostApiClient _iPostApi;
        public TopicClientController(
            ITopicApi iTopicApi,
            IConfiguration configuration,
            IPostApiClient iPostApi

            )
        {
            _iTopicApi = iTopicApi;
            _iPostApi = iPostApi;
            _configuration = configuration;
        }
       
        public async Task<IActionResult> Details(int id)
        {
            var result = await _iTopicApi.GetById(id);
            return View(result);
        }
        public async Task<IActionResult> GetAll()
        {
            var topic = await _iTopicApi.GetAll();
            return Ok(topic);
        }
    }
}
