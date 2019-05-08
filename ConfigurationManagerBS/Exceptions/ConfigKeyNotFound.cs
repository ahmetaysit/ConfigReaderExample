using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationManager.Exceptions
{
    public class ConfigKeyNotFound : Exception
    {
        public ConfigKeyNotFound() : base("Config key is not found!")
        {

        }

        public ConfigKeyNotFound(string exMessage) : base(exMessage)
        {

        }
    }
}
