using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilin.Common.Atrribute;
using Vilin.Core.IServer;

namespace Vilin.Core.Server
{
    public class DefaultTimeProvider : ITimeProvider
    {
        public DateTime GetCurrentTime(DateTimeKind dateTimeKind)
        {
            System.Diagnostics.Debug.WriteLine("===1=======================================");
            switch (dateTimeKind)
            {
                case DateTimeKind.Local: return DateTime.Now.ToLocalTime();
                case DateTimeKind.Utc: return DateTime.Now.ToUniversalTime();
                default: return DateTime.Now;
            }
        }
    }
}
