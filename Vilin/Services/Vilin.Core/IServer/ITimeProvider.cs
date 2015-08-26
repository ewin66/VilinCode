using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilin.Common.Atrribute;

namespace Vilin.Core.IServer
{
    public interface ITimeProvider
    {
        [CachingCallHandler("00:00:03")]
        DateTime GetCurrentTime(DateTimeKind dateTimeKind);
    }
}
