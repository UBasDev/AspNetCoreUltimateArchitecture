using Demo1.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Services.GrpcServiceClient
{
    public interface IGrpcServiceClientFactory
    {
        NoteServiceApi.NoteServiceApiClient CreateNoteApiGrpcServiceClient();
    }
}
