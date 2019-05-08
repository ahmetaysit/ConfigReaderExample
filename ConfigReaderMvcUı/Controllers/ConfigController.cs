using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.MicroKernel;
using ConfigReaderMvcUı.Models;
using ConfigurationManager.Interfaces;
using ConfigurationManager.Ioc;
using ConfigurationManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfigReaderMvcUı.Controllers
{
    public class ConfigController : Controller
    {
        List<Config> _configs;
        public IActionResult Config()
        {
            Arguments prms = new Arguments();
            prms.Add("applicationName", "SERVICE - A");
            prms.Add("refreshTimerIntervalInMs", 10000);
            prms.Add("connectionString", "Deneme");

            IConfigurationReader configurationReader = IocHelper.Resolve<IConfigurationReader>(prms);

            ConfigModel model = new ConfigModel();
            
            model.Configs = IocHelper.Resolve<IConfigProvider>().GetByApplication("SERVICE - A");

            return View(model);
        }

        public ActionResult Delete(Config config)
        {
            IocHelper.Resolve<IConfigProvider>().Delete(config);
            return RedirectToAction("Config");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Config config)
        {
            IocHelper.Resolve<IConfigProvider>().Add(config);
            return RedirectToAction("Config");
        }
    }
}