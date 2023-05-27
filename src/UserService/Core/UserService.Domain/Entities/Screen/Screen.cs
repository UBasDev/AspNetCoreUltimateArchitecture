using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entities.Common;
using UserService.Domain.Entities.RoleEntity;
using UserService.Domain.Entities.UserEntity;

namespace UserService.Domain.Entities.ScreenEntity
{    
    public class Screen:BaseEntity
    {
        public Screen()
        {
            Name= string.Empty;
            Value= string.Empty;
            OrderNumber = 0;
            Users = new HashSet<User>();
            Roles= new HashSet<Role>();
        }
        public string Name { get; set; }
        public string Value { get; set; }
        public int OrderNumber { get; set; }
        public ICollection<Role>? Roles { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
