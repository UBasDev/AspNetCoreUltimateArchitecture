using Demo1.Protos;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Services.GrpcServiceClient
{
    public class GrpcServiceClientFactory:IGrpcServiceClientFactory
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly GrpcServiceSettings _grpcServiceSettings;
        public GrpcServiceClientFactory(ILoggerFactory loggerFactory, GrpcServiceSettings grpcServiceSettings)
        {
            _grpcServiceSettings = grpcServiceSettings;
            _loggerFactory = loggerFactory;
        }

        public NoteServiceApi.NoteServiceApiClient CreateNoteApiGrpcServiceClient()
        {
            var channelOptions = GrpcChannelOptions();
            var channel = GrpcChannel.ForAddress($"{_grpcServiceSettings.NoteApiGrpcServiceSettings.Protocol}://{_grpcServiceSettings.NoteApiGrpcServiceSettings.Host}:{_grpcServiceSettings.NoteApiGrpcServiceSettings.Port}", channelOptions);
            return new NoteServiceApi.NoteServiceApiClient(channel);
        }

        private GrpcChannelOptions GrpcChannelOptions()
        {
            //var certificate = new X509Certificate2(_settings.CertFileName, _settings.CertPassword);
            var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
            //handler.ClientCertificates.Add(certificate);
            var httpClient = new HttpClient(handler);
            var channelOptions = new GrpcChannelOptions
            {
                HttpClient = httpClient,
                LoggerFactory = _loggerFactory,
                MaxReceiveMessageSize = null,
                MaxSendMessageSize = null

            };
            return channelOptions;
        }

    }
}
