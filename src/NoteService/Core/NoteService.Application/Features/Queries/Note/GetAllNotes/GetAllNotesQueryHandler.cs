using MediatR;
using NoteService.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Application.Features.Queries.Note.GetAllNotes
{
    public class GetAllNotesQueryHandler : IRequestHandler<GetAllNotesQueryRequest, GetAllNotesQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllNotesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetAllNotesQueryResponse> Handle(GetAllNotesQueryRequest request, CancellationToken cancellationToken)
        {
            var allReceivedNotesAfterFormatted = new List<GetNoteDto>();
            try
            {                
                var allReceivedNotes = await _unitOfWork.NoteRepository.GetAllAsNoTrackingAsync();
                foreach (var currentNote in allReceivedNotes)
                {
                    var formattedNote = new GetNoteDto()
                    {
                        Title = currentNote.Title,
                        Description = currentNote.Description,
                        BackgroundColorHex = currentNote.BackgroundColorHex,
                        Status = currentNote.Status.ToString(),
                    };
                    allReceivedNotesAfterFormatted.Add(formattedNote);
                }                
            }          
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new GetAllNotesQueryResponse() {
                AllReceivedNotes = allReceivedNotesAfterFormatted,
            };
        }
    }
}
