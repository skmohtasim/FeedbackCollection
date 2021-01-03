using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackCollection.BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IFeedbackCollection _feedbackCollection;


        public DefaultController(IFeedbackCollection feedbackCollection)
        {
            _feedbackCollection = feedbackCollection;

        }
        public async Task<IActionResult> Index()
        {
            var result = await _feedbackCollection.GetFeedbackInfos();

            return Ok(result);
        }
    }
}