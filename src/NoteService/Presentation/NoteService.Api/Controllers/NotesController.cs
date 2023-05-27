using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NoteService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Test1()
        {
            return Ok();
        }
    }
}
