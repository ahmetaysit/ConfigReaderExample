using ConfigurationManager.Interfaces;
using ConfigurationManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigurationManager.Dal
{
    public class MockConfigProvider : IConfigProvider
    {
        List<Config> _configs;

        public MockConfigProvider()
        {
            if(_configs == null)
            {
                _configs = new List<Config>
                {
                    new Config { Id = 1, Name = "SiteName", Type = "String", Value = "Boyner.com.tr", IsActive = true, ApplicationName = "SERVICE - A" },
                    new Config { Id = 2, Name = "IsBasketEnabled", Type = "Boolean", Value = "1", IsActive = true, ApplicationName = "SERVICE - B" },
                    new Config { Id = 3, Name = "MaxItemCount", Type = "Int", Value = "50", IsActive = false, ApplicationName = "SERVICE - A" },
                    new Config { Id = 4, Name = "MaxItemCount", Type = "Int", Value = "30", IsActive = true, ApplicationName = "SERVICE - A" },
                    new Config { Id = 5, Name = "IsBasketEnabled", Type = "Boolean", Value = "1", IsActive = true, ApplicationName = "SERVICE - A" }
                };
            }
        }

        public List<Config> GetAll()
        {
            return _configs;
        }

        public List<Config> GetByApplication(string applicationName)
        {
            return GetAll().Where(x => x.ApplicationName == applicationName && x.IsActive == true).ToList();
        }

        public Config Delete(Config config)
        {
            _configs.Where(x => x.Id == config.Id).FirstOrDefault().IsActive = false;
            return config;
        }

        public Config Add(Config config)
        {
            _configs.Add(config);
            return config;
        }

    }
}
