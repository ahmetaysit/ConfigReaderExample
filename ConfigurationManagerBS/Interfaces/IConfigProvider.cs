using ConfigurationManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationManager.Interfaces
{
    public interface IConfigProvider
    {
        IEnumerable<Config> GetAll();
        List<Config> GetByApplication(string applicationName);
    }
}
