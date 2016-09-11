﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationDemo
{
    public class LanguageActionFilter: ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public LanguageActionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("LanguageActionFilter");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string culture = context.RouteData.Values["culture"].ToString();
            _logger.LogInformation($"Setting the culture from the URL: {culture}");

#if NET451
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
#elif NET46
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
#else
            CultureInfo.CurrentCulture = new CultureInfo(culture);
            CultureInfo.CurrentUICulture = new CultureInfo(culture);
#endif
            base.OnActionExecuting(context);
        }
    }
}
