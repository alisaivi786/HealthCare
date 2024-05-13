using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Jwt.Enum;

public enum TokenTypeEnum
{
    [Description("Access_Token")]
    Access_Token = 1,

    [Description("Refresh_Token")]
    Refresh_Token = 2
}
