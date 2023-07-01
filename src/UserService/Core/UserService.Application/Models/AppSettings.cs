using Demo1.Helper.Services.GrpcServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.Models
{
    public class AppSettings
    {
        public AppSettings()
        {
            DatabaseConnectionString= String.Empty;
        }
        public string DatabaseConnectionString { get; set; }
        public GrpcServiceSettings GrpcServiceSettings { get; set; }
    }
}
