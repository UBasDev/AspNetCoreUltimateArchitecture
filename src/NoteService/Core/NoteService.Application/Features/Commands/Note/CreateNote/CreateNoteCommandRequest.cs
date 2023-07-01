using Demo1.Data.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Application.Features.Commands.Note.CreateNote
{
    public class CreateNoteCommandRequest:IRequest<CreateNoteCommandResponse>
    {
        public CreateNoteCommandRequest() {
            Title = String.Empty;
            Description = String.Empty;
            BackgroundColorHex = String.Empty;
            Status = NoteStatus.NotStartedYet;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BackgroundColorHex { get; set; }
        public NoteStatus Status { get; set; }
    }
}
