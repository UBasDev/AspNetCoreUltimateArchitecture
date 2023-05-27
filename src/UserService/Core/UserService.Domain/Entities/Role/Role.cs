using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entities.Common;
using UserService.Domain.Entities.ScreenEntity;
using UserService.Domain.Entities.UserEntity;

namespace UserService.Domain.Entities.RoleEntity
{   
    public class Role:BaseEntity
    {
        public Role()
        {
            Name = String.Empty;
            Value= String.Empty;
            Code = 0;
            Screens = new HashSet<Screen>();
            Users= new HashSet<User>();
        }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Code { get; set; }
        public ICollection<Screen>? Screens { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
