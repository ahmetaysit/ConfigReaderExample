using ConfigurationManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationManager.Interfaces
{
    public interface IConfigProvider
    {
        List<Config> GetAll();
        List<Config> GetByApplication(string applicationName);
        Config Add(Config config);
        Config Delete(Config config);
    }
}
