using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppSettingsExample.wwwroot
{
    [Produces("application/json")]
    [Route("api/Config")]
    public class ConfigController : Controller
    {

    }
}