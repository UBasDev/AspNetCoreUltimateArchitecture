using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Data.Enums
{
    public enum NoteStatus
    {
        [Description("Not Started Yet")] NotStartedYet = 1,
        [Description("In Progress")] InProgress = 2,
        [Description("Postponed")] Postponed = 3,
        [Description("Completed")] Completed = 4,
    }
}
