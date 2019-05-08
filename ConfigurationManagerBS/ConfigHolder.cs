using ConfigurationManager.Interfaces;
using ConfigurationManager.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigurationManager
{
    public class ConfigHolder : IConfigHolder
    {
        protected static ConcurrentDictionary<string, List<Config>> _items = new ConcurrentDictionary<string, List<Config>>();

        public List<Config> Get(string applicationName)
        {
            return _items[applicationName];
        }

        public void Put(string applicationName, List<Config> configs)
        {
            _items[applicationName] = configs;
        }
    }
}
