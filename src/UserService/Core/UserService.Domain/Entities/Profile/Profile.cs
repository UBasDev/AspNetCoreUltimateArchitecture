using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entities.Common;
using UserService.Domain.Entities.UserEntity;

namespace UserService.Domain.Entities.ProfileEntity
{
    public class Profile:BaseEntity
    {
        public Profile()
        {
            Level=1;
            ImagePath=String.Empty;
            Adress=String.Empty;
            Age = 1;
        }
        public int Level { get; set; }
        public string? ImagePath { get; set; }
        public string? Adress { get; set; }
        public int? Age { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
