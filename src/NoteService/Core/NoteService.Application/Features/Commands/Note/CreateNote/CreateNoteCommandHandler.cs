using Demo1.Data.Enums;
using MediatR;
using NoteService.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteEntity = NoteService.Domain.Entities.Note.Note;

namespace NoteService.Application.Features.Commands.Note.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommandRequest, CreateNoteCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateNoteCommandResponse> Handle(CreateNoteCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateNoteCommandResponse();            
            try
            {
                if (!(typeof(NoteStatus).IsEnumDefined(request.Status))) return response;
                await _unitOfWork.NoteRepository.InsertSingleAsync(new NoteEntity()
                {
                    Title = request.Title,
                    Description = request.Description,
                    BackgroundColorHex = request.BackgroundColorHex,
                    Status = (NoteStatus) Enum.Parse(typeof(NoteStatus), request.Status.ToString()),
                });
                await _unitOfWork.SaveAsync();
                response.IsSuccesfull = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return response;
        }
    }
}
