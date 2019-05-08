using Castle.MicroKernel;
using ConfigurationManager.Dal;
using ConfigurationManager.Interfaces;
using ConfigurationManager.Ioc;
using ConfigurationManagerBS;
using System;

namespace ConfigurationManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Arguments prms = new Arguments();
            prms.Add("applicationName", "SERVICE - A");
            prms.Add("refreshTimerIntervalInMs", 10000);
            prms.Add("connectionString", "Deneme");

            IConfigurationReader configurationReader = IocHelper.Resolve<IConfigurationReader>(prms);          


            var val = configurationReader.GetValue<int>("MaxItemCount");
            
            Console.ReadKey();
        }
    }
}
