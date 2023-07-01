using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Services.GrpcServiceClient
{
    public class GrpcServiceSettings
    {
        public GrpcServiceApiSettings NoteApiGrpcServiceSettings { get; set; }

        public class GrpcServiceApiSettings
        {
            public string Protocol { get; set; }
            public string Host { get; set; }
            public string Port { get; set; }
            public string CertFileName { get; set; }
            public string CertPassword { get; set; }
        }

    }
}
