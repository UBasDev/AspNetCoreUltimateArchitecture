using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Entities.Common
{
    public interface ISoftDelete
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        DateTimeOffset? DeletedDate { get; set; }
    }
}
