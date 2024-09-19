using Microsoft.AspNetCore.Mvc;
using OneStream_Assessment_Services.FrontEnd;

namespace OneStream_Assessment_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontEndController : ControllerBase
    {
        private readonly IFrontEndService _frontEndService;

        public FrontEndController(IFrontEndService frontEndService)
        {
            _frontEndService = frontEndService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var task1 = _frontEndService.CallApi1();
            var task2 = _frontEndService.CallApi2();

            await Task.WhenAll(task1, task2);

            var result = new
            {
                Api1Result = task1.Result,
                Api2Result = task2.Result
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object data)
        {
            var task1 = _frontEndService.PostToApi1(data);
            var task2 = _frontEndService.PostToApi2(data);

            await Task.WhenAll(task1, task2);

            var result = new
            {
                Api1Result = task1.Result,
                Api2Result = task2.Result
            };

            return Ok(result);
        }


    }
}
