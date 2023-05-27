using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Application.Models
{
    public class AppSettings
    {
        public AppSettings()
        {
            DatabaseConnectionString= String.Empty;
        }
        public string DatabaseConnectionString { get; set; }
    }
}
