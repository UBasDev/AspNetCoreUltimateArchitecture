using Demo1.Helper.Attributes;
using Demo1.Helper.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteService.Application.Features.Commands.Note.CreateNote;
using NoteService.Application.Features.Queries.Note.GetAllNotes;
using Demo1.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using IdentityModel;
using static System.Net.WebRequestMethods;
using System.Security.Claims;
using Demo1.Helper.Models;
using System.IdentityModel.Tokens.Jwt;
using Demo1.Helper.Helpers;

namespace NoteService.Api.Controllers
{
    public class NotesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly JwtSettings _jwtSettings;
        public NotesController(IMediator mediator, JwtSettings jwtSettings)
        {
            _mediator = mediator;
            _jwtSettings = jwtSettings;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSingleNote(CreateNoteCommandRequest createNoteCommandRequest)
        {
            CreateNoteCommandResponse response = await _mediator.Send(createNoteCommandRequest);
            return response.IsSuccesfull ? Ok(response) : BadRequest(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllNotes()
        {
            GetAllNotesQueryResponse response = await _mediator.Send(new GetAllNotesQueryRequest());
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ExceptionTest()
        {
            throw new CommonException("error1", System.Net.HttpStatusCode.Unauthorized, new
            {
                Prop1 = "Value1",
                Prop2 = "Value2"
            });
            return Ok();
        }

        [HttpGet("[action]")]
        [Authorized(AuthRole.CEO, AuthRole.AN)]
        public async Task<IActionResult> AuthorizeTest()
        {
            return Ok(RequestedUser);
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> AllowedAuthorizeTest()
        {
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GenerateToken()
        {
            var tokenExpireDate = new TimeSpan(180, 0, 0, 0, 0);
            var claims = new List<Claim>
        {
            new(JwtClaimTypes.Id, "213129"),
            new(JwtClaimTypes.Email, "email1@gmail.com"),
            new(JwtClaimTypes.PreferredUserName, "Ayhan Pekmez"),
            new(JwtClaimTypes.Role, "CEO"),
                new("Phone", "5326254522"),
        };
            var token = JwtHelper.GetJwtToken(_jwtSettings, tokenExpireDate, claims);
            return Ok(token);
        }
        private string TokenGenerator()
        {
            var tokenExpireDate = new TimeSpan(180, 0, 0, 0, 0);
            var claims = new List<Claim>
        {
            new(JwtClaimTypes.Id, "213129"),
            new(JwtClaimTypes.Email, "email1@gmail.com"),
            new(JwtClaimTypes.PreferredUserName, "Ayhan Pekmez"),
            new(JwtClaimTypes.Role, "CEO"),
                new("Phone", "5326254522"),
        };
            var token = JwtHelper.GetJwtToken(_jwtSettings, tokenExpireDate, claims);
            return token;
        }
    }
}
