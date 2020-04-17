using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConduitPortal.Mapping;
using ConduitPortal.Services;

namespace WebPortal
{
    public static class ServicesInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Automaper Config
            services.AddAutoMapper(typeof(MappingProfile));

            // Services injection
            services.AddScoped<IArticleService, ArticleService>();
        }
    }
}
