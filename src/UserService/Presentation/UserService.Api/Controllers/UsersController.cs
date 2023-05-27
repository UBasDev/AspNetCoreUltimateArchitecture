using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using UserService.Application.Models;

namespace UserService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;
        public UsersController(AppSettings appSettings, IMediator mediator, ILogger<UsersController> logger) { 
            _appSettings= appSettings;
            _mediator = mediator;
            _logger = logger;
        }
        /*

        [HttpGet("[action]")]
        public IActionResult Test1()
        {
            return Ok($"{_appSettings.Prop1?.Prop2}-- {MethodInfo.GetCurrentMethod().Name} çalıştı!");
            
        }

        [HttpPost("[action]")] 
        public IActionResult Test2([FromBody] CreateProductDto createProductDto)
        {
            
            var response = new
            {
                text = $"{MethodInfo.GetCurrentMethod().Name} çalıştı!",
                obj = createProductDto
            };
            return Ok(response);
        }
        

        [HttpPost("[action]")]
        public async Task<IActionResult> Test4()
        {
            throw new BadHttpRequestException("Test1", 478);
            return Ok();
        }

        */

    }
}
