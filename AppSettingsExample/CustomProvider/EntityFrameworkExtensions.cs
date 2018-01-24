using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSettingsExample.CustomProvider
{
    public static class EntityFrameworkExtensions
    {
        public static IConfigurationBuilder AddEntityFrameworkConfig(this IConfigurationBuilder builder)
        {
            var config = builder.Build();
            
            return builder.Add(new EFConfigSource(o => o.UseSqlServer(config.GetConnectionString("DefaultConnection"))));
        }
    }
}
