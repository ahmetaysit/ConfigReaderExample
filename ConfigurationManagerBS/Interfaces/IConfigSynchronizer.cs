using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationManager.Interfaces
{
    public interface IConfigSynchronizer
    {
        void Start(int refreshTimerIntervalInMs, string application);
        void Stop();
    }
}
