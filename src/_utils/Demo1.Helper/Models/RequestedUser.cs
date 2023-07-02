using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Models
{
    public class RequestedUser
    {
        public RequestedUser()
        {
            Id = String.Empty;
            FullName = String.Empty;
            Email = String.Empty;
            Phone = String.Empty;
        }
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
