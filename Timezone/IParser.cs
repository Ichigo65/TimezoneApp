﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    interface IParser
    {
        DateTime? DisplayTime(string time, string timezone);
    }
}
