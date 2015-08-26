using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilin.Common.Handler
{
    class PerformanceInterceptionBehavior : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();

            // Invoke the next behavior in the chain.
            var result = getNext()(input, getNext);

            // After invoking the method on the original target.
            if (result.Exception != null)
            {
                WriteLog(String.Format("Method {0} threw exception {1} at {2}",
                    input.MethodBase,
                    result.Exception.Message,
                    DateTime.Now.ToLongTimeString()));
            }
            else
            {
                stopwatch.Stop();
                WriteLog(String.Format("Method {0} executed {1}", input.MethodBase, stopwatch.Elapsed));
            }

            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private void WriteLog(string message)
        {
            Console.WriteLine(message);
        }
    }
}
