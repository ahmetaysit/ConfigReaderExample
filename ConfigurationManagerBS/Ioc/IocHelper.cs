using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ConfigurationManager.Dal;
using ConfigurationManager.Interfaces;
using ConfigurationManagerBS;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationManager.Ioc
{
    public static class IocHelper
    {
        private static WindsorContainer _container;
        private static object _lockedObj = new object();
        private static void Build()
        {
            _container = new WindsorContainer();
            _container.Register(Component.For<IConfigurationReader>().ImplementedBy<ConfigurationReader>().DependsOn(
                ).LifestyleSingleton());
            _container.Register(Component.For<IConfigProvider>().ImplementedBy<MockConfigProvider>().LifestyleSingleton());
            _container.Register(Component.For<IConfigHolder>().ImplementedBy<ConfigHolder>().LifestyleSingleton());
            _container.Register(Component.For<IConfigSynchronizer>().ImplementedBy<ConfigSynchronizer>().LifestyleSingleton());
            
        }

        private static WindsorContainer Container
        {
            get
            {
                if (_container == null)
                {
                    lock(_lockedObj)
                    {
                        Build();
                    }                    
                }

                return _container;
            }
        }


        public static T Resolve<T>(Arguments prms)
        {
            return Container.Resolve<T>(prms);
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
