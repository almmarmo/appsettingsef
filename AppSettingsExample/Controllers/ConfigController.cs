﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppSettingsExample.CustomProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AppSettingsExample.Controllers
{
    [Produces("application/json")]
    [Route("api/Config")]
    public class ConfigController : Controller
    {
        IConfiguration _config;
        public ConfigController(IConfiguration config)
        {
            //_config = new ConfigurationBuilder()
            //    .AddEntityFrameworkConfig(o => o.UseSqlServer(config.GetConnectionString("DefaultConnection")))
            //    .Build();


            _config = config;
        }

        [HttpGet]
        [Route("getValues")]
        public IActionResult GetValues()
        {


            return Json(new {Key1=_config.GetValue<string>("key1"), Key2=_config.GetValue<string>("key2"), Key3= _config.GetValue<string>("key3") });
        }

        [HttpGet]
        [Route("reload")]
        public IActionResult Reload()
        {
            var root = _config as ConfigurationRoot;
            var ef = root.Providers.FirstOrDefault(x => x.GetType() == typeof(EFConfigProvider));
            ef.Load();

            return Json(new { status = "ok" });
        }
    }
}