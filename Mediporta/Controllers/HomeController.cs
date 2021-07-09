using Mediporta.Models;
using Mediporta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mediporta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStackOverflowService _stackOverflowService;
        public HomeController(ILogger<HomeController> logger, IStackOverflowService stackOverflowService)
        {
            _logger = logger;
            _stackOverflowService = stackOverflowService;
        }

        public async Task<IActionResult> Index()
        {
            List<Tag> Tags = await _stackOverflowService.GetMostPopularTagsAsync(1000);

            long sumOfAll = Tags.Sum(tag => tag.count);

            List<double> tagProportions = Tags.Select(tag => Math.Round(100 * (double)tag.count / sumOfAll, 3)).ToList();

            return View(new IndexViewModel(Tags, tagProportions));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
