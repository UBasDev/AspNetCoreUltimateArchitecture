using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Data.Enums
{
    public enum AuthRole
    {
        [Description("CEO")] CEO,
        [Description("OC")] OC,
        [Description("GenelMudur")] GM,
        [Description("SoftwareDeveloper")] SD,
        [Description("Analyst")] AN,
        [Description("Tester")] TE,
        [Description("Employee")] EM,
    }
}
