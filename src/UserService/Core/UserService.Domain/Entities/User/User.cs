using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entities.Common;
using UserService.Domain.Entities.ProfileEntity;
using UserService.Domain.Entities.RoleEntity;
using UserService.Domain.Entities.ScreenEntity;

namespace UserService.Domain.Entities.UserEntity
{    
    public class User : BaseEntity, ISoftDelete
    {
        public User()
        {            
            Firstname = String.Empty;
            Lastname= String.Empty;
            Email= String.Empty;
            Phone= String.Empty;
            UpdateWithIntegration = true;
            Screens = new HashSet<Screen>();
            DeletedDate = null;
            IsActive = true;
            IsDeleted = false;
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool UpdateWithIntegration { get; set; }        
        public ICollection<Screen>? Screens { get; set; }
        public Role? Role { get; set; }
        public Profile? Profile { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
