using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vilin.Common.Handler;

namespace Vilin.Common.Atrribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method)]
    public class CachingCallHandlerAttribute : HandlerAttribute
    {
        public TimeSpan? ExpirationTime { get; private set; }

        public CachingCallHandlerAttribute(string expirationTime = "")
        {
            System.Diagnostics.Debug.WriteLine("===2=======================================");
            if (!string.IsNullOrEmpty(expirationTime))
            {
                TimeSpan expirationTimeSpan;
                if (!TimeSpan.TryParse(expirationTime, out expirationTimeSpan))
                {
                    throw new ArgumentException("输入的过期时间(TimeSpan) 不合法", "expirationTime");
                }
                this.ExpirationTime = expirationTimeSpan;
            }
        }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new CachingCallHandler(this.ExpirationTime) { Order = this.Order };
        }
    }
}