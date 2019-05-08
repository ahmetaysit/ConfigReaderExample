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
        public IEnumerable<Config> GetAll()
        {
            yield return new Config { Id = 1, Name = "SiteName", Type = "String", Value = "Boyner.com.tr", IsActive = true, ApplicationName = "SERVICE - A" };
            yield return new Config { Id = 2, Name = "IsBasketEnabled", Type = "Boolean", Value = "1", IsActive = true, ApplicationName = "SERVICE - B" };
            yield return new Config { Id = 3, Name = "MaxItemCount", Type = "Int", Value = "50", IsActive = false, ApplicationName = "SERVICE - A" };
            yield return new Config { Id = 4, Name = "MaxItemCount", Type = "Int", Value = "30", IsActive = true, ApplicationName = "SERVICE - A" };
            yield return new Config { Id = 5, Name = "IsBasketEnabled", Type = "Boolean", Value = "1", IsActive = true, ApplicationName = "SERVICE - A" };
        }

        public List<Config> GetByApplication(string applicationName)
        {
            return GetAll().Where(x => x.ApplicationName == applicationName && x.IsActive == true).ToList();
        }
    }
}
