using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _002.Owin
{
    public class LoggerModule
    {
        private readonly Func<IDictionary<string, object>, Task> _next;
        private readonly string _prefix;

        public LoggerModule(Func<IDictionary<string, object>, Task> next, string prefix)
        {
            if (next == null)
                throw new ArgumentException("next");

            if (string.IsNullOrEmpty(prefix))
                throw new ArgumentException("prefix can't be null or empty");

            this._next = next;
            this._prefix = prefix;
        }
        public Task Invoke(IDictionary<string, object> env)
        {
            try
            {
                 Debug.WriteLine("{0} Request: {1}", this._prefix, env["owin.RequestPath"]);
            }
            catch (System.Exception ex)
            {
                var tcs   = new TaskCompletionSource<object>();
                tcs.SetException(ex);
                return tcs.Task;
            }
            return this._next(env);
        }
    }
}
