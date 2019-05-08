using ConfigurationManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ConfigurationManager
{
    public class ConfigSynchronizer : IConfigSynchronizer
    {
        private System.Timers.Timer _tm = null;
        private readonly IConfigHolder _configHolder;
        private readonly IConfigProvider _configProvider;
        private string _application;
        public ConfigSynchronizer(IConfigHolder configHolder,IConfigProvider configProvider)
        {
            _configHolder = configHolder;
            _configProvider = configProvider;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Put();
        }

        private async void Put()
        {
            await Task.Run(() => { _configHolder.Put(_application, _configProvider.GetByApplication(_application)); });
        }

        public void Start(int refreshTimerIntervalInMs,string application)
        {
            try
            {
                _application = application;
                _configHolder.Put(_application, _configProvider.GetByApplication(_application));
                _tm = new System.Timers.Timer();
                _tm.Interval = refreshTimerIntervalInMs;
                _tm.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
                _tm.AutoReset = true;
                _tm.Start();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Stop()
        {
            _tm.Stop();
        }
    }
}
