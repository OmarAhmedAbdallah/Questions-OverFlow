using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Infrastructure
{
    public static class ConfigurartionExtensions
    {
        //string in AppSetting File
        public static string GetDefualtConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DevConnection");
    }
}
