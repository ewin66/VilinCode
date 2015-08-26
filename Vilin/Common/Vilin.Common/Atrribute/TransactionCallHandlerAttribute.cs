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
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionCallHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new TransactionCallHandler { Order = this.Order };
        }
    }
}
