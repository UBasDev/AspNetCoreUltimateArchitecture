using Demo1.Data.Enums;
using NoteService.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Domain.Entities.Note
{
    public class Note:BaseEntity, ISoftDelete
    {
        public Note()
        {
            Title= String.Empty;
            Description= String.Empty;
            BackgroundColorHex = String.Empty;
            Status = NoteStatus.NotStartedYet;
            IsActive = true;
            IsDeleted= false;
            DeletedDate = null;            
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BackgroundColorHex { get; set; }
        public NoteStatus Status { get; set; }
        public int? UserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
    }
}
