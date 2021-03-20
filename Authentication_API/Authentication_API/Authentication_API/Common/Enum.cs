using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_API.Common
{
    public class Enum
    {
        public enum ActionStatus
        {
            [Description("Failed")]
            Failed = 0,
            [Description("Success")]
            Success = 1,
            [Description("DuplicateEntry")]
            DuplicateEntry = 2,
            [Description("NoRecordFound")]
            NoRecordFound = 3,
            [Description("SeverValidationFailed")]
            SeverValidationFailed = 4,
            [Description("ServerAlreadyExists")]
            ServerAlreadyExists = 5
        }
    }
}
