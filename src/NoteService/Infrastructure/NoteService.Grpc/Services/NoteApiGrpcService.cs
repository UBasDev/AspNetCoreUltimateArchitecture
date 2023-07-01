using Demo1.Data.Enums;
using Demo1.Helper.Services.GrpcServiceClient;
using Demo1.Protos;
using Grpc.Core;
using NoteService.Application.Interfaces.Repositories;

namespace NoteService.Grpc.Services
{
    public class NoteApiGrpcService: NoteServiceApi.NoteServiceApiBase
    {
        private readonly ILogger<NoteApiGrpcService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public NoteApiGrpcService(ILogger<NoteApiGrpcService> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public override async Task<GetAllNotesResponse> GetAllNotesGrpcService(GetAllNotesRequest request, ServerCallContext context)
        {
            var response = new GetAllNotesResponse();
            var allReceivedNotes = await _unitOfWork.NoteRepository.GetAllAsync();
            
            foreach (var currentNote in allReceivedNotes)
            {
                var formattedNote = new GetAllNotes()
                {
                    Title = currentNote.Title,
                    Description = currentNote.Description,
                    BackgroundColorHex = currentNote.BackgroundColorHex,
                    Status = currentNote.Status.ToString(),
                };
                response.GetAllNotes.Add(formattedNote);
            }

            return await Task.Run(() =>
            {
                return response;
            });
        }
    }
}
