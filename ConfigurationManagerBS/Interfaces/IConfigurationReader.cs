using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationManager.Interfaces
{
    public interface IConfigurationReader
    {
        T GetValue<T>(string key) where T : IConvertible;
    }
}
