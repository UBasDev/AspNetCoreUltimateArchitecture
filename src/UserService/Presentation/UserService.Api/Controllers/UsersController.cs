using Demo1.Helper.Services.GrpcServiceClient;
using Demo1.Protos;
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
        private readonly IGrpcServiceClientFactory _grpcServiceClientFactory;
        public UsersController(AppSettings appSettings, IMediator mediator, ILogger<UsersController> logger, IGrpcServiceClientFactory grpcServiceClientFactory)
        {
            _appSettings = appSettings;
            _mediator = mediator;
            _logger = logger;
            _grpcServiceClientFactory = grpcServiceClientFactory;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GrpcTest1()
        {
            var noteApiGrpcServiceClient = _grpcServiceClientFactory.CreateNoteApiGrpcServiceClient();
            var responseFromNoteGrpcService = await noteApiGrpcServiceClient.GetAllNotesGrpcServiceAsync(new GetAllNotesRequest());
            return Ok(responseFromNoteGrpcService);
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
