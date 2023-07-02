using Demo1.Helper.Attributes;
using Demo1.Helper.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteService.Application.Features.Commands.Note.CreateNote;
using NoteService.Application.Features.Queries.Note.GetAllNotes;
using Demo1.Data.Enums;

namespace NoteService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotesController(IMediator mediator)
        {
            _mediator = mediator;
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
        [Authorized(AuthRole.CEO)]
        public async Task<IActionResult> AuthorizedTest()
        {
            return Ok();
        }
    }
}
