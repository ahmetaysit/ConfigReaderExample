using ConfigurationManager.Exceptions;
using ConfigurationManager.Interfaces;
using ConfigurationManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Timers;

namespace ConfigurationManagerBS
{
    public class ConfigurationReader : IConfigurationReader
    {
        private IConfigHolder _configHolder;

        private string _application;

        public ConfigurationReader(string applicationName, int refreshTimerIntervalInMs,string connectionString,IConfigHolder configHolder,IConfigSynchronizer configSynchronizer)
        {
            _application = applicationName;
            _configHolder = configHolder;
            configSynchronizer.Start(refreshTimerIntervalInMs, applicationName);            
        }

        public T GetValue<T>(string key) where T : IConvertible
        {
            string value = "";

            var config = GetValueFromKey(key);

            if(config == null)
            {
                throw new ConfigKeyNotFound();
            }

            value = config.Value;

            TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(T));

            return (T)typeConverter.ConvertFrom(value);
        }

        private Config GetValueFromKey(string key)
        {
            return _configHolder.Get(_application).Where(x => x.Name == key).FirstOrDefault();
            
        }
    }
}
