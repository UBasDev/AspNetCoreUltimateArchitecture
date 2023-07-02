using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Application.Features.Queries.Note.GetAllNotes
{
    public class GetAllNotesQueryRequest: IRequest<GetAllNotesQueryResponse>
    {
    }
}
