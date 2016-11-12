using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task7StorageControl
{
    class Timer : IDisposable
    {
        private readonly Stopwatch stopwatchObject;
        private bool isDisposed = false;

        public long ElapsedMilliseconds
        {
            get
            {
                return stopwatchObject.ElapsedMilliseconds;
            }
        }

        public Timer()
        {
            stopwatchObject = new Stopwatch();
        }

        ~Timer()
        {
            Dispose(false);
        }

        public Timer Start()
        {
            stopwatchObject.Restart();
            return this;
        }

        public Timer Continue()
        {
            stopwatchObject.Start();
            return this;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool fromFinalize)
        {
            if ( !isDisposed )
            {
                if (!fromFinalize)
                {
                    stopwatchObject.Stop();
                }

                isDisposed = true;
            }
        }

    }
}
