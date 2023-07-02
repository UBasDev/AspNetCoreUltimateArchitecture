using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Application.Features.Queries.Note.GetAllNotes
{
    public class GetAllNotesQueryResponse
    {
        public List<GetNoteDto> AllReceivedNotes { get; set; }
    }
    public class GetNoteDto
    {
        public string   Title { get; set; }
        public string Description { get; set; }
        public string BackgroundColorHex { get; set; }
        public string Status { get; set; }
    }
}
