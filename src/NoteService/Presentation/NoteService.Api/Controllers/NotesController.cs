using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteService.Application.Features.Commands.Note.CreateNote;

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
    }
}
