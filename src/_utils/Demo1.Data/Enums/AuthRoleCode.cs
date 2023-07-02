using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Data.Enums
{
    public enum AuthRoleCode
    {
        [Description("CEO")] CEO = 1,
        [Description("OC")] OC = 2,
        [Description("GenelMudur")] GM = 3,
        [Description("SoftwareDeveloper")] SD = 4,
        [Description("Analyst")] AN = 5,
        [Description("Tester")] TE = 6,
        [Description("Employee")] EM = 7,
    }
}
