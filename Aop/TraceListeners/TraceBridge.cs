using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceListeners
{
    public class TraceBridge<T> where T : TraceListener
    {
        private static T _traceListener;

        public TraceBridge()
        {
            _traceListener = (T)Trace.Listeners.Cast<TraceListener>().ToList().Where(tl => tl.GetType() == typeof(T)).FirstOrDefault();
            //_traceListener.TraceOutputOptions = TraceOptions.Callstack | TraceOptions.ThreadId | TraceOptions.Timestamp;

        }
        public void WriteMessage(string message)
        {
            _traceListener.WriteLine(message);
            _traceListener.Flush();

        }

        public void WriteInformation(string message)
        {
            //_traceListener.TraceData(new TraceEventCache(), "Foo", TraceEventType.Critical, 0, "hello");

            _traceListener.WriteLine(message);
            _traceListener.Flush();
        }

    }


}
