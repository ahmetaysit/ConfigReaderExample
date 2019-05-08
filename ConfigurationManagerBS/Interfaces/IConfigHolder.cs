using ConfigurationManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationManager.Interfaces
{
    public interface IConfigHolder
    {
        List<Config> Get(string applicationName);
        void Put(string applicationName, List<Config> configs );

    }
}
