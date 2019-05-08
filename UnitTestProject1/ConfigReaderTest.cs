using Castle.MicroKernel;
using ConfigurationManager.Exceptions;
using ConfigurationManager.Interfaces;
using ConfigurationManager.Ioc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class ConfigReaderTest
    {
        IConfigurationReader _configurationReader;
        public ConfigReaderTest()
        {
            Arguments prms = new Arguments();
            prms.Add("applicationName", "SERVICE - A");
            prms.Add("refreshTimerIntervalInMs", 10000);
            prms.Add("connectionString", "Deneme");

            _configurationReader = IocHelper.Resolve<IConfigurationReader>(prms);
        }

        [TestMethod]
        public void Get_value()
        {
            var val = _configurationReader.GetValue<int>("MaxItemCount");
        }

        [TestMethod]
        public void Get_Non_Exist_Value()
        {
            try
            {
                var val = _configurationReader.GetValue<int>("NonExistKey");
            }
            catch (Exception ex)
            {
                if(ex is ConfigKeyNotFound)
                {

                }
                else
                {
                    throw;
                }                
            } 
        }
    }
}
